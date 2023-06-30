import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/domain/services/authentication.service';

@Component({
  selector: 'app-navDash',
  templateUrl: './navDash.component.html',
  styleUrls: ['./navDash.component.css']
})
export class NavDashComponent implements OnInit {


  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
  ) { }

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/']);
  }

}
