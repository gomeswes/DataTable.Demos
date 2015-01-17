var Global = [];

Global.doAjaxPost = function (url, data, successCallback) {
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        type: "POST",
        url: url,
        data: data,
        success: function (data) {
            if (typeof (successCallback) != 'undefined') {
                successCallback(data);
            }
            else {
                alert("Done!");
            }
        }
    });
}
