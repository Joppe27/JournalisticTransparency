window.enableBeforeUnload = function () {
    window.onbeforeunload = function (e) {
        e.preventDefault();
        return '';
    };
};

window.scrollElementIntoView = async function (id) {
    await delay(300);
    const element = document.getElementById(id);
    element.scrollIntoView({behavior: "smooth", block: "nearest"});
};

function delay(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}