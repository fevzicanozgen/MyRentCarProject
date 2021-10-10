using Core.Result;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Text;
using System;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);

    }
}
