import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/security/auth.guard';
import { DashBoardComponent } from './presentation/pages/dashBoard/dashBoard.component';
import { LoginComponent } from './presentation/pages/homePage/login/login.component';
import { RegisterComponent } from './presentation/pages/homePage/register/register.component';
import { MessageExchangeComponent } from './presentation/pages/messageExchange/messageExchange.component';
import { HomePageComponent } from './presentation/pages/homePage/homePage.component';
import { initialPageComponent } from './presentation/pages/homePage/initialPage/initialPage.component';



const routes: Routes = [
  { path: '', component: HomePageComponent,
    children: [
      {path: '', component: initialPageComponent},
      {path: 'home', component: initialPageComponent},
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
    ]},
    
  { path: 'dashboard', component: DashBoardComponent , canActivate: [AuthGuard], 
    children: [{path: '', component: DashBoardComponent}
  ]},

  { path: 'messageExchange', component: MessageExchangeComponent, canActivate: [AuthGuard],
  children: [{path: '', component: MessageExchangeComponent}
  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
