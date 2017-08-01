using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerefordSecuritiesLtd.Entities
{
    public class WorkExperience
    {
        public Client Client { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Website> Websites { get; set; }
        public string Narrative { get; set; }
    }

    public class Website
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Website Weblink { get; set; }
    }
}