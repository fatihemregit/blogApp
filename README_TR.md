# BlogApp Projesi
Kendi Blog Yazýlarýmý kendi websitemde(fatihemrekilinc.xyz) yayýnlamak için geliþtirdiðim bir proje.
## Projenin Amacý
Blog yazýlarýmý kendi websitemde yayýnlamak ve bu sayede hem yazýlarýmý paylaþmak hem de web geliþtirme becerilerimi geliþtirmek.
## Bu Committe Yapýlan iþlemler
- Veritabaný baðlantý metninin yazýlmasý
- Veritabaný için gerekli ApplicationDbContext sýnýfýnýn oluþturulmasý.
- Auth Ýþlemleri için gerekli olan AppUser ve AppRole sýnýflarýnýn oluþturulmasý.
- Auth Ýþlemleri için gerekli olan Extension Metotlarýn yazýlmasý.Ve Program.cs dosyasýnda kullanýlmasý
- Veritabaný için gerekli olan Migration iþlemlerinin yapýlmasý
## Proje Günlüðü
### Gün 1 (26.06.2025)
- Proje oluþturuldu.
- Projedeki Gereksiz Dosyalar Silindi.(Controllers/HomeController.cs,Models/ErrorViewModel,Views/Home,Views/Shared/_Layout.cshtml,Views/Shared/Error.cshtml) 
- Projenin Github ayarlarý yapýldý.
- Proje Readme dosyalarý oluþturuldu.(README.md, README_TR.md)
### Gün 2 (27.06.2025)
- Layout dosyasý oluþturuldu (Views/Shared/_Layout.cshtml) ve içeriði kodlandý.
- Türkçe Readme dosyasý düzenlendi (README_TR.md)
- Yüklü olan Boostrap kütüphanesi kaldýrýldý ve yeni bir versiyonu eklendi.
- Proje için gerekli olabilecek kütüphaneler yüklendi(Microsoft.AspNetCore.Identity,Microsoft.AspNetCore.Identity.EntityFrameworkCore,Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.SqlServer,icrosoft.EntityFrameworkCore.Tools).
### Gün 3 (29.06.2025)
- Veritabaný baðlantý metni yazýldý(secrets.json)
- Veritabaný için gerekli ApplicationDbContext sýnýfý oluþturuldu.
- Auth Ýþlemleri için gerekli olan AppUser ve AppRole sýnýflarý oluþturuldu.
- Auth Ýþlemleri için gerekli olan Extension Metotlar yazýldý.(Utils/Extensions/MainExtensions.cs).Ve Program.cs dosyasýnda kullanýldý.
- Veritabaný için gerekli olan Migration iþlemleri yapýldý.