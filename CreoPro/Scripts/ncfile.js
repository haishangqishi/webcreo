$(document).ready(function () {

    //初始化页面时，加载列表（包含分页）
    getParaList(null, 1, true);

    //模型展示（折叠框效果）
    $('#nc_aMin').click(function () {
        var divcss = $('#ncDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $("#prtDiv").slideToggle(500);
            $('#nc_iMin').removeClass("glyphicon-chevron-up");
            $('#nc_iMin').addClass("glyphicon-chevron-down");
        } else {
            $("#ncDiv").show(500);
            $('#nc_iMin').removeClass("glyphicon-chevron-down");
            $('#nc_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //过滤table中数据（去掉）
    $(".dyn").each(function () {
        var text = $(this).text();
        $(this).text(parseFloat(text));
    });

    //分页工具
    function pagiation(totalPage, pageIndex) {
        $(".tcdPageCode").createPage({
            pageCount: totalPage,
            current: pageIndex,
            backFn: function (p) {
                var formData = JSON.stringify($('#ncForm').serializeObject());
                getParaList(formData, p, false);
            }
        });
    }

    //分页工具(只负责页码，不查数据)
    function pagiation_sel(totalPage, pageIndex) {
        $(".tcdPageCode").createPage({
            pageCount: totalPage,
            current: pageIndex,
            backFn: function (p) {
            }
        });
    }

    //查询
    $('#selnc').click(function () {
        var formData = JSON.stringify($('#ncForm').serializeObject());
        getParaList(formData, 1, false);
    });

    //加载参数列表
    function getParaList(formData, pageIndex, flag) {
        $.ajax({
            type: "post",
            url: "/mainForm/paraList",
            data: { "formData": formData, "pageIndex": pageIndex },
            cache: false,
            dataType: "json",
            success: function (data) {
                var jsonObj = $.parseJSON(data.list);
                createTable(jsonObj);
                if (flag == true) {
                    pagiation(data.totalPage, pageIndex);
                } else {
                    pagiation_sel(data.totalPage, pageIndex);
                }
            }
        });
    }

    //动态创建table的tbody
    function createTable(data) {
        $("#ncbody").html("");
        var tbody = "";
        var len = data.length;
        for (var i = 0; i < len; i++) {
            var flag = "否";
            var isStand = data[i].isStandard; //是否标准
            if (isStand == 1) {
                flag = "是";
            }
            tbody = tbody + "<tr class='ta-tr'>"
                + "<td class='td-hid'><input type='text' value='" + data[i].parm_id + "'/></td>"
                + "<td class='dyn'>" + data[i].moshu + "</td>"
                + "<td>" + data[i].rongxieNum + "</td>"
                + "<td class='dyn'>" + data[i].deg + "</td>"
                + "<td class='dyn'>" + data[i].L + "</td>"
                + "<td class='dyn'>" + data[i].kongjing + "</td>"
                + "<td class='dyn'>" + flag + "</td>"
                + "<td><a class='btn btn-success btn-mid' href='#'><i class='glyphicon glyphicon-zoom-in icon-white i-padd'></i>生成</a></td>"
                + "</tr>";
        }
        if (len == 0) {
            tbody = tbody + "<tr style='text-align: center'>"
                + "<td colspan='6'><font color='#cd0a0a'>暂无记录</font></td>"
                + "</tr>";
        }
        //添加到div中  
        $("#ncbody").html(tbody);
    }

});
