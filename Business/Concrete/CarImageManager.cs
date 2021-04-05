using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

using Core.Utilities.Helpers;
using Core.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Core.Business;

namespace Business.Concrete
{
    public class CarImageManager : ICarsImageService
    {
        ICarsImageDal _carsImageDal;

        public CarImageManager(ICarsImageDal carImageDal)
        {
            _carsImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarsImageValidator))]
        public IResult Add(CarsImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimited(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carsImageDal.Add(carImage);
            return new SuccessResult(Messages.CarListed);
        }

        public IResult Delete(CarsImage carImages)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carsImageDal.GetAll(p => p.Id == carImages.Id);
            IResult result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carsImageDal.Delete(carImages);
            return new SuccessResult(Messages.CarNotAvailable);


        }

        public IDataResult<CarsImage> Get(int id)
        {
            return new SuccessDataResult<CarsImage>(_carsImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarsImage>> GetAll()
        {
            return new SuccessDataResult<List<CarsImage>>(_carsImageDal.GetAll(), Messages.CarListed);

        }

        public IDataResult<List<CarsImage>> GetImagesByCarId(int CarId)
        {
            var result = _carsImageDal.GetAll(c => c.CarId == CarId).Any();
            if (!result)
            {
                List<CarsImage> carimage = new List<CarsImage>();
                carimage.Add(new CarsImage { CarId = CarId, ImagePath = @"\Images\default.png" });
                return new SuccessDataResult<List<CarsImage>>(carimage);
            }
            return new SuccessDataResult<List<CarsImage>>(_carsImageDal.GetAll(p => p.CarId == CarId));
        }

        [ValidationAspect(typeof(CarsImageValidator))]
        public IResult Update(CarsImage carImage, IFormFile file)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carsImageDal.Get(p => p.Id == carImage.CarId).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;
            _carsImageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckImageLimited(int carId)
        {
            var carImageCount = _carsImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            return new SuccessResult();
        }
    }
}