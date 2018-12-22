/**
* updatepassword.js
*
* 功 能：修改密码
* 文件名称： updatepassword.js
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/06/18 12:00:00   HUHY  初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

 
function ShowErrorMsg(msg) {
    $("#errorMsg").html(msg);
    $(".ui-error").addClass("displayblock");
    setTimeout(function () {
        $(".ui-error").removeClass("displayblock");
    }, 2000);
}

$(function () {
    $(".closeBtn").click(function () { //点击X
        $(".ui-error").hide();
    });


    $(function () {
        /*密码开始*/
        $("#txtPwd").blur(function () {
            checkpassword();
        });
        /*密码结束*/

        /*新密码开始*/
        $("#txtNewPwd").blur(function () {
            checknewpassword();
        });
        /*新密码开始*/

        /*确认密码开始*/
        $("#txtConfirmPwd").blur(function () {
            checkconfirmpassword();
        });
        /*确认密码结束*/

    });

    // 验证用户原密码

    function checkpassword() {

        var errnum = 0;

        var passwordVal = $.trim($('#txtPwd').val());

        if (passwordVal == '') {
            ShowErrorMsg("原密码不能为空！");
            return false;
        } else {
            $.ajax({
                url: $YSWL.BasePath + 'u/CheckPassword',
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                async: false,
                data: {
                    Action: "post",
                    Password: passwordVal
                },
                success: function (JsonData) {
                    if (JsonData.STATUS == "ERROR") {
                        errnum++;
                        ShowErrorMsg("原密码错误！");
                    } else if (JsonData.STATUS == "OK") {
                        $("#pwdTip").removeClass("red").addClass("tipClass").html("&nbsp;");
                    } else {
                        errnum++;
                        ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    errnum++;
                    ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                }
            });
        }
        return errnum == 0 ? true : false;
    }

    // 验证用户新密码

    function checknewpassword() {
        var newpasswordVal = $.trim($('#txtNewPwd').val());
        if (newpasswordVal == '') {
            ShowErrorMsg("新密码不能为空！");
            return false;
        } else if (newpasswordVal.length < 6 || newpasswordVal.length > 16) {
            ShowErrorMsg("新密码长度为6~16个字符！");
            return false;
        } else {
            $("#newpwdTip").removeClass("red").addClass("tipClass").html("&nbsp;");
            return true;
        }
    }

    // 验证用户确认密码

    function checkconfirmpassword() {

        var newpasswordVal = $.trim($('#txtNewPwd').val());
        var confirmpwdVal = $.trim($('#txtConfirmPwd').val());
        if (confirmpwdVal == '') {
            ShowErrorMsg("确认密码不能为空！");
            return false;
        } else if (newpasswordVal != confirmpwdVal) {
            ShowErrorMsg("两次密码不一致,请确认！");
            return false;
        }
        $("#confirmpwdTip").removeClass("red").addClass("tipClass").html("&nbsp;");
        return true;

    }

    $("#btnSureChange").click(function () {
        submit();
    });
    function submit() {
        var errnum = 0;
        if (!checkpassword()) {
            errnum++;
        }
        if (!checknewpassword()) {
            errnum++;
        }
        if (!checkconfirmpassword()) {
            errnum++;
        }
        if (!(errnum == 0 ? true : false)) {
            return false;
        } else {
            var newpasswordVal = $.trim($('#txtNewPwd').val());
            var confirmpwdVal = $.trim($('#txtConfirmPwd').val());
            $.ajax({
                url: $YSWL.BasePath + 'u/UpdateUserPassword',
                type: 'post',
                dataType: 'json',
                timeout: 10000,
                async: false,
                data: {
                    Action: "post",
                    NewPassword: newpasswordVal,
                    ConfirmPassword: confirmpwdVal
                },
                success: function (JsonData) {
                    switch (JsonData.STATUS) {
                        case "FAIL":
                            ShowErrorMsg("新密码和确认密码不一致！");
                            break;
                        case "UPDATESUCC":
                            $("#txtPwd").val("");
                            $("#txtNewPwd").val("");
                            $("#txtConfirmPwd").val("");
                            ShowSuccessTip("修改密码成功！");
                            break;
                        case "UPDATEFAIL":
                            ShowFailTip("修改密码失败！");
                            break;
                        default:
                            ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                            break;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                }
            });

        }
    }
});