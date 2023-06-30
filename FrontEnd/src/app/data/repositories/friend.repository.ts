import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AddFriendDTO } from "src/app/domain/models/Dtos/AddFriendDTO";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class FriendRepository {

  constructor(private httpClient: HttpClient) { }

  AddFriend(addFriendDTO: AddFriendDTO) {
  return this.httpClient.post(`${environment.apiUrl}` + '/Request/send-friend-request', addFriendDTO) ;
  }

  RemoveFriend(formMsg: any) {
  return this.httpClient.delete(`${environment.apiUrl}` + '/Friend/remove-friend', formMsg);
  }

  ListFriends() {
  return this.httpClient.get(`${environment.apiUrl}` + '/Friend/list-friends');
  }

  ListRequestsPendents() {
  return this.httpClient.get(`${environment.apiUrl}` + '/Request/list-pendent-requests')
  }

  AcceptRequest(requestId: number) {
  return this.httpClient.post(`${environment.apiUrl}` + '/Request/accept-request','"' + requestId + '"' , { headers: new HttpHeaders({
      'Content-Type': 'application/json',
      })
    });
  }

  RefuseRequest(requestId: number) {
  return this.httpClient.delete(`${environment.apiUrl}` + '/Request/refuse-request', {body: '"' + requestId + '"', headers: new HttpHeaders({
      'Content-Type': 'application/json',
      })
    });
  }
}
