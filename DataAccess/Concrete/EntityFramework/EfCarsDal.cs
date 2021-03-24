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
    public class EfCarsDal : EfEntityRepositoryBase<Cars, MyDatabaseContext>, ICarsDal
    {
       

       

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from s in context.cars
                             join c in context.colors
                             on s.Id equals c.ColorsId
                             join b in context.brand
                             on c.ColorsId equals b.BrandId
                             select new CarDetailDto
                             {
                                 Id = s.Id,
                                 BrandName = b.BrandName,
                                 ColorsName = c.ColorsName,
                                 DailyPrice = Convert.ToInt32(s.DailyPrice),
                             };
                return result.ToList();
            }
        
          }
    }
}

