using Core.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardTypeService
    {
        IResult Add(CreditCardType creditCardType);
        IResult Update(CreditCardType creditCardType);
        IResult Delete(CreditCardType creditCardType);
        IDataResult<List<CreditCardType>> GetAll();
        IDataResult<CreditCardType> GetCardTypeById(int typeId);
    }
}