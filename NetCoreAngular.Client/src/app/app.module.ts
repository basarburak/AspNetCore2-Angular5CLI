import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent, ProductComponent, NavbarComponent } from '../app/components';
import { ApiService } from '../services/api/api-service';


@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    {
      provide: "apiUrl", useValue: "/api/",
    },
    ApiService
  ],
  bootstrap: [AppComponent, NavbarComponent]
})
export class AppModule { }
