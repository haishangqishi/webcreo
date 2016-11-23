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
            var jsonObj = $.parseJSON(data);
            $("#txtusername").val(jsonObj.userName);
            $("#txtemail").val(jsonObj.email);
            $("#txtphone").val(jsonObj.phone);
            $("#txtcreoSetup").val(jsonObj.creoSetup);
            $("#txtcreoWorkSpace").val(jsonObj.creoWorkSpace);
        }
    });

    //保存用户
    $('#saveMem').click(function () {
        var formData = JSON.stringify($('#memForm').serializeObject());
        $.ajax({
            type: "post",
            url: "/Member/updateUser",
            data: formData,
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
        return false;
    });

    //将form表单转换成json
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

});