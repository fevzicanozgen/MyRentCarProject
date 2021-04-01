using Business.Abstract;
using Business.Constants;
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
        ICarsDal _carsDal;

        public CarManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }

        public IResult Add(Cars cars)
        {
            if (cars.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.DailyPrice);
            }
            else if (cars.CarName.Length <= 2)
            {
                return new ErrorResult(Messages.Invalid);
            }
            else
            {
                _carsDal.Add(cars);
                return new SuccessResult(Messages.Added);
            }
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
