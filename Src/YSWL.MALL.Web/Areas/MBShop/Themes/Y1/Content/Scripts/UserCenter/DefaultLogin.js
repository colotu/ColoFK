
var passwordStatus = true;
$(document).ready(function () {
    //登录按钮的单击事件
    $('#loginsubmit').click(function () {
        if (CheckLogin()) {//验证通过
            $("#formlogin").submit(); //触发submit按钮
        }
    });

    //微信用户绑定
    $("#bindsubmit").click(function () {
        if (CheckLogin()) {//验证通过
            $(this).attr("disabled", "disabled");
            var userName = $("#txtLogin").val();
            var pwd = $("#password").val();
            var user = $("#txtUser").val();
            var open = $("#txtOpenId").val();
            $.ajax({
                url: $YSWL.BasePath + "Account/AjaxBind",
                type: 'post',
                dataType: 'text',
                timeout: 10000,
                async: false,
                data: {
                    Action: "post", UserName: userName, UserPwd: pwd, User: user, OpenId: open
                },
                success: function (resultData) {
                    if (resultData == "1") {
                        AlertSuccess("绑定用户成功！");
                    }
                    if (resultData == "2") {
                        AlertWarning("该账户已被冻结，请联系管理员！");
                    }
                    if (resultData == "3") {
                        AlertWarning("该账户已经绑定了其它帐号！");
                    }

                    if (resultData == "0") {
                        AlertWarning("您输入的用户名和密码有误，请重试！");
                        $("#bindsubmit").removeAttr("disabled");
                    }
                    if (resultData == "-1") {
                        AlertWarning("服务器繁忙，请稍候再试！");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    ShowServerBusyTip("服务器繁忙，请稍候再试！");
                }

            });
        }
    });

    $("#password").focus(function () {
        $("#divPasswordTip").html("请填写密码");
    }).keypress(function (event) {
        if (event.which == 13) {
            $("#loginsubmit").trigger("click");
        }
    }).blur(function () {
        CheckPassword($(this));
    });

});


//验证登录
function CheckLogin() {

    CheckPassword($("#password"));
    var checkOK = false;
    if (!passwordStatus) {
        checkOK = false;
    }
    else {
        checkOK = true;
    }
    return checkOK;
}


//验证密码
function CheckPassword(obj) {
    if (obj.val() != "") {
        passwordStatus = true;
        $("#divPasswordTip").html('');
    }
    else {
        passwordStatus = false;
        AlertWarning("请填写密码");
  
    }
}

 