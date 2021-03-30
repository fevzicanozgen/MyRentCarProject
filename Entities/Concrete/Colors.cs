using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Colors : IEntity
    {
        public int ColorsId { get; set; }
        public string ColorsName { get; set; }

    }
}
