using Core.Result;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<List<Cars>> GetAll();

        IDataResult<List<Cars>> GetCarsByBrandId(int id);

        IDataResult<List<Cars>> GetAllById(int id);
        IDataResult<List<Cars>> GetCarsByColorId(int id);
        DataResult<List<Cars>> GetByDailyPrice();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Cars cars);

    }

}
