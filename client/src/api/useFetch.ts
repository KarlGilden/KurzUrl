import type { Result } from "./types";

const BASEURL = import.meta.env.VITE_BASE_API_URL;

interface FetchProps<B> {
	method: HTTPMethod;
	path: string;
	contentType?: string;
	body?: B;
}

type HTTPMethod = "GET" | "POST" | "PUT" | "PATCH" | "DELETE";

export const useFetch = () => {
	const fetch = async <T, B = {}>({
		method,
		path,
		contentType = "application/json",
		body,
	}: FetchProps<B>) => {
		switch (method) {
			case "GET":
				return await sendRequest<T>(BASEURL + path, method, contentType);
			case "POST":
				return await sendRequest<T, B>(
					BASEURL + path,
					method,
					contentType,
					body,
				);
		}
	};

	return fetch;
};

const sendRequest = async <T, B = {}>(
	path: string,
	method: HTTPMethod,
	contentType: string,
	body?: B,
) => {
	const res = await fetch(path, {
		method: method,
		body: JSON.stringify(body),
		headers: {
			"Content-Type": contentType,
		},
	});

	return (await res.json()) as Result<T>;
};
