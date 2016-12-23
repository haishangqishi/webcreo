$(document).ready(function () {

    //默认加载参数列表
    //getParaList();

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
            beforeSend: function () {
                $('#createModel').attr("disabled", "disabled");
                $("#loadingModal").modal('show');
            },
            success: function (data) {
                if (data == "success") {
                    $('#createModel').removeAttr("disabled");
                    $("#loadingModal").modal('hide');
                }
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

    //过滤table中数据（去掉）
    $(".dyn").each(function () {
        var text = $(this).text();
        $(this).text(parseFloat(text));
    });

    //分页工具
    //    $(".tcdPageCode").createPage({
    //        pageCount: 10,
    //        current: 1,
    //        backFn: function (p) {
    //            console.log(p);
    //        }
    //    });

    //查询
    $('#selFilter').click(function () {
        //获取页码。。。。

        getParaList();
    });

    //加载参数列表
    function getParaList(page) {
        var formData = JSON.stringify($('#paraSelectForm').serializeObject());
        console.log("测试下拉选择：" + formData);
        $.ajax({
            type: "post",
            url: "/mainForm/paraList",
            data: { "formData": formData },
            //data: { "formData": formData, "pageIndex": pageIndex },
            cache: false,
            dataType: "json",
            success: function (data) {
                console.log(data);
            }
        });
    }

});
