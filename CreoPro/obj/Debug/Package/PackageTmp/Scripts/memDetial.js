$(document).ready(function () {

    //折叠框效果
    $('#mem_aMin').click(function () {
        var divcss = $('#memDiv').attr("style").toString();
        if (divcss.indexOf("block") >= 0) {
            $('#memDiv').slideToggle(500);
            $('#mem_iMin').removeClass("glyphicon-chevron-up");
            $('#mem_iMin').addClass("glyphicon-chevron-down");
        } else {
            $('#memDiv').show(500);
            $('#mem_iMin').removeClass("glyphicon-chevron-down");
            $('#mem_iMin').addClass("glyphicon-chevron-up");
        }
    });

    //动态绑定用户
    $.ajax({
        type: "post",
        url: "/mainForm/getCurrentUser",
        data: {},
        cache: false,
        dataType: "json",
        success: function (data) {
            console.log("json串11" + data);
            var jsonObj = $.parseJSON(data);
            $("#txtusername").val(jsonObj.userName);
            $("#txtemail").val(jsonObj.email);
            $("#txtphone").val(jsonObj.phone);
            $("#txtcadPath").val(jsonObj.cadPath);
            $("#txtcreoSetup").val(jsonObj.creoSetup);
        }
    });

    //保存用户
    $('#saveMem').click(function () {
        var formData = JSON.stringify($('#memForm').serializeObject());
        $.ajax({
            type: "post",
            url: "/Member/updateUser",
            data: { formData: formData },
            cache: false,
            dataType: "json",
            success: function (data) {
                var massage = data;
                if (massage == "True") {
                    $('#msg').text("保存成功！");
                } else {
                    $('#msg').text("保存错误！");
                }
                $("#myModal").modal();
            }
        });
        //return false;
    });

});
