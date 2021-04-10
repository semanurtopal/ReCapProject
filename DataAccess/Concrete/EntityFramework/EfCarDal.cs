using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandId= b.BrandId,
                                 ColorId=r.ColorId,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 MinimumFindeksRating = c.MinimumFindeksRating,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
