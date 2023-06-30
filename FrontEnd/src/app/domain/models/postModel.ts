import { SafeResourceUrl } from "@angular/platform-browser";
import { CommentModel } from "./commentModel";
import { LikeModel } from "./likeModel";

export class Post {
  id: number = 0;
  message: string = "";
  date: string = "";
  comments: CommentModel[] = [];
  photo: string = "";
  applicationUserId: string = "";
  username: string = "";
  likes: LikeModel[] = [];
  url:  SafeResourceUrl = "";
}
