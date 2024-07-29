<strong>Not: test.cs classları kaldıralacak.</strong>

<h3>PROJE TEKNİK ÖZELLİKLER</h3>
<ul>
  <li>Onion arch. </li>
  <li>Mediatör tasarım deseni</li>
  <li>Fluentvalidation</li>
  <li>Automapper</li>
  <li>Authentication ve authorize Jwt ile olucak</li>
  <li>Mssql veritabanı</li>
  <li>SignalR kullanılacak</li>
  <li>Google cloud storage kullanıcı görselleri ve ürün görselleri</li>
  <li>Google chart</li>
  <li>PagedList</li>
  <li>İTextSharp</li>
  <li>Mailkit</li>
  <li>EPPLUS</li>
  <li>Tüm işlemler web apiden consume edilecek</li>
  <li>MVC</li>
  <li>Apiler jwt ile güvenliğe alınacak</li>
  <li>ErrorPage ve AccessDenied Page</li>
  <li>MVC</li>
  <li>(Daha çoğaltılabilir)</li>
</ul>

<h3>Paneller:</h3>
<p>UI Panel</p>
<p>User Panel</p>
<p>Admin Panel (Moderatör Rolü de erişim sağlayabilecek ama her menüye erişimi olmayacak.)</p>

<h3>Notlar</h3>
<p>Requestlerde headers'a token eklenerek request yapılacak</p>
<p>Oturumu açık olan kullanıcının bilgileri alınacak user panelinde gösterilecek (IHttpContextAccessor)</p>
<p>Api isimleri request classlarının içerisinden "ApiRoute" adlı property üzerinden gelicek</p>
<p>Sql bağlantısı appsetting.json içerisinden alınacak</p>


# DbConnect - Tekrar yazılmasına gerek yoktur, Pull edildiğinde yazılmış şekilde gelecek. Bilgilendirme amaçlıdır
# 1.Adım: Presentation/Api içerisinde appsetting.json dosyasına connectionString bilgilerinin eklenmesi
![1](https://github.com/user-attachments/assets/2f49442a-4521-40d3-a801-af6d0f7e19e5)

# 2.Adım: Infrastructer/Persistance/Context dosyasına, DbContext yazılması
![2](https://github.com/user-attachments/assets/99235d7d-864c-4534-8151-b41ff0bd120a)

# 3.Adım:  Infrastructer/Persistance/.csproj içerisine 4 adet paketin yüklenmes. EntityFramework, Design, Tools, SqlServer. Ve Domain'den entityleri alacağımız için, Entity katmanı olan Domain katmanının referans verilmesi
![3](https://github.com/user-attachments/assets/3ef7c5e3-5b6c-4984-ac7d-4a0c167ef38d)

# 4.Adım: Presentation/Api.csproj içerisine Persistance.csproj katmanının referans verilmesi ve Design paketinin yüklenmesi
![4](https://github.com/user-attachments/assets/721ace67-2fc7-4280-a0d8-31349c48f62c)

# 5.Adım: Presentation/Api içerisinde bulunan program.cs dosyası içerisinde Context'in Configurasyon işlemi
![5](https://github.com/user-attachments/assets/6c5cd0ea-bbcc-48fd-866b-8cd58c94f685)

# 6.Adım: Persistance dosyasından konumlanıp, Startup projesi olarak Presentation/Api'nin seçilmesi ve migrate eklenmesi ve yine aynı şekilde migration update edilmesi.
