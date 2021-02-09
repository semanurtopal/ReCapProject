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
            CarTest();
            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //carManager.Add(new Car {
            //    Id = 6,
            //    BrandId = 5,
            //    ColorId = 2,
            //    CarName = "Megane",
            //    ModelYear = 2008,
            //    DailyPrice = 250,
            //    Description = "Comfort"
            //});
            

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + car.CarName + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetByDailyPrice(100, 700))
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }
            Console.WriteLine("*****************");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "/" + car.CarName);
            }
            Console.WriteLine("*****************");
            

        }
    }
}
