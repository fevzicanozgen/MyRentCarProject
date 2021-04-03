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
         

          CarTest();

            //BrandTest();

            //ColorTest();


          //GetCarDetailsTest();
       

        }


        private static void GetCarDetailsTest()
        {

            CarManager carManager = new CarManager(new EfCarsDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " " + car.ColorsName);
            }
        }

       

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorsDal());
            colorManager.Add(new Colors { ColorsName = "Deep Blue",ColorsId=5 });
            Console.WriteLine("New Color Added" + Environment.NewLine);
            
            list();
            void list()
            {
                Console.WriteLine("Colors Listing" + Environment.NewLine);
                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.ColorsId + " " + color.ColorsName);
                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mercedes",BrandId=5 });
            Console.WriteLine("New Brand Added" + Environment.NewLine);
            list();
            void list()
            {
                Console.WriteLine("Brands Listing" + Environment.NewLine);
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandId + " " + brand.BrandName);
                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarsDal());
            carManager.Add(new Cars { CarName="Bmw",BrandId = 7, ColorId = 3, DailyPrice = 1000, Description = "428i Petrol and Automatic", ModelYear = 2021 });
            Console.WriteLine(Messages.Added + Environment.NewLine);
            list();

            void list()
            {
                Console.WriteLine(Messages.CarListed + Environment.NewLine);
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Id + "-- " + car.CarName + "-- " +  car.DailyPrice + "$ " + car.Description);
                }
            }
        }

    }



}