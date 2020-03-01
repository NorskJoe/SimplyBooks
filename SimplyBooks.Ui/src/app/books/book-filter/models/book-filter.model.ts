export class GenreSelectList {
	public items: GenreListItem[];
}

export class GenreListItem {
	public name: string;
	public genreId: number;
}

export class AuthorSelectList {
	public items: AuthorListItem[];
}

export class AuthorListItem {
	public name: string;
	public authorId: number;
}

export class BookListFilter {
	public title: string;
	public authorId: number;
	public genreId: number;
	public yearRead: Date;
	public yearPublished: Date;
}
