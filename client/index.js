import * as util from './util.js'

//functions

const copyUrl = () => {
    // Get the text field
    const copyText = document.getElementById("short-url");

    // Copy the text inside the text field
    navigator.clipboard.writeText(copyText.innerText);

    // display tool tip
    displayCopied();
};

const displayCopied = () => {
    outputContainer.appendChild(tooltip);

    setTimeout(()=>{
        outputContainer.removeChild(tooltip);
    }, 3000);
};

const displayOutput = (resultContainer) => {
    outputContainer.replaceChildren(resultContainer);
};

const buildMessage = (result) => {
    const textNode = document.createElement("p");
    textNode.innerText = result;
    return textNode;
};

const buildResult = (result) => {
    const resultDiv = document.createElement("div");
    const link = document.createElement("a");
    const copyIcon = document.createElement("i");
    const copyBtn = document.createElement("button");

    resultDiv.className = "output";

    link.href = result;
    link.id = "short-url"
    link.innerText = result;

    copyIcon.className = "fa fa-clone"

    copyBtn.addEventListener("click", copyUrl);
    copyBtn.className = "btn-copy";
    copyBtn.id = "btn-copy";

    copyBtn.appendChild(copyIcon);
    resultDiv.appendChild(link);
    resultDiv.appendChild(copyBtn);

    return resultDiv;
}


// globals
const baseURL = window.location.href;
const urlForm = document.getElementById("form-url");
const outputContainer = document.getElementById("container-output");

const tooltip = document.createElement("div");
tooltip.id = "tooltip";
tooltip.innerText = "Copied!";
tooltip.className = "tooltip";

// submit listener
urlForm.addEventListener("submit", async (e)=>{
    e.preventDefault();

    displayOutput(buildMessage("Loading..."));

    let urlInput = document.getElementById("input-url");
    let output;

    const isUrlValid = util.validateUrl(urlInput.value);

    if(isUrlValid){
        const shortUrl = await util.getShortUrl(urlInput.value);
        if(shortUrl){
            output = buildResult(baseURL + shortUrl.slug);
        }else{
            output = buildMessage("Error getting short url");
        }
    }else{
        output = buildMessage("Invalid Url");
    }

    displayOutput(output);
});