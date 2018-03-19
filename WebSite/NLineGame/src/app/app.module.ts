import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';



import { AppComponent } from './app.component';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import {HeaderComponent} from './header/header.component';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
