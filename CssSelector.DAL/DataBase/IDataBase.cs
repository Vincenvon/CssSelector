using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.Common.Entities;

namespace CssSelector.DAL.DataBase
{

    //TODO Add comments to methods
    public interface IDataBase<T>
    {
        /// <summary>
        /// Method is used for initial of database parameters
        /// </summary>
        /// <param name="connectionString"></param>

        IEnumerable<T> GetListByParam(string parameterName, string value);

        IEnumerable<T> GetList();

        void Update(T element);

        void Insert(T element);
    }
}
