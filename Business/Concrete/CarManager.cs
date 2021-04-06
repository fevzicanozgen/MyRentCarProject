﻿using Business.Abstract;
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
        public IResult Add(Cars cars)
        {
                _carsDal.Add(cars);
                return new SuccessResult(Messages.Added);
            
        }



        public IDataResult<List<Cars>> GetAll()
        {
            
            return new SuccessDataResult<List<Cars>>(_carsDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Cars>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Cars>>(_carsDal.GetAll(c => c.Id == id));
        }

        public DataResult<List<Cars>> GetByDailyPrice()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails(), Messages.Added);


        }
        public IDataResult<List<Cars>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Cars>>(_carsDal.GetAll(c=>c.BrandId==id));

        }

        public IDataResult<List<Cars>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Cars>>(_carsDal.GetAll(c => c.ColorId == id));
        }
    }
}
