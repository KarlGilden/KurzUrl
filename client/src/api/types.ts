export interface Url {
	id: number;
	slug: string;
	destinationUrl: string;
	clicks: number;
	dateTime: Date;
}

export interface UrlInput {
	destinationUrl: string;
}

export interface Result<T> {
	status: number;
	errorMessage: string;
	isSuccess: boolean;
	data?: T;
}
