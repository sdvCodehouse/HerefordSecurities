using System.Web.Mvc;

namespace HerefordSecuritiesLtd.Entities
{
    public class ServiceImage
    {
        public int Id { get; set; }
        [AllowHtml]
        public string ImageLink { get; set; }
        public int ServiceProvidedId { get; set; }
    }
}