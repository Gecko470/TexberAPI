using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TexberAPI.Models
{
    public partial class texberDBContext : DbContext
    {
        public texberDBContext()
        {
        }

        public texberDBContext(DbContextOptions<texberDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcumuladoStock> AcumuladoStocks { get; set; }
        public virtual DbSet<Almacene> Almacenes { get; set; }
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<CabeceraAlbaranCliente> CabeceraAlbaranClientes { get; set; }
        public virtual DbSet<CabeceraAlbaranProveedor> CabeceraAlbaranProveedors { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CoFibra> CoFibras { get; set; }
        public virtual DbSet<CoLinea> CoLineas { get; set; }
        public virtual DbSet<CoProduccionesxLinea> CoProduccionesxLineas { get; set; }
        public virtual DbSet<CoProduccionesxLineaMp> CoProduccionesxLineaMps { get; set; }
        public virtual DbSet<CoProduccionesxLineaPf> CoProduccionesxLineaPfs { get; set; }
        public virtual DbSet<ConsumosOt> ConsumosOts { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<LineasAlbaranCliente> LineasAlbaranClientes { get; set; }
        public virtual DbSet<LineasAlbaranProveedor> LineasAlbaranProveedors { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MovimientoStock> MovimientoStocks { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=defaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<AcumuladoStock>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Ejercicio, e.CodigoArticulo, e.CodigoAlmacen, e.Periodo, e.Partida, e.TipoUnidadMedida, e.CodigoColor, e.CodigoTalla01 })
                    .HasName("AcumuladoStock_AcumuladoArticulo");

                entity.ToTable("AcumuladoStock");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.Ejercicio, e.CodigoAlmacen, e.CodigoArticulo, e.Periodo, e.Partida, e.TipoUnidadMedida }, "AcumuladoStock_EjercicioAlmacen");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.Ejercicio, e.CodigoArticulo, e.CodigoAlmacen, e.Periodo, e.Partida, e.TipoUnidadMedida }, "AcumuladoStock_EjercicioArticulo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoArticulo, e.Partida }, "AcumuladoStock_Partidas");

                entity.HasIndex(e => e.IdAcumuladoStock, "AcumuladoStock_Sync_id");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAlmacen)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoUnidadMedida)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TipoUnidadMedida_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoColor_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTalla01)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoTalla01_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CosteSalida).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaEntrada).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaSalida).HasColumnType("datetime");

                entity.Property(e => e.IdAcumuladoStock).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ImporteCompra).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteConsumo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteEntrada).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteSaldo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteSalida).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioMedio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioUltimaEntrada).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioUltimaSalida).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadCompra).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadCompraTipo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("UnidadCompraTipo_");

                entity.Property(e => e.UnidadConsumo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadConsumoTipo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("UnidadConsumoTipo_");

                entity.Property(e => e.UnidadEntrada).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadEntradaTipo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("UnidadEntradaTipo_");

                entity.Property(e => e.UnidadSaldo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadSaldoTipo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("UnidadSaldoTipo_");

                entity.Property(e => e.UnidadSalida).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadSalidaTipo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("UnidadSalidaTipo_");
            });

            modelBuilder.Entity<Almacene>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoAlmacen })
                    .HasName("Almacenes_Almacen");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.GrupoAlmacen, e.CodigoAlmacen }, "Almacenes_GrupoAlmacen");

                entity.HasIndex(e => e.IdAlmacen, "Almacenes_Id_Sync");

                entity.Property(e => e.CodigoAlmacen)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AgruparMovimientos).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Almacen)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoCodigoAlmacenSauleda)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoAlmacenSauleda")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrupoAlmacen)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAlmacen).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdDelegacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoArticulo })
                    .HasName("Articulos_Articulo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoAlternativo }, "Articulos_Alternativo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoAlternativo2 }, "Articulos_Alternativo2");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.DescripcionArticulo }, "Articulos_Descripcion");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoFamilia, e.CodigoSubfamilia, e.CodigoArticulo }, "Articulos_Familia");

                entity.HasIndex(e => e.IdArticulo, "Articulos_Id_Sync");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.ReferenciaEdi }, "Articulos_ReferenciaEdi");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcumulaEstadistica)
                    .HasColumnName("AcumulaEstadistica_")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.CobrarDevolucionTardia).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodigoAlternativo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAlternativo2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArancelario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAreaCompetenciaLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticuloFacturacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticuloOferta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCategoriaLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoClaseArticuloLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoComisionista2).HasColumnName("CodigoComisionista2_");

                entity.Property(e => e.CodigoComisionista3).HasColumnName("CodigoComisionista3_");

                entity.Property(e => e.CodigoComisionista4).HasColumnName("CodigoComisionista4_");

                entity.Property(e => e.CodigoConjuntoLc)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContaje)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFabricanteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFamiliaFabricanteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoGrupoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoModoLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPeriodicidadPrecio)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSerie)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubcategoriaLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubconjuntoLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubfamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubgrupoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubtipoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoCoberturaLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoPeriodicidadPrecioLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Colores).HasColumnName("Colores_");

                entity.Property(e => e.ComentarioArticulo).HasColumnType("text");

                entity.Property(e => e.Comision)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision");

                entity.Property(e => e.Comision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision2_");

                entity.Property(e => e.Comision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision3_");

                entity.Property(e => e.Comision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision4_");

                entity.Property(e => e.CosteFabricacionUnitario).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.DemandaMediaDiaria).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Descripcion2Articulo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionLinea).HasColumnType("text");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Descuento2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento2");

                entity.Property(e => e.Descuento3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento3");

                entity.Property(e => e.DescuentoCompras)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%DescuentoCompras");

                entity.Property(e => e.DescuentoCompras2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%DescuentoCompras2");

                entity.Property(e => e.DescuentoCompras3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%DescuentoCompras3");

                entity.Property(e => e.DescuentoOferta).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.EnviaraSr)
                    .HasColumnName("EnviaraSR")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("FactorConversion_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FactorCrecimiento)
                    .HasColumnType("decimal(28, 10)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FactorPrecioCompra)
                    .HasColumnName("FactorPrecioCompra_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FactorPrecioVenta)
                    .HasColumnName("FactorPrecioVenta_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaFinalOferta).HasColumnType("datetime");

                entity.Property(e => e.FechaInicioOferta).HasColumnType("datetime");

                entity.Property(e => e.GeneraCompraAutomatica).HasColumnName("GeneraCompraAutomatica_");

                entity.Property(e => e.GrupoTalla).HasColumnName("GrupoTalla_");

                entity.Property(e => e.IdArticulo).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ImagenExt).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.ImagenTactilSr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ImagenTactilSR")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImpresionResguardoSr).HasColumnName("ImpresionResguardoSR");

                entity.Property(e => e.Lote).HasColumnName("Lote_");

                entity.Property(e => e.MarcaProducto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Margen)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Margen");

                entity.Property(e => e.MaximoSinRetencionLc).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Medida)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoAgruparSr).HasColumnName("NoAgruparSR");

                entity.Property(e => e.NoTraspasarSfa).HasColumnName("NoTraspasarSFA");

                entity.Property(e => e.NumDecimalesUnidades).HasDefaultValueSql("(2)");

                entity.Property(e => e.PeriodoGarantiaSr).HasColumnName("PeriodoGarantiaSR");

                entity.Property(e => e.PesableSr).HasColumnName("PesableSR");

                entity.Property(e => e.PesoBrutoUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoBrutoUnitario_");

                entity.Property(e => e.PesoNetoUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoNetoUnitario_");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioCosteEstandar).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioModificableSr).HasColumnName("PrecioModificableSR");

                entity.Property(e => e.PrecioOfertaconIva)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioOfertaconIVA");

                entity.Property(e => e.PrecioOfertasinIva)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioOfertasinIVA");

                entity.Property(e => e.PrecioPeriodoRetraso).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioUnidadPerdida).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioVentaconIva1)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentaconIVA1");

                entity.Property(e => e.PrecioVentaconIva2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentaconIVA2");

                entity.Property(e => e.PrecioVentaconIva3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentaconIVA3");

                entity.Property(e => e.PrecioVentasinIva1)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentasinIVA1");

                entity.Property(e => e.PrecioVentasinIva2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentasinIVA2");

                entity.Property(e => e.PrecioVentasinIva3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioVentasinIVA3");

                entity.Property(e => e.PublicarGcrm)
                    .HasColumnName("PublicarGCRM")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.PuntoPedido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StockMaximo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.StockMinimo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.StockSeguridad).HasColumnName("%StockSeguridad");

                entity.Property(e => e.TaraUnitaria)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TaraUnitaria_");

                entity.Property(e => e.TasaProduccionDiaria).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Temporada)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TiempoMedioReposicion).HasColumnType("decimal(28, 19)");

                entity.Property(e => e.TipoAbc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TipoABC")
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.TipoArticulo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.TipoArticuloPresupuesto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoCodigoBarrasSr).HasColumnName("TipoCodigoBarrasSR");

                entity.Property(e => e.TipoDemanda)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TipoEnvase).HasColumnName("TipoEnvase_");

                entity.Property(e => e.TipoUnidadCalculo).HasColumnName("TipoUnidadCalculo_");

                entity.Property(e => e.UnidadMedida2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedidaAlternativa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedidaAlternativa_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedidaCompras)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedidaCompras_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedidaFabricacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedidaFabricacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedidaSerie)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedidaVentas)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedidaVentas_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadesMinimasOferta).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesRegaloOferta).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ValoracionStock).HasDefaultValueSql("(1)");

                entity.Property(e => e.VolumenUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("VolumenUnitario_");
            });

            modelBuilder.Entity<CabeceraAlbaranCliente>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran })
                    .HasName("CabeceraAlbaranCliente_Albaran");

                entity.ToTable("CabeceraAlbaranCliente");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "CabeceraAlbaranCliente_AlbaranDel");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoCliente, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "CabeceraAlbaranCliente_Cliente");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.NumeroCaja, e.NumeroInterno }, "CabeceraAlbaranCliente_DocumentoPv");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.StatusEstadis, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.FechaAlbaran }, "CabeceraAlbaranCliente_Estadis");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioFactura, e.SerieFactura, e.NumeroFactura, e.StatusFacturado }, "CabeceraAlbaranCliente_Factura");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.FechaAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.CodigoCliente, e.StatusFacturado }, "CabeceraAlbaranCliente_FechaAlbaran");

                entity.HasIndex(e => e.IdAlbaranCli, "CabeceraAlbaranCliente_Id_Sync");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoCliente, e.StatusFacturado, e.NoFacturable }, "CabeceraAlbaranCliente_Riesgo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.EsTicket }, "CabeceraAlbaranCliente_Ticket");

                entity.Property(e => e.SerieAlbaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlbaranValorado).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AnaCapitulo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnaLote)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseComision).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseComisionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseComisionDivisa_");

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseImponibleDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseImponibleDivisa_");

                entity.Property(e => e.CalculoDeBultos)
                    .HasColumnName("CalculoDeBultos_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Ccc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifDni)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifEuropeo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoActividadLc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAgencia)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAmbitoClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoBanco)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCadena)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCadena_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCanal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoClaseClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoComisionista2).HasColumnName("CodigoComisionista2_");

                entity.Property(e => e.CodigoComisionista3).HasColumnName("CodigoComisionista3_");

                entity.Property(e => e.CodigoComisionista4).HasColumnName("CodigoComisionista4_");

                entity.Property(e => e.CodigoContable)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContableAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoContableANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisionLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoExportacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoGrupoClienteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIdioma_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoJefeVenta).HasColumnName("CodigoJefeVenta_");

                entity.Property(e => e.CodigoJefeZona).HasColumnName("CodigoJefeZona_");

                entity.Property(e => e.CodigoMotivoAbonoLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipioEnvios)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoNacion).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoNacionEnvios).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPostalEnvios)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvinciaEnvios)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoRuta)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoRuta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubactividadLc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubclaseClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoOperacionLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoOperacionOrigenLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipioEnvios)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comision)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision");

                entity.Property(e => e.Comision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision2_");

                entity.Property(e => e.Comision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision3_");

                entity.Property(e => e.Comision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision4_");

                entity.Property(e => e.ComisionSobreVenta)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ComisionSobreVenta%_");

                entity.Property(e => e.ComisionSobreZona)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ComisionSobreZona%_");

                entity.Property(e => e.CondicionExportacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CondicionExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.DesgloseContenido)
                    .HasColumnName("DesgloseContenido_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2Envios)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DomicilioEnvios)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnEuros)
                    .HasColumnName("EnEuros_")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.EnvioEfactura).HasColumnName("EnvioEFactura");

                entity.Property(e => e.FactorCambio)
                    .HasColumnType("decimal(28, 10)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FaxEnvios)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaAlbaran)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.Financiacion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Financiacion");

                entity.Property(e => e.FormadePago)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GastosAduana)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("GastosAduana_");

                entity.Property(e => e.GastosAduanaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("GastosAduanaDivisa_");

                entity.Property(e => e.GenerarFactura)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.HoraCreacion).HasColumnType("decimal(28, 19)");

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAlbaranCli).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdDelegacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdDelegacionCentralLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImporteAcuentaA)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteACuentaA_");

                entity.Property(e => e.ImporteAcuentaAdivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteACuentaADivisa_");

                entity.Property(e => e.ImporteBruto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteBrutoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteBrutoDivisa_");

                entity.Property(e => e.ImporteCambio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteCambioViejo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteCambioViejo_");

                entity.Property(e => e.ImporteComision).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteComision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision2_");

                entity.Property(e => e.ImporteComision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision3_");

                entity.Property(e => e.ImporteComision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision4_");

                entity.Property(e => e.ImporteComisionJefeVentas)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComisionJefeVentas_");

                entity.Property(e => e.ImporteComisionJefeZona)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComisionJefeZona_");

                entity.Property(e => e.ImporteConsumidoA).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteConsumidoAdivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteConsumidoADivisa_");

                entity.Property(e => e.ImporteCoste).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuento).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuentoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDescuentoDivisa_");

                entity.Property(e => e.ImporteDescuentoLineas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDtoLineasDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDtoLineasDivisa_");

                entity.Property(e => e.ImporteEnvases)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteEnvases_");

                entity.Property(e => e.ImporteEnvasesDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteEnvasesDivisa_");

                entity.Property(e => e.ImporteFactura).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteFacturaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFacturaDivisa_");

                entity.Property(e => e.ImporteFinanciacion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteFinanciacionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFinanciacionDivisa_");

                entity.Property(e => e.ImporteFletes)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFletes_");

                entity.Property(e => e.ImporteFletesDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFletesDivisa_");

                entity.Property(e => e.ImporteLiquido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteLiquidoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteLiquidoDivisa_");

                entity.Property(e => e.ImporteNetoLineas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteNetoLineasDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteNetoLineasDivisa_");

                entity.Property(e => e.ImportePendienteAac)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImportePendienteAAC");

                entity.Property(e => e.ImportePendienteAacdivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImportePendienteAACDivisa_");

                entity.Property(e => e.ImportePortes).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImportePortesDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImportePortesDivisa_");

                entity.Property(e => e.ImporteProntoPago).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProntoPagoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProntoPagoDivisa_");

                entity.Property(e => e.ImporteProvisiones).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProvisionesDivisa).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProvisionesNf)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProvisionesNF");

                entity.Property(e => e.ImporteProvisionesNfdivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProvisionesNFDivisa");

                entity.Property(e => e.ImporteRappel).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRappelDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRappelDivisa_");

                entity.Property(e => e.ImporteRetencion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRetencionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRetencionDivisa_");

                entity.Property(e => e.ImporteSeguro)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteSeguro_");

                entity.Property(e => e.ImporteSeguroDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteSeguroDivisa_");

                entity.Property(e => e.ImporteSuplidos).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteSuplidosDivisa).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.IndicadorIva)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.MantenerCambio).HasColumnName("MantenerCambio_");

                entity.Property(e => e.MargenBeneficio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MascaraAlbaran)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraFactura)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraFactura_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Matricula2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovConta).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MunicipioEnvios)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NacionEnvios)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreEnvios)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroPlazos).HasDefaultValueSql("(1)");

                entity.Property(e => e.NumeroTerminalSr).HasColumnName("NumeroTerminalSR");

                entity.Property(e => e.NumeroTurnoSr).HasColumnName("NumeroTurnoSR");

                entity.Property(e => e.ObservacionExportacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ObservacionExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionExportacion2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ObservacionExportacion2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesAlbaran)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesFactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesWeb)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackingList).HasColumnName("PackingList_");

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoBruto_");

                entity.Property(e => e.PesoNeto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoNeto_");

                entity.Property(e => e.PorMargenBeneficio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ProntoPago)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%ProntoPago");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProvinciaEnvios)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PuertoDestino)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PuertoDestino_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PuertoOrigen)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PuertoOrigen_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rappel)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Rappel");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2Envios)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocialEnvios)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaMandato)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RemesaHabitual)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RemesaHabitualAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RemesaHabitualANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Retencion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Retencion");

                entity.Property(e => e.SerieAlbaranDevolucionA)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieAlbaranOriginalLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieExpediente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFacturaOriginal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SiglaNacion)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ES')");

                entity.Property(e => e.StatusCreadoXml).HasColumnName("StatusCreadoXML");

                entity.Property(e => e.StatusEnvioXml).HasColumnName("StatusEnvioXML");

                entity.Property(e => e.SuContrato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuPedido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TelefonoEnvios)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoPortesEnvios)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.TotalCuotaIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalCuotaIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalCuotaIvaDivisa_");

                entity.Property(e => e.TotalCuotaRecargo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalCuotaRecargoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalCuotaRecargoDivisa_");

                entity.Property(e => e.TotalIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalIvaDivisa_");

                entity.Property(e => e.ViaPublicaEnvios)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Volumen)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Volumen_");
            });

            modelBuilder.Entity<CabeceraAlbaranProveedor>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran })
                    .HasName("CabeceraAlbaranProveedor_Albaran");

                entity.ToTable("CabeceraAlbaranProveedor");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "CabeceraAlbaranProveedor_AlbaranDel");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.StatusEstadis, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.FechaAlbaran }, "CabeceraAlbaranProveedor_Estadis");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.StatusFacturado, e.CodigoProveedor }, "CabeceraAlbaranProveedor_FacturaProveedor");

                entity.HasIndex(e => e.IdAlbaranPro, "CabeceraAlbaranProveedor_Id_Sync");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.CodigoProveedor, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "CabeceraAlbaranProveedor_Proveedor");

                entity.Property(e => e.SerieAlbaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnaCapitulo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnaLote)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseImponibleDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseImponibleDivisa_");

                entity.Property(e => e.Ccc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifDni)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifEuropeo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoFibra)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CO_Fibra")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAgencia)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoBanco)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCanal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContable)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContableAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoContableANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoExportacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIdioma_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoNacion).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CondicionExportacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CondicionExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnEuros)
                    .HasColumnName("EnEuros_")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FactorCambio)
                    .HasColumnType("decimal(28, 10)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FechaAlbaran)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.FechaSuAlbaran).HasColumnType("datetime");

                entity.Property(e => e.FechaSuFactura).HasColumnType("datetime");

                entity.Property(e => e.Financiacion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Financiacion");

                entity.Property(e => e.FinanciacionSobreBase).HasColumnName("FinanciacionSobreBase_");

                entity.Property(e => e.FormadePago)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdAlbaranPro).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdDelegacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImporteBruto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteBrutoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteBrutoDivisa_");

                entity.Property(e => e.ImporteCambio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteCambioViejo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteCambioViejo_");

                entity.Property(e => e.ImporteDescuento).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuentoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDescuentoDivisa_");

                entity.Property(e => e.ImporteDescuentoLineas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDtoLineasDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDtoLineasDivisa_");

                entity.Property(e => e.ImporteFactura).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteFacturaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFacturaDivisa_");

                entity.Property(e => e.ImporteFinanciacion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteFinanciacionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteFinanciacionDivisa_");

                entity.Property(e => e.ImporteLiquido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteLiquidoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteLiquidoDivisa_");

                entity.Property(e => e.ImporteNetoLineas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteNetoLineasDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteNetoLineasDivisa_");

                entity.Property(e => e.ImporteParcial).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteParcialDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteParcialDivisa_");

                entity.Property(e => e.ImportePortes).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImportePortesDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImportePortesDivisa_");

                entity.Property(e => e.ImporteProntoPago).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProntoPagoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProntoPagoDivisa_");

                entity.Property(e => e.ImporteRappel).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRappelDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRappelDivisa_");

                entity.Property(e => e.ImporteRetencion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRetencionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRetencionDivisa_");

                entity.Property(e => e.IndicadorIva)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.MantenerCambio).HasColumnName("MantenerCambio_");

                entity.Property(e => e.MascaraAlbaran)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraFactura)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraFactura_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroPlazos).HasDefaultValueSql("(1)");

                entity.Property(e => e.ObservacionesAlbaran)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesFactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProntoPago)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%ProntoPago");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rappel)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Rappel");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RemesaHabitual)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RemesaHabitualAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RemesaHabitualANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Retencion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Retencion");

                entity.Property(e => e.RetencionConIva).HasColumnName("RetencionConIva_");

                entity.Property(e => e.SerieExpediente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFacturaOriginal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SiglaNacion)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ES')");

                entity.Property(e => e.SuAlbaranNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuFacturaNo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoPortes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.TotalCuotaIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalCuotaIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalCuotaIvaDivisa_");

                entity.Property(e => e.TotalCuotaRecargo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalCuotaRecargoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalCuotaRecargoDivisa_");

                entity.Property(e => e.TotalIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalIvaDivisa_");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoCliente })
                    .HasName("Clientes_Cliente");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.CodigoCliente }, "Clientes_ClienteDel");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.CodigoContable }, "Clientes_CodigoContable");

                entity.HasIndex(e => e.IdCliente, "Clientes_Id_Sync");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.RazonSocial }, "Clientes_Nombre");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.Nombre }, "Clientes_NombreFiscal");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Actividad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlbaranValorado).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AsesorNominaLw)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("AsesorNominaLW")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AutorizacionLopdlc).HasColumnName("AutorizacionLOPDLc");

                entity.Property(e => e.Cargo1)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cargo2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cargo3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ccc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifDni)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifEuropeo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoActividadLc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAgencia)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAmbitoClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoBanco)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCadena)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCadena_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCanal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCargo1)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCargo2)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCargo3)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCategoriaCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCategoriaCliente_")
                    .HasDefaultValueSql("('CLI')");

                entity.Property(e => e.CodigoClaseClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColectivoClienteLc)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoComisionista2).HasColumnName("CodigoComisionista2_");

                entity.Property(e => e.CodigoComisionista3).HasColumnName("CodigoComisionista3_");

                entity.Property(e => e.CodigoComisionista4).HasColumnName("CodigoComisionista4_");

                entity.Property(e => e.CodigoContable)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContableAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoContableANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisionLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoExportacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoGrupoClienteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIdioma_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoJefeZona).HasColumnName("CodigoJefeZona_");

                entity.Property(e => e.CodigoMotivoBajaClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoNacion).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoNaturaleza)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPuerto)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoRegimenEstadistico)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoRuta)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoRuta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSector)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoSector_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubActividadLc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoClienteLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoPrimerContactoLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTransporte)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComentarioAsiento)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comentarios).HasColumnType("text");

                entity.Property(e => e.Comision)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision");

                entity.Property(e => e.Comision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision2_");

                entity.Property(e => e.Comision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision3_");

                entity.Property(e => e.Comision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision4_");

                entity.Property(e => e.ComisionSobreZona)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ComisionSobreZona%_");

                entity.Property(e => e.CondicionExportacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CondicionExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContraseñaLogicNet)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaGasto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaProvision)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaProvisionAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CuentaProvisionANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepartamentoEdi)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Dire)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIRe")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DomingosFestivos).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email2)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailEnvioEfactura)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EmailEnvioEFactura")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmpresaNominaLwin)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EmpresaNominaLWin")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnvioEfactura).HasColumnName("EnvioEFactura");

                entity.Property(e => e.Escalera)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExcluirPorLopdlc).HasColumnName("ExcluirPorLOPDLc");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaAutorizacionLopdlc)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaAutorizacionLOPDLc");

                entity.Property(e => e.FechaBajaLc).HasColumnType("datetime");

                entity.Property(e => e.FechaExcluirPorLopdlc)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaExcluirPorLOPDLc");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaProximaAccionLc).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaAccionLc).HasColumnType("datetime");

                entity.Property(e => e.Financiacion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Financiacion");

                entity.Property(e => e.FormadePago)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FormatoEfactura).HasColumnName("FormatoEFactura");

                entity.Property(e => e.FormatoEnvio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GuiaXmlefactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GuiaXMLEFactura")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HorarioDomicilioLc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdCliente).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdClientePago).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.IdDelegacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdDelegacionCentralLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IndicadorIva)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Letra)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MantenerCambio).HasColumnName("MantenerCambio_");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraAlbaran)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraFactura)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraFactura_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraOferta)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraOferta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraPedido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraPedido_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraRecibo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraRecibo_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoTraspasarSfa).HasColumnName("NoTraspasarSFA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre3)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero1)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero2)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PersonaAsignada)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PersonaClienteLc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Piso)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProntoPago)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%ProntoPago");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicarGcrm)
                    .HasColumnName("PublicarGCRM")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Puerta)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PuntosSr)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PuntosSR");

                entity.Property(e => e.Rappel)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Rappel");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaMandato)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciadelProveedor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Retencion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Retencion");

                entity.Property(e => e.RiesgoMaximo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.SabadosFestivos).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SerieAlbaran)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SerieAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieOferta)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SerieOferta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SeriePedido_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SiglaNacion)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ES')");

                entity.Property(e => e.Social1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social1Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social2)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social2Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social3)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social3Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social4)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social4Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.StatusWf).HasColumnName("StatusWF");

                entity.Property(e => e.TarjetaSr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TarjetaSR")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Telefono3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono3Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.TelefonoAccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.TipoCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoPortes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.UsuarioLogicNet)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ViaPublica)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CoFibra>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CoFibra1 })
                    .HasName("CO_Fibras_Primario");

                entity.ToTable("CO_Fibras");

                entity.Property(e => e.CoFibra1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CO_Fibra")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoDescFibra)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CO_DescFibra")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CoLinea>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CoCodigoLinea })
                    .HasName("CO_Lineas_Primario");

                entity.ToTable("CO_Lineas");

                entity.Property(e => e.CoCodigoLinea)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoLinea")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CoProduccionesxLinea>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CoCodigoLinea, e.NumeroFabricacion })
                    .HasName("CO_ProduccionesxLinea_Primario");

                entity.ToTable("CO_ProduccionesxLinea");

                entity.Property(e => e.CoCodigoLinea)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoLinea")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CoProduccionesxLineaMp>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CoCodigoLinea, e.NumeroFabricacion, e.CodigoArticulo, e.Partida })
                    .HasName("CO_ProduccionesxLineaMP_Primario");

                entity.ToTable("CO_ProduccionesxLineaMP");

                entity.Property(e => e.CoCodigoLinea)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoLinea")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Unidades).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<CoProduccionesxLineaPf>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CoCodigoLinea, e.NumeroFabricacion, e.CodigoArticulo, e.Partida })
                    .HasName("CO_ProduccionesxLineaPF_Primario");

                entity.ToTable("CO_ProduccionesxLineaPF");

                entity.Property(e => e.CoCodigoLinea)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoLinea")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoFibra)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CO_Fibra")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ConsumosOt>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.EjercicioTrabajo, e.NumeroTrabajo, e.Orden })
                    .HasName("ConsumosOT_OrdenTrabajo");

                entity.ToTable("ConsumosOT");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioTrabajo, e.NumeroTrabajo, e.ArticuloComponente }, "ConsumosOT_ArticuloComponente");

                entity.Property(e => e.AcumulaCoste).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AlmacenDeposito)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ArticuloComponente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAlmacen)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColorComponente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoColorComponente_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Colores).HasColumnName("Colores_");

                entity.Property(e => e.CosteComponente).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CosteRealComponente).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CosteRealUnitario).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CosteUnitario).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Descripcion2Articulo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionLinea).HasColumnType("text");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("FactorConversion_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.GrupoTalla).HasColumnName("GrupoTalla_");

                entity.Property(e => e.Identificador).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IncrementoMermas)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%IncrementoMermas");

                entity.Property(e => e.Mermas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Mermas2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MermasFijas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MermasReales).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MermasReales2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.NumeroSerieLc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TallaComponente01)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TallaComponente01_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoComponente).HasDefaultValueSql("(1)");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UbicacionDeposito)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida1_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadesComponente).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesComponente2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesEntregadas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesEntregadas2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesEscandallo)
                    .HasColumnType("decimal(28, 10)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.UnidadesFijas).HasColumnName("UnidadesFijas_");

                entity.Property(e => e.UnidadesIncidencia).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesIncidencia2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesNecesarias).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesNecesarias2).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesUsadas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesUsadas2).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoCliente, e.TipoDomicilio, e.NumeroDomicilio })
                    .HasName("Domicilios_Domicilio");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoCliente }, "Domicilios_Dom_CodigoCliente");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoCliente, e.TipoDomicilio }, "Domicilios_Dom_Tipo");

                entity.HasIndex(e => e.IdDomicilio, "Domicilios_Id_Sync");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoDomicilio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoNacion).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Domicilio")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Escalera)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HorarioDomicilioLc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdDomicilio).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Letra)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero1)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero2)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PersonaClienteLc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Piso)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Puerta)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoPortes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.ViaPublica)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<LineasAlbaranCliente>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.Orden, e.LineasPosicion })
                    .HasName("LineasAlbaranCliente_Albaran");

                entity.ToTable("LineasAlbaranCliente");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoArticulo, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "LineasAlbaranCliente_Articulo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.StatusEstadis }, "LineasAlbaranCliente_Estadis");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioFactura, e.SerieFactura, e.NumeroFactura }, "LineasAlbaranCliente_Factura");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioFactura, e.SerieFactura, e.NumeroFactura, e.SerieAlbaran, e.NumeroAlbaran, e.Orden }, "LineasAlbaranCliente_ListadoFacturas");

                entity.Property(e => e.SerieAlbaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineasPosicion).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AcumulaEstadistica)
                    .HasColumnName("AcumulaEstadistica_")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.AlmacenContrapartida)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Alto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Alto_");

                entity.Property(e => e.AnaCapitulo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnaLote)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ancho)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Ancho_");

                entity.Property(e => e.BaseComision).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseComisionDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseComisionDivisa_");

                entity.Property(e => e.BaseCorreccion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%BaseCorreccion");

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseImponibleDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseImponibleDivisa_");

                entity.Property(e => e.BaseIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseIvaDivisa_");

                entity.Property(e => e.BloqueoRebaje).HasColumnName("BloqueoRebaje_");

                entity.Property(e => e.CausaExencion)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoBobinas).HasColumnName("CO_Bobinas");

                entity.Property(e => e.CoMovOrigen)
                    .HasColumnName("CO_MovOrigen")
                    .HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.CodigoAlmacen)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArancelario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAreaLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCategoriaLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoColor_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoComisionista2).HasColumnName("CodigoComisionista2_");

                entity.Property(e => e.CodigoComisionista3).HasColumnName("CodigoComisionista3_");

                entity.Property(e => e.CodigoComisionista4).HasColumnName("CodigoComisionista4_");

                entity.Property(e => e.CodigoConjuntoLc)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDun14)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFabricanteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFamiliaFabricanteLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoGrupoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoJefeVenta).HasColumnName("CodigoJefeVenta_");

                entity.Property(e => e.CodigoJefeZona).HasColumnName("CodigoJefeZona_");

                entity.Property(e => e.CodigoModoLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPerceptor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubcategoriaLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubconjuntoLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubfamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubgrupoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubtipoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTalla01)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoTalla01_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoArticuloLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoOperacionLc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTipoPeriodicidadPrecioLc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigodelCliente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comision)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision");

                entity.Property(e => e.Comision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision2_");

                entity.Property(e => e.Comision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision3_");

                entity.Property(e => e.Comision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Comision4_");

                entity.Property(e => e.ComisionSobreVenta)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ComisionSobreVenta%_");

                entity.Property(e => e.ComisionSobreZona)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ComisionSobreZona%_");

                entity.Property(e => e.CuotaIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CuotaIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("CuotaIvaDivisa_");

                entity.Property(e => e.CuotaRecargo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CuotaRecargoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("CuotaRecargoDivisa_");

                entity.Property(e => e.Descripcion2Articulo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionLinea).HasColumnType("text");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Descuento2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento2");

                entity.Property(e => e.Descuento3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento3");

                entity.Property(e => e.Dimension)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Dimension_");

                entity.Property(e => e.EdiBatchNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EdiEtiquetaEan)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EdiEtiquetaEAN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EdiIsbn)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EdiISBN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EdiSellerNumber)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EdiSerialNumber)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("FactorConversion_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FactorPrecioVenta)
                    .HasColumnName("FactorPrecioVenta_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FechaAlbaran)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCaduca).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GrupoTalla).HasColumnName("GrupoTalla_");

                entity.Property(e => e.IdPrecioLc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImporteBruto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteBrutoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteBrutoDivisa_");

                entity.Property(e => e.ImporteComision).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteComision2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision2_");

                entity.Property(e => e.ImporteComision3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision3_");

                entity.Property(e => e.ImporteComision4)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComision4_");

                entity.Property(e => e.ImporteComisionJefeVentas)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComisionJefeVentas_");

                entity.Property(e => e.ImporteComisionJefeZona)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteComisionJefeZona_");

                entity.Property(e => e.ImporteCoste).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuento).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuentoCliente).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuentoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDescuentoDivisa_");

                entity.Property(e => e.ImporteDtoClienteDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDtoClienteDivisa_");

                entity.Property(e => e.ImporteEnvases)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteEnvases_");

                entity.Property(e => e.ImporteEnvasesDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteEnvasesDivisa_");

                entity.Property(e => e.ImporteLiquido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteLiquidoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteLiquidoDivisa_");

                entity.Property(e => e.ImporteNeto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteNetoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteNetoDivisa_");

                entity.Property(e => e.ImporteProntoPago).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProntoPagoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProntoPagoDivisa_");

                entity.Property(e => e.ImporteRappel).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRappelDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRappelDivisa_");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Iva");

                entity.Property(e => e.Largo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Largo_");

                entity.Property(e => e.LineaPedido).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.LineaPosAbonoLc).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.LineasPosicionCompuesto).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.LineasPosicionRegalo).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.Lote).HasColumnName("Lote_");

                entity.Property(e => e.MargenBeneficio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MovOrigenSuplido).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.NumeroEnvases)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("NumeroEnvases_");

                entity.Property(e => e.NumeroSerieLc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrdenBulto).HasColumnName("OrdenBulto_");

                entity.Property(e => e.Partida)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoBruto_");

                entity.Property(e => e.PesoBrutoUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoBrutoUnitario_");

                entity.Property(e => e.PesoNeto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoNeto_");

                entity.Property(e => e.PesoNetoUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoNetoUnitario_");

                entity.Property(e => e.PorMargenBeneficio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Precio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioCoste).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioEnvase)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PrecioEnvase_");

                entity.Property(e => e.PrecioRebaje).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Recargo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Recargo");

                entity.Property(e => e.ReservarStock).HasColumnName("ReservarStock_");

                entity.Property(e => e.SerieExpediente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuContrato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuPedido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoArticulo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.TipoEnvase).HasColumnName("TipoEnvase_");

                entity.Property(e => e.TipoUnidadCalculo).HasColumnName("TipoUnidadCalculo_");

                entity.Property(e => e.TotalIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalIvaDivisa_");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida1_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Unidades).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Unidades2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Unidades2_");

                entity.Property(e => e.Unidades2AbonadasLc).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesAbonadasLc).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesAgrupacion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesRegalo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesServidas).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Volumen)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Volumen_");

                entity.Property(e => e.VolumenUnitario)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("VolumenUnitario_");
            });

            modelBuilder.Entity<LineasAlbaranProveedor>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.Orden, e.LineasPosicion })
                    .HasName("LineasAlbaranProveedor_Albaran");

                entity.ToTable("LineasAlbaranProveedor");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoArticulo, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran }, "LineasAlbaranProveedor_Articulo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioAlbaran, e.SerieAlbaran, e.NumeroAlbaran, e.StatusEstadis }, "LineasAlbaranProveedor_Estadis");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioFactura, e.SerieFactura, e.NumeroFactura }, "LineasAlbaranProveedor_Factura");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioFactura, e.SerieFactura, e.NumeroFactura, e.SerieAlbaran, e.NumeroAlbaran, e.Orden }, "LineasAlbaranProveedor_ListadoFacturas");

                entity.Property(e => e.SerieAlbaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineasPosicion).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AcumulaCosteProyectos).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AcumulaEstadistica)
                    .HasColumnName("AcumulaEstadistica_")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Alto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Alto_");

                entity.Property(e => e.AnaCapitulo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnaLote)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ancho)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Ancho_");

                entity.Property(e => e.BaseCorreccion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%BaseCorreccion");

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseImponibleDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseImponibleDivisa_");

                entity.Property(e => e.BaseIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.BaseIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("BaseIvaDivisa_");

                entity.Property(e => e.BloqueoRebaje).HasColumnName("BloqueoRebaje_");

                entity.Property(e => e.CoBobinas).HasColumnName("CO_Bobinas");

                entity.Property(e => e.CodigoAlmacen)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoColor_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoElemento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSubfamilia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTalla01)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoTalla01_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigodelProveedor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuotaIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CuotaIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("CuotaIvaDivisa_");

                entity.Property(e => e.CuotaRecargo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.CuotaRecargoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("CuotaRecargoDivisa_");

                entity.Property(e => e.Descripcion2Articulo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionArticulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionLinea).HasColumnType("text");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Descuento2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento2");

                entity.Property(e => e.Descuento3)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento3");

                entity.Property(e => e.Dimension)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Dimension_");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("FactorConversion_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FactorPrecioCompra)
                    .HasColumnName("FactorPrecioCompra_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FechaAlbaran)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCaduca).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GrupoTalla).HasColumnName("GrupoTalla_");

                entity.Property(e => e.IdIncidencia).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.ImporteBruto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteBrutoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteBrutoDivisa_");

                entity.Property(e => e.ImporteDescuento).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDescuentoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDescuentoDivisa_");

                entity.Property(e => e.ImporteDescuentoProveedor).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteDtoProveedorDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteDtoProveedorDivisa_");

                entity.Property(e => e.ImporteLiquido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteLiquidoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteLiquidoDivisa_");

                entity.Property(e => e.ImporteNeto).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteNetoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteNetoDivisa_");

                entity.Property(e => e.ImporteParcial).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteParcialDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteParcialDivisa_");

                entity.Property(e => e.ImporteProntoPago).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteProntoPagoDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteProntoPagoDivisa_");

                entity.Property(e => e.ImporteRappel).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteRappelDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("ImporteRappelDivisa_");

                entity.Property(e => e.IncrementoCoste)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("IncrementoCoste_");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Iva");

                entity.Property(e => e.Largo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Largo_");

                entity.Property(e => e.LineaPedido).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.NumeroSerieLc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Precio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioRebaje).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Recargo)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Recargo");

                entity.Property(e => e.SerieExpediente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoArticulo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.TipoUnidadCalculo).HasColumnName("TipoUnidadCalculo_");

                entity.Property(e => e.TotalIva).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.TotalIvaDivisa)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("TotalIvaDivisa_");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida1_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Unidades).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Unidades2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Unidades2_");

                entity.Property(e => e.UnidadesAgrupacion).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadesRecibidas).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("token");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<MovimientoStock>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Ejercicio, e.Periodo, e.Fecha, e.FechaRegistro, e.Serie, e.Documento, e.MovPosicion })
                    .HasName("MovimientoStock_Fecha");

                entity.ToTable("MovimientoStock");

                entity.HasIndex(e => new { e.StatusAcumulado, e.CodigoArticulo, e.CodigoColor, e.CodigoTalla01, e.Fecha, e.FechaRegistro, e.CodigoAlmacen, e.Partida, e.UnidadMedida1 }, "MovimientoStock_Acumulado");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.Ejercicio, e.CodigoArticulo, e.CodigoAlmacen, e.Periodo, e.Fecha, e.Partida }, "MovimientoStock_Articulo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CodigoArticulo, e.Partida }, "MovimientoStock_ArticuloPartida");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.EjercicioDocumento, e.Serie, e.Documento }, "MovimientoStock_Documento");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.Ejercicio, e.CodigoArticulo, e.Periodo }, "MovimientoStock_FichaPeriodo");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.MovIdentificador, e.MovConsumo }, "MovimientoStock_MovIdentificador");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.MovPosicion }, "MovimientoStock_MovPosicion")
                    .IsUnique();

                entity.HasIndex(e => new { e.CodigoEmpresa, e.MovOrigen }, "MovimientoStock_Origen");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Serie)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovPosicion).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AlmacenContrapartida)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoBobinas).HasColumnName("CO_Bobinas");

                entity.Property(e => e.CoCodigoLinea)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CO_CodigoLinea")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAlmacen)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCanal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoColor_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTalla01)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoTalla01_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("FactorConversion_")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.FechaCaduca).HasColumnType("datetime");

                entity.Property(e => e.GrupoTalla).HasColumnName("GrupoTalla_");

                entity.Property(e => e.Importe).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.ImporteCoste).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.MovConsumo).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.MovIdentificador).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.MovOrigen).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.MovTraspaso).HasDefaultValueSql("('{00000000-0000-0000-0000-000000000000}')");

                entity.Property(e => e.NumeroSerieLc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrigenMovimiento)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.Partida)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Partida2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Partida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Precio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.PrecioMedio).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Proceso).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SysTraspasoLwg).HasColumnName("sysTraspasoLWG");

                entity.Property(e => e.TipoMovimiento).HasDefaultValueSql("(1)");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadEntrada).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.UnidadMedida1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida1_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadMedida2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnidadMedida2_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadStock).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Unidades).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Unidades2)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("Unidades2_");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoProveedor })
                    .HasName("Proveedores_Proveedor");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.CodigoContable }, "Proveedores_CodigoContable");

                entity.HasIndex(e => e.IdProveedor, "Proveedores_Id_Sync");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.Nombre }, "Proveedores_Nombre");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdDelegacion, e.CodigoProveedor }, "Proveedores_ProveedorDel");

                entity.Property(e => e.CodigoProveedor)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Actividad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlmacenDeposito)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cargo1)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cargo2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cargo3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ccc)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CCC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifDni)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CifEuropeo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClienteVenta)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoAgencia)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoBanco)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCanal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContable)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoContableAnt)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoContableANT_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDefinicion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CodigoDefinicion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDepartamento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoDivisa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoExportacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIdioma_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoNacion).HasDefaultValueSql("(108)");

                entity.Property(e => e.CodigoNaturaleza)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProvincia)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoProyecto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoPuerto)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoRegimenEstadistico)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoSigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoTransporte)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColaMunicipio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comentarios).HasColumnType("text");

                entity.Property(e => e.CondicionExportacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CondicionExportacion_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Descuento");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Domicilio2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email2)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Escalera)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExcluirPorLopdlc).HasColumnName("ExcluirPorLOPDLc");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaBajaLc).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Financiacion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Financiacion");

                entity.Property(e => e.FinanciacionSobreBase).HasColumnName("FinanciacionSobreBase_");

                entity.Property(e => e.FormadePago)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdDelegacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdProveedor).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IndicadorIva)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Letra)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MantenerCambio).HasColumnName("MantenerCambio_");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraAlbaran)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraFactura)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraFactura_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraOferta)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraOferta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraPedido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraPedido_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MascaraTalones)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MascaraTalones_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre3)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero1)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero2)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObservacionesProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Piso)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProntoPago)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%ProntoPago");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Puerta)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rappel)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Rappel");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RazonSocial2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaEdi)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ReferenciaEdi_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciadelCliente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Retencion)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("%Retencion");

                entity.Property(e => e.RetencionConIva).HasColumnName("RetencionConIva_");

                entity.Property(e => e.RiesgoMaximo).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.SerieAlbaran)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SerieAlbaran_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SerieOferta)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SerieOferta_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SeriePedido_")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SiglaNacion)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ES')");

                entity.Property(e => e.Social1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social1Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social2)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social2Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social3)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social3Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Social4)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Social4Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.StatusWf).HasColumnName("StatusWF");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.Telefono3)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono3Accion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.TelefonoAccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Defecto')");

                entity.Property(e => e.TipoPortes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.TipoProveedor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ViaPublica)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
