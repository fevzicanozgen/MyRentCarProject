using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarsDal _carsDal;

        public CarManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }

        public void Add(Cars car)
        {
            _carsDal.Add(car);
        }

        public List<Cars> GetAll()
        {
            return _carsDal.GetAll();
        }

        public List<Cars> GetCarsByBrandId(int id)
        {
            return _carsDal.GetAll(c=>c.BrandId==id);

        }

        public List<Cars> GetCarsByColorId(int id)
        {
            return _carsDal.GetAll(c => c.ColorId == id);
        }
    }
}
