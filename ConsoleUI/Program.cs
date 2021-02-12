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
            //CarTest();
            //BrandTest();

            //Core.Utilities.Results.IResult result = RentalTest();

            //Core.Utilities.Results.IResult result = CustomerTest();

            //UserTest();
        }

        private static void UserTest()
        {
            UserManager user = new UserManager(new EfUserDal());
            var result = user.Add(new User
            {
                UserId=6,
                FirstName = "Deniz",
                LastName = "Azaklı",
                Email = "denizazakli@gmail.com",
                Password = "123456"
            });

            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static Core.Utilities.Results.IResult CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            {
                CustomerId=6,
                CompanyName = "Trainer"
            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);

            }

            return result;
        }

        private static Core.Utilities.Results.IResult RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal(),new EfCarDal());
            var result = rentalManager.Add(new Rental()
            {
                RentalId=6,
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 2, 12),
                ReturnDate=new DateTime(2021,2,13)
            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);

            }

            return result;
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            

            carManager.Add(new Car
            {
                BrandId = 5,
                ColorId = 2,
                CarName = "Megane",
                ModelYear = 2008,
                DailyPrice = 250,
                Description = "Comfort"
            });
            

            Console.WriteLine("*****************");



            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description + car.CarName + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }

            Console.WriteLine("*****************");

            foreach (var car in carManager.GetByDailyPrice(100, 700).Data)
            {
                Console.WriteLine(car.Description + "Fiyat: " + car.DailyPrice);
            }
            Console.WriteLine("*****************");

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.WriteLine("*****************");
          
        }

        
    }
}
