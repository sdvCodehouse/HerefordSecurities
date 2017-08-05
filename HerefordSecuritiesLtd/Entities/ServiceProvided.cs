using System.Collections.Generic;
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
        public ICollection<ServiceImage> Images { get; set; }
        public int SiteDataId { get; set; }
        public bool IsActive { get; set; }
    }
}