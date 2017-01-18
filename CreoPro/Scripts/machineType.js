$(document).ready(function () {

    //机床类型（折叠框效果）
    $('#machList_aMin').click(function () {
        var divcss = $('#machListDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#machListDiv").slideToggle(500);
            $('#machList_iMin').removeClass("glyphicon-chevron-up");
            $('#machList_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#machListDiv").show(500);
            $('#machList_iMin').removeClass("glyphicon-chevron-down");
            $('#machList_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //点击机床链接，跳转页面
    $('.td-mach').click(function () {
        $(this).parent().submit();
        //$('.hi-form').submit();
        return false;
    });

});
