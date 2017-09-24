function Selector(url) {
    this.url = url;
}

Selector.prototype= {
    elementWasSelect: function(evnt) {
        evnt.preventDefault();
        evnt.stopPropagation();
        var data = {
            TagName: evnt.currentTarget.nodeName,
            ElementId: evnt.currentTarget.attributes["id"].value
        }
        this.postToServer(data,this.url);
    },
    postToServer: function (data, url) {
        $.ajax({
            method: "POST",
            url: url,
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(data),
            dataType: "json",
            success: function(data, textStatus, jqXHR) {
                alert("Request success");
            }
        });
    }
}