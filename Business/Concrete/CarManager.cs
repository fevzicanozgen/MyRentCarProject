using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Result;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carsDal;

        public CarManager(ICarDal carsDal)
        {
            _carsDal = carsDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car cars)
        {
                _carsDal.Add(cars);
                return new SuccessResult(Messages.CarAdded);
            
        }



        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.Id == id));
        }

        public DataResult<List<Car>> GetByDailyPrice()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTeam);

            }
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails(), Messages.CarListed);


        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c=>c.BrandId==id));

        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.ColorId == id));
        }
    }
}
