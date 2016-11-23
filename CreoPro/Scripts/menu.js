$(document).ready(function () {
    //菜单滑动
    $('.accordion > a').click(function (e) {
        e.preventDefault();
        var $ul = $(this).siblings('ul');
        var $li = $(this).parent();
        if ($ul.is(':visible')) $li.removeClass('active');
        else $li.addClass('active');
        $ul.slideToggle();
    });

    //动态显示用户名
    $.ajax({
        type: "post",
        url: "/mainForm/getCurrentUser",
        data: {},
        cache: false,
        dataType: "json",
        success: function (data) {
            var jsonObj = $.parseJSON(data);
            console.log(jsonObj);
            $("#spanUser").text(jsonObj.userName);
        }
    });

});

//写入cookies
function setCookie(name, value) {
    var exp = new Date();
    exp.setTime(exp.getTime() + 30 * 60 * 1000); //30分钟
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
//读取cookies
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
//删除cookies
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}