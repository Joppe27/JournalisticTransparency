window.enableBeforeUnload = function () {
    window.onbeforeunload = function (e) {
        e.preventDefault();
        return '';
    };
};