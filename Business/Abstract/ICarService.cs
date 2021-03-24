using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
       
        List<Cars> GetAll();

        List<Cars> GetCarsByBrandId(int id);


        List<Cars> GetCarsByColorId(int id);
        void Add(Cars cars);

    }

}
