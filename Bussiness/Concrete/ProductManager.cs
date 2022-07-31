using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.DependencyResolvers.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entitites.Concrete;
using Entitites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager (IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            //Business Codes
            //Validation Code
            ValidationTool.Validate(new ProductValidator(),product);
            //Loglama
            //Cache remove
            //Performance 
            //Transaction
            //Authorizontal
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        //public Product GetById(int productId)
        //{
        //    return _productDal.Get(p=>p.ProductId == productId);
        //}
        public IDataResult<List<Product>> GetAll()
        {
            //İŞ kodları 
            //if (DateTime.Now.Hour == 16)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
