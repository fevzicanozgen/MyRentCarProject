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
    public class CustomerManager : ICustomerService
    {
        ICustomersDal _customerDal;

        public CustomerManager(ICustomersDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {

            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customers>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(p => p.UserId == id));
        }

        [ValidationAspect(typeof(CustomersValidator))]
        public IResult Add(Customers customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
