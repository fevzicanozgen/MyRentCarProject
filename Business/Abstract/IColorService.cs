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
        IDataResult<List<Color>> GetAll();

        IResult Update(Color colors);
        IResult Delete(Color colors);
        IResult Add(Color colors);

        IDataResult<List<Color>> GetAllById(int colorId);
    }
}
