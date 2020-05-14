import { Advertising } from './advertising';
import { FilterModel } from './filterModel';
import { PageModel } from './pageModel';

export class PageInfo {

    public ads: Advertising[];

    public pageModel: PageModel;

    public filterModel: FilterModel;
}