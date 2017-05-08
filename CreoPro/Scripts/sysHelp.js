$(document).ready(function () {

    //折叠框效果
    $('#exe_aMin').click(function () {
        var divcss = $('#exeDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#exeDiv').slideToggle(500);
            $('#exe_iMin').removeClass("glyphicon-chevron-up");
            $('#exe_iMin').addClass("glyphicon-chevron-down");
        } else {
            $('#exeDiv').show(500);
            $('#exe_iMin').removeClass("glyphicon-chevron-down");
            $('#exe_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //表单提交前验证
    //    $("#regForm").bind("submit", function () {
    //        var flag = false;
    //        $.ajax({
    //            type: "post",
    //            url: "/Member/hasGundaoSetup",
    //            data: {},
    //            cache: false,
    //            dataType: "json",
    //            async: false, //同步模式
    //            success: function (data) {
    //                console.log(data);
    //                if (data != "true") {
    //                    $("#msg").text(data);
    //                    $("#myModal").modal();
    //                    flag = false;
    //                } else {
    //                    flag = true;
    //                }
    //            }
    //        });

    //        if (!flag) {//不能在ajax返回中return，否则不能阻止下载
    //            return false;
    //        }
    //    });

});
