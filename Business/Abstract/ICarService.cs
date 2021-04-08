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

        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetAllById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        DataResult<List<Car>> GetByDailyPrice();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car cars);

    }

}
