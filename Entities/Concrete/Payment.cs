using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int TotalPrice { get; set; }
        public int CreditCardId { get; set; }
    }
}