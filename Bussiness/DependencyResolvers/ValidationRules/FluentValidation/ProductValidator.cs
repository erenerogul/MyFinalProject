using Entitites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.DependencyResolvers.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p =>p.ProductName).NotEmpty();
            RuleFor(p=>p.ProductName).MinimumLength(2);
            RuleFor(p =>p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);//Birim fiyatı 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId ==1);//Kategori ıdsi 1se birim fiyatı 10 a eşit veya daha yüksek olmalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//A ile başlamalı
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }a
    }
}
