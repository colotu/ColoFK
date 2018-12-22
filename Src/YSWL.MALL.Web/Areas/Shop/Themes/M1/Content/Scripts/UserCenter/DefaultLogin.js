﻿var loginNameStatus = true;
var passwordStatus = true;

$(document).ready(function () {
    var regStr = $('#hfRegisterToggle').val(); //注册方式
    //登录按钮的单击事件
    $('#loginsubmit').click(function () {
        if (CheckLogin()) {//验证通过
            $("#inputloginsubmit").trigger("click"); //触发submit按钮
        }
    });
    //邮箱文本框的光标
    $("#txtLogin").focus(function () {
        var str = '';
        if (regStr == "Phone") {
            str = '手机号码';
        } else {
            str = 'Email地址';
        }
        $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-err").addClass("msg msg-info")
                    .html("<i class=\"msg-ico\"></i><p>请填写" + str + "</p>");
    }).keypress(function (event) {
        if (event.which == 13) {
            $("#loginsubmit").trigger("click");
        }
    }).blur(function () {
        if (regStr == "Phone") {
            CheckLoginPhoneName($("#txtLogin"));
        } else {
            CheckLoginEmailName($("#txtLogin"));
        }
    });
    //    
    //   // 手机验证
    //        $("#txtLogin").focus(function () {
    //            $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-err").addClass("msg msg-info")
    //                        .html("<i class=\"msg-ico\"></i><p>请填写手机号码</p>");
    //        }).keypress(function (event) {
    //            if (event.which == 13) {
    //                $("#loginsubmit").trigger("click");
    //            }
    //        }).blur(function () {
    //            CheckLoginName($(this));
    //        });
    //密码文本框的光标
    $("#password").focus(function () {
        $("#divPasswordTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-err").addClass("msg msg-info")
                    .html("<i class=\"msg-ico\"></i><p>请填写密码</p>");
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
    var regStr = $('#hfRegisterToggle').val(); //注册方式
    if (regStr == "Phone") {
        CheckLoginPhoneName($("#txtLogin"));
    } else {
        CheckLoginEmailName($("#txtLogin"));
    }
    
    CheckPassword($("#password"));
    var checkOK = false;
    if (!loginNameStatus || !passwordStatus ) {
        checkOK = false;
    }
    else {
        checkOK = true;
    }
    return checkOK;
}

////验证用户名
function CheckLoginEmailName(obj) {
    var regsEmail = /^[\w-]+(\.[\w-]+)*\@[A-Za-z0-9]+((\.|-|_)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
    //var regsPhone = /^1\d{10}$/;
    var val = obj.val();
    if (val == "" || val == "Email") {
        loginNameStatus = false;
        $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-info").addClass("msg msg-err")
                    .html("<i class=\"msg-ico\"></i><p>请填写Email地址</p>");
    } else if (!regsEmail.test(val)) {// && !regsPhone.test(val)
        $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-info").addClass("msg msg-err").html("<i class=\"msg-ico\"></i><p>请填写有效的Email地址</p>");
            loginNameStatus = false;
    } else { 
        loginNameStatus = true;
        $("#divLoginTip").removeClass("msg msg-err").removeClass("msg msg-info").addClass("msg msg-ok msg-naked")
            .html("<i class=\"msg-ico\"></i><p>&nbsp;</p>");
    }
}

function CheckLoginPhoneName(obj) {
    var regs = /^1\d{10}$/;//^1\d{10}$/;
    var val = obj.val();
    if (val == "" || val == "Email") {
        loginNameStatus = false;
        $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-info").addClass("msg msg-err")
                    .html("<i class=\"msg-ico\"></i><p>请填写手机号码</p>");
    } else if (!regs.test(val)) {
        $("#divLoginTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-info").addClass("msg msg-err").html("<i class=\"msg-ico\"></i><p>请填写有效的手机号码</p>");
        loginNameStatus = false;
    } else {
        loginNameStatus = true;
        $("#divLoginTip").removeClass("msg msg-err").removeClass("msg msg-info").addClass("msg msg-ok msg-naked")
            .html("<i class=\"msg-ico\"></i><p>&nbsp;</p>");
    }
}
 //验证密码
function CheckPassword(obj) {
    if (obj.val() != "") {
        passwordStatus = true;
        $("#divPasswordTip").removeClass("msg msg-err").removeClass("msg msg-info").addClass("msg msg-ok msg-naked")
                    .html("<i class=\"msg-ico\"></i><p>&nbsp;</p>");
    }
    else {
        passwordStatus = false;
        $("#divPasswordTip").removeClass("msg msg-ok msg-naked").removeClass("msg msg-info").addClass("msg msg-err")
                    .html("<i class=\"msg-ico\"></i><p>请填写密码</p>");
    }
}

 