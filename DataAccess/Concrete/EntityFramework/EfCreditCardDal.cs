using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, MyDatabaseContext>, ICreditCardDal
    {
        public CreditCardDto GetCardByCustomerId(int customerId)
        {
            return GetCardsDetails(c => c.CustomerId == customerId).OrderBy(c => c.CreditCardId).LastOrDefault();
        }

        public CreditCardDto GetCardDetails(Expression<Func<CreditCardDto, bool>> filter = null)
        {
            return GetCardsDetails(filter).FirstOrDefault();
        }

        public List<CreditCardDto> GetCardsDetails(Expression<Func<CreditCardDto, bool>> filter = null)
        {
            using (MyDatabaseContext myDatabaseContext = new MyDatabaseContext())
            {
                var result = from creditCard in myDatabaseContext.CreditCards
                             join creditCardType in myDatabaseContext.CreditCardTypes
                             on creditCard.CreditCardId equals creditCardType.CreditCardTypeId
                             select new CreditCardDto
                             {
                                 CreditCardId = creditCard.CreditCardId,
                                 CustomerId = creditCard.CustomerId,
                                 CreditCardTypeId = creditCard.CreditCardTypeId,
                                 CardTypeName = creditCardType.TypeName,
                                 CardNumber = creditCard.CardNumber,
                                 FirstName = creditCard.FirstName,
                                 LastName = creditCard.LastName,
                                 ExpirationMonth = creditCard.ExpirationMonth,
                                 ExpirationYear = creditCard.ExpirationYear,
                                 Cvv = creditCard.Cvv
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}