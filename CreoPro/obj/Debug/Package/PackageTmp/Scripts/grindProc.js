$(document).ready(function () {

    //仿真加工展示（折叠框效果）
    $('#grind_aMin').click(function () {
        var divcss = $('#grindDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#grindDiv").slideToggle(500);
            $('#grind_iMin').removeClass("glyphicon-chevron-up");
            $('#grind_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#grindDiv").show(500);
            $('#grind_iMin').removeClass("glyphicon-chevron-down");
            $('#grind_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //齿轮系列 触发事件
    $(document).on('change', '#sel_serail_grind', function () {
        console.log("系列，类型触发事件：");
        $("#sel_moshu_grind").html(''); //先清空
        var serail = $('#sel_serail_grind').val();
        var option = "";
        var arr;
        if (serail == 1) {
            arr = new Array(1, 1.25, 1.5, 2, 2.5, 3, 4, 5, 6, 8, 10);
        } else if (serail == 2) {
            arr = new Array(1.75, 2.25, 2.75, 3.25, 3.5, 3.75, 4.5, 5.5, 6.5, 7, 9);
        }
        for (var i = 0; i < arr.length; i++) {
            option += "<option value='" + arr[i] + "'>" + arr[i] + "</option>";
        }
        $("#sel_moshu_grind").html(option);
    });

    //查询零件模型(放映)
    //    $('#selPrt_grind').click(function () {
    //        var paras = JSON.stringify($('#grindForm').serializeObject());
    //        var moshu = $('#sel_moshu_grind').val();
    //        var serail = $('#sel_serail_grind').val();
    //        var type = $('#sel_type_grind').val();
    //        var MN = moshu;
    //        if (moshu.indexOf('.') >= 0) {
    //            MN = moshu.replace('.', 'd');
    //        }

    //        $('#prtAlbum').html('');
    //        var path = "../../Content/images/";
    //        var link = "";
    //        for (var i = 1; i <= 5; i++) {//图片名称格式：m模数-系列-类型_i;其中模数中'.'换成'd'
    //            link += "<a href='#' id='dynImg" + i + "' class='gallery-css-" + i + "'><img src='../../Content/images/m" + MN + "/m" + MN + "-" + serail + "-" + type + "_" + i
    //                    + ".png' alt='模数" + moshu + "齿轮滚刀'></a>";
    //        }
    //        console.log("图片名称" + link);
    //        $('#prtAlbum').html(link);
    //    });


    $('#selPrt_grind').click(function () {
        $('#divGrind1').removeClass("div-show");
        $('#divGrind1').addClass("div-hid");
        $('#divGrind2').removeClass("div-hid");
        $('#divGrind2').addClass("div-show");
    });
});
