using Microsoft.Extensions.Configuration;
using DataAccess.PayzeeRequestResponse.TokenService;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using Business.Abstract;
using DataAccess.PayzeeRequestResponse.PaymentService;
using RestSharp;
using Azure.Core.Pipeline;
using Azure.Core;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PayzeeManager:IPayzeeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private RestClient _restClient;
        public PayzeeManager(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _restClient = new RestClient();
        }


        public async Task<TokenResponse> GetToken()
        {
            TokenRequest request = _configuration.GetSection("PayzeeTokenService").Get<TokenRequest>();
            string endpoint = _configuration.GetValue<string>("PayzeeTokenEndPoint");
            var tokenjson = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,Application.Json);
            var serviceClient=_httpClientFactory.CreateClient();
            using var httpResponseMessage = await serviceClient.PostAsync(endpoint, tokenjson);
            TokenResponse response= JsonConvert.DeserializeObject<TokenResponse>( await httpResponseMessage.Content.ReadAsStringAsync());
            return response;

        }
        public  IDataResult<PaymentResponse> Payment(PaymentRequest request)
        {
            string endpoint = _configuration.GetValue<string>("PayzeePaymentEndPoint");
            string hash = CreateHash(request);
            request.hash = hash;
            RestRequest restrequest = new RestRequest(endpoint, Method.Post);
            string json=JsonConvert.SerializeObject(request,new JsonSerializerSettings() { NullValueHandling=NullValueHandling.Ignore });
            TokenResponse token = GetToken().Result;
            restrequest.AddJsonBody(json);
            restrequest.AddHeader("Authorization", string.Format("Bearer {0}", token.Result.Token));
            restrequest.AddHeader("content-type", "application/json");
            var response = _restClient.Post<PaymentResponse>(restrequest);

            return new SuccessDataResult<PaymentResponse>(response,Messages.GetCustomerSuccess);
        }
        private string CreateHash(PaymentRequest request)
        {
            var apiKey = _configuration["PayzeePaymentService:ApiKey"]; 
            var hashString = $"{apiKey}{request.merchantId}{request.rnd}{request.txnType}{request.totalAmount}{request.customerId}{ request.orderId}";
            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create();
            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding();
            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));
            var hash = System.BitConverter.ToString(bytes).Replace("-", "");
            return hash;

        }


    }
}
