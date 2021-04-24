using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
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
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetBrandAndColorId(int brandId,int colorsId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails().Where(c => c.BrandId == brandId && c.ColorsId == colorsId).ToList());
        }

        public IDataResult<List<Car>> GetByDailyPrice()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTeam);

            }
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails(), Messages.CarListed);


        }
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails().Where(c => c.BrandId == id).ToList());

        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails().Where(c => c.ColorsId == id).ToList());
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carsDal.Update(car);
            _carsDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

     
    }
}
