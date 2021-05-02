using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("CreditCardType", Schema = "dbo")]
    public class CreditCardType : IEntity
    {
        [Key]
        public int CreditCardTypeId { get; set; }
        public string TypeName { get; set; }
    }
}