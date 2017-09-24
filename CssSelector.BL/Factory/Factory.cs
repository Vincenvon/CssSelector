using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.Service.UserService;
using CssSelector.Common.Entities;
using CssSelector.DAL.DataBase;

namespace CssSelector.BL.Factory
{
    public static class Factory
    {
        public static IUserService  GetService(string connection)
        {
            var dataBase=new MongoDataBase<UserEntity>(connection);
            return new UserService(dataBase);
        }
    }
}
