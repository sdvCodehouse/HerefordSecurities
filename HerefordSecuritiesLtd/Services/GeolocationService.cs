using System.Net;
using System.Threading.Tasks;
using System.Web;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Services
{
    public class GeolocationService
    {
        private readonly string _ipAddress;
        //private readonly GeoLocation _location;
        private readonly HttpRequestBase _request;

        public GeolocationService(HttpRequestBase request)
        {
            _request = request;
            _ipAddress = GetIpAddress();
            //_location = GetLocationAsync(_ipAddress).Result;
        }

        public string IpAddress { get { return _ipAddress; } }
        //public GeoLocation Location { get { return _location; } }

        public async Task<GeoLocation> GetLocationAsync()
        {
            return await GetLocationAsync(_ipAddress);
        }

        public async Task<GeoLocation> GetLocationAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return null;

            var webRequest = WebRequest.Create("http://freegeoip.net/json/" + ipAddress);
            var webProxy = new WebProxy("http://freegeoip.net/json/" + ipAddress, true);
            webRequest.Proxy = webProxy;
            webRequest.Timeout = 2000;
            try
            {
                var response = await webRequest.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                {
                    return responseStream.CreateFromJsonStream<GeoLocation>();
                }
            }
            catch
            {
                //todo need to log exceptions
                return null;
            }
        }
        private string GetIpAddress()
        {
            string ipAddress;
            if (RequestServerVariable("HTTP_X_FORWARDED_FOR", out ipAddress)) return ipAddress;
            if (RequestServerVariable("REMOTE_ADDR", out ipAddress)) return ipAddress;
            if (RequestServerVariable("REMOTE_HOST", out ipAddress)) return ipAddress;
            return null;
        }

        private bool RequestServerVariable(string serverVariable, out string ipAddress)
        {
            if (!string.IsNullOrWhiteSpace(_request.ServerVariables[serverVariable]))
            {
                ipAddress = _request.ServerVariables[serverVariable];
                return true;
            }
            ipAddress = null;
            return false;
        }

        

    }
}