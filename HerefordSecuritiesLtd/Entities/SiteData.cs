using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HerefordSecuritiesLtd.Entities
{
    public class SiteData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string IntroLead { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Intro { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Education { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string ProfessionalQuals { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Expertise { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Interests { get; set; }
    }
}