using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarsDal
    {
        List<Cars> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Cars>
            {
                new Cars {Id=1,BrandId=1,ColorId=1,DailyPrice=1000,ModelYear=2021,Description="Red BMW M4"},
                  new Cars {Id=2,BrandId=2,ColorId=2,DailyPrice=750,ModelYear=2019,Description="Black Mercedes E250"},
                    new Cars {Id=3,BrandId=3,ColorId=3,DailyPrice=600,ModelYear=2017,Description="White Audi A3"},
                      new Cars {Id=4,BrandId=4,ColorId=4,DailyPrice=350,ModelYear=2015,Description="Blue VW Polo"},
            };
        }

        public void Add(Cars entity)
        {
            _cars.Add(entity);
        }

        public void Add(CarDetailDto car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cars entity)
        {
            Cars CarToDelete = CarToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(CarToDelete);
        }

        public List<Cars> GetAll(Expression<Func<Cars, bool>> filter = null)
        {
            return _cars.Where(c => c.Id==c.Id ).ToList();
           
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Cars entity)
        {
            Cars CarToUpdate = CarToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            CarToUpdate.ModelYear = entity.ModelYear;
            CarToUpdate.ColorId = entity.ColorId;
            CarToUpdate.BrandId = entity.BrandId;
            CarToUpdate.DailyPrice = entity.DailyPrice;
            CarToUpdate.Description = entity.Description;
        }
    }
}
