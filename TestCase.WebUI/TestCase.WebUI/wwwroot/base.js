function sub_operator(action, str,RouteSource) {

}

function All(ch) {
    var sda = ch.checked;
    var char = document.getElementsByName("checkbox-1");
    for (var i in char) {
        char[i].checked = sda;
    }
}

function confDel(id)
{
    var mymessage = confirm("确认删除？");
    if (mymessage == true) {
        window.location.href = '/_Plan/Del?pid=' + id;
    }
}
function toUpdate() {
    var mymessage = confirm("确认修改？");
    if (mymessage == true) {
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