using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {

         IResult Add(CustomerDto customer);
         IResult Update(CustomerDto customer);
         IDataResult<Customer> GetById(int customerId);
         IDataResult<List<Customer>> GetAll();



    }
}
