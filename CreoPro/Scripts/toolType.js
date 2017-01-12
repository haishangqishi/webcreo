$(document).ready(function () {

    //刀具类型（折叠框效果）
    $('#toolList_aMin').click(function () {
        var divcss = $('#toolListDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#toolListDiv").slideToggle(500);
            $('#toolList_iMin').removeClass("glyphicon-chevron-up");
            $('#toolList_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#toolListDiv").show(500);
            $('#toolList_iMin').removeClass("glyphicon-chevron-down");
            $('#toolList_iMin').addClass("glyphicon-chevron-up");
        }
    });

});