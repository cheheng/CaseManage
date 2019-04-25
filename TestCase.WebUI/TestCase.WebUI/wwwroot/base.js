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
    var a = document.getElementsByClassName(".del");
    var mymessage = confirm("确认删除？");
    if (mymessage == true) {
        window.location.href = '/_Plan/Del?pid=' + id;
    }
}

function toshow(pid) {
    $.ajax({
        type: "post",
        url: "/_Plan/Detail",
        data: { "pid": pid, },
        dataType: 'JSON',
        success: function () {
        }
    });

}