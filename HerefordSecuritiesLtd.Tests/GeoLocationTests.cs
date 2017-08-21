using System.IO;
using System.Net;
using System.Threading.Tasks;
using HerefordSecuritiesLtd.Entities;
using HerefordSecuritiesLtd.Services;
using NUnit.Framework;

namespace HerefordSecuritiesLtd.Tests
{
    [TestFixture]
    public class GeoLocationTests
    {
        private GeoLocation _sut;

        [OneTimeSetUp]
        public async Task SetupGeoLocationObject()
        {
            using (var responseStream = await GetGeolocationStreamAsync("81.97.56.197"))
            {
                _sut = responseStream.CreateFromJsonStream<GeoLocation>();
            }
        }

        [Test]
        public void GetObjFromStream_CanCreateGoLocationObject()
        {
            Assert.That(_sut, Is.Not.Null);
        }

        [Test]
        public void GeoLocation_AllPropertiesPopulatedAtCreation()
        {
            Assert.That(_sut.Ip, Is.EqualTo("81.97.56.197"));
            Assert.That(_sut.City, Is.EqualTo("Surbiton"));
            Assert.That(_sut.Country_Code, Is.EqualTo("GB"));
            Assert.That(_sut.Country_Name, Is.EqualTo("United Kingdom"));
            Assert.That(_sut.Region_Code, Is.EqualTo("ENG"));
            Assert.That(_sut.Region_Name, Is.EqualTo("England"));
            Assert.That(_sut.City, Is.EqualTo("Surbiton"));
            Assert.That(_sut.Zip_Code, Is.EqualTo("KT6"));
            Assert.That(_sut.Time_Zone, Is.EqualTo("Europe/London"));
            Assert.That(_sut.Latitude, Is.EqualTo(51.3915).Within(0.0001));
            Assert.That(_sut.Longitude, Is.EqualTo(-0.2982).Within(0.0001));
            Assert.That(_sut.Metro_Code, Is.EqualTo(0));
        }

        [Test]
        public void GeoLocation_ToStringIsCorrectFormatAndValue()
        {
            Assert.That(_sut.ToString(), Is.EqualTo("81.97.56.197: Surbiton, KT6, England, United Kingdom"));
        }

        internal async Task<Stream> GetGeolocationStreamAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return null;

            var webRequest = WebRequest.Create("http://freegeoip.net/json/" + ipAddress);
            var webProxy = new WebProxy("http://freegeoip.net/json/" + ipAddress, true);
            webRequest.Proxy = webProxy;
            webRequest.Timeout = 2000;
            try
            {
                var response = await webRequest.GetResponseAsync();
                return response.GetResponseStream();
            }
            catch
            {
                //todo need to log exceptions
                return null;
            }
        }
    }
}
