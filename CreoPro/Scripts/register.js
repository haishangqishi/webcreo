$(document).ready(function () {

    //验证用户名是否存在
    $("#txtusername").blur(function () {
        $.ajax({
            type: "post",
            url: "/Member/hasUserName",
            data: { username: $("#txtusername").val() },
            cache: false,
            dataType: "json",
            success: function (data) {
                var massage = data;
                if (massage == "True") {
                    $('#usernameRight').css('display', 'block');
                    $('#addMem').attr('disabled', true);
                } else {
                    $('#usernameRight').css('display', 'none');
                    $('#addMem').attr('disabled', false);
                }
            }
        });
    });

    //添加用户
    $('#addMem').click(function () {
        var formData = JSON.stringify($('#memForm').serializeObject());
        $.ajax({
            type: "post",
            url: "/Member/addUser",
            data: formData,
            cache: false,
            dataType: "json",
            success: function (data) {
                var massage = data;
                if (massage == "True") {
                    $('#msg').text("注册成功！");
                } else {
                    $('#msg').text("注册错误！");
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