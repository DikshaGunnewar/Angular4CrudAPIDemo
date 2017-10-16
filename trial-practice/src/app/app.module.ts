import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { DataService } from "./services/data.service";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { DataInterceptor } from "./services/dataInterceptor";
import { ModalModule } from "ngx-bootstrap/modal";
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ModalModule.forRoot()
  ],
  providers: [
     DataService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: DataInterceptor,
    multi: true,
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
