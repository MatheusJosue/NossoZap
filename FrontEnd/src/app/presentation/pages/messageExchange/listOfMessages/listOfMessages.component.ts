import { Component, ElementRef, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ChatDTO } from 'src/app/domain/models/Dtos/ChatDTO';
import { friendDTO } from 'src/app/domain/models/Dtos/FriendDTO';
import { Message } from 'src/app/domain/models/messageModel';
import { User } from 'src/app/domain/models/userModel';
import { AuthenticationService } from 'src/app/domain/services/authentication.service';
import { FriendService } from 'src/app/domain/services/friend.service';
import { MessageService } from 'src/app/domain/services/message.service';
@Component({
  selector: 'app-listOfMessages',
  templateUrl: './listOfMessages.component.html',
  styleUrls: ['./listOfMessages.component.css']
})
export class ListOfMessagesComponent implements OnInit {

  chats: ChatDTO[] = [];
  friends: friendDTO[] = [];
  messages: Message[] = [];
  currentFriendUsername: string = "";
  currentUser : User;
  dateOfMessage: Date;
  
  constructor(
    private elementRef: ElementRef,
    private friendService: FriendService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
  ) {
    this.route.queryParams.subscribe(params =>{
      this.currentFriendUsername = params['username'];
    })

    this.currentUser = this.authenticationService.currentUserValue;

      this.dateOfMessage = new Date();
   }

  
  ngOnInit() {
    this.ListMyChats();
    this.ListFriends();
  }

  ListMyChats() {
    return this.messageService.ListMyChats().subscribe((data : any) => {
      this.chats = data;
      }
  )}
  
  ListFriends(){
    this.friendService.ListFriends().subscribe((data : any) => {
      this.friends = data;
    })
  }

  openModalFriendList() {
    const modal = this.elementRef.nativeElement.querySelector('.friendList');
    modal.style.display = 'block';
  }

  closeModalFriendList() {
    const modal = this.elementRef.nativeElement.querySelector('.friendList');
    modal.style.display = 'none';
  }

  openChat(username: string){
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(
      ['/messageExchange'],
      { queryParams: { username: username} }
    );
  }

  goToChatWithFriend(username: string){
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(
      ['/messageExchange'],
      { queryParams: { username: username} }
    );
  }
}
