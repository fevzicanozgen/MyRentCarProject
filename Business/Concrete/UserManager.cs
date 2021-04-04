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
    public class UserManager : IUsersService
    {
        IUsersDal _userDal;

        public UserManager(IUsersDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll());
        }

        public IDataResult<List<Users>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p => p.Id == id));
        }

        [ValidationAspect(typeof(UsersValidator))]
        public IResult Add(Users user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(UsersValidator))]
        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}

