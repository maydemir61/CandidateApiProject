using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.DtoMapper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.PayzeeRequestResponse.PaymentService;
using DataAccess.PayzeeRequestResponse.TokenService;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        IMapper _mapper;
        ICustomerDal _customerDal;
        IPayzeeService _payzeeService;
        public CustomerManager(ICustomerDal customerDal,IMapper mapper,IPayzeeService payzeeService)
        {
            this._customerDal = customerDal;
            this._mapper = mapper;
            this._payzeeService = payzeeService;
        }

        //[ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(CustomerDto customerDto)
        {

            Customer customer= _mapper.Map<Customer>(customerDto);

            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);        
        }

        public IDataResult<List<Customer>> GetAll()
        {
            TokenResponse response= _payzeeService.GetToken().Result;
            PaymentRequest paymentRequest = new PaymentRequest();
            paymentRequest.rnd = "abcd";
            paymentRequest.cvv = "715";
            paymentRequest.merchantId = 1894;
            paymentRequest.memberId = 1;
            paymentRequest.cardNumber = "4938 4601 5875 4205";
            paymentRequest.expiryDateMonth ="11";
            paymentRequest.expiryDateYear ="2024";
            paymentRequest.userCode = "441";
            paymentRequest.txnType = "Auth";
            paymentRequest.installmentCount = "1";
            paymentRequest.currency = "949";
            paymentRequest.customerId = "murat.karayilan@dotto.com.tr";
            paymentRequest.orderId = "12345";
            paymentRequest.totalAmount = "100";
            _payzeeService.Payment(paymentRequest);
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);

            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);

            return new SuccessResult(Messages.GetCustomerSuccess);
        }
      
    }
}
