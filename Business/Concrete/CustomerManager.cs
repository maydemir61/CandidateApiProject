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
        public CustomerManager(ICustomerDal customerDal,IMapper mapper,IPayzeeService payzeeService)
        {
            this._customerDal = customerDal;
            this._mapper = mapper;
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
