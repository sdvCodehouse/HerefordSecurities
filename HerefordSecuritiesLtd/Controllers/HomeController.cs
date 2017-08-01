using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            var workExperience = new WorkExperience
            {
                Client = new Client
                {
                    Name = "Codehouse Group",
                    Weblink = new Website {Link = "http://www.codehousegrup.com"}
                },
                DateFrom = new DateTime(2016, 4, 1),
                DateTo = new DateTime(2017, 3, 1),
                Skills = new List<Skill>()
                {
                    new Skill() {Name = "C# 5.0"},
                    new Skill() {Name="Sitecore 6.5"},
                    new Skill() {Name="TeamCity"}
                },
                Websites = new List<Website>()
                {
                    new Website() {Title = "mang.com", Link = "http://mandg.com"}
                },
                Narrative = "<p>Returned to Codehouse to work on a number of updated features to be integrated to the M&G website. These included making the site responsive to mobile viewports, and updating several sections of the existing site. Required working on a dual synchronised git branching, allowing maintenance to the existing code set whist developing the feature branch in an up to date state. Was responsible for setting up and maintaining the CI and auto deployment using TeamCity and Octopus.</p>"
                + "<p>Having worked largely on more recent versions of Sitecore, it tested the powers of memory going back to the features of Sitecore 6.5</p>"
            };

            workExperiences.Add(workExperience);

            return View();
        }

        // GET: Home
        public ActionResult Services()
        {
            return View();
        }

        // GET: Home
        public ActionResult ContactMe()
        {
            return View();
        }

        public ActionResult LegacyHome()
        {
            return View();
        }

        public ActionResult LegacyServices()
        {
            return View();
        }

        public ActionResult LegacyContactMe()
        {
            return View();
        }
    }
}