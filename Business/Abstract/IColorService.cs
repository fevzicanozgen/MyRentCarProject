using Core.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Colors>> GetAll();

        IResult Update(Colors colors);
        IResult Delete(Colors colors);
        IResult Add(Colors colors);

        IDataResult<List<Colors>> GetAllById(int colorId);
    }
}
