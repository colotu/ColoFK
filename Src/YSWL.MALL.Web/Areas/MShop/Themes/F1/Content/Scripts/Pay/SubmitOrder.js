/*
* File:        SubmitOrder.js
* Author:      yaoyuan@ys56.com
* Copyright © 2004-2013 YSWL. All Rights Reserved.
*/
;

function Edit_Consignee(sender, addressId) {
    if (sender) $(sender).hide();
    var $target = $('#step-1');
    Status_Editing($target);
    $target.load($YSWL.BasePath + 'Order/AddressInfo', { addressId: addressId });
}

function Edit_Payment(sender, isShowTip) {
    if (sender) $(sender).hide();
    var $target = $('#step-2'),
        payId = $target.find('#PaymentModeId').val(),
        shipId = $target.find('#ShippingTypeId').val();
    Status_Editing($target);
    $target.load($YSWL.BasePath + 'Order/PayAndShipInfo', {
        payId: payId,
        shipId: shipId
    }, function () {
        if (isShowTip) $('#save-consignee-tip').show();
    });
}

function Status_Editing(target) {
    $('.step').removeClass('step-current');
    target.addClass('step-current');
    target.find('.step-content').empty().append('<div class="step-loading"><div class="loading-style1" style="margin-bottom: 20px;"><b></b>正在加载中，请稍候...</div></div>');
    $(document.body).append(
        ('<div id="mask_maticsoft" style="width: 100%; height: {0}px; position: absolute; top: 0px; left: 0px; z-index: 9998; opacity: 0.7; display: block;"></div>').format(
            $(document).height())
    );
}

function Status_None() {
    $('.step').removeClass('step-current');
    $('#mask_maticsoft').remove();
}

//提交订单
function SubmitOrder(sender, shippingAddressId, shippingTypeId, paymentModeId,conpon) {
    //    $.alert("此功能还在完善中, 敬请期待.");
    //    return;
    var error = 0;
    $.ajax({
        type: "post",
        url: $YSWL.BasePath + 'Order/GetSentPrices',
        dataType: "text",
        cache: false,
        async: false,
        success: function (resultData) {
            var resultVal = parseFloat(resultData); //起送价格
            var totalPrice = $('#payPriceId').attr('TotalPrice'); //应付金额
            if (totalPrice < resultVal) {
                ShowFailTip("抱歉,您的订单小于起送价格.不能下单.");
                ++error;
            }
        }
    });
    if ( parseInt(error) > 0) {
        return false;
    }
    var skuArry = [];
    var skuId = $('#SkuInfo').val();
    var count = $('#SkuCount').val();
    if (skuId) {
        var sku = {};
        sku.SKU = skuId;
        sku.Count = count ? count : 1;
        skuArry.push(sku);
    } else {
        skuArry = null;
    }

    var checkoutLoading = $('<span id="order-loading" class="checkout-state"><b></b>\u6B63\u5728\u63D0\u4EA4\u8BA2\u5355\uFF0C\u8BF7\u7A0D\u5019\uFF01</span>');
    var originSubmit = $("#order-submit").clone(true);
    //lock
    $(sender).fadeOut('slow', function () {
        $("#order-loading").replaceWith(originSubmit);
        //进入Jquery队列执行
        $(this).replaceWith(checkoutLoading).queue(function (next) {
            $.ajax({
                url: '/Pay/OrderHandler.aspx',
                type: 'post',
                dataType: 'json',
                timeout: 0,
                async: true,
                data: { Action: "SubmitOrder",
                    ShippingAddressId: shippingAddressId,
                    ShippingTypeId: shippingTypeId,
                    PaymentModeId: paymentModeId,
                    Coupon: conpon,
                    SkuInfos: skuArry ? JSON.stringify(skuArry) : null
                },
                success: function (resultData) {
                    var isOK = false;
                    switch (resultData.STATUS) {
                        // 提交订单成功         
                        case "SUCCESS":
                            isOK = true;
                            //清空一下cooke 
                            $.cookie('m_so_code', "", { expires: -1, path: '/' });
                            $.cookie('m_so_payId', "", { expires: -1, path: '/' });
                            $.cookie('m_so_shipId', "", { expires: -1, path: '/' }); 
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
                        case "NOSTOCK":
			    alert('很抱歉.您购买的部分商品已经被其TA人抢先下单了.');
                             break;
                        case "NOSHOPPINGCARTINFO":
			
                            ShowFailTip("您的购物车是空的, 请加入商品后提交订单!");
                            break;
                        case "NOLOGIN":
                            // 用户未登陆
                            if (confirm("您还没有登陆或者登陆已超时，请您登陆后提交订单．")) {
                                $YSWL.BasePath + 'Account/Login?return=' + encodeURIComponent(window.location.href);
                            }
                            break;
                        case "UNAUTHORIZED":
                            // 权限不足
                            ShowFailTip("只有普通用户才可以提交订单喔, 请您登陆普通用户再提交订单.");
                            break;
                        case "NOTCANUSECOUPON":
                            ShowFailTip('不能使用优惠劵');
                            break;
                     
                        case "INVALID": //已失效
			alert('很抱歉.您购买的部分商品已失效.');
                            break;
                        default:
                            // 抛出异常消息
                            ShowFailTip(resultData.STATUS);
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
                        ShowFailTip(xmlHttpRequest.responseText);
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

