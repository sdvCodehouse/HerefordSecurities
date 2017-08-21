using System;
using System.Text;

namespace HerefordSecuritiesLtd.Entities
{
    //Json returned from valid call
    //{"ip":"81.97.56.197","country_code":"GB","country_name":"United Kingdom",
    //"region_code":"ENG","region_name":"England","city":"Surbiton","zip_code":"KT6",
    //"time_zone":"Europe/London","latitude":51.3915,"longitude":-0.2982,"metro_code":0}

    public class GeoLocation
    {
        public string Ip { get; set; }
        public string Country_Code { get; set; }
        public string Country_Name { get; set; }
        public string Region_Code { get; set; }
        public string Region_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Time_Zone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Metro_Code { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(!string.IsNullOrWhiteSpace(Ip) ? Ip : ", <unknown>");
            str.Append(!string.IsNullOrWhiteSpace(City) ? ": " + City : ": <unknown>");
            str.Append(!string.IsNullOrWhiteSpace(Zip_Code) ? ", " + Zip_Code : ", <unknown>");
            str.Append(!string.IsNullOrWhiteSpace(Region_Name) ? ", " + Region_Name : ", <unknown>");
            str.Append(!string.IsNullOrWhiteSpace(Country_Name) ? ", " + Country_Name : ", <unknown>");

            return String.Format(str.ToString());
        }
    }
}