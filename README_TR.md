# BlogApp Projesi
Kendi Blog Yazýlarýmý kendi websitemde(fatihemrekilinc.xyz) yayýnlamak için geliþtirdiðim bir proje.
## Projenin Amacý
Blog yazýlarýmý kendi websitemde yayýnlamak ve bu sayede hem yazýlarýmý paylaþmak hem de web geliþtirme becerilerimi geliþtirmek.
## Bu Committe Yapýlan iþlemler
- Custom Exception Altyapýsýnýn kurulmasý ve Business Klasörü içindeki Sýnýflara uygulanmasý
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
### Gün 4 (12.07.2025)
- AutoMapper kütüphanesi yüklendi,profil sýnýfý yazýldý ve baðlantý iþlemleri için gerekli kod bloðu extension metot olarak yazýldý.
- Ýþ mantýðý kodlarý için Business Klasörü ve Business te gerekli klasör altyapýsý oluþturuldu.
- IAuthUserService ve IAuthRoleService interface leri kodlandý.
- AuthUserService sýnýfý ,IAuthUserService interface inden kalýtýlarak içeriði kodlandý ve gerekli sýnýflar kodlandý.
- AuthRoleService sýnýfý ,IAuthRoleService interface inden kalýtýlarak içeriði kodlandý ve gerekli sýnýflar kodlandý.
### Gün 5 (13.07.2025)
- Custom Exception Altyapýsý kuruldu ve Business Klasörü içindeki Sýnýflara uygulandý
### Yapýlacaklar
- Custom Exception Altyapýsý kurulmasý
- Custom Nullchecker yazýlmasý
- SafeDelete mekanizmasýnýn kurulmasý