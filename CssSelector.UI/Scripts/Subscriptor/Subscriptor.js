function Subscriptor() {
};

Subscriptor.prototype = {
    SubscriptAllByTagName: function (rootElement, callBackFunction) {
        var child = rootElement.firstElementChild;
        while (child) {
            child.onclick = function(e) {
                callBackFunction(e);
                return false;
            }
            setTimeout(this.SubscriptAllByTagName(child, callBackFunction), 500);
            child = child.nextElementSibling;
        }
    }
};

function DeleteAllListeners() {
    
}

document.addEventListener("DOMContentLoaded", function () {
    var obj = new Subscriptor();
    var selector = new Selector("../Home/SaveElement");
    obj.SubscriptAllByTagName(document.getElementsByTagName('body')[0], selector.elementWasSelect.bind(selector));
});