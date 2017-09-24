using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.Common.Entities;

namespace CssSelector.BL.Service
{
    public interface IDataBaseService
    {
        void Insert(ElementEntity entity);
    }
}
