using Core.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IResult Update(Customer customers);
        IResult Delete(Customer customers);
        IResult Add(Customer customers);

        IDataResult<List<Customer>> GetAllById(int customerId);
    }
}
