import { Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { friendDTO } from 'src/app/domain/models/Dtos/FriendDTO';
import { RequestDTO } from 'src/app/domain/models/Dtos/Request';
import { User } from 'src/app/domain/models/userModel';
import { AuthenticationService } from 'src/app/domain/services/authentication.service';
import { FriendService } from 'src/app/domain/services/friend.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  formFriend: FormGroup;
  friends: friendDTO[] = [];
  currentUser : User;
  requests : RequestDTO[] = [];
  
  constructor(
    private elementRef: ElementRef,
    private formBuilder: FormBuilder,
    private friendService: FriendService,
    private router: Router,
    private authenticationService: AuthenticationService) 
    {
      this.formFriend = this.formBuilder.group({
        username: [null]
      });

      this.currentUser = this.authenticationService.currentUserValue;
    }

  openModalAddFriend() {
    const modal = this.elementRef.nativeElement.querySelector('.addFriend');
    modal.style.display = 'block';
  }

  addFriend() {
    this.friendService.AddFriend(this.formFriend.value)
    .subscribe( () => {
    window.location.reload();
    })
  }

  closeModalAddFriend() {
    const modal = this.elementRef.nativeElement.querySelector('.addFriend');
    modal.style.display = 'none';
  }

  openModalPedidosAmizade() {
    const modal = this.elementRef.nativeElement.querySelector('.pedidosAmizade');
    modal.style.display = 'block';
  }

  ListRequestsPendents() {
    this.friendService.ListRequestsPendents().subscribe((data : any) => {
      this.requests = data;
    })
  }

  AcceptRequest(requestId: number) {
    this.friendService.AcceptRequest(requestId).subscribe((data : any) => {
      this.friends = data;
      window.location.reload();
    })
  }

  RefuseRequest(requestId: number) {
    this.friendService.RefuseRequest(requestId).subscribe((data : any) => {
    window.location.reload();
    })
  }

  ListFriends(){
    this.friendService.ListFriends().subscribe((data : any) => {
      this.friends = data;
    })
  }

  closeModalPedidosAmizade() {
    const modal = this.elementRef.nativeElement.querySelector('.pedidosAmizade');
    modal.style.display = 'none';
  }

  openModalPerfil() {
    const modal = this.elementRef.nativeElement.querySelector('.perfil');
    modal.style.display = 'block';
  }

  closeModalPerfil() {
    const modal = this.elementRef.nativeElement.querySelector('.perfil');
    modal.style.display = 'none';
  }

  openModalFriendList() {
    const modal = this.elementRef.nativeElement.querySelector('.friendList');
    modal.style.display = 'block';
  }

  closeModalFriendList() {
    const modal = this.elementRef.nativeElement.querySelector('.friendList');
    modal.style.display = 'none';
  }
  
  attPage(){
    window.location.reload();
  }

  goToChatWithFriend(username: string){
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(
      ['/messageExchange'],
      { queryParams: { username: username} }
    );
  }
  
  ngOnInit() {
    this.ListFriends();
    this.ListRequestsPendents();
  }

}
