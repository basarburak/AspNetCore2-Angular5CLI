
# AspNetCore2-Angular5CLI
ASP .Net Core 2.0 CLI ve Proxy ile Angular 5 CLI uygulaması geliştirmek.

Windows Ortamında Projenin Çalıştırılması <br>

<b> cd NetCoreAngular.Hosting </b> dizinine gidin ve <b> dotnet run </b> komutunu çalıştırın.  <br>

Bu komutu çalıştırdığınızda Startup.cs dosyası içerisindeki

```ruby
app.UseMultiplateApplication(Configuration);
```
çalışacak ve Proxy, Api ve Angular CLI uygulaması ayrı portlarda ayağa kalkacaktır.

<b> NetCoreAngular.Client - Angular CLI </b>

Angular CLI uygulamasında proxy config dosyası bulunmaktadır. <br>

```ruby
{
  "/api": {
    "target": "http://localhost:5000",
    "secure": false
  }
}
```
Angular CLI uygulaması çalıştığında gelen /api istekleri proxy sunucusuna (NetCoreAngular.Hosting) yönlendirilir.

Hepsi bu kadar değil şimdi package.json dosyasına içerisine gidip aşağıdaki alanı değiştirmemiz gerekiyor.<br>
Bunu yapmamızın sebebi <b> npm start </b> komutu girildiğinde proxy devreye girecek ve Angular uygulamasından gelen api istekleri localhost:5000 
portuna gidecek.

```ruby
"start": "ng serve --proxy-config proxy.conf.json"
```
<br>
<b> Peki Neden Proxy Config Dosyasını Yazdık ? </b>  <br>

Burdaki seneryo şu şekilde ben Angular CLI uygulamasını derledikten sonra derlenen dosyaları NetCoreAngular.Hosting dizini içerisindeki <b> wwwroot </b>
dizini içerisine bırakmam gerekiyor. Böylelikle proxy uygulaması ayağa kalktığında angular uygulamasıda çalışssın ve gelen api istekleri proxy sunucusuna yönlendirilsin.

<br>
Şimdi bununla ilgili ayarları yapalım. <br>

angular-cli.json dosyasını açalım ve Angular Prod ortamına çıktığında derlenen dosyaları bir üst klasördeki NetCoreAngular.Hosting içerisindeki wwwroot dizine atmasını sağlayalım.

```ruby
  "root": "src",
      "outDir": "../NetCoreAngular.Hosting/wwwroot",
      "assets": [
        "assets",
        "favicon.ico"
      ],
```
 <b> Angular CLI uygulamasının derlenmesi. </b> <br>
 
 <b> ng build --prod </b> komutunu çalıştırın. Angular dosyaları compile edildiğinde  NetCoreAngular.Hosting içerisindeki wwwroot dizine
 dosyaların yazıldığını göreceksiniz.
  
  <b> NetCoreAngular.Hosting </b> <br>
  
  .Net Core projesi çalıştığında /api haricindeki gelen istekleri wwwroot içerisindeki index.html dosyasına yönlendirmemiz gerekiyor.
   Aşağıdaki kod tam olarak bu işi yapıyor.
  
 ```ruby
     app.UseAngular();
```
<br>

NetCoreAngular.Hosting dizinine gidin ve <b> dotnet run </b> komutunu çalıştırın.

<b> Sonuç : </b> <br>

1.) Angular CLI ve Api uygulamalarınızı isterseniz farklı sunucularda yayınlayabilirsiniz. <br>
2.) Eğer isterseniz Api uygulamasını yayınladığınız sunucuda aynı anda angular uygulamasını da ayağa kaldırabilirsiniz.
<br>

Proxy için NetCoreStack Kütüphanesi kullanılmıştır. <br>
Aşağıdaki Nuget adresinden bu kütüphaneye erişebilirsiniz.
<br>
https://www.nuget.org/packages/NetCoreStack.Proxy/

  
