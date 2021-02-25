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
        ICarDal _carDal;
        public CarImageManager(ICarImageDal carImageDal, ICarDal carDal)
        {
            _carImageDal = carImageDal;
            _carDal = carDal;
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
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
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
    }
}
