$(document).ready(
    function () {
        var str = $.cookie("user");
        var login = eval("(" + str + ")");
        if (login.relation.Eid == 1) {
            jQuery(".admin").attr("style", "display:block");
        }
        
    }
)
