$(document).ready(function () {
    //展开被点击的ul
    if (sessionStorage.getItem("ulId") != null) {
        var $ul = $('#' + sessionStorage.getItem("ulId"));
        $ul.slideToggle();
        sessionStorage.removeItem("ulId");
    }

    //菜单滑动
    $('.accordion > a').click(function (e) {
        e.preventDefault();
        var $ul = $(this).siblings('ul');
        var $li = $(this).parent(); //ul的父li
        if ($ul.is(':visible')) {
            $li.removeClass('active');
        }
        else {
            $li.addClass('active');
        }
        $ul.slideToggle();
    });

    $('.liClick').click(function (e) {
        var $ul = $(this).parent(); //li的父ul
        sessionStorage.setItem("ulId", $ul.attr('id'));
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

    //将form表单转换成json
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

});

/** cookies有bug(最好不用) **/
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