using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Getter readonlydir ama Constructor da SET edilebilir.
        //ctor tab tab constructor 
        //prop tab tab entity yaratmak için 
        //Setter koymuyoruz çünkü başka kodlayan birisi kendi kafasına göre nesne oluşturup ordan oynamasın diye 
        //constructor da yapıyoruzki bizim standartlarımıza göre yazssın kodu bozmasın diye 
        public Result(bool success, string message):this(success)//iki parametre gönderen birisi için bu constructor çalışır lakin 
        {                                                       //this ile önce bu constructurıda çalıştır daha sonra succeslede bununda
                                                                //çalışması lazımdı onu da çalıştır diyoruz
            Message = message;
        }
        //Method overloading Adam isterse mesaj vermesin demek 
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
