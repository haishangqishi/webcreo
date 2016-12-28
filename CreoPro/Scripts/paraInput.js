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
<<<<<<< HEAD
    function pagiation(totalPage, pageIndex) {
        $(".tcdPageCode").createPage({
            pageCount: totalPage,
            current: pageIndex,
            backFn: function (p) {
                getParaList(p);
            }
        });
    }

    //查询
    $('#selFilter').click(function () {
        getParaList(1);
    });

    //加载参数列表
    function getParaList(pageIndex) {
=======
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
>>>>>>> b9e05b3865c4eba4ae14bde5112e988130c2833a
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
<<<<<<< HEAD
                var jsonObj = $.parseJSON(data.list);
                createTable(jsonObj);
                pagiation(data.totalPage, pageIndex);
=======
>>>>>>> b9e05b3865c4eba4ae14bde5112e988130c2833a
            }
        });
    }

<<<<<<< HEAD
    //动态创建table的tbody
    function createTable(data) {
        $("#listbody").html("");
        var tbody = "";
        var len = data.length;
        for (var i = 0; i < len; i++) {
            tbody = tbody + "<tr class='ta-tr'>"
                        + "<td class='dyn'>" + data[i].moshu + "</td>"
                        + "<td>" + data[i].rongxieNum + "</td>"
                        + "<td class='dyn'>" + data[i].deg + "</td>"
                        + "<td class='dyn'>" + data[i].L + "</td>"
                        + "<td class='dyn'>" + data[i].kongjing + "</td>"
                        + "<td><a class='btn btn-success btn-mid' href='#'><i class='glyphicon glyphicon-zoom-in icon-white i-padd'></i>查看</a>"
                        + "<a class='btn btn-danger btn-mid' href='#'><i class='glyphicon glyphicon-trash icon-white i-padd'></i>删除</a></td>"
                        + "</tr>";
        }
        if (len == 0) {
            tbody = tbody + "<tr style='text-align: center'>"
                + "<td colspan='6'><font color='#cd0a0a'>" + 暂无记录 + "</font></td>"
                + "</tr>";
        }
        //添加到div中  
        $("#listbody").html(tbody);
    }

=======
>>>>>>> b9e05b3865c4eba4ae14bde5112e988130c2833a
});
