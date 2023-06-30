import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageRepository } from 'src/app/data/repositories/message.repository';
import { MessageDTO } from '../models/Dtos/MessageDTO';
import { SendMessageDTO } from '../models/Dtos/sendMessageDTO';


@Injectable({
  providedIn: 'root'
})
export class MessageService {

  apiUrl = 'https://localhost:5001/api'

  constructor(
    private httpClient: HttpClient,
    private messageRepository: MessageRepository
  ) { }

  
  GetMessage(id: number) {
    return this.messageRepository.GetMessage(id);
  }

  DeleteMessage(id: number) {
    return this.messageRepository.DeleteMessage(id);
  }

  ListAllMessagesWithUser(username: string) {
    return this.messageRepository.ListAllMessagesWithUser(username);
  }

  SendMessage(message: SendMessageDTO) {
    return this.messageRepository.CreateMessage(message);
  }

  ListMyChats() {
    return this.messageRepository.ListMyChats();
  }

}
