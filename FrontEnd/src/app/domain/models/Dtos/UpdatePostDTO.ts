export class UpdatePostDTO {
    id: number = 0;
    message: string = "";

    constructor(
        id: number,
        message: string,

    ) {
        this.id = id
        this.message = message
    }
  }
  