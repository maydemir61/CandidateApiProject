using Core.Utilities.Results;
using DataAccess.PayzeeRequestResponse.PaymentService;
using DataAccess.PayzeeRequestResponse.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface  IPayzeeService
    {
        public Task<TokenResponse> GetToken();
        public IDataResult<PaymentResponse> Payment(PaymentRequest request);
    }
}
