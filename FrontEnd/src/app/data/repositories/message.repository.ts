import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MessageDTO } from "src/app/domain/models/Dtos/MessageDTO";
import { SendMessageDTO } from "src/app/domain/models/Dtos/sendMessageDTO";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class MessageRepository {

    constructor(private httpClient: HttpClient) { }

    CreateMessage(message: SendMessageDTO) {
        return this.httpClient.post(`${environment.apiUrl}` + '/message/create-message', message);
    }

    DeleteMessage(id: number) {
        return this.httpClient.delete(`${environment.apiUrl}` + '/message/delete-message?messageId=' + id);
    }

    GetMessage(id: number) {
        return this.httpClient.get(`${environment.apiUrl}` + '/message/get-message?messageId=' + id);
    }

    ListAllMessagesWithUser(username: string) {
        return this.httpClient.get(`${environment.apiUrl}` + '/message/list-messages-with-user?username=' + username);
    }

    ListMyChats() {
        return this.httpClient.get(`${environment.apiUrl}` + '/message/list-last-messages');
    }

}
