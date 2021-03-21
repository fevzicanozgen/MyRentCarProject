using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarsDal());

            carManager.Add(new Cars { 
                Id=1,
                BrandId = 1,
                ColorId = 1,
                ModelYear = 2018,
                DailyPrice = 200000,
                Description = "A7" 
            });


            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Id + " " + cars.ModelYear + " " + cars.Description);
            }
        }
    }
}
