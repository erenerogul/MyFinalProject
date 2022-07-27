using Core.Utilities.Results;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IProductService
    {
        //list of product bizim T miz
        IDataResult<List<Product>> GetAll();//IDataResult sayesinde hem bool hem mesaj hemde data döndüreceğiz
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);//IResult Sayesinde bool ve mesaj döndürmüş oluyoruz 
        IDataResult<Product> GetById(int productId);
        //Bişey Dönddürenlerin hepsi DataResult oluyor 
    }
}
