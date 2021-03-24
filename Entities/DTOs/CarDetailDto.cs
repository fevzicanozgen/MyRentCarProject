using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorsName { get; set; }
        public int DailyPrice { get; set; }



    }
}
