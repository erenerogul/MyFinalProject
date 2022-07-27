using Core.DataAccess;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>//Bu Sen IEntityRepositoryi Product için yapılandırdın demek
    {
        //Burası sadece mesela productı ilgilendiren sorgular gerektiği zaman kullanılacak olan yer 
        List<ProductDetailDto> GetProductDetails();
    }
}//Code refactoring kodun iyileştirilmesi

