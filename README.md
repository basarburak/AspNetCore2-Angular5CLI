# AspNetCore2-Angular5CLI
Asp .Net Core 2.0 ile Angular 5 CLI uygulaması geliştirmek.

Api uygulamasını çalıştırmak için <b> dotnet run </b> komutunu girin.

Angular Client uygulamasını çalıştırmak için <b> ng serve </b> komutunu girin.

<b> ng serve </b> komutu angular cli uygulamanızdaki yaptığınız değişlikleri anında izlemenize olanak tanır. <br>

Client katmanında bulunan Proxy.config dosyası içersinde api uygulamanızın adresini girdiğinizden emin olun.

Uygulama development ortamında ise  api ve client tarafını ayrı ayağa kaldırmanız gerekecek.

Proxy config dosyasındaki api adresi doğru olmalı aksi takdirde apiye erişemeyeceksiniz.

Uygulamanın Yayımlanması
<br><br>

Ugulamanın yayınlanma aşamasında ng-build prod komutunu çalıştırın.

Bu komutu çalıştırdığınızda Api katmanının altında wwwroot dizinine angular Cli uygulamanızın bundle config dosyaları bırakılacaktır.

Bundan sonraki adımda sadece .Net core projenizi sunucunuza pubish edebilirsiniz.

Mac İşletim Sisteminde Chrome Start Etmek İçin  =>  /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --app="http://www.google.de"