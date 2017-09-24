using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.Common.Entities;
using CssSelector.DAL.DataBase;

namespace CssSelector.BL.Service
{
    public class MongoDbService:IDataBaseService
    {
        private IDataBase<ElementEntity> _dataBase;

        public MongoDbService(IDataBase<ElementEntity> elementDataBase)
        {
            _dataBase = elementDataBase;
        }

        public void Insert(ElementEntity entity)
        {
            _dataBase.Insert(entity);
        }
    }
}
