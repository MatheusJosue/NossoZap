import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { friendDTO } from 'src/app/domain/models/Dtos/FriendDTO';
import { Message } from 'src/app/domain/models/messageModel';
import { User } from 'src/app/domain/models/userModel';
import { AuthenticationService } from 'src/app/domain/services/authentication.service';
import { MessageService } from 'src/app/domain/services/message.service';

@Component({
  selector: 'app-chatWithUser',
  templateUrl: './chatWithUser.component.html',
  styleUrls: ['./chatWithUser.component.css']
})
export class ChatWithUserComponent implements OnInit {

  friends: friendDTO[] = [];
  readMessageId: string = "";
  currentUser: User;
  users: User[] = [];
  currentFriendId: string = "";
  currentFriendUsername: string = '';
  formMsg: FormGroup;
  messagesBetweenUsers: boolean = false;

  messages: Message[] = [];
  dateOfMessage: Date;
  
  constructor(
    private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private formBuilder : FormBuilder,
  )
  {
    this.currentUser = authenticationService.currentUserValue
    this.route.queryParams.subscribe(params =>{
      this.currentFriendUsername = params['username'];
    })
    
    this.formMsg = this.formBuilder.group({
      toUsername: [this.currentFriendUsername],
      text: [null]
    });

    this.dateOfMessage = new Date();
  }

  ngOnInit(): void {
    if(this.currentFriendUsername == undefined)
        return
    this.ListAllMessages(this.currentFriendUsername);

  }

  ListAllMessages(username: string){
    this.messageService.ListAllMessagesWithUser(username).subscribe((data : any) => {
      this.messages = data;
    })
  }

  onSubmit() {
    var message = this.formMsg.value; 

    this.messageService.SendMessage(message).subscribe(data => {
      window.location.reload();
    })
  }

}
