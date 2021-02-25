using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _carService = carService;
        }

        public IResult Add(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(entity.CarId));
            if (result!=null)
            {
                return result;
            }

            string createPath = ImagePath(entity.CarId);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            entity.Date = DateTime.Now;

            _carImageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(i => i.ImageId == entity.ImageId);
            File.Delete(imageData.ImagePath);
            _carImageDal.Delete(entity);
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

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int id)
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

        public IResult Update(CarImage entity)
        {
            string createPath = ImagePath(entity.CarId);
            File.Copy(entity.ImagePath, createPath);
            File.Delete(entity.ImagePath);
            entity.ImagePath = createPath;
            _carImageDal.Update(entity);
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

    }
}
