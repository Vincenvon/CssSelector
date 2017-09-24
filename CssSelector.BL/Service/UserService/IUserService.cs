using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.Enum;
using CssSelector.Common.Entities;

namespace CssSelector.BL.Service.UserService
{
    public interface IUserService
    {
        UserEntity GetUser(string value);

        OperationStatus InsertUser(UserEntity userEntity);
    }
}
