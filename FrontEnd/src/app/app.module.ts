import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashBoardComponent } from './presentation/pages/dashBoard/dashBoard.component';
import { LoginComponent } from './presentation/pages/homePage/login/login.component';
import { RegisterComponent } from './presentation/pages/homePage/register/register.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { NavHomeComponent } from './presentation/shared/navHome/navHome.component';
import { NavDashComponent } from './presentation/shared/navDash/navDash.component';
import { SidebarComponent } from './presentation/pages/dashBoard/sidebar/sidebar.component';
import { DashContentComponent } from './presentation/pages/dashBoard/dashContent/dashContent.component';
import { DatePipe } from '@angular/common';
import { MessageExchangeComponent } from './presentation/pages/messageExchange/messageExchange.component';
import { HomePageComponent } from './presentation/pages/homePage/homePage.component';
import { initialPageComponent } from './presentation/pages/homePage/initialPage/initialPage.component';
import { ListOfMessagesComponent } from './presentation/pages/messageExchange/listOfMessages/listOfMessages.component';
import { ChatWithUserComponent } from './presentation/pages/messageExchange/chatWithUser/chatWithUser.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    initialPageComponent,
    LoginComponent,
    RegisterComponent,
    DashBoardComponent,
    ChatWithUserComponent,
    ListOfMessagesComponent,
    NavHomeComponent,
    NavDashComponent,
    SidebarComponent,
    DashContentComponent,
    MessageExchangeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
    
  ],
  providers: [
    DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
