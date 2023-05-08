using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.TokenService
{
    public class TokenResponse
    {
        [JsonProperty("fail")]
        public bool Fail { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("result")]
        public TokenResult Result { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }
        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }



    }

}
