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

function delay (ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

window.visibility = {
    handler: null,
    dotnetComponent: null,
    
    addVisibilityRestoredListener: function (dotNet) {
        this.dotnetComponent = dotNet;
        
        this.handler = () => {
            if (document.visibilityState === "visible") {
                this.dotnetComponent.invokeMethodAsync("AddClosedInteraction");
            }
        };
        
        document.addEventListener("visibilitychange", this.handler);
    },

    removeVisibilityRestoredListener: function ()
    {
        if (this.handler) {
            document.removeEventListener("visibilitychange", this.handler);
            this.handler = null;
        }
        
        this.dotnetComponent = null;
    }
}