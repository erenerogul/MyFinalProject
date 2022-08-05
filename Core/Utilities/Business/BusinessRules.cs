using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Params yazdığımız zaman parametre olduğunu söyleyip direk birden fazla kuralı IResult şeklinde gönderebiliyoruz
        //Gönderdiğimiz bütün parametreleri array haline getirip buraya atıyor 
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
