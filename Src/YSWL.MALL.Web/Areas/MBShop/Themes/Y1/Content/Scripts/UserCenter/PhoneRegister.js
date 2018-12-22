var phoneStatus = false;//手机号验证状态
var pwdStatus = false;//密码验证状态
var vpwdStatus = false;//确认密码验证状态
var truenameStatus = false;//真实姓名
var isCanStatus = false;//是否可以增加
var regs = /^[A-Za-z0-9]{6,20}$/;

$(function () {
    //焦点验证
    $("#phone").focus(function () {
        $("#phone").attr("placeholder", "请输入手机号");
        errorBorder($(this));
    }).blur(function () {
        CheckPhone($(this));
    });
    $("#trueName").focus(function () {
        $("#trueName").attr("placeholder", "请输入真实姓名");
        errorBorder($(this));
    }).blur(function () {
        CheckTrueName($(this));
    });
    $("#password").focus(function () {
        $("#password").attr("placeholder", "请输入密码（6~20位英文或数字）");
        errorBorder($(this));
    }).blur(function () {
        CheckPwd($(this));
    });
    $("#rePassword").focus(function () {
        $("#rePassword").attr("placeholder", "确认密码");
        errorBorder($(this));
    }).blur(function () {
        CheckVPwd($(this));
    });


    //注册按钮
    $("#btnPhoneRegister").click(function () {
        if (CheckRegister()) {
            $('#formregister').submit();
        }
    });
})

//注册验证
function CheckRegister() {

    CheckVPwd($("#rePassword"));
    CheckPwd($("#password"));
    CheckTrueName($("#trueName"));
    CheckPhone($("#phone"));

    CheckIsCan();

    if (!phoneStatus || !pwdStatus || !vpwdStatus || !truenameStatus || !isCanStatus) {
        checkOK = false;
    } else {
        checkOK = true;
    }
    return checkOK;
}
//验证是否可以添加
function CheckIsCan() {
    $.ajax({
        url: $YSWL.BasePath + "Account/IsCanAdd",
        type: 'post',
        dataType: 'text',
        timeout: 10000,
        async: false,
        data: {
            Action: "post"
        },
        success: function (resultData) {
            if (resultData == "true") {
                isCanStatus = true;
            }
            else {
                AlertWarning("您的客户数已经达到上限，请联系客服进行充值");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertWarning("服务器没有返回数据，可能服务器忙，请稍候再试！");
        }
    });
    return;
}

//验证手机号
function CheckPhone(obj) {
    var regs = /^1([358][0-9]|4[57]|7[01678])\d{8}$/;
    var phoneval = obj.val();
    if (phoneval != "") {
        if (!regs.test(phoneval)) {     //正则验证手机号
            AlertWarning("请填写真实的手机号码");
            phoneStatus = false;
            return;
        } else {
            //验证手机是否存在
            $.ajax({
                url: $YSWL.BasePath + "Account/IsExistUserName",
                type: 'post',
                dataType: 'text',
                timeout: 10000,
                async: false,
                data: {
                    Action: "post", userName: phoneval
                },
                success: function (resultData) {
                    if (resultData == "true") {
                        phoneStatus = true;
                        passBorder(obj);
                    }
                    else {

                        AlertWarning("该手机号已被注册,请使用其它手机号");
                        phoneStatus = false;
                        errorBorder(obj);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    AlertWarning("服务器没有返回数据，可能服务器忙，请稍候再试！");
                    phoneStatus = false;
                    errorBorder(obj);
                }

            });
        }
    } else {
        AlertInfo('请填写手机号码');
        phoneStatus = false;
        errorBorder(obj);
    }
    return;
}

//验证密码
function CheckPwd(obj) {
    var pwdval = obj.val();
    if (pwdval.length == 0) {
        AlertInfo("请输入密码");
        pwdStatus = false;
        errorBorder(obj);
        return;
    }
    if (!regs.test(pwdval)) {

        AlertInfo("请输入密码（6~20位英文或数字）");
        pwdStatus = false;
        errorBorder(obj);
    } else {
        pwdStatus = true;
        passBorder(obj);
    }
}

//验证确认密码
function CheckVPwd(obj) {
    if (obj.val() != "") {
        if (obj.val() != $("#password").val()) {
            AlertWarning("两次密码的不一致，请重新填写！");
            vpwdStatus = false;
            errorBorder(obj);
        } else {
            vpwdStatus = true;
            passBorder(obj);
        }
    } else {
        AlertInfo("请确认密码");
        vpwdStatus = false;
        errorBorder(obj);

    }
}

//验证真实姓名
function CheckTrueName(obj) {
    if (obj.val().trim() != "") {
        truenameStatus = true;
        passBorder(obj);
    } else {
        AlertInfo("请输入真实姓名");
        errorBorder(obj);
    }
}

function errorBorder(obj) {
    obj.css('border-color', '#b94a48');
}

function passBorder(obj) {
    obj.css('border-color', '');
}










