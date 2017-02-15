$(document).ready(function () {

    //机床设置（折叠框效果）
    $('#tdList_aMin').click(function () {
        var divcss = $('#tdListDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#tdListDiv").slideToggle(500);
            $('#tdList_iMin').removeClass("glyphicon-chevron-up");
            $('#tdList_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#tdListDiv").show(500);
            $('#tdList_iMin').removeClass("glyphicon-chevron-down");
            $('#tdList_iMin').addClass("glyphicon-chevron-up");
        }
    });

});