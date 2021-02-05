using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
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

            foreach (var car in carManager.GetByDailyPrice(100,700))
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }
        }
    }
}
