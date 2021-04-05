using Core.Result;
using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarsImageService
    {
        IResult Add(CarsImage carImages, IFormFile file);
        IResult Delete(CarsImage carImages);
        IResult Update(CarsImage carImages, IFormFile file);
        IDataResult<List<CarsImage>> GetAll();
        IDataResult<CarsImage> Get(int id);
        IDataResult<List<CarsImage>> GetImagesByCarId(int CarId);
    }
}