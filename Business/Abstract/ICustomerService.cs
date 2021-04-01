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
        IDataResult<List<Customers>> GetAll();

        IResult Update(Customers customers);
        IResult Delete(Customers customers);
        IResult Add(Customers customers);

        IDataResult<List<Customers>> GetAllById(int Id);
    }
}
