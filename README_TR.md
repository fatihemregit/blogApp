# BlogApp Projesi
Kendi Blog Yaz�lar�m� kendi websitemde(fatihemrekilinc.xyz) yay�nlamak i�in geli�tirdi�im bir proje.
## Projenin Amac�
Blog yaz�lar�m� kendi websitemde yay�nlamak ve bu sayede hem yaz�lar�m� payla�mak hem de web geli�tirme becerilerimi geli�tirmek.
## Bu Committe Yap�lan i�lemler
- Rol Bazl� Yetkilendirme sistemi kodlanmas�
- Dinamik layout dosyas� yap�lmas�
- Rol bazl� yetkilendirme kullan�larak Yazar Kayd� Sayfas�n�n Sadece bir sefer �al��acak �ekilde ayarlanmas�
- Safe Delete Mekanizmas�n�n Kurulmas�.
- Custom NullChecker yaz�lmas� ve null check kodlar�nda kullan�lmas�
## Proje G�nl���
### G�n 1 (26.06.2025)
- Proje olu�turuldu.
- Projedeki Gereksiz Dosyalar Silindi.(Controllers/HomeController.cs,Models/ErrorViewModel,Views/Home,Views/Shared/_Layout.cshtml,Views/Shared/Error.cshtml) 
- Projenin Github ayarlar� yap�ld�.
- Proje Readme dosyalar� olu�turuldu.(README.md, README_TR.md)
### G�n 2 (27.06.2025)
- Layout dosyas� olu�turuldu (Views/Shared/_Layout.cshtml) ve i�eri�i kodland�.
- T�rk�e Readme dosyas� d�zenlendi (README_TR.md)
- Y�kl� olan Boostrap k�t�phanesi kald�r�ld� ve yeni bir versiyonu eklendi.
- Proje i�in gerekli olabilecek k�t�phaneler y�klendi(Microsoft.AspNetCore.Identity,Microsoft.AspNetCore.Identity.EntityFrameworkCore,Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.SqlServer,icrosoft.EntityFrameworkCore.Tools).
### G�n 3 (29.06.2025)
- Veritaban� ba�lant� metni yaz�ld�(secrets.json)
- Veritaban� i�in gerekli ApplicationDbContext s�n�f� olu�turuldu.
- Auth ��lemleri i�in gerekli olan AppUser ve AppRole s�n�flar� olu�turuldu.
- Auth ��lemleri i�in gerekli olan Extension Metotlar yaz�ld�.(Utils/Extensions/MainExtensions.cs).Ve Program.cs dosyas�nda kullan�ld�.
- Veritaban� i�in gerekli olan Migration i�lemleri yap�ld�.
### G�n 4 (12.07.2025)
- AutoMapper k�t�phanesi y�klendi,profil s�n�f� yaz�ld� ve ba�lant� i�lemleri i�in gerekli kod blo�u extension metot olarak yaz�ld�.
- �� mant��� kodlar� i�in Business Klas�r� ve Business te gerekli klas�r altyap�s� olu�turuldu.
- IAuthUserService ve IAuthRoleService interface leri kodland�.
- AuthUserService s�n�f� ,IAuthUserService interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
- AuthRoleService s�n�f� ,IAuthRoleService interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
### G�n 5 (13.07.2025)
- Custom Exception Altyap�s� kuruldu ve Business Klas�r� i�indeki S�n�flara uyguland�
- Blog,Writer S�n�flar� kodland� ve tablolar aras� ili�kiler kuruldu.
### G�n 6 (14.07.2025)
- IBlogRepository ve IWriterRepository interface leri kodland�
- BlogRepository s�n�f�,IBlogRepository interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
- WriterRepository s�n�f�,IWriterRepository interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
### G�n 7 (15.07.2025)
- IBlogService ve IWriterService interface leri kodland�
- BlogService s�n�f�,IBlogService interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
- WriterService s�n�f�,IWriterService interface inden kal�t�larak i�eri�i kodland� ve gerekli s�n�flar kodland�.
### G�n 8 (16.07.2025)
- AuthUserController ve AuthRoleController s�n�flar� kodland� ve di�er s�n�flarda gerekli d�zenlemeler yap�ld�.
- AuthUserController ve AuthRoleController s�n�flar� i�in gerekli yard�mc� s�n�flar kodland�.
### G�n 9 (17.07.2025)
- WriterController s�n�f� kodland� ve di�er s�n�flarda gerekli d�zenlemeler yap�ld�.
- WriterController i�in gerekli yard�mc� s�n�flar kodland�.
- Blog yaz�lar�n� yazmak i�in gerekli edit�r eklentisi y�klendi(tinymce)
- BlogController s�n�f� kodland� ve di�er s�n�flarda gerekli d�zenlemeler yap�ld�.
- BlogController i�in gerekli yard�mc� s�n�flar kodland�.
### G�n 10 (18.07.2025)
- Rol Bazl� Yetkilendirme sistemi kodland�
- Dinamik layout dosyas� yap�ld�(kullan�c�, �st barda sadece yetkisi olan sayfalar� g�r�yor)
- Rol bazl� yetkilendirme kullan�larak Yazar Kayd� Sayfas�n�n Sadece bir sefer �al��acak �ekilde ayarland�
- Safe Delete Mekanizmas� Kuruldu.
- Custom NullChecker yaz�ld� ve null check kodlar�nda kullan�ld�