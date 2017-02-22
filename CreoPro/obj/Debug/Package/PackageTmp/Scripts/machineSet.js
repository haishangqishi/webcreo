$(document).ready(function () {

    //机床设置（折叠框效果）
    $('#mdList_aMin').click(function () {
        var divcss = $('#mdListDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#mdListDiv").slideToggle(500);
            $('#mdList_iMin').removeClass("glyphicon-chevron-up");
            $('#mdList_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#mdListDiv").show(500);
            $('#mdList_iMin').removeClass("glyphicon-chevron-down");
            $('#mdList_iMin').addClass("glyphicon-chevron-up");
        }
    });

});