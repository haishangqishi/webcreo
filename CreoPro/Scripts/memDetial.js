$(document).ready(function () {

    //折叠框效果
    $('#aMin').click(function () {
        var divcss = $('#memMin').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#memMin').css("display", "none");
            $('#iMin').removeClass("glyphicon-chevron-up");
            $('#iMin').addClass("glyphicon-chevron-down");
        } else {
            $('#memMin').css("display", "block");
            $('#iMin').removeClass("glyphicon-chevron-down");
            $('#iMin').addClass("glyphicon-chevron-up");
        }
    });

});