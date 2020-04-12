export class AuthorListFilter {
	public name: string;
	public nationalityId: number;
}

export class NationalityListItem {
	public name: string;
	public nationalityId: number;
}

export class NationalitySelectList {
	public items: NationalityListItem[];
}
