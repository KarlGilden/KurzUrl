import * as util from './util.js'

//functions
const displayShortUrl = (url) => {

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

const displayError = () => {
    const outputContainer = document.getElementById("container-output")
    outputContainer.textContent = "Invalid Url"
}


const copyUrl = () => {
  // Get the text field
  var copyText = document.getElementById("short-url");

  // Copy the text inside the text field
  navigator.clipboard.writeText(copyText.textContent);
};


// globals
const baseURL = window.location.href;
const urlForm = document.getElementById("form-url");


// submit listener
urlForm.addEventListener("submit", async (e)=>{
    e.preventDefault();

    let urlInput = document.getElementById("input-url");

    const isUrlValid = util.validateUrl(urlInput.value);

    if(isUrlValid){
        const shortUrl = await util.getShortUrl(urlInput.value);
        displayShortUrl(shortUrl);
    }else{
        displayError();
    }

});