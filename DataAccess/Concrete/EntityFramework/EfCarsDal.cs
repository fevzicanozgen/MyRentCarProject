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
    public class EfCarsDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorsId
                             select new CarDetailDto {
                                 CarName = c.CarName,
                                 BrandId=c.BrandId,
                                 BrandName = b.BrandName,
                                 ColorsId=c.ColorId,
                                 ColorsName = color.ColorsName,
                                 DailyPrice = c.DailyPrice, 
                                 ModelYear=c.ModelYear,
                                 Description=c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault(),
                             };

                return result.ToList();


            }
        }

      
    }
}