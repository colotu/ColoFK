/*
* File:        SubmitOrder.js
* Author:      yaoyuan@ys56.com
* Copyright © 2004-2013 YSWL. All Rights Reserved.
*/
;
function Status_None() {
    $('.step').removeClass('step-current');
    $('#mask_maticsoft').remove();
}

//提交订单
function SubmitOrder(sender) {
    //    $.alert("此功能还在完善中, 敬请期待.");
    //    return;

    var sku = $.getUrlParam('sku');
    var count = $.getUrlParam('count');
    var remark = $('#txtRemark').val();
    var phone = $("#txtPhone").val();
    if (!phone||phone == "") {
        ShowFailTip('请填写手机号码');
    }
    var productid = $(sender).attr("productid");
    var name = $(sender).attr("name");
    var preproid = $.getUrlParam('id');
    var amount = $("#payPriceId").attr("BasePrice");

    var checkoutLoading = $('<span id="order-loading" class="checkout-state"><b></b>\u6B63\u5728\u63D0\u4EA4\u8BA2\u5355\uFF0C\u8BF7\u7A0D\u5019\uFF01</span>');
    var originSubmit = $("#order-submit").clone(true);
    //lock
    $(sender).fadeOut('slow', function () {
        $("#order-loading").replaceWith(originSubmit);
        //进入Jquery队列执行
        $(this).replaceWith(checkoutLoading).queue(function (next) {
            $.ajax({
                url: $YSWL.BasePath + 'Order/AjaxPreOrder',
                type: 'post',
                dataType: 'json',
                timeout: 0,
                async: true,
                data: {
                    id: preproid,
                    sku: sku,
                    productid: productid,
                    name: name,
                    phone: phone,
                    amount: amount,
                    count: count,
                    remark: remark
                },
                success: function (resultData) {
                    var isOK = false;
                    switch (resultData.STATUS) {
                        // 提交订单成功   
                        case "SUCCESS":
                            isOK = true;
                            //延迟两秒后跳转
                            $("#order-loading").html("<b></b>订单提提交成功, 请稍后..").animate({ opacity: 1.0 }, 1000).fadeOut("slow", function () {
                                //DONE: 货到付款/银行汇款 跳转 BEN MODIFY 20131205
                                if (resultData.GATEWAY == 'cod' || resultData.GATEWAY == 'bank') {
                                    window.location.replace('/pay/certification' + resultData.DATA.OrderId + '/' + $YSWL.CurrentArea);
                                } else {
                                    window.location.replace($YSWL.BasePath + 'Order/SubmitSuccess/' + resultData.DATA.OrderId);
                                }
                            });
                            break;
                    
                        case "NOLOGIN":
                            // 用户未登陆
                            $.alertEx('您还没有登陆或者登陆已超时，请您登陆后提交订单．', function () {
                                $.navURL($YSWL.BasePath + 'Account/Login?return=' + encodeURIComponent(window.location.href));
                            });
                            break;
                        case "UNAUTHORIZED":
                            // 权限不足
                            $("#submit_message").html("只有普通用户才可以提交订单喔, 请您登陆普通用户再提交订单.");
                            $("#submit_message").show();
                            break;
                        default:
                            // 抛出异常消息
                            $.alertError(resultData.STATUS);
                            break;
                    }
                    if (!isOK) {
                        $("#order-loading").fadeOut('slow', function () {
                            $("#order-loading").replaceWith(originSubmit);
                            $(sender).fadeIn('slow');
                        });
                    }
                },

                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        $.alertError(xmlHttpRequest.responseText);
                    } else {
                        $("#submit_message").html("噗, 您的网络忒慢了! 访问服务器超时了, 请再试一下!");
                    }
                    $("#order-loading").replaceWith(originSubmit);
                    $("#submit_message").show();
                    $(sender).fadeIn('slow');
                }
            });

            next();
        });
    });
}

