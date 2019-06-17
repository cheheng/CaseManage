function toUpdate() {
    if (confirm("确认修改？")) {
        var form = document.getElementById("update");
        form.submit();
    }
}

function toCreate() {
    if (confirm("确认提交？")) {
        var form = document.getElementById("create");
        form.submit();
    }
}
function enterSearch() {
    var keycode = document.all ? event.keyCode : e.which;
    if (keycode == 13) {
        var form = document.getElementById("search");
        form.submit();
    };
}

function All(ch) {
    var sda = ch.checked;
    var char = document.getElementsByName("checkbox-1");
    for (var i in char) {
        char[i].checked = sda;
    }
}

function isEmail(strEmail) {
    //定义正则表达式的变量:邮箱正则
    var reg = /^\w+@+[a-z0-9]+(\.[a-z]+){1,3}$/;
    //文本框不为空，并且验证邮箱正则成功，给出正确提示
    if (strEmail != null && strEmail.search(reg) != -1) {
        document.getElementById("test_user").innerHTML = "<font color='green' size='4px'>√邮箱格式正确！</font>";
    } else {
        document.getElementById("test_user").innerHTML = "<font color='red' size='4px'>邮箱格式错误！</font>";
    }
}