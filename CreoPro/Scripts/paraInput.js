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
                console.log(data);
                $("#msg").text(data);
                $("#myModal").modal();
            }
        });
    });

    //折叠框效果
    $('#para_aMin').click(function () {
        var divcss = $('#paraMin').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#paraMin').css("display", "none");
            $('#para_iMin').removeClass("glyphicon-chevron-up");
            $('#para_iMin').addClass("glyphicon-chevron-down");
        } else {
            $('#paraMin').css("display", "block");
            $('#para_iMin').removeClass("glyphicon-chevron-down");
            $('#para_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //折叠框效果
    $('#paralist_aMin').click(function () {
        var divcss = $('#paralistMin').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#paralistMin').css("display", "none");
            $('#paralist_iMin').removeClass("glyphicon-chevron-up");
            $('#paralist_iMin').addClass("glyphicon-chevron-down");
        } else {
            $('#paralistMin').css("display", "block");
            $('#paralist_iMin').removeClass("glyphicon-chevron-down");
            $('#paralist_iMin').addClass("glyphicon-chevron-up");
        }
    });

});