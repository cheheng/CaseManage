 <div class="mask" id="mask" style="width: 100%;height: 100%; position: fixed;top: 0; left: 0;display: none;background-color: rgba(0, 0, 0, 0.6);">
        <div class="add" id="add" style=" width: 500px; height: 350px; background-color: #fff;  margin: 150px auto;">
         
  </div>
 </div>

var a = document.getElementsByTagName("a")[0];
var mask = document.getElementById("mask");
function ab(event) {
    alert("zhix");
    mask.style.display = "block";
    //阻止冒泡
    event = event || window.event;
    if (event || event.stopPropagation()) {
        event.stopPropagation();
    } else {
        event.cancelBubble = true;
    }
}

document.onclick = function (event) {
    event = event || window.event;
    //兼容获取触动事件时被传递过来的对象
    var aaa = event.target ? event.target : event.srcElement;
    if (aaa.id == "mask"||aaa.id=="cancel") {
        mask.style.display = "none";
    }
}