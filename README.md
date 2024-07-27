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
