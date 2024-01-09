import * as util from './util.js'

const redirect = async (slug) => {
    const url = await util.getOriginalUrl(slug);
    const originalUrl = url.originalUrl

    if(originalUrl){
        window.location.replace(originalUrl);
    }
};

const init = () => {
    const slug = window.location.pathname.split("/")[1];
    redirect(slug);
};

init();