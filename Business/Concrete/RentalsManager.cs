using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Rentals rental)
        {

            if (rental.ReturnDate == null)
            {

                return new ErrorResult(Messages.CarNotAvailable);

            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);

        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}