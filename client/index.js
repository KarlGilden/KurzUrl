//functions
const getShortUrl = async (url) => {
    const shortUrl = await fetch(`${baseAPI}/Url/Url/CreateUrl?OriginalUrl=${url}`, {
        method: "POST"
    });

    return await shortUrl.json();
}

const showShortUrl = (url) => {
    const shortUrl = baseURL + url.slug;
    const outputContainer = document.getElementById("container-output")

    const outputContent = `
    <div class="output">
        <a id="short-url" href="${shortUrl}">${shortUrl}</a>
        <button class="btn-copy" onclick="copyUrl()">
            <i class="fa fa-clone" aria-hidden="true"></i>
        </button>
    </div>`

    outputContainer.innerHTML = outputContent;
}

const copyUrl = () => {
  // Get the text field
  var copyText = document.getElementById("short-url");

  // Copy the text inside the text field
  navigator.clipboard.writeText(copyText.textContent);
};

const onInitLoad = () => {
    const slugs = baseURL.split("/");

    if(slugs.length > 1){
        redirect(slugs[1]);
    }
};

const redirect = async (slug) => {
    const originalUrl = await getOriginalUrl(slug);

    window.location.replace(originalUrl);
}

const getOriginalUrl = async () =>{
    const originalUrl = await fetch(`${baseAPI}/Url/Url/GetOriginalUrl?Slug=${slug}`, {
        method: "GET"
    });

    return await originalUrl.json();
};

// globals
const baseAPI = "https://localhost:7114";
const baseURL = window.location.href;
const urlForm = document.getElementById("form-url");

// submit listener
urlForm.addEventListener("submit", async (e)=>{
    e.preventDefault();

    let urlInput = document.getElementById("input-url");

    const shortUrl = await getShortUrl(urlInput.value);

    showShortUrl(shortUrl);
});

onInitLoad();