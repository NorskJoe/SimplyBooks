import { ListCriteria } from 'src/app/shared/models/list.model';

export class AuthorListCriteria extends ListCriteria {
	public authorName: string;
	public nationalityId: number;
}

export class AuthorList {
	public items: AuthorListItem[];
}

export class AuthorListItem {
	public name: string;
	public nationality: string;
	public averageRating: number;
	public booksRead: number;
}