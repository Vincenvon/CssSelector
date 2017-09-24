using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.Enum;
using CssSelector.Common.Attributes;
using CssSelector.Common.Entities;
using CssSelector.DAL.DataBase;

namespace CssSelector.BL.Service.UserService
{
    public class UserService:IUserService
    {
        private IDataBase<UserEntity> _dataBase;


        public UserService(IDataBase<UserEntity> userDataBase)
        {
            _dataBase = userDataBase;
        }

        public UserEntity GetUser(string value)
        {
            var uniqueParamName = GetUniquePropName();
            return _dataBase.GetListByParam(uniqueParamName, value).FirstOrDefault();
        }

        public OperationStatus InsertUser(UserEntity userEntity)
        {
            var uniqueParamName = GetUniquePropName();
            var elem = _dataBase.GetListByParam(uniqueParamName, userEntity.Email); //TODO ::Change for dinamyc 
            if (elem.Any())
            {
                return OperationStatus.AlreadyExists;
            }
            else
            {
                _dataBase.Insert(userEntity);
                return OperationStatus.Success;
            }
        }

        private string GetUniquePropName()
        {
            var result= typeof(UserEntity).GetProperties()
                .First(item => item.GetCustomAttributes(typeof(UserUniqueAttribute), true).Length > 0)
                .Name;
            return result;
        }

    }
}
