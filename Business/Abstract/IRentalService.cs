using Core.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult Delete(Rental rentals);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto();

        IDataResult<List<Rental>> GetAllById(int Id);
    }
}
