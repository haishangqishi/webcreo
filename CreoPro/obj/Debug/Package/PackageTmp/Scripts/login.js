$(document).ready(function () {

    //验证用户名是否存在
    $("#username").blur(function () {
        $.ajax({
            type: "post",
            url: "/Member/hasUserName",
            data: { username: $("#username").val() },
            cache: false,
            dataType: "json",
            success: function (data) {
                var massage = data;
                if (massage == "True") {
                    $('#usernameError').css('display', 'none');
                    $('#btnlogin').attr('disabled', false);
                } else {
                    $('#usernameError').css('display', 'block');
                    $('#btnlogin').attr('disabled', true);
                }
            }
        });
    });

    //验证密码是否正确
    $("#password").blur(function () {
        $.ajax({
            type: "post",
            url: "/Member/rightPwd",
            data: { username: $("#username").val(),
                password: $("#password").val()
            },
            cache: false,
            dataType: "json",
            success: function (data) {
                var massage = data;
                if (massage == "True") {
                    $('#pwdError').css('display', 'none');
                    $('#btnlogin').attr('disabled', false);
                } else {
                    $('#pwdError').css('display', 'block');
                    $('#btnlogin').attr('disabled', true);
                }
            }
        });
    });

    //Enter键操作
    $(document).keydown(function (e) {
        if (e.which == 13) {
            $("#password").blur(); //失去焦点(不可缺)
            loginIn();
        }
    });

    function loginIn() {
        $.ajax({
            type: "post",
            url: "/Member/rightPwd",
            data: { username: $("#username").val(),
                password: $("#password").val()
            },
            cache: false,
            dataType: "json",
            success: function (massage) {
                if (massage == "True") {
                    $('#loginForm').submit();
                } else {
                    return false;
                }
            }
        });
    };

});