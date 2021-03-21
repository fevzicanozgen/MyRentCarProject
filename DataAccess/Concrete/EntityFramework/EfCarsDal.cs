using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarsDal : ICarsDal
    {
        public void Add(Cars entity)
        {
            if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                using (MyDatabaseContext context = new MyDatabaseContext())
                {
                    var addedCars = context.Entry(entity);
                    addedCars.State = EntityState.Added;

                    context.SaveChanges();
                }
            }
             else
            {
                Console.WriteLine("Enter the correct car name or Daily Price value.");
            }
        }

        public void Delete(Cars entity)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var deletedCars = context.Entry(entity);
                deletedCars.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
        public List<Cars> GetAll(Expression<Func<Cars, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                return filter == null ? context.Set<Cars>().ToList() : context.Set<Cars>().Where(filter).ToList();


            }
        }

        public void Update(Cars entity)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var updatedCars = context.Entry(entity);
                updatedCars.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}

