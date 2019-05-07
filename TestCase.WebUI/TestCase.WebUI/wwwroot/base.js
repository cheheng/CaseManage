function sub_operator(action, str,RouteSource) {

}

function All(ch) {
    var sda = ch.checked;
    var char = document.getElementsByName("checkbox-1");
    for (var i in char) {
        char[i].checked = sda;
    }
}

function toUpdate() {
    if (confirm("确认修改？")) {
        var form = document.getElementById("update");
        form.submit();
    }
}

function enterSearch() {
    var keycode = document.all ? event.keyCode : e.which;
    if (keycode == 13) {
        var form = document.getElementById("search");
        form.submit();
    };}