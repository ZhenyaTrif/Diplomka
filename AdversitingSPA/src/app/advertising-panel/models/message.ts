import { Lot } from './lot';
import { UserModelInfo } from './userModelInfo';

export class Message {

  public lots: Lot[];

  public creators: UserModelInfo[];
}
