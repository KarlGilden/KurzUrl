const baseAPI = "https://kurzurlservice.azurewebsites.net"//"https://localhost:7114";

// returns url object
export const getShortUrl = async (url) => {
    try{
        const shortUrl = await fetch(`${baseAPI}/Url`, {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                originalUrl: url,
            })
        });
        return await shortUrl.json();
    }catch(error){
        console.log(error)
    }


}

// returns url object
export const getOriginalUrl = async (slug) => {
    const originalUrl = await fetch(`${baseAPI}/Url/${slug}`, {
        method: "GET"
    });

    return await originalUrl.json();
};

export const validateUrl = (url) => {
    try{
        new URL("/", url);
        return true;
    }catch{
        return false;
    }
}