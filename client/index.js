import * as util from './util.js'

//functions

const copyUrl = () => {
    // Get the text field
    var copyText = document.getElementById("short-url");
  
    // Copy the text inside the text field
    navigator.clipboard.writeText(copyText.textContent);
  };

const displayResult = (result) => {
    outputContainer.innerHTML = `
        <div class="output">
            <a href="${result}"><p>${result}</p></a>
            <button class="btn-copy"><i class="fa fa-clone"></i></button>
        </div>
    `
};

const displayMessage = (msg) => {
    outputContainer.innerHTML = `<p>${msg}</p>`
};




// globals
const baseURL = window.location.href;
const urlForm = document.getElementById("form-url");
const outputContainer = document.getElementById("container-output");

// submit listener
urlForm.addEventListener("submit", async (e)=>{
    e.preventDefault();

    displayMessage("Loading...");

    let urlInput = document.getElementById("input-url");

    const isUrlValid = util.validateUrl(urlInput.value);

    if(isUrlValid){
        const shortUrl = await util.getShortUrl(urlInput.value);
        if(shortUrl){
            displayResult(baseURL + shortUrl.slug);
        }else{
            displayMessage("Error getting short url");
        }
    }else{
        displayMessage("Invalid Url");
    }
});