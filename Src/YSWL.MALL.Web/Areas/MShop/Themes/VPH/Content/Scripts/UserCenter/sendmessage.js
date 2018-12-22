/**
* sendmessage.js
*
* 功 能：发送站内信
* 文件名称：sendmessage.js
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/09/25 12:00:00  蒋海滨    初版
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

$(function() {
    
      $(".closeBtn").click(function () { //点击X
        $(".ui-error").hide();
    });

    /*验证用户昵称开始*/
    $("#txtNickName").blur(function() {
        checknickname();
    });
    /*验证用户结束*/

    /*验证主题开始*/
    $("#txtTitle").blur(function() {
        checktitle();
    });
    /*验证主题结束*/

    /*验证内容开始*/
    $("#txtContent").blur(function() {
        checkcontent();
    });
    /*验证内容结束*/

});
// 验证用户昵称
function checknickname() {
    var nicknameVal = $.trim($('#txtNickName').val());
    if (nicknameVal == '') {
        ShowErrorMsg("昵称不能为空！");
        return false;
    }
    var errnum = 0;
    $.ajax({
        url: $YSWL.BasePath +"UserCenter/ExistsNickName",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        async: false,
        data: {
            Action: "post",
            NickName: nicknameVal
        },
        success: function(JsonData) {
            switch (JsonData.STATUS) {
            case "EXISTS":
                $("#nciknameTip").removeClass("red").addClass("tipClass").html("&nbsp;");
                break;
            case "NOTEXISTS":
                errnum++;
                 ShowErrorMsg("昵称不存在！");
                break;
            case "NOTNULL":
                errnum++;
                 ShowErrorMsg("昵称不能为空！");
                break;
            default:
                errnum++;
                 ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                break;
            }
        },
        error: function(XMLHttpRequest, textStatus, errorThrown) {
            errnum++;
             ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
        }
    });

    return errnum == 0 ? true: false;
}

// 验证主题
function checktitle() {
    var titleVal = $.trim($('#txtTitle').val());
    if (titleVal == '') {
          ShowErrorMsg("主题不能为空！");
        return false;
    }
    if (titleVal.length == 0 || titleVal.length > 50) {
          ShowErrorMsg("请控制在0~50字符！");
        return false;
    }
    $("#titleTip").removeClass("red").addClass("tipClass").html("&nbsp;");
    return true;
}

// 验证内容
function checkcontent() {
    var contentVal = $.trim($('#txtContent').val());
    if (contentVal == '') {
          ShowErrorMsg("内容不能为空！");
        return false;
    }
    if (contentVal.length == 0 || contentVal.length > 500) {
         ShowErrorMsg("请控制在1~500字符！");
        return false;
    }
    $("#contentTip").removeClass("red").addClass("tipClass").html("&nbsp;");
    return true;
}

$(function() {
    $("#btnSendMsg").click(function() {
        submit();
    });
});
function submit() {

    var errnum = 0;

    if (!checknickname()) {
        errnum++;
    }

    if (!checktitle()) {
        errnum++;
    }

    if (!checkcontent()) {
        errnum++;
    }

    if (! (errnum == 0 ? true: false)) {
        return false;
    } else {
        var nickname = $.trim($("#txtNickName").val());
        var title = $.trim($("#txtTitle").val());
        var content = $.trim($("#txtContent").val());

        $.ajax({
            url: $YSWL.BasePath +"UserCenter/SendMsg",
            type: 'post',
            dataType: 'json',
            timeout: 10000,
            async: false,
            data: {
                Action: "post",
                NickName: nickname,
                Title: title,
                Content: content,
            },
            success: function(JsonData) {

                switch (JsonData.STATUS) {
                case "NICKNAMENULL":
                     ShowErrorMsg("昵称不能为空！");
                    break;
                case "NICKNAMENOTEXISTS":
                      ShowErrorMsg("昵称不存在，请重新输入！");
                    break;
                case "TITLENULL":
                      ShowErrorMsg("主题不能为空！");
                   
                    break;
                case "CONTENTNULL":
                    ShowErrorMsg("内容不能为空！");
                    break;
                case "SUCC":
                    $("#txtNickName").val("");
                    $("#txtTitle").val("");
                    $("#txtContent").val("");
                    ShowSuccessTip("发送成功！");
                    break;
                case "FAIL":
                    ShowFailTip("发送失败！");
                    break;
                default:
                       ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
                    break;
                }
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                  ShowErrorMsg("服务器没有返回数据，可能服务器忙，请稍候再试！");
            }

        });
    }

}