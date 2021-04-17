using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            
                using (MyDatabaseContext context = new MyDatabaseContext())
                {
                IQueryable<RentalDetailDto> rentalDetails = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                                                            join c in context.Cars
                                                            on r.CarId equals c.CarId
                                                            join b in context.Brand
                                                            on c.BrandId equals b.BrandId
                                                            join cs in context.Customers
                                                            on r.CustomerId equals cs.CustomerId
                                                            join user in context.Users
                                                            on cs.UserId equals user.UserId
                                                            select new RentalDetailDto
                                                            {
                                                                CarId = c.CarId,
                                                                RentalId = r.RentalId,
                                                                BrandId = c.BrandId,
                                                                BrandName = b.BrandName,
                                                                CarName = c.CarName,
                                                                CompanyName = cs.CompanyName,
                                                                UserName = user.FirstName + " " + user.LastName,
                                                                RentDate = r.RentDate,
                                                                ReturnDate = r.ReturnDate
                                                            };
                return rentalDetails.ToList();
            }
        }



    }


}