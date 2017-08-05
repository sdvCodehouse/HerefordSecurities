using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HerefordSecuritiesLtd.Entities
{
    public class ServiceProvided
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Narrative { get; set; }
        public int SiteDataId { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageLink { get; set; }
        public string ImageAltText { get; set; }
        public bool IsActive { get; set; }
    }
}