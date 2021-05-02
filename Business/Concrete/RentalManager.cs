using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        private ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllById(int id)
        {

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.RentalId == id));
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult GetRentalsCar(Rental rental)
        {
            if (rental.RentDate > rental.ReturnDate) return new ErrorResult("Teslim tarihi alış tarihinden küçük olamaz.");
            var result = _rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).
                Where(r =>
                        ((r.RentDate == rental.RentDate) && (r.ReturnDate == rental.ReturnDate)) ||
                        ((rental.RentDate >= r.RentDate) && (rental.RentDate <= r.ReturnDate)) ||
                        ((rental.ReturnDate >= r.RentDate) && (rental.ReturnDate <= r.ReturnDate))).ToList();

            if (result.Count > 0)
            {
                string errorMessage = "seçilen tarihler arasında araç zaten kiralanmış.";
                return new ErrorResult(errorMessage);
            }
            return new SuccessResult("seçilen tarihler arasında araç kiralanabilir.");
        }
    }
}