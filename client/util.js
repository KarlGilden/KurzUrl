const baseAPI = "https://localhost:7114";

export const getShortUrl = async (url) => {
    const shortUrl = await fetch(`${baseAPI}/Url/Url/CreateUrl?OriginalUrl=${url}`, {
        method: "POST"
    });

    return await shortUrl.json();
}

export const getOriginalUrl = async (slug) =>{
    const originalUrl = await fetch(`${baseAPI}/Url/Url/GetOriginalUrl?Slug=${slug}`, {
        method: "GET",
        headers:{
            "Content-Type": "text/plain"
        }
    });

    return await originalUrl.text();
};
