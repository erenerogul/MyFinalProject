using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //Validasyon aspecte gelerek Sen bir method interceptionsın ezilmesi gereken metodlardan sen OnBefore metodunu ez diyoruz 
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            //Defensive coding 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//validatorType IValidatordan atanabilir mi ! koyarak atanabilir değilse doğrulama sınıf değil dedirtiyoruz
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;//Eğer öyleyse o zamaan burda validator type atayıp onu OnBefore komutun ezmede kullanuyoruz 
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
