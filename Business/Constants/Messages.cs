﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductListed = "ürünler listelendi";
        public static string AddedCategory= "Kategori eklendi";
        public static string ProductCountOfCategoryExceed = "Bu kategoryde en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExist = "Aynı isimde ürün var zaten. Lütfen ürünü güncelleyin";
        public static string CategoryLimitExceeded = "Kategory Limiti aşıldığı icin ürün eklemenemedi.";
        public static string AuthorizationDenied= "Yetkisiz kullanıcı";
        public static string UserRegistered = "Kayıt Tamamlandı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Sifreniz hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
