using Core.Utilities.Results;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface ICategoryService
    {
        IDataResult <List<Category>> GetAll();
        IDataResult<List<Category>> GetById(int categoryId);

    }
}
