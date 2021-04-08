using Core.Entities.Concrete;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);

    }
}
