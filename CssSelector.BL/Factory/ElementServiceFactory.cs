using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.Service;
using CssSelector.Common.Entities;
using CssSelector.DAL.DataBase;

namespace CssSelector.BL.Factory
{
    public static class ElementServiceFactory
    {
        public static IDataBaseService GetElementService(string connection)
        {
             var dataBase = new MongoDataBase<ElementEntity>(connection);
            return new MongoDbService(dataBase);
        }
    }
}
