using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarsDal : EfEntityRepositoryBase<Cars, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from c in context.cars
                             join b in context.brand
                             on c.BrandId equals b.BrandId
                             join color in context.colors
                             on c.ColorId equals color.ColorsId
                             select new CarDetailDto {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorsName = color.ColorsName,
                                 DailyPrice = c.DailyPrice 
                             };

                return result.ToList();


            }
        }

      
    }
}