import * as util from './util.js'

const redirect = async (slug) => {
    const redirectUrl = await util.getOriginalUrl(slug);
    window.location.href = redirectUrl;
};

const init = () => {
    const slug = window.location.pathname.split("/")[1];
    redirect(slug);
};

init();