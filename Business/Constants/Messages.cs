using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string DailyPriceInvalid = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz.";
        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandNameInvalid = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz.";
        public static string BrandDeleted = "Marka başarıyla silindi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string ColorAdded = "Renk tercihi başarıyla eklendi.";
        public static string ColorDeleted = "Renk tercihi başarıyla kaldırıldı.";
        public static string ColorUpdated = "Renk tercihi başarıyla güncellendi.";
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";
        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";
        public static string RentalAdded = "İşlem başarıyla eklendi.";
        public static string RentalDeleted = "İşlem başarıyla silindi.";
        public static string RentalUpdated = "İşlem başarıyla güncellendi.";
        public static string RentalInvalid = "İşlem başarısız.";
        public static string CarImageDeleted = "Araba resmi başarıyla silindi.";
        public static string CarImageLimitExceded="En fazla 5 resim yüklenebilir!";
        public static string CarImageAdded = "Araba resmi başarıyla eklendi.";
        public static string CarImageUpdated = "Araba resmi başarıyla güncellendi.";
        public static string GetErrorCarMessage="Araba bulunamadı.";
    }
}
