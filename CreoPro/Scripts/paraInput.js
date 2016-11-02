$(document).ready(function () {

    //启动Creo按钮
    $('#startCreo').click(function () {
        $.ajax({
            type: "post",
            url: "/mainForm/startCreo",
            data: {},
            cache: false,
            dataType: "json",
            success: function (data) {
            }
        });
    });

    //折叠框效果
    $('#aMin1').click(function () {
        var divcss = $('#memMin1').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#memMin1').css("display", "none");
            $('#iMin1').removeClass("glyphicon-chevron-up");
            $('#iMin1').addClass("glyphicon-chevron-down");
        } else {
            $('#memMin1').css("display", "block");
            $('#iMin1').removeClass("glyphicon-chevron-down");
            $('#iMin1').addClass("glyphicon-chevron-up");
        }
    });

});