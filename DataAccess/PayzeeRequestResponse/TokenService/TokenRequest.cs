using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.TokenService
{
    public  class TokenRequest
    {
        [JsonProperty("ApiKey")]
        public string ApiKey { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Lang")]
        public string Lang { get; set; }
    }
}
