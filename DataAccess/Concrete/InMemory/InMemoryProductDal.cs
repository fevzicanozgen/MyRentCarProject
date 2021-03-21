using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal :IProductDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=1000,ModelYear=2021,Description="Red BMW M4"},
                  new Car {Id=2,BrandId=2,ColorId=2,DailyPrice=750,ModelYear=2019,Description="Black Mercedes E250"},
                    new Car {Id=3,BrandId=3,ColorId=3,DailyPrice=600,ModelYear=2017,Description="White Audi A3"},
                      new Car {Id=4,BrandId=4,ColorId=4,DailyPrice=350,ModelYear=2015,Description="Blue VW Polo"},



            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.Id == CarId).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = CarToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;

        }
    }
}
