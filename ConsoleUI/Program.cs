using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          
            CarDetailDto();
        }

        private static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarsDal());
            
            carManager.Add(new Cars
            {
                Id = 11,
                CarName="BMW",
                DailyPrice = 165,
                Description="Black 4.28i xdrive",
                ModelYear=2020,

            }); 


            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.CarName + "" + cars.ModelYear + " " + cars.Description);
            }
        }
    }
}
