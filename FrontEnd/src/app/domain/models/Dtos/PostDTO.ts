export class PostDTO {
    message: string = "";
    photo: string = "";

    constructor(
        message: string,
        photo: string,
    ) {
        this.message = message
        this.photo = photo
    }
  }
  