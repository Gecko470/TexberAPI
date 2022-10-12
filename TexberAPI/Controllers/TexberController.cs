using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TexberAPI.Models;
using Microsoft.EntityFrameworkCore;
using TexberAPI.DTOs;
using AutoMapper;
using System.Text;
using System.Security.Cryptography;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.IO.Image;
using System.Drawing;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Events;
using TexberAPI.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace TexberAPI.Controllers
{
    [ApiController]
    [Route("api/texber")]
    public class TexberController : ControllerBase
    {
        private readonly texberDBContext dBContext;
        private readonly IMapper mapper;

        public TexberController(texberDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("proveedores")]
        public async Task<IEnumerable<ProveedorDTO>> GetProveedores()
        {
            IEnumerable<Proveedore> listaProveedores = await dBContext.Proveedores.ToListAsync();
            IEnumerable<ProveedorDTO> listaProveedoresDTO = mapper.Map<IEnumerable<ProveedorDTO>>(listaProveedores);
            return listaProveedoresDTO;
        }

        [HttpGet]
        [Route("proveedores/{codProveedor}")]
        public async Task<ActionResult<Proveedore>> GetProveedorCod(string codProveedor)
        {
            return await dBContext.Proveedores.Where(p => p.CodigoProveedor == codProveedor).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("fibras")]
        public async Task<ActionResult<IEnumerable<CoFibra>>> GetFibras()
        {
            return await dBContext.CoFibras.ToListAsync();
        }

        [HttpGet]
        [Route("fibras/{codFibra}")]
        public async Task<ActionResult<CoFibra>> GetFibrasCod(string codFibra)
        {
            return await dBContext.CoFibras.Where(p => p.CoFibra1 == codFibra).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("almacenes")]
        public async Task<ActionResult<IEnumerable<Almacene>>> GetAlmacenes()
        {
            return await dBContext.Almacenes.ToListAsync();
        }

        [HttpGet]
        [Route("almacenes/{codArticulo}/{partida}")]
        public async Task<ActionResult<List<string>>> GetAlmacenesByArticuloPartida(string codArticulo, string partida)
        {
            return await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == codArticulo && p.Partida == partida && p.UnidadSaldo > 0 && p.Periodo == 99).Select(p => p.CodigoAlmacen).ToListAsync();
        }

        [HttpGet]
        [Route("domicilios/{codCliente}")]
        public async Task<ActionResult<IEnumerable<Domicilio>>> GetDomicilios(string codCliente)
        {
            return await dBContext.Domicilios.Where(p => p.CodigoCliente == codCliente).ToListAsync();
        }

        [HttpGet]
        [Route("articulos")]
        public async Task<IEnumerable<ArticuloDTO>> GetArticulos()
        {
            IEnumerable<Articulo> listaArticulos = await dBContext.Articulos.ToListAsync();
            IEnumerable<ArticuloDTO> listaArticulosDTO = mapper.Map<IEnumerable<ArticuloDTO>>(listaArticulos);
            return listaArticulosDTO;
        }

        [HttpGet]
        [Route("articuloByCod/{codArticulo}")]
        public async Task<ArticuloDTO> GetArticuloByCod(string codArticulo)
        {
            Articulo articulo = await dBContext.Articulos.Where(p => p.CodigoArticulo == codArticulo).FirstOrDefaultAsync();
            ArticuloDTO articuloDTO = mapper.Map<ArticuloDTO>(articulo);

            return articuloDTO;
        }

        [HttpGet]
        [Route("partidasByCodArticuloAlmacen/{codArticulo}/{codAlmacen}")]
        public async Task<List<AcumuladoStockDTO>> GetPartidasByCodArticuloAlmacen(string codArticulo, string codAlmacen)
        {
            List<AcumuladoStock> listaPartidas = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == codArticulo && p.CodigoAlmacen == codAlmacen && p.Periodo == 99 && p.UnidadSaldo != 0).OrderByDescending(x => x.Ejercicio).OrderBy(c => c.Partida).ToListAsync();
            List<AcumuladoStockDTO> listaPartidasDTO = mapper.Map<List<AcumuladoStockDTO>>(listaPartidas);

            return listaPartidasDTO;
        }

        [HttpPost]
        [Route("getMovimientosStock")]
        public async Task<ActionResult<int>> GetMovimientosStock([FromBody] MovimientoStockDTO lineaMovStockDTO)
        {
            var articulo = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == lineaMovStockDTO.CodigoArticulo && p.CodigoAlmacen == lineaMovStockDTO.CodigoAlmacen && p.Partida == lineaMovStockDTO.Partida && p.Periodo == 99).FirstOrDefaultAsync();

            if (articulo != null)
            {
                if (articulo.UnidadSaldo < lineaMovStockDTO.Unidades)
                {
                    return Ok(2);
                }

                return Ok(0);
            }
            else
            {
                return Ok(1);
            }
        }

        [HttpPost]
        [Route("setMovimientosStock")]
        public async Task<ActionResult<List<string>>> SetMovmientosStock([FromBody] List<MovimientoStockDTO> listaMovimientosStockDTO)
        {
            List<string> listaPdfs = new List<string>();
            string pdf = "";
            string text = "";
            decimal unidadesEnStock = 0;
            string codAlmacen = "";
            if (ModelState.IsValid)
            {
                foreach (var item in listaMovimientosStockDTO)
                {
                    AcumuladoStock ItemAcumuladoStock99Or = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.Periodo == 99 && p.Partida == item.Partida && p.CodigoAlmacen == item.CodigoAlmacen).FirstOrDefaultAsync();
                    AcumuladoStock ItemAcumuladoStock99De = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.Periodo == 99 && p.Partida == item.Partida && p.CodigoAlmacen == item.CodigoAlmacen2).FirstOrDefaultAsync();
                    AcumuladoStock ItemAcumuladoStockOr = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.Periodo != 99 && p.Partida == item.Partida && p.CodigoAlmacen == item.CodigoAlmacen).FirstOrDefaultAsync();
                    AcumuladoStock ItemAcumuladoStockDe = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.Periodo != 99 && p.Partida == item.Partida && p.CodigoAlmacen == item.CodigoAlmacen2).FirstOrDefaultAsync();
                    unidadesEnStock = ItemAcumuladoStock99Or.UnidadSaldo;
                    codAlmacen = item.CodigoAlmacen;
                    //Tabla AcumuladoStock

                    //Periodo 99
                    if (ItemAcumuladoStock99Or is not null)
                    {
                        ItemAcumuladoStock99Or.UnidadSalida = ItemAcumuladoStock99Or.UnidadSalida + item.Unidades;
                        ItemAcumuladoStock99Or.UnidadSaldo = ItemAcumuladoStock99Or.UnidadEntrada - ItemAcumuladoStock99Or.UnidadSalida;

                        await dBContext.SaveChangesAsync();
                    }

                    if (ItemAcumuladoStock99De is not null)
                    {

                        ItemAcumuladoStock99De.UnidadEntrada = ItemAcumuladoStock99De.UnidadEntrada + item.Unidades;
                        ItemAcumuladoStock99De.UnidadSaldo = ItemAcumuladoStock99De.UnidadEntrada - ItemAcumuladoStock99De.UnidadSalida;

                        await dBContext.SaveChangesAsync();
                    }
                    else
                    {
                        AcumuladoStockDTO itemAcumuladoStockNuevoDTO = new AcumuladoStockDTO();
                        itemAcumuladoStockNuevoDTO.CodigoArticulo = item.CodigoArticulo;
                        itemAcumuladoStockNuevoDTO.CodigoAlmacen = item.CodigoAlmacen2;
                        itemAcumuladoStockNuevoDTO.Partida = item.Partida;
                        itemAcumuladoStockNuevoDTO.Periodo = 99;
                        itemAcumuladoStockNuevoDTO.UnidadEntrada = item.Unidades;
                        itemAcumuladoStockNuevoDTO.UnidadSalida = 0;
                        itemAcumuladoStockNuevoDTO.UnidadSaldo = itemAcumuladoStockNuevoDTO.UnidadEntrada - itemAcumuladoStockNuevoDTO.UnidadSalida;

                        AcumuladoStock itemAcumuladoStockNuevo = mapper.Map<AcumuladoStock>(itemAcumuladoStockNuevoDTO);

                        dBContext.AcumuladoStocks.Add(itemAcumuladoStockNuevo);
                        await dBContext.SaveChangesAsync();
                    }

                    //Periodo mes
                    if (ItemAcumuladoStockOr is not null)
                    {
                        ItemAcumuladoStockOr.UnidadSalida = ItemAcumuladoStockOr.UnidadSalida + item.Unidades;
                        ItemAcumuladoStockOr.UnidadSaldo = ItemAcumuladoStockOr.UnidadEntrada - ItemAcumuladoStockOr.UnidadSalida;

                        await dBContext.SaveChangesAsync();
                    }

                    if (ItemAcumuladoStock99De is not null)
                    {

                        ItemAcumuladoStockDe.UnidadEntrada = ItemAcumuladoStockDe.UnidadEntrada + item.Unidades;
                        ItemAcumuladoStockDe.UnidadSaldo = ItemAcumuladoStockDe.UnidadEntrada - ItemAcumuladoStockDe.UnidadSalida;

                        await dBContext.SaveChangesAsync();
                    }
                    else
                    {
                        AcumuladoStockDTO itemAcumuladoStockNuevoDTO = new AcumuladoStockDTO();
                        itemAcumuladoStockNuevoDTO.CodigoArticulo = item.CodigoArticulo;
                        itemAcumuladoStockNuevoDTO.CodigoAlmacen = item.CodigoAlmacen2;
                        itemAcumuladoStockNuevoDTO.Partida = item.Partida;
                        itemAcumuladoStockNuevoDTO.Periodo = (short)DateTime.Now.Month;
                        itemAcumuladoStockNuevoDTO.UnidadEntrada = item.Unidades;
                        itemAcumuladoStockNuevoDTO.UnidadSalida = 0;
                        itemAcumuladoStockNuevoDTO.UnidadSaldo = itemAcumuladoStockNuevoDTO.UnidadEntrada - itemAcumuladoStockNuevoDTO.UnidadSalida;

                        AcumuladoStock itemAcumuladoStockNuevo = mapper.Map<AcumuladoStock>(itemAcumuladoStockNuevoDTO);

                        dBContext.AcumuladoStocks.Add(itemAcumuladoStockNuevo);
                        await dBContext.SaveChangesAsync();
                    }


                    //Tabla MovimientoStock
                    MovimientoStock ultDocumento = await dBContext.MovimientoStocks.Where(p => p.Ejercicio == (short)DateTime.Now.Year).OrderBy(p => p.Documento).LastOrDefaultAsync();
                    item.Documento = ultDocumento.Documento + 1;

                    //Salida
                    item.TipoMovimiento = 2;
                    item.UnidadEntrada = ItemAcumuladoStock99Or.UnidadEntrada;
                    item.UnidadStock = ItemAcumuladoStock99Or.UnidadSaldo - item.Unidades;

                    MovimientoStock ItemMovimientosStockS = mapper.Map<MovimientoStock>(item);
                    await dBContext.MovimientoStocks.AddAsync(ItemMovimientosStockS);
                    await dBContext.SaveChangesAsync();

                    //Entrada
                    MovimientoStock itemMovimientoStockE = await dBContext.MovimientoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.Partida == item.Partida && p.CodigoAlmacen == item.CodigoAlmacen2 && p.TipoMovimiento == 1).FirstOrDefaultAsync();

                    item.TipoMovimiento = 1;
                    if (itemMovimientoStockE is not null)
                    {
                        item.UnidadEntrada = item.Unidades + itemMovimientoStockE.UnidadStock;
                    }
                    else
                    {
                        item.UnidadEntrada = item.Unidades;
                    }
                    item.UnidadStock = item.UnidadEntrada;
                    item.CodigoAlmacen = item.CodigoAlmacen2;

                    MovimientoStock ItemMovimientosStockE = mapper.Map<MovimientoStock>(item);
                    await dBContext.MovimientoStocks.AddAsync(ItemMovimientosStockE);
                    await dBContext.SaveChangesAsync();

                    Articulo articulo = await dBContext.Articulos.Where(p => p.CodigoArticulo == item.CodigoArticulo).FirstOrDefaultAsync();

                    //Generación etiqueta entrada en almacén destino
                    BarcodeLib.Barcode CodBarras = new BarcodeLib.Barcode();
                    CodBarras.IncludeLabel = true;

                    item.Unidades = decimal.Round(item.Unidades, 2);
                    var arrayPartida = item.Partida.Split("-");
                    if (arrayPartida.Length < 2)
                    {
                        arrayPartida = item.Partida.Split(" ");
                    }
                    text = item.CodigoArticulo + " " + arrayPartida[0] + " " + arrayPartida[1] + " " + item.Unidades.ToString("F").Replace(",", "").Replace(".", "");

                    System.Drawing.Image etiquetaCodBarras = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
                    byte[] etiquetaCodBarrasBytes = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

                    iText.Layout.Element.Image etiquetaCodBarrasI = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        PdfWriter writer = new PdfWriter(ms);
                        using (var pdfDoc = new PdfDocument(writer))
                        {
                            Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

                            PageRotationEventHandler eventHandler = new PageRotationEventHandler();
                            pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);

                            Table table = new Table(4);

                            Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                            table.AddCell(cell);
                            Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Traspas Magatzem").SetMarginTop(10));
                            table.AddCell(cell2);
                            Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + item.CodigoAlmacen2).SetMarginTop(10));
                            table.AddCell(cell3);
                            Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(articulo.DescripcionArticulo).SetFontSize(40));
                            table.AddCell(cell4);
                            Cell cell5 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                            table.AddCell(cell5);
                            Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                            table.AddCell(cell6);
                            Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + item.Unidades.ToString()).SetFontSize(15));
                            table.AddCell(cell7);
                            Cell cell8 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasI).SetMarginTop(25).SetMarginBottom(25));
                            table.AddCell(cell8);

                            table.SetMarginTop(85f);
                            doc.Add(table);

                            doc.Close();
                            writer.Close();


                            byte[] buffer = ms.ToArray();
                            string base64 = Convert.ToBase64String(buffer);
                            pdf = "data:application/pdf;base64," + base64;

                            listaPdfs.Add(pdf);
                        }
                    }

                    if (unidadesEnStock - item.Unidades > 0)
                    {
                        //Generación etiqueta entrada en almacén origen
                        BarcodeLib.Barcode CodBarrasOr = new BarcodeLib.Barcode();
                        CodBarras.IncludeLabel = true;

                        item.Unidades = decimal.Round(item.Unidades, 2);
                        var arrayPartidaOr = item.Partida.Split("-");
                        if (arrayPartidaOr.Length < 2)
                        {
                            arrayPartidaOr = item.Partida.Split(" ");
                        }
                        text = item.CodigoArticulo + " " + arrayPartidaOr[0] + " " + arrayPartidaOr[1] + " " + (unidadesEnStock - item.Unidades).ToString("F").Replace(",", "").Replace(".", "");

                        System.Drawing.Image etiquetaCodBarrasOr = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
                        byte[] etiquetaCodBarrasBytesOr = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

                        iText.Layout.Element.Image etiquetaCodBarrasIOr = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            PdfWriter writer2 = new PdfWriter(ms2);
                            using (var pdfDoc2 = new PdfDocument(writer2))
                            {
                                Document doc2 = new Document(pdfDoc2, PageSize.A4.Rotate());

                                PageRotationEventHandler eventHandler2 = new PageRotationEventHandler();
                                pdfDoc2.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler2);

                                Table table2 = new Table(4);

                                Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                                table2.AddCell(cell);
                                Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Traspas Magatzem").SetMarginTop(10));
                                table2.AddCell(cell2);
                                Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + codAlmacen).SetMarginTop(10));
                                table2.AddCell(cell3);
                                Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(articulo.DescripcionArticulo).SetFontSize(40));
                                table2.AddCell(cell4);
                                Cell cell5 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                                table2.AddCell(cell5);
                                Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                                table2.AddCell(cell6);
                                Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + (unidadesEnStock - item.Unidades).ToString()).SetFontSize(15));
                                table2.AddCell(cell7);
                                Cell cell8 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasIOr).SetMarginTop(25).SetMarginBottom(25));
                                table2.AddCell(cell8);

                                table2.SetMarginTop(85f);
                                doc2.Add(table2);

                                doc2.Close();
                                writer2.Close();


                                byte[] buffer2 = ms2.ToArray();
                                string base642 = Convert.ToBase64String(buffer2);
                                pdf = "data:application/pdf;base64," + base642;

                                listaPdfs.Add(pdf);
                            }
                        }
                    }
                }
                return listaPdfs;
            }
            else
            {
                return listaPdfs;
            }

        }

        [HttpGet]
        [Route("numAlbaran")]
        public async Task<int> GetNumAlb()
        {
            CabeceraAlbaranProveedor ultCabAlb = await dBContext.CabeceraAlbaranProveedors.OrderBy(p => p.NumeroAlbaran).LastOrDefaultAsync();
            return ultCabAlb.NumeroAlbaran;
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            IEnumerable<Cliente> listaClientes = await dBContext.Clientes.ToListAsync();
            IEnumerable<ClienteDTO> listaClientesDTO = mapper.Map<IEnumerable<ClienteDTO>>(listaClientes);

            return listaClientesDTO;
        }

        [HttpGet]
        [Route("clientes/{codCliente}")]
        public async Task<ClienteDTO> GetClienteByCod(string codCliente)
        {
            Cliente Cliente = await dBContext.Clientes.Where(p => p.CodigoCliente == codCliente).FirstOrDefaultAsync();
            ClienteDTO ClienteDTO = mapper.Map<ClienteDTO>(Cliente);

            return ClienteDTO;
        }

        [HttpGet]
        [Route("cliente/{codArticulo}/{codPartida}")]
        public async Task<string> GetClienteByCodArticulo(string codArticulo, string codPartida)
        {
            CoProduccionesxLineaPf lineaPf = await dBContext.CoProduccionesxLineaPfs.Where(p => p.CodigoArticulo == codArticulo).Where(p => p.Partida == codPartida).FirstOrDefaultAsync();
            if (lineaPf is null)
            {
                codPartida = codPartida.Replace("-", " ");

                lineaPf = await dBContext.CoProduccionesxLineaPfs.Where(p => p.CodigoArticulo == codArticulo).Where(p => p.Partida == codPartida).FirstOrDefaultAsync();
            }
            CoProduccionesxLineaMp lineaMp = await dBContext.CoProduccionesxLineaMps.Where(p => p.CoCodigoLinea == lineaPf.CoCodigoLinea && p.NumeroFabricacion == lineaPf.NumeroFabricacion).FirstOrDefaultAsync();
            LineasAlbaranProveedor lineaAlbProv = await dBContext.LineasAlbaranProveedors.Where(p => p.CodigoArticulo == lineaMp.CodigoArticulo && p.Partida == lineaMp.Partida).FirstOrDefaultAsync();

            return lineaAlbProv.CodigodelProveedor;
        }

        [HttpGet]
        [Route("stockByCod/{codigoArticulo}")]
        public async Task<IEnumerable<AcumuladoStockDTO>> GetStockByCod(string codigoArticulo)
        {
            IEnumerable<AcumuladoStock> stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == codigoArticulo && p.Periodo == 99).Where(p => p.UnidadSaldo != 0).OrderByDescending(x => x.Ejercicio).OrderBy(c => c.CodigoAlmacen).ToListAsync();
            IEnumerable<AcumuladoStockDTO> stockProdDTO = mapper.Map<IEnumerable<AcumuladoStockDTO>>(stockProd);

            return stockProdDTO;
        }

        [HttpGet]
        [Route("stockByCodPart/{codArticulo}/{partida}/{codAlmacen}")]
        public async Task<ActionResult> GetStockByCodPart(string codArticulo, string partida, string codAlmacen)
        {
            AcumuladoStock stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == codArticulo && p.Periodo == 99 && p.Partida == partida && p.CodigoAlmacen == codAlmacen).FirstOrDefaultAsync();
            if(stockProd is null)
            {
                partida = partida.Replace("-", " ");

                stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == codArticulo && p.Periodo == 99 && p.Partida == partida && p.CodigoAlmacen == codAlmacen).FirstOrDefaultAsync();
            }
            if (stockProd == null)
            {
                return Ok(0);
            }
            else
            {
                if (stockProd.UnidadSaldo == 0)
                {
                    return Ok(1);
                }
                else
                {
                    AcumuladoStockDTO stockProdDTO = mapper.Map<AcumuladoStockDTO>(stockProd);
                    return Ok(stockProdDTO.UnidadSaldo);
                }
            }
        }

        [HttpGet]
        [Route("histEntregas/{codArticulo}")]
        public async Task<IEnumerable<LinAlbCliDTO>> GetHistEntregas(string codArticulo)
        {
            IEnumerable<LineasAlbaranCliente> histEntregas = await dBContext.LineasAlbaranClientes.Where(p => p.CodigoArticulo == codArticulo).OrderByDescending(p => p.EjercicioAlbaran).OrderByDescending(p => p.NumeroAlbaran).Take(200).ToListAsync();

            IEnumerable<LinAlbCliDTO> histEntregasDTO = mapper.Map<IEnumerable<LinAlbCliDTO>>(histEntregas);

            return histEntregasDTO;
        }

        [HttpGet]
        [Route("lineas")]
        public async Task<IEnumerable<CO_LineaDTO>> GetLineas()
        {
            IEnumerable<CoLinea> lineas = await dBContext.CoLineas.ToListAsync();
            IEnumerable<CO_LineaDTO> lineasDTO = mapper.Map<IEnumerable<CO_LineaDTO>>(lineas);

            return lineasDTO;
        }

        [HttpPost]
        [Route("cabAlbProv")]
        public async Task<ActionResult<int>> PostCabAlbProv([FromBody] CabAlbProvDTO cabAlbProvDTO)
        {
            CabeceraAlbaranProveedor ultCabAlb = await dBContext.CabeceraAlbaranProveedors.OrderBy(p => p.NumeroAlbaran).LastOrDefaultAsync();
            cabAlbProvDTO.NumeroAlbaran = ultCabAlb.NumeroAlbaran + 1;
            var cabAlbProv = mapper.Map<CabeceraAlbaranProveedor>(cabAlbProvDTO);

            if (ModelState.IsValid)
            {
                dBContext.CabeceraAlbaranProveedors.Add(cabAlbProv);
                await dBContext.SaveChangesAsync();
                return cabAlbProvDTO.NumeroAlbaran;
            }
            return BadRequest(false);

        }


        [HttpPost]
        [Route("lineasAlbProv")]
        public async Task<ActionResult<List<string>>> PostLinAlbProv([FromBody] List<LinAlbProvDTO> lineasAlbProvDTO)
        {
            List<string> listaPdfs = new List<string>();
            string pdf = "";
            string text = "";
            List<LineasAlbaranProveedor> lineasAlbProv = mapper.Map<List<LineasAlbaranProveedor>>(lineasAlbProvDTO);

            if (ModelState.IsValid)
            {
                await dBContext.LineasAlbaranProveedors.AddRangeAsync(lineasAlbProv);
                await dBContext.SaveChangesAsync();

                foreach (var item in lineasAlbProvDTO)
                {
                    CabeceraAlbaranProveedor ultCabAlb = await dBContext.CabeceraAlbaranProveedors.OrderBy(p => p.NumeroAlbaran).LastOrDefaultAsync();
                    ultCabAlb.NumeroLineas = (short)(ultCabAlb.NumeroLineas + 1);
                    await dBContext.SaveChangesAsync();

                    AcumuladoStockDTO stockProdDTO = new AcumuladoStockDTO();

                    AcumuladoStock stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida).FirstOrDefaultAsync();

                    if (stockProd == null)
                    {
                        stockProdDTO.CodigoArticulo = item.CodigoArticulo;
                        stockProdDTO.CodigoAlmacen = item.CodigoAlmacen;
                        stockProdDTO.Partida = item.Partida;
                        stockProdDTO.Periodo = (short)DateTime.Now.Month;
                        stockProdDTO.UnidadEntrada = item.Unidades;
                        stockProdDTO.UnidadSaldo = stockProdDTO.UnidadEntrada - stockProdDTO.UnidadSalida;
                        stockProdDTO.FechaUltimaEntrada = DateTime.Now;

                        stockProd = mapper.Map<AcumuladoStock>(stockProdDTO);
                        dBContext.AcumuladoStocks.Add(stockProd);

                        await dBContext.SaveChangesAsync();
                    }
                    else
                    {
                        stockProd.UnidadEntrada = stockProd.UnidadEntrada + item.Unidades;
                        stockProd.UnidadSaldo = stockProd.UnidadEntrada - stockProd.UnidadSalida;
                        stockProd.FechaUltimaEntrada = DateTime.Now;

                        await dBContext.SaveChangesAsync();
                    }


                    AcumuladoStock stockProd99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida && p.Periodo == 99).FirstOrDefaultAsync();

                    if (stockProd99 == null)
                    {
                        stockProdDTO.CodigoArticulo = item.CodigoArticulo;
                        stockProdDTO.CodigoAlmacen = item.CodigoAlmacen;
                        stockProdDTO.Partida = item.Partida;
                        stockProdDTO.Periodo = 99;
                        stockProdDTO.UnidadEntrada = item.Unidades;
                        stockProdDTO.UnidadSaldo = stockProdDTO.UnidadEntrada - stockProdDTO.UnidadSalida;
                        stockProdDTO.FechaUltimaEntrada = DateTime.Now;

                        stockProd99 = mapper.Map<AcumuladoStock>(stockProdDTO);
                        dBContext.AcumuladoStocks.Add(stockProd99);

                        await dBContext.SaveChangesAsync();
                    }
                    else
                    {
                        stockProd99.UnidadEntrada = stockProd99.UnidadEntrada + item.Unidades;
                        stockProd99.UnidadSaldo = stockProd99.UnidadEntrada - stockProd99.UnidadSalida;
                        stockProd99.FechaUltimaEntrada = DateTime.Now;

                        await dBContext.SaveChangesAsync();
                    }


                    Articulo articulo = await dBContext.Articulos.Where(p => p.CodigoArticulo == item.CodigoArticulo).FirstOrDefaultAsync();

                    //Generar código de barras y generar etiqueta PDF
                    BarcodeLib.Barcode CodBarras = new BarcodeLib.Barcode();
                    CodBarras.IncludeLabel = true;

                    item.Unidades = decimal.Round(item.Unidades, 2);
                    var arrayPartida = item.Partida.Split("-");
                    if (arrayPartida.Length < 2)
                    {
                        arrayPartida = item.Partida.Split(" ");
                    }
                    text = item.CodigoArticulo + " " + arrayPartida[0] + " " + arrayPartida[1] + " " + item.Unidades.ToString("F").Replace(",", "").Replace(".", "");

                    System.Drawing.Image etiquetaCodBarras = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
                    byte[] etiquetaCodBarrasBytes = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

                    iText.Layout.Element.Image etiquetaCodBarrasI = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        PdfWriter writer = new PdfWriter(ms);
                        using (var pdfDoc = new PdfDocument(writer))
                        {
                            Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

                            PageRotationEventHandler eventHandler = new PageRotationEventHandler();
                            pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);

                            Table table = new Table(4);

                            Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                            table.AddCell(cell);
                            Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Matèria primera").SetMarginTop(10));
                            table.AddCell(cell2);
                            Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + item.CodigoAlmacen).SetMarginTop(10));
                            table.AddCell(cell3);
                            Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(articulo.DescripcionArticulo).SetFontSize(40));
                            table.AddCell(cell4);
                            Cell cell5 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                            table.AddCell(cell5);
                            Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                            table.AddCell(cell6);
                            Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + item.Unidades.ToString()).SetFontSize(15));
                            table.AddCell(cell7);
                            Cell cell8 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasI).SetMarginTop(25).SetMarginBottom(25));
                            table.AddCell(cell8);

                            table.SetMarginTop(85f);
                            doc.Add(table);

                            doc.Close();
                            writer.Close();


                            byte[] buffer = ms.ToArray();
                            string base64 = Convert.ToBase64String(buffer);
                            pdf = "data:application/pdf;base64," + base64;

                            listaPdfs.Add(pdf);

                        }
                    }
                }
                return listaPdfs;
            }
            return listaPdfs;
        }

        [HttpPost]
        [Route("cabAlbCli")]
        public async Task<int> PostCabAlbCli([FromBody] CabAlbCliDTO cabAlbCliDTO)
        {
            int longDom = cabAlbCliDTO.Domicilio.Length;
            int longRaz = cabAlbCliDTO.RazonSocial.Length;
            int longNom = cabAlbCliDTO.Nombre.Length;
            int longMun = cabAlbCliDTO.Municipio.Length;
            int longVia = cabAlbCliDTO.ViaPublicaEnvios.Length;
            int longProv = cabAlbCliDTO.Provincia.Length;
            int longNac = cabAlbCliDTO.Nacion.Length;

            if (longDom > 40)
            {
                cabAlbCliDTO.Domicilio = cabAlbCliDTO.Domicilio.Substring(0, 40);
                cabAlbCliDTO.DomicilioEnvios = cabAlbCliDTO.DomicilioEnvios.Substring(0, 40);
            }
            if (longRaz > 40)
            {
                cabAlbCliDTO.RazonSocial = cabAlbCliDTO.RazonSocial.Substring(0, 40);
                cabAlbCliDTO.RazonSocialEnvios = cabAlbCliDTO.RazonSocialEnvios.Substring(0, 40);
            }
            if (longNom > 35)
            {
                cabAlbCliDTO.Nombre = cabAlbCliDTO.Nombre.Substring(0, 35);
                cabAlbCliDTO.NombreEnvios = cabAlbCliDTO.NombreEnvios.Substring(0, 35);
            }
            if (longMun > 25)
            {
                cabAlbCliDTO.Municipio = cabAlbCliDTO.Municipio.Substring(0, 25);
                cabAlbCliDTO.MunicipioEnvios = cabAlbCliDTO.MunicipioEnvios.Substring(0, 25);
            }
            if (longVia > 25)
            {
                cabAlbCliDTO.ViaPublicaEnvios = cabAlbCliDTO.ViaPublicaEnvios.Substring(0, 25);
            }
            if (longProv > 20)
            {
                cabAlbCliDTO.Provincia = cabAlbCliDTO.Provincia.Substring(0, 20);
                cabAlbCliDTO.ProvinciaEnvios = cabAlbCliDTO.ProvinciaEnvios.Substring(0, 20);
            }
            if (longNac > 25)
            {
                cabAlbCliDTO.Nacion = cabAlbCliDTO.Nacion.Substring(0, 25);
                cabAlbCliDTO.NacionEnvios = cabAlbCliDTO.NacionEnvios.Substring(0, 25);
            }



            CabeceraAlbaranCliente lastCabAlbCliente = await dBContext.CabeceraAlbaranClientes.Where(p => p.EjercicioAlbaran == (short)DateTime.Now.Year).OrderBy(p => p.NumeroAlbaran).LastOrDefaultAsync();


            if (lastCabAlbCliente != null)
            {
                cabAlbCliDTO.NumeroAlbaran = lastCabAlbCliente.NumeroAlbaran + 1;
            }
            else
            {
                cabAlbCliDTO.NumeroAlbaran = 1;
            }


            CabeceraAlbaranCliente cabAlbCliente = mapper.Map<CabeceraAlbaranCliente>(cabAlbCliDTO);
            dBContext.CabeceraAlbaranClientes.Add(cabAlbCliente);
            await dBContext.SaveChangesAsync();

            return cabAlbCliente.NumeroAlbaran;
        }

        [HttpPost]
        [Route("linAlbCli")]
        public async Task<ActionResult<List<string>>> PostLinAlbCli([FromBody] IEnumerable<LinAlbCliDTO> linAlbCliDTO)
        {
            short orden = 0;
            List<string> etiquetasPDF = new List<string>();

            IEnumerable<LineasAlbaranCliente> linAlbCli = mapper.Map<IEnumerable<LineasAlbaranCliente>>(linAlbCliDTO);
            foreach (var item in linAlbCli)
            {
                orden += 5;
                item.Orden = (short)orden;
                item.ImporteNeto = item.Unidades * item.Precio;
                item.ImporteLiquido = item.ImporteNeto + (item.ImporteNeto * 21 / 100);
            }
            if (ModelState.IsValid)
            {
                CabeceraAlbaranCliente lastCabAlbCliente = await dBContext.CabeceraAlbaranClientes.Where(p => p.EjercicioAlbaran == (short)DateTime.Now.Year).OrderBy(p => p.NumeroAlbaran).LastOrDefaultAsync();


                await dBContext.LineasAlbaranClientes.AddRangeAsync(linAlbCli);
                await dBContext.SaveChangesAsync();

                lastCabAlbCliente.NumeroLineas = (short)(linAlbCli.Count());
                await dBContext.SaveChangesAsync();

                foreach (var item in linAlbCliDTO)
                {
                    AcumuladoStock stockProd = new AcumuladoStock();
                    try
                    {
                        stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida && p.Periodo != 99).FirstAsync();
                    }
                    catch
                    {
                        item.Partida = item.Partida.Replace("-", " ");

                        stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida && p.Periodo != 99).FirstAsync();
                    }
                   
                    if (stockProd != null)
                    {
                        stockProd.UnidadSalida = stockProd.UnidadSalida + item.Unidades;
                        stockProd.UnidadSaldo = stockProd.UnidadEntrada - stockProd.UnidadSalida;
                        stockProd.FechaUltimaSalida = DateTime.Now;

                        await dBContext.SaveChangesAsync();
                    }

                    AcumuladoStock stockProd99 = new AcumuladoStock();
                    try
                    {
                        stockProd99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida && p.Periodo == 99).FirstAsync();
                    }
                    catch
                    {
                        item.Partida = item.Partida.Replace("-", " ");

                        stockProd99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == item.CodigoArticulo && p.CodigoAlmacen == item.CodigoAlmacen && p.Partida == item.Partida && p.Periodo == 99).FirstAsync();
                    }
                    
                    if (stockProd99 != null)
                    {
                        stockProd99.UnidadSalida = stockProd99.UnidadSalida + item.Unidades;
                        stockProd99.UnidadSaldo = stockProd99.UnidadEntrada - stockProd99.UnidadSalida;
                        stockProd99.FechaUltimaSalida = DateTime.Now;

                        await dBContext.SaveChangesAsync();
                    }

                    //Generar código de barras y generar etiqueta PDF
                    string pdf = "";
                    string text = "";

                    BarcodeLib.Barcode CodBarras = new BarcodeLib.Barcode();
                    CodBarras.IncludeLabel = true;

                    item.Unidades = decimal.Round(item.Unidades, 2);
                    var arrayPartida = item.Partida.Split('-');
                    if (arrayPartida.Length < 2)
                    {
                        arrayPartida = item.Partida.Split(' ');
                    }
                    text = item.CodigoArticulo + " " + arrayPartida[0] + " " + arrayPartida[1] + " " + item.Unidades.ToString("F").Replace(",", "").Replace(".", "");

                    System.Drawing.Image etiquetaCodBarras = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
                    byte[] etiquetaCodBarrasBytes = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

                    iText.Layout.Element.Image etiquetaCodBarrasI = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        PdfWriter writer = new PdfWriter(ms);
                        using (var pdfDoc = new PdfDocument(writer))
                        {
                            Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

                            PageRotationEventHandler eventHandler = new PageRotationEventHandler();
                            pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);

                            Table table = new Table(4);

                            Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                            table.AddCell(cell);
                            Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Producte final").SetMarginTop(10));
                            table.AddCell(cell2);
                            Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + item.CodigoAlmacen).SetMarginTop(10));
                            table.AddCell(cell3);
                            Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(item.DescripcionArticulo).SetFontSize(40));
                            table.AddCell(cell4);
                            Cell cell5 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                            table.AddCell(cell5);
                            Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                            table.AddCell(cell6);
                            Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Bobines: " + item.CoBobinas.ToString()).SetFontSize(15));
                            table.AddCell(cell7);
                            Cell cell8 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + item.Unidades.ToString()).SetFontSize(15));
                            table.AddCell(cell8);
                            Cell cell9 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasI).SetMarginTop(25).SetMarginBottom(25));
                            table.AddCell(cell9);

                            table.SetMarginTop(85f);
                            doc.Add(table);

                            doc.Close();
                            writer.Close();


                            byte[] buffer = ms.ToArray();
                            string base64 = Convert.ToBase64String(buffer);
                            pdf = "data:application/pdf;base64," + base64;

                            etiquetasPDF.Add(pdf);

                        }
                    }
                }
                return etiquetasPDF;
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("ordenesFabByLin/{linea}")]
        public async Task<ActionResult<List<CoProduccionesxLineaDTO>>> GetOrdenesFabByLin(string linea)
        {
            List<CoProduccionesxLinea> listaOrdenes = await dBContext.CoProduccionesxLineas.Where(p => p.StatusActivo == -1 && p.CoCodigoLinea == linea).ToListAsync();
            List<CoProduccionesxLineaDTO> listaOrdenesDTO = mapper.Map<List<CoProduccionesxLineaDTO>>(listaOrdenes);

            return listaOrdenesDTO;
        }

        [HttpPost]
        [Route("consumos")]
        public async Task<ActionResult<int>> PostConsumos([FromBody] List<CoProduccionesxLineaMpDTO> listaConsumosDTO)
        {

            foreach (var item in listaConsumosDTO)
            {
                var existe = await dBContext.CoProduccionesxLineaMps.Where(p => p.CoCodigoLinea == item.CoCodigoLinea && p.NumeroFabricacion == item.NumeroFabricacion && p.Partida == item.Partida && p.CodigoArticulo == item.CodigoArticulo).FirstOrDefaultAsync();
                if (existe != null)
                {
                    return Ok(item);
                }
            }

            if (ModelState.IsValid)
            {
                for (int i = 0; i < listaConsumosDTO.Count; i++)
                {
                    AcumuladoStock stockProd = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == listaConsumosDTO[i].CodigoArticulo && p.CodigoAlmacen == listaConsumosDTO[i].CodigoAlmacen && p.Partida == listaConsumosDTO[i].Partida && p.Periodo != 99).FirstOrDefaultAsync();
                    if (stockProd != null)
                    {
                        if (stockProd.UnidadSaldo > listaConsumosDTO[i].Unidades)
                        {
                            stockProd.UnidadSalida = stockProd.UnidadSalida + listaConsumosDTO[i].Unidades;
                            stockProd.UnidadSaldo = stockProd.UnidadEntrada - stockProd.UnidadSalida;
                            stockProd.UnidadConsumo = stockProd.UnidadConsumo + listaConsumosDTO[i].Unidades;
                            await dBContext.SaveChangesAsync();
                        }
                        else
                        {
                            return Ok(3);
                        }
                    }

                    AcumuladoStock stockProd99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == listaConsumosDTO[i].CodigoArticulo && p.CodigoAlmacen == listaConsumosDTO[i].CodigoAlmacen && p.Partida == listaConsumosDTO[i].Partida && p.Periodo == 99).FirstOrDefaultAsync();
                    if (stockProd99 != null)
                    {
                        if (stockProd99.UnidadSaldo > listaConsumosDTO[i].Unidades)
                        {
                            stockProd99.UnidadSalida = stockProd99.UnidadSalida + listaConsumosDTO[i].Unidades;
                            stockProd99.UnidadSaldo = stockProd99.UnidadEntrada - stockProd99.UnidadSalida;
                            stockProd99.UnidadConsumo = stockProd99.UnidadConsumo + listaConsumosDTO[i].Unidades;
                            await dBContext.SaveChangesAsync();
                        }
                        else
                        {
                            return Ok(3);
                        }

                    }
                }
                List<CoProduccionesxLineaMp> listaConsumos = mapper.Map<List<CoProduccionesxLineaMp>>(listaConsumosDTO);

                await dBContext.CoProduccionesxLineaMps.AddRangeAsync(listaConsumos);
                await dBContext.SaveChangesAsync();

                return Ok(1);
            }
            else
            {
                return Ok(0);
            }

        }

        [HttpGet]
        [Route("getOrdenesFab/{codLinea}")]
        public async Task<ActionResult<List<int>>> GetOrdenesFab(string codLinea)
        {
            return await dBContext.CoProduccionesxLineas.Where(p => p.StatusActivo == -1 && p.CoCodigoLinea == codLinea).Select(p => p.NumeroFabricacion).ToListAsync();
        }

        [HttpGet]
        [Route("getLineasOrdFabMp/{codLinea}/{ordenFab}")]
        public async Task<ActionResult<List<CoProduccionesxLineaMpDTO>>> GetLineasOrdenFabMp(string codLinea, int ordenFab)
        {
            List<CoProduccionesxLineaMp> listaLineas = await dBContext.CoProduccionesxLineaMps.Where(p => p.CoCodigoLinea == codLinea && p.NumeroFabricacion == ordenFab).ToListAsync();
            List<CoProduccionesxLineaMpDTO> listaLineasDTO = mapper.Map<List<CoProduccionesxLineaMpDTO>>(listaLineas);

            return listaLineasDTO;
        }

        [HttpGet]
        [Route("getLineasOrdFabPf/{codLinea}/{ordenFab}")]
        public async Task<ActionResult<List<CoProduccionesxLineaPfDTO>>> GetLineasOrdenFabPf(string codLinea, int ordenFab)
        {
            List<CoProduccionesxLineaPf> listaLineas = await dBContext.CoProduccionesxLineaPfs.Where(p => p.CoCodigoLinea == codLinea && p.NumeroFabricacion == ordenFab).ToListAsync();
            List<CoProduccionesxLineaPfDTO> listaLineasDTO = mapper.Map<List<CoProduccionesxLineaPfDTO>>(listaLineas);

            return listaLineasDTO;
        }

        [HttpPost]
        [Route("setProduccionMp")]
        public async Task<ActionResult<string>> SetProduccionMp([FromBody] CoProduccionesxLineaMpDTO lineaProduccionMpDTO)
        {
            string etiquetaPdf = "";
            string text = "";
            AcumuladoStock lineaProduccionMp99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == lineaProduccionMpDTO.CodigoArticulo && p.Partida == lineaProduccionMpDTO.Partida && p.CodigoAlmacen == lineaProduccionMpDTO.CodigoAlmacen && p.Periodo == 99).FirstOrDefaultAsync();
            AcumuladoStock lineaProduccionMp = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == lineaProduccionMpDTO.CodigoArticulo && p.Partida == lineaProduccionMpDTO.Partida && p.CodigoAlmacen == lineaProduccionMpDTO.CodigoAlmacen && p.Periodo != 99).FirstOrDefaultAsync();

            if (lineaProduccionMp99 is null)
            {
                AcumuladoStock lineaMpAcumuladoStock99 = new AcumuladoStock();
                lineaMpAcumuladoStock99.CodigoArticulo = lineaProduccionMpDTO.CodigoArticulo;
                lineaMpAcumuladoStock99.Partida = lineaProduccionMpDTO.Partida;
                lineaMpAcumuladoStock99.CodigoAlmacen = lineaProduccionMpDTO.CodigoAlmacen;
                lineaMpAcumuladoStock99.Periodo = 99;
                lineaMpAcumuladoStock99.UnidadEntrada = lineaProduccionMpDTO.Unidades;
                lineaMpAcumuladoStock99.UnidadSalida = 0;
                lineaMpAcumuladoStock99.UnidadSaldo = lineaMpAcumuladoStock99.UnidadEntrada;
                lineaMpAcumuladoStock99.FechaUltimaEntrada = DateTime.Now;

                await dBContext.AcumuladoStocks.AddAsync(lineaMpAcumuladoStock99);
                await dBContext.SaveChangesAsync();
            }
            else
            {
                lineaProduccionMp99.UnidadSalida = lineaProduccionMp99.UnidadSalida - lineaProduccionMpDTO.Unidades;
                lineaProduccionMp99.UnidadSaldo = lineaProduccionMp99.UnidadEntrada - lineaProduccionMp99.UnidadSalida;
                if (lineaProduccionMp99.UnidadConsumo >= lineaProduccionMpDTO.Unidades)
                {
                    lineaProduccionMp99.UnidadConsumo = lineaProduccionMp99.UnidadConsumo - lineaProduccionMpDTO.Unidades;
                }
                await dBContext.SaveChangesAsync();
            }

            if (lineaProduccionMp is null)
            {
                AcumuladoStock lineaMpAcumuladoStock = new AcumuladoStock();
                lineaMpAcumuladoStock.CodigoArticulo = lineaProduccionMpDTO.CodigoArticulo;
                lineaMpAcumuladoStock.Partida = lineaProduccionMpDTO.Partida;
                lineaMpAcumuladoStock.CodigoAlmacen = lineaProduccionMpDTO.CodigoAlmacen;
                lineaMpAcumuladoStock.Periodo = (short)DateTime.Now.Month;
                lineaMpAcumuladoStock.UnidadEntrada = lineaProduccionMpDTO.Unidades;
                lineaMpAcumuladoStock.UnidadSalida = 0;
                lineaMpAcumuladoStock.UnidadSaldo = lineaMpAcumuladoStock.UnidadEntrada;
                lineaMpAcumuladoStock.FechaUltimaEntrada = DateTime.Now;

                await dBContext.AcumuladoStocks.AddAsync(lineaMpAcumuladoStock);
                await dBContext.SaveChangesAsync();
            }
            else
            {
                lineaProduccionMp.UnidadSalida = lineaProduccionMp.UnidadSalida - lineaProduccionMpDTO.Unidades;
                lineaProduccionMp.UnidadSaldo = lineaProduccionMp.UnidadEntrada - lineaProduccionMp.UnidadSalida;
                if (lineaProduccionMp.UnidadConsumo >= lineaProduccionMpDTO.Unidades)
                {
                    lineaProduccionMp.UnidadConsumo = lineaProduccionMp.UnidadConsumo - lineaProduccionMpDTO.Unidades;
                }
                await dBContext.SaveChangesAsync();
            }

            Articulo articulo = await dBContext.Articulos.Where(p => p.CodigoArticulo == lineaProduccionMpDTO.CodigoArticulo).FirstOrDefaultAsync();

            //Generar código de barras y generar etiqueta PDF
            BarcodeLib.Barcode CodBarras = new BarcodeLib.Barcode();
            CodBarras.IncludeLabel = true;

            lineaProduccionMpDTO.Unidades = decimal.Round(lineaProduccionMpDTO.Unidades, 2);
            var arrayPartida = lineaProduccionMpDTO.Partida.Split("-");
            if (arrayPartida.Length < 2)
            {
                arrayPartida = lineaProduccionMpDTO.Partida.Split(" ");
            }
            text = lineaProduccionMpDTO.CodigoArticulo + " " + arrayPartida[0] + " " + arrayPartida[1] + " " + lineaProduccionMpDTO.Unidades.ToString("F").Replace(",", "").Replace(".", "");

            System.Drawing.Image etiquetaCodBarras = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
            byte[] etiquetaCodBarrasBytes = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

            iText.Layout.Element.Image etiquetaCodBarrasI = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                using (var pdfDoc = new PdfDocument(writer))
                {
                    Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

                    PageRotationEventHandler eventHandler = new PageRotationEventHandler();
                    pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);

                    Table table = new Table(4);

                    Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                    table.AddCell(cell);
                    Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Matèria primera").SetMarginTop(10));
                    table.AddCell(cell2);
                    Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + lineaProduccionMpDTO.CodigoAlmacen).SetMarginTop(10));
                    table.AddCell(cell3);
                    Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(articulo.DescripcionArticulo).SetFontSize(40));
                    table.AddCell(cell4);
                    Cell cell5 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                    table.AddCell(cell5);
                    Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                    table.AddCell(cell6);
                    Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + lineaProduccionMpDTO.Unidades.ToString()).SetFontSize(15));
                    table.AddCell(cell7);
                    Cell cell8 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasI).SetMarginTop(25).SetMarginBottom(25));
                    table.AddCell(cell8);

                    table.SetMarginTop(85f);
                    doc.Add(table);

                    doc.Close();
                    writer.Close();


                    byte[] buffer = ms.ToArray();
                    string base64 = Convert.ToBase64String(buffer);
                    etiquetaPdf = "data:application/pdf;base64," + base64;

                    return etiquetaPdf;
                }
            }

        }

        [HttpPost]
        [Route("setProduccionPf")]
        public async Task<ActionResult<string>> SetProduccionPf([FromBody] CoProduccionesxLineaPfDTO lineaProduccionPfDTO)
        {
            string etiquetaPdf = "";
            string text = "";

            AcumuladoStock lineaProduccionPf99 = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == lineaProduccionPfDTO.CodigoArticulo && p.Partida == lineaProduccionPfDTO.Partida && p.CodigoAlmacen == lineaProduccionPfDTO.CodigoAlmacen && p.Periodo == 99).FirstOrDefaultAsync();
            AcumuladoStock lineaProduccionPf = await dBContext.AcumuladoStocks.Where(p => p.CodigoArticulo == lineaProduccionPfDTO.CodigoArticulo && p.Partida == lineaProduccionPfDTO.Partida && p.CodigoAlmacen == lineaProduccionPfDTO.CodigoAlmacen && p.Periodo != 99).FirstOrDefaultAsync();

            if (lineaProduccionPf99 is null)
            {
                AcumuladoStock lineaPfAcumuladoStock99 = new AcumuladoStock();
                lineaPfAcumuladoStock99.CodigoArticulo = lineaProduccionPfDTO.CodigoArticulo;
                lineaPfAcumuladoStock99.Partida = lineaProduccionPfDTO.Partida;
                lineaPfAcumuladoStock99.CodigoAlmacen = lineaProduccionPfDTO.CodigoAlmacen;
                lineaPfAcumuladoStock99.Periodo = 99;
                lineaPfAcumuladoStock99.UnidadEntrada = lineaProduccionPfDTO.Unidades;
                lineaPfAcumuladoStock99.UnidadSalida = 0;
                lineaPfAcumuladoStock99.UnidadSaldo = lineaPfAcumuladoStock99.UnidadEntrada;
                lineaPfAcumuladoStock99.FechaUltimaEntrada = DateTime.Now;

                await dBContext.AcumuladoStocks.AddAsync(lineaPfAcumuladoStock99);
                await dBContext.SaveChangesAsync();
            }
            else
            {
                lineaProduccionPf99.UnidadSalida = lineaProduccionPf99.UnidadSalida - lineaProduccionPfDTO.Unidades;
                lineaProduccionPf99.UnidadSaldo = lineaProduccionPf99.UnidadEntrada - lineaProduccionPf99.UnidadSalida;
                if (lineaProduccionPf99.UnidadConsumo >= lineaProduccionPfDTO.Unidades)
                {
                    lineaProduccionPf99.UnidadConsumo = lineaProduccionPf99.UnidadConsumo - lineaProduccionPfDTO.Unidades;
                }
                await dBContext.SaveChangesAsync();
            }

            if (lineaProduccionPf is null)
            {
                AcumuladoStock lineaPfAcumuladoStock = new AcumuladoStock();
                lineaPfAcumuladoStock.CodigoArticulo = lineaProduccionPfDTO.CodigoArticulo;
                lineaPfAcumuladoStock.Partida = lineaProduccionPfDTO.Partida;
                lineaPfAcumuladoStock.CodigoAlmacen = lineaProduccionPfDTO.CodigoAlmacen;
                lineaPfAcumuladoStock.Periodo = (short)DateTime.Now.Month;
                lineaPfAcumuladoStock.UnidadEntrada = lineaProduccionPfDTO.Unidades;
                lineaPfAcumuladoStock.UnidadSalida = 0;
                lineaPfAcumuladoStock.UnidadSaldo = lineaPfAcumuladoStock.UnidadEntrada;
                lineaPfAcumuladoStock.FechaUltimaEntrada = DateTime.Now;

                await dBContext.AcumuladoStocks.AddAsync(lineaPfAcumuladoStock);
                await dBContext.SaveChangesAsync();
            }
            else
            {
                lineaProduccionPf.UnidadSalida = lineaProduccionPf.UnidadSalida - lineaProduccionPfDTO.Unidades;
                lineaProduccionPf.UnidadSaldo = lineaProduccionPf.UnidadEntrada - lineaProduccionPf.UnidadSalida;
                if (lineaProduccionPf.UnidadConsumo >= lineaProduccionPfDTO.Unidades)
                {
                    lineaProduccionPf.UnidadConsumo = lineaProduccionPf.UnidadConsumo - lineaProduccionPfDTO.Unidades;
                }
                await dBContext.SaveChangesAsync();
            }

            Articulo articulo = await dBContext.Articulos.Where(p => p.CodigoArticulo == lineaProduccionPfDTO.CodigoArticulo).FirstOrDefaultAsync();

            //Generar código de barras y generar etiqueta PDF
            BarcodeLib.Barcode CodBarras = new BarcodeLib.Barcode();
            CodBarras.IncludeLabel = true;

            lineaProduccionPfDTO.Unidades = decimal.Round(lineaProduccionPfDTO.Unidades, 2);
            var arrayPartida = lineaProduccionPfDTO.Partida.Split("-");
            if (arrayPartida.Length < 2)
            {
                arrayPartida = lineaProduccionPfDTO.Partida.Split(" ");
            }
            text = lineaProduccionPfDTO.CodigoArticulo + " " + arrayPartida[0] + " " + arrayPartida[1] + " " + lineaProduccionPfDTO.Unidades.ToString("F").Replace(",", "").Replace(".", "");

            System.Drawing.Image etiquetaCodBarras = CodBarras.Encode(BarcodeLib.TYPE.CODE128, text, 700, 100);
            byte[] etiquetaCodBarrasBytes = (byte[])(new ImageConverter()).ConvertTo(etiquetaCodBarras, typeof(byte[]));

            iText.Layout.Element.Image etiquetaCodBarrasI = new iText.Layout.Element.Image(ImageDataFactory.Create(etiquetaCodBarrasBytes));

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                using (var pdfDoc = new PdfDocument(writer))
                {
                    Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

                    PageRotationEventHandler eventHandler = new PageRotationEventHandler();
                    pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);

                    Table table = new Table(4);

                    Cell cell = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Texber s.a.").SetFontSize(20).SetMarginLeft(20));
                    table.AddCell(cell);
                    Cell cell2 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Producte final").SetMarginTop(10));
                    table.AddCell(cell2);
                    Cell cell3 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Magatzem: " + lineaProduccionPfDTO.CodigoAlmacen).SetMarginTop(10));
                    table.AddCell(cell3);
                    Cell cell4 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(articulo.DescripcionArticulo).SetFontSize(40));
                    table.AddCell(cell4);
                    Cell cell5 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Partida: " + arrayPartida[0]).SetFontSize(15));
                    table.AddCell(cell5);
                    Cell cell6 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Embalum: " + arrayPartida[1]).SetFontSize(15));
                    table.AddCell(cell6);
                    Cell cell7 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Pes: " + lineaProduccionPfDTO.Unidades.ToString()).SetFontSize(15));
                    table.AddCell(cell7);
                    Cell cell8 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph().Add(etiquetaCodBarrasI).SetMarginTop(25).SetMarginBottom(25));
                    table.AddCell(cell8);

                    table.SetMarginTop(85f);
                    doc.Add(table);

                    doc.Close();
                    writer.Close();


                    byte[] buffer = ms.ToArray();
                    string base64 = Convert.ToBase64String(buffer);
                    etiquetaPdf = "data:application/pdf;base64," + base64;
                }
            }
            return etiquetaPdf;
        }

        [HttpGet]
        [Route("cerrarOrdenFab/{codLinea}/{ordFab}")]
        public async Task<ActionResult<int>> CerrarOrdFab(string codLinea, int ordFab)
        {
            CoProduccionesxLinea ordFabricacion = await dBContext.CoProduccionesxLineas.Where(p => p.StatusActivo == -1 && p.CoCodigoLinea == codLinea && p.NumeroFabricacion == ordFab).FirstOrDefaultAsync();
            if(ordFabricacion is not null)
            {
                ordFabricacion.StatusActivo = 0;
                await dBContext.SaveChangesAsync();

                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] LoginDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                var nombreUsuario = await dBContext.Logins.Where(p => p.Usuario == usuarioDTO.Usuario).FirstOrDefaultAsync();
                if (nombreUsuario != null)
                {
                    return Ok(0);
                }

                string clave = usuarioDTO.Password;
                SHA256Managed sha = new SHA256Managed();
                byte[] buffer = Encoding.Default.GetBytes(clave);
                byte[] claveCifrada = sha.ComputeHash(buffer);
                string claveCifradaString = BitConverter.ToString(claveCifrada).Replace("-", "");

                usuarioDTO.Password = claveCifradaString;

                string token = "";
                for (int i = 0; i < 30; i++)
                {
                    Random r = new Random();
                    int n = r.Next(0, 9);
                    token += n.ToString();
                }
                usuarioDTO.Token = token;

                Login usuario = mapper.Map<Login>(usuarioDTO);

                dBContext.Logins.Add(usuario);
                await dBContext.SaveChangesAsync();

                LoginDTO userDTO = mapper.Map<LoginDTO>(usuario);
                return Ok(userDTO);
            }
            else
            {
                return Ok(1);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                string clave = usuarioDTO.Password;
                SHA256Managed sha = new SHA256Managed();
                byte[] buffer = Encoding.Default.GetBytes(clave);
                byte[] claveCifrada = sha.ComputeHash(buffer);
                string claveCifradaString = BitConverter.ToString(claveCifrada).Replace("-", "");

                usuarioDTO.Password = claveCifradaString;

                Login usuario = await dBContext.Logins.Where(p => p.Usuario == usuarioDTO.Usuario && p.Password == usuarioDTO.Password).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return Ok(0);
                }
                else
                {
                    string token = "";
                    for (int i = 0; i < 30; i++)
                    {
                        Random r = new Random();
                        int n = r.Next(0, 9);
                        token += n.ToString();
                    }

                    usuario.Token = token;
                    await dBContext.SaveChangesAsync();

                    LoginDTO userDTO = mapper.Map<LoginDTO>(usuario);
                    return Ok(userDTO);
                }
            }
            else
            {
                return Ok(0);
            }

        }

        [HttpGet]
        [Route("verifToken/{token}")]
        public async Task<ActionResult> VerifToken(string token)
        {
            Login usuario = await dBContext.Logins.Where(p => p.Token == token).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return Ok(null);
            }
            else
            {
                LoginDTO userDTO = mapper.Map<LoginDTO>(usuario);
                return Ok(userDTO);
            }
        }

    }
}

