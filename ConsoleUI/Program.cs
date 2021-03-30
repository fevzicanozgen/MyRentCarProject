using Business.Concrete;
using Business.Constants;
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
           // CarAdded();
        }

     

        private static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarsDal());

            var result = carManager.GetCarDetails();


            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorsName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }  
        }
        private static void CarAdded()
        {
            CarManager carManager = new CarManager(new EfCarsDal());

            // var result = carManager.GetAll();
            carManager.Add(new Cars
            {
                
                CarName = "Bmw",
                ModelYear = 2020,
                Description = "420i Cabrio ",
                DailyPrice = 1200,
                BrandId = 2,
                ColorId = 3,
            });
            Console.WriteLine(Messages.CarAdded);
        }
    }
}
