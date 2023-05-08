using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.TokenService
{
    public class TokenResult
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
