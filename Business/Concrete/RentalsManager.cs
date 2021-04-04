using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalDal;

        public RentalsManager(IRentalsDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rentals>> GetAllById(int id)
        {

            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(p => p.Id == id));
        }


        [ValidationAspect(typeof(RentalsValidator))]
        public IResult Add(Rentals rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);

        }
        [ValidationAspect(typeof(RentalsValidator))]
        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}