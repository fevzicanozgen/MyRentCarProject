using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public void Add(Cars cars)
        {
            if (cars.DailyPrice <= 0)
            {
                Console.WriteLine("The daily price should be greater then 0.");
            }
            else if (cars.CarName.Length <= 2)
            {
                Console.WriteLine("The car name should be longer then two letters.");
            }
            else
            {
                _carsDal.Add(cars);
                Console.WriteLine("Car added to database.");
            }
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
