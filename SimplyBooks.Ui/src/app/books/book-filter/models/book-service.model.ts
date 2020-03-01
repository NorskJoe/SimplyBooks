export class BookListCriteria {
	public bookTitle: string;
	public authorId: number;
	public genreId: number;
	public yearRead: Date;
	public yearPublished: Date;
}

export class BookList {
	public items: BookListItem[];
}

export class BookListItem {
	public title: string;
	public author: string;
	public nationality: string;
	public genre: string;
	public rating: number;
	public dateRead: Date;
	public yearPublished: Date;
}