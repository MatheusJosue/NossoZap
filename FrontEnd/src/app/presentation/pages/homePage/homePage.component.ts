import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../domain/services/authentication.service';
import { User } from 'src/app/domain/models/userModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homePage',
  templateUrl: './homePage.component.html',
  styleUrls: ['./homePage.component.css']
})
export class HomePageComponent implements OnInit {
  currentUser: User;

  constructor(private authenticationService: AuthenticationService, private router: Router) {
    this.currentUser = authenticationService.currentUserValue;
    if(this.currentUser != null){
      this.router.navigate(["dashboard"]);
    }
  }

  ngOnInit() {
  }

}
