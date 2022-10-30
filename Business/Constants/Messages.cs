using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages // mesaji vermek icin new'lemeye gerek olmadığı icin static yaptım
    {
        //sabit mesajlarımızı burada vericeğiz.
        // ilerleyen dönemde gerek duyarsak ingilizce ve türkçe secenekleri ekliyeceğiz.
        // IMessage interface ->> TurkishMessage ve EngilishMessage eklenebilir.
        
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";

    }
}
