using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath}";
            FileHelper.DeleteAsync(oldpath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = id, ImagePath = @"\Images\default1.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }

        


        private IResult CheckIfImageLimit(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(CarImage carImage, IFormFile file)
        {
            Add(carImage, file);
            Update(carImage, file);

            return new SuccessResult(Messages.CarImageUpdated);
        }

    }
}