import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FriendRepository } from 'src/app/data/repositories/friend.repository';
import { environment } from 'src/environments/environment';
import { AddFriendDTO } from '../models/Dtos/AddFriendDTO';

@Injectable({
  providedIn: 'root'
})
export class FriendService {



  constructor(
    private httpClient: HttpClient,
    private friendRepository: FriendRepository
  ) { }


  AddFriend(addFriendDTO: AddFriendDTO) {
    return this.friendRepository.AddFriend(addFriendDTO);
  }

  RemoveFriend(formMsg: any) {
    return this.friendRepository.RemoveFriend(formMsg);
  }

  ListFriends() {
    return this.friendRepository.ListFriends();
  }

  ListRequestsPendents() {
    return this.friendRepository.ListRequestsPendents();
  }

  AcceptRequest(requestId: number) {
    return this.friendRepository.AcceptRequest(requestId)
}

  RefuseRequest(requestId: number) {
    return this.friendRepository.RefuseRequest(requestId)
  }

}
