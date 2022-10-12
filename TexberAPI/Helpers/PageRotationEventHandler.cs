using iText.Kernel.Events;
using iText.Kernel.Pdf;

namespace TexberAPI.Helpers
{
    public class PageRotationEventHandler : IEventHandler
    {
        public static readonly PdfNumber LANDSCAPE = new PdfNumber(90);

        private PdfNumber orientation = LANDSCAPE;

        public void HandleEvent(Event currentEvent)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
            docEvent.GetPage().Put(PdfName.Rotate, LANDSCAPE);

        }
    }
}
