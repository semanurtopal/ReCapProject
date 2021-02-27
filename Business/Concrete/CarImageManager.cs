using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService =  carService;   
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.ImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarId(id));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }

            var getallresult = _carImageDal.GetAll(p => p.CarId == id);
            if (getallresult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePaths.ImageDefaultPath } });
            }

            return new SuccessDataResult<List<CarImage>>(getallresult);
            
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.ImageId == carImage.ImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private string ImagePath(int carId)
        {
            string GuidKey = Guid.NewGuid().ToString();
            return FilePaths.ImageFolderPath + GuidKey + ".jpg";
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count >5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarId(int carId)
        {
            if (!_carService.GetById(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarMessage);
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

    }
}
