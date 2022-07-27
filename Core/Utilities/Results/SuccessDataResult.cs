using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //Succes resultta ve Error resultta benden istediği iki şey var data ve mesaj çüknü succces bool değeri belli ki ona göre zaten success veriyoruz
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(string message) : base(default,true, message)//Default data yani direk boş data yolluyorsun 
        {

        }
        public SuccessDataResult() : base(default, true)//Buda mesaj vermiyorum türümde bu demek 
        {

        }
    }
}
