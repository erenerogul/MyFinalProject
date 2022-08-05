using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Constants
{
    public class Messages
    {
        //publicler pascal cae ile yazılır ilk harflaride büyük
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Kategori başına düşen ürün sayısı aşıldı";
        public static string ProductNameAlreadyExists= "Bu isimde zaten başka bir ürün var.";
        public static string CategoryLimitExceded = "Kategori sınırı aşıldı daha fazla ürün eklenemez.";
    }
}
