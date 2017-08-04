using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HerefordSecuritiesLtd.Entities
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string ClientWeblink { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [AllowHtml]
        public string ClientAdditional { get; set; }
        public string Position { get; set; }
        public string KeySkills { get; set; }
        public ICollection<Website> Websites { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Narrative { get; set; }
        public int SiteDataId { get; set; }
        public bool IsActive { get; set; }
        public bool IsRecent { get; set; }
    }
}