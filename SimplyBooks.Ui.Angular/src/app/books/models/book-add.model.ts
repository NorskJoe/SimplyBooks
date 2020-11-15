export class Book {
	title: string;
	rating: number;
	dateRead: Date;
	datePublished: Date;
	author: Author;
	genre: Genre;
}

export class Author {
	name: string;
	authorId: number;
	nationality: Nationality;
}

export class Genre {
	name: string;
	genreId: number;
}

export class Nationality {
	name: string;
	nationalityId: number;
}
