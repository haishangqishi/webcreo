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

    //菜单点击事件
//    $('#paraInput').click(function () {
//        var url = "paraInput.cshtml";
//        $('#contentPage').empty(); //清空div
//        $('#contentPage').html("@RenderPage('paraInput.cshtml')"); //向div添加对应网页
//        $('#contentPage').load(url);
//    });
//    $('#modelShow').click(function () {
//        $('#contentPage').empty(); //清空div
//        $('#contentPage').html("@RenderPage('modelShow.cshtml')"); //向div添加对应网页
//    });

    //    var arr = $(".menulink");
    //    var len = arr.length;
    //    var strUrl = "";
    //    for (i = 0; i < len; i++) {
    //        strUrl = arr[i].href;
    //        strUrl = strUrl.substring(strUrl.lastIndexOf("/") + 1); //url
    //        arr[i].addEventListener('click', function () { //为菜单添加点击事件
    //            console.log(i);
    //            console.log(strUrl);
    //            $('#contentPage').empty(); //清空div
    //            $('#contentPage').html("@RenderPage('" + strUrl + "')"); //向div添加对应网页
    //        });
    //    }



});