import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
//Genel Componentler
import { AppComponent, ProductComponent, NavbarComponent, NotFoundComponent, HomeComponent } from '../app/components';
//Account Componentler
import { LoginComponent, RegisterComponent } from '../app/account/account-component';
//Genel Servisler
import { ApiService } from '../services/services';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    NavbarComponent,
    NotFoundComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'product', component: ProductComponent },
      { path: '404', component: NotFoundComponent },
      { path: '**', redirectTo: '/404' }
    ])
  ],
  providers: [
    {
      provide: "apiUrl", useValue: "/api" //api servis içerisindeki tüm http istekleri bu adrese yönlendirilir.
    },
    ApiService
  ],
  bootstrap: [AppComponent, NavbarComponent]
})
export class AppModule { }
