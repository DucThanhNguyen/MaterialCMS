using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Events.Documents
{
    public class OnWebpagePublishedEventArgs
    {
        public OnWebpagePublishedEventArgs(Webpage document)
        {
            Webpage = document;
        }

        public Webpage Webpage { get; set; }
    }
}