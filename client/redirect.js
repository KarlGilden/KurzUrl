import * as util from './util.js'

const redirect = async (slug) => {
    if(slug){
        const redirectUrl = await util.getOriginalUrl(slug);
        console.log("REDIRECT: ", redirectUrl)
        window.location.href = redirectUrl;
    }
};

const init = () => {
    const slug = window.location.pathname.split("/")[1];
    console.log("SLUG: ",slug)
    redirect(slug);
};

init();