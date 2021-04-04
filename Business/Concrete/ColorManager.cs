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
    public class ColorManager : IColorService
    {
        IColorsDal _colorDal;

        public ColorManager(IColorsDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Delete(Colors color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Colors>> GetAll()
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll());
        }

        public IDataResult<List<Colors>> GetAllById(int colorId)
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll(p => p.ColorsId == colorId));
        }

        [ValidationAspect(typeof(ColorsValidator))]
        public IResult Add(Colors color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(ColorsValidator))]
        public IResult Update(Colors color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
