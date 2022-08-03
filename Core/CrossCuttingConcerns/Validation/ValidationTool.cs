using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    //Static bir sınıfın metodlarınında static olması gerekir c# da geçerli javada değil
    public static class ValidationTool
    {

        // tekrar 
        //Burada IValidator bir refereans tutucu ve ProductValidatoru tutuyor yani 
        //Doğrulanacak olan Kurallar , Doğrulanacak Class 
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
