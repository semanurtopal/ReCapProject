using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {CarId=1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=200, Description="Economic" },
                new Car {CarId=2, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=300, Description="Comfort" },
                new Car {CarId=3, BrandId=3, ColorId=1, ModelYear=2020, DailyPrice=500, Description="Premium" },
                new Car {CarId=4, BrandId=4, ColorId=3, ModelYear=2020, DailyPrice=400, Description="Prestige" },
                new Car {CarId=5, BrandId=5, ColorId=2, ModelYear=2009, DailyPrice=200, Description="Economic" },

                };

            List<Brand> _brands;
            _brands= new List<Brand>{
                new Brand {BrandId=1, BrandName="Fiat" },
                new Brand {BrandId=2, BrandName="Peugeot" },
                new Brand {BrandId=3, BrandName="Mercedes" },
                new Brand {BrandId=4, BrandName="Opel" },
                new Brand {BrandId=5, BrandName="Renault" }
            };

            List<Color> _colors;
            _colors = new List<Color>{
                new Color {ColorId=1, ColorName="Grey" },
                new Color {ColorId=2, ColorName="White" },
                new Color {ColorId=3, ColorName="Black" },
                
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.CarId==id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
