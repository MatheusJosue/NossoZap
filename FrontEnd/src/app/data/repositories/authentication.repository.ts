import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LoginDTO } from 'src/app/domain/models/Dtos/LoginDTO';
import { signupDTO } from 'src/app/domain/models/Dtos/SignupDTO';
import { User } from 'src/app/domain/models/userModel';
import { SsoDTO } from 'src/app/domain/models/Dtos/SsoDTO';

@Injectable({ providedIn: 'root' })
export class AuthenticationRepository {

  constructor(private http: HttpClient) { }

  login(user: LoginDTO): Observable<SsoDTO> {
    return this.http.post<any>(`${environment.apiUrl}/Authentication/sign-in`, user)
    .pipe(
      map((data) => {
      let ssoDTO: SsoDTO = data;
      return ssoDTO;
    }))
  }

  register(user: signupDTO) {
    return this.http.post<User>(`${environment.apiUrl}/Authentication/sign-up`, user)
  }

  getCurrentUser() {
    return this.http.get<User>(`${environment.apiUrl}/Authentication/get-current-user`)
  }
}
