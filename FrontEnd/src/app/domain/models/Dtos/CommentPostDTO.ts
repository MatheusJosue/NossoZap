export class CommentPostDTO {
    postId: number = 0;
    message: string = "";
   
    constructor(
        postId: number,
        message: string,
    ) {
        this.postId = postId
        this.message = message
    }
  }
  