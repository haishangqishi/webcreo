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

    //生成模型按钮
    $('#createModel').click(function () {
        var paras = JSON.stringify($('#paraForm').serializeObject());
        $.ajax({
            type: "post",
            url: "/mainForm/createModel",
            data: { paras: paras },
            cache: false,
            dataType: "json",
            success: function (data) {
                console.log(data);
                //$("#msg").text(data);
                //$("#myModal").modal();
            }
        });
    });

    //测试Creo按钮
    $('#test').click(function () {
        $.ajax({
            type: "post",
            url: "/mainForm/testCreo",
            data: {},
            cache: false,
            dataType: "json",
            success: function (data) {
                console.log(data);
            }
        });
    });

    //参数输入（折叠框效果）
    $('#para_aMin').click(function () {
        var divcss = $('#paraDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#paraDiv").slideToggle(500);
            $('#para_iMin').removeClass("glyphicon-chevron-up");
            $('#para_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#paraDiv").show(500);
            $('#para_iMin').removeClass("glyphicon-chevron-down");
            $('#para_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //参数列表（折叠框效果）
    $('#paralist_aMin').click(function () {
        var divcss = $('#paralistDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#paralistDiv").slideToggle(500);
            $('#paralist_iMin').removeClass("glyphicon-chevron-up");
            $('#paralist_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#paralistDiv").show(500);
            $('#paralist_iMin').removeClass("glyphicon-chevron-down");
            $('#paralist_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //加载参数列表
    $.ajax({
        type: "post",
        url: "/mainForm/paraInput",
        data: {},
        cache: false,
        success: function (data) {
            console.log(data);
        }
    });

    //过滤table中数据（去掉）
    $(".dyn").each(function () {
        var text = $(this).text();
        $(this).text(parseFloat(text));
    });

    //Regenerate the Pro/ENGINEER model.
    function WlModelRegenerate() {
        if (!pfcIsWindows())
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        var ret = document.pwl.pwlMdlRegenerate(document.main.ModelNameExt.value);
        if (!ret.Status) {
            alert("pwlMdlRegenerate failed (" + ret.ErrorCode + ")");
            return;
        }
    }

    //分页工具
    //    $(".tcdPageCode").createPage({
    //        pageCount: 10,
    //        current: 1,
    //        backFn: function (p) {
    //            console.log(p);
    //        }
    //    });

});