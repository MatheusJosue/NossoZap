import { User } from "../userModel";

export class SsoDTO {

  access_token: string = '';
  user: User = new User();

}
