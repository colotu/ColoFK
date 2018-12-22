
$(function () {
    $(document).on("click", "#plus", function () {
        var count = parseInt($("#productCount").val());
        if (isNaN(count) || count <= 0) {
            count = 1;
        } else {
            count = count + 1;
        }
        $("#productCount").val(count);
    });
 
    $(document).on("click", "#subtract", function () {
        var count = parseInt($("#productCount").val());
        if (isNaN(count) || count <= 1) {
            count = 1;
        } else {
            count = count - 1;
        }
        $("#productCount").val(count);
    });

    //收藏操作
    $(document).on("click", "#btnProductFav", function () {
        if ($(this).hasClass('isAdded')){
            return;
        }
        if (CheckUserState()) {
            var productId = $(this).attr("productId");
            $.ajax({
                type: "POST",
                dataType: "text",
                url: $YSWL.BasePath + "u/AjaxAddFav",
                async: false,
                data: { ProductId: productId },
                success: function (data) {
                    if (data == "Rep") {
                        $('#btnProductFav').addClass('isAdded');
                        $('#img_love').hide();
                        $('#img_love2').show();
                        AlertSuccess('已经加入收藏，请不要重复收藏');
                    } else if (data == "True") {
                        $('#btnProductFav').addClass('isAdded');
                        $('#img_love').hide();
                        $('#img_love2').show();
                        AlertSuccess('收藏商品成功');
                    } else {
                        AlertWarning('服务器繁忙，请稍候再试！');
                    }
                }
            });
        }
    });
    //开启分仓
    if ($('#hdIsMultiDepot').length > 0 && $('#hdIsMultiDepot').val().toLocaleLowerCase() == "true") {
        loadDeliveryAreas();

        //获取分仓商品库存
        getDepotProdSkus();
    }
});

//是否添加过收藏
var IsAddedFav = function (productId) {
    $.ajax({
        type: "POST",
        dataType: "text",
        url: $YSWL.BasePath + "u/IsAddedFav",
        async: false,
        data: { ProductId: productId },
        success: function (data) {
            if (data == "True") {
                $('#btnProductFav').addClass('isAdded');
                $('#img_love').hide();
                $('#img_love2').show();
            } else {
                $('#btnProductFav').removeClass('isAdded');
                $('#img_love').show();
                $('#img_love2').hide();
            }
        }
    });
}

//检查是否登录
var CheckUserState = function () {
    var islogin;
    var url = $.getUrlMiddle();
    $.ajax({
        url: $YSWL.BasePath +"Account/AjaxIsLogin",
        type: 'post',
        dataType: 'text',
        async: false,
        success: function (resultData) {
            if (resultData != "True") {
                //dialog层中项的设置
                location.href = $YSWL.BasePath +"a/l?returnUrl=" + url;
                return false;
            } else {
                islogin = true;
                return true;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
    return islogin;
};


var GetPvCount = function (pid) {
    $.ajax({
        url: $YSWL.BasePath + "Product/GetPvCount",
        type: 'post',
        dataType: 'json',
        timeout: 10000,
        data: {
            pid: pid
        },
        success: function (jsondata) {
            if (jsondata.STATUS == "SUCCESS") {
                //jsondata.DATA; 将访问数展示到页面上  预留 
            }
        },
        error: function (messsage) {
        }
    });

};


//获取分仓商品库存
function getDepotProdSkus() {
    //if (!CheckUserState()) {
    //    return;
    //}

    //alert("getDepotProdSkus");
    //if (!CheckUserState()) {
    //    return;
    //}
    //商家商品不走分仓
    if (parseInt($('#hdsuppId').val()) > 0) {
        return;
    }
    if (!$('#hdsuppId').val() || !$('#hdHasSKU').val()) {
        return;
    }
    var suppid = $('#hdsuppId').val();
    var hasSKU = $('#hdHasSKU').val().toLocaleLowerCase();

    if (hasSKU == "true") {//开启了sku
        var pid = parseInt($("#hdProductId").val());
        $.ajax({
            url: $YSWL.BasePath + "Product/GetSKUInfos",
            type: 'post',
            dataType: 'text',
            timeout: 10000,
            async: true,
            data: { productId: pid, suppId: suppid },
            success: function (resultData) {
                $('#SKUDATA').val(resultData);
                InitializationSku();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    } else {
        //没有开启sku
        var prodSku = $('#hdprodSku').val();
        $.ajax({
            url: $YSWL.BasePath + "Product/GetSKUStock",
            type: 'post',
            dataType: 'text',
            timeout: 10000,
            async: true,
            data: { sku: prodSku, suppId: suppid },
            success: function (resultData) {
                $('#hdprodSku').attr('stock', resultData);
                if (parseInt(resultData) <= 0) {//无库存
                    $('#div_stock').show().find('#stock_num').text('0');
                    noStock();
                } else { //有库存
                    $('#div_stock').show().find('#stock_num').text(resultData);
                    inStock();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    }
};



//无库存
function noStock() {
    $('#btnAddToCart').attr('disabled', 'disabled').addClass('btn_disabled').find('#btnAddToCart_text').text('已售罄');
    if ($('#btnBuyNow').length > 0) {
        $('#btnBuyNow').attr('disabled', 'disabled').addClass('btn_disabled').find('#btnBuyNow_text').text('已售罄');
    }
    $('#iteminfo #divBuyInfo').hide();
    $('.quantity_wrap').hide();//兼容分仓

    //$('#iteminfo #divSelectInfo').empty();
}

//有库存
function inStock() {
    $('#btnAddToCart').removeAttr('disabled', 'disabled').removeClass('btn_disabled').find('#btnAddToCart_text').text('加入购物车');
    if ($('#btnBuyNow').length > 0) {
        $('#btnBuyNow').removeAttr('disabled', 'disabled').removeClass('btn_disabled').find('#btnBuyNow_text').text('立即购买');
    }
    $('#iteminfo #divBuyInfo').show();
    $('.quantity_wrap').show();//兼容分仓
    //$('#iteminfo #divSelectInfo').empty();
};
 
//设置单品页配送地区
function setProdDetailDeliveryAreas(regoinId) {
    setDeliveryAreas(regoinId);
    getDepotProdSkus();
}

function goto(_self,flag) {   
    if ($(_self).hasClass('btn_disabled')) return false;
    if (!$(_self).attr('itemid')) {
            $('#SKUOptions,#SKUOptions a').effect('highlight', 500);
            AlertWarning('请选择商品规格属性！');
            return false;
        }
        var count = parseInt($("#productCount").val());
        if (isNaN(count) || count <= 0) {
            count = 1;
        }
        //获取推广信息

        //未开启sku时的判断库存
        if ($('#hdHasSKU').val().toLocaleLowerCase() == "false") {
            var stock = parseInt($('#hdprodSku').attr('stock'));
            if (stock < count) {
                AlertWarning('库存不足！');
                return false;
            }
        } else {//开启sku时的判断库存
            var stock_num = parseInt($('#stock_num').text());
            if (isNaN(stock_num) || stock_num <= 0 || stock_num < count) {
                AlertWarning('库存不足！');
                return false;
            }
        }
        if (flag == 1) {
            //立刻购买
            location.href = $YSWL.BasePath + "Order/SubmitOrder?sku=" + $(_self).attr('itemid') + "&Count=" + count + "&r=" + $.getUrlParam("r");
        } else {//加入购物车
            //location.href = $YSWL.BasePath + "ShoppingCart/AddCart?sku=" + $(_self).attr('itemid') + "&Count=" + count + "&r=" + $.getUrlParam("r");
            if (CheckUserState()) {
                //加入购物车
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    async: false,
                    url: $YSWL.BasePath + "ShoppingCart/AddCart?s=" + new Date().format('yyyyMMddhhmmssS'),
                    data: { Sku: $(_self).attr('itemid'), Count: count },
                    success: function(resultData) {
                        switch (resultData.STATUS) {
                        case "SUCCESS":
                            AlertSuccess('添加成功！');
                            dialoghide();
                            return true;
                        case "FAILED":
                            switch (resultData.DATA) {
                            case "NOSTOCK":
                                AlertWarning("库存不足！");
                                return false;
                            case "NOSKU":
                            case "NO":
                            default:
                                AlertWarning("服务器繁忙，请稍候再试！");
                                return false;
                            }
                        default:
                            AlertWarning("服务器繁忙，请稍候再试！");
                            return false;
                        }
                    }
                });
            }
        }
}

//隐藏窗体
function dialoghide() {
    $('html').css('overflow-y', 'auto');//恢复页面滚动条
    $('#dialog').hide(300);
    $('#fade').hide();
    if ($('#footer').length > 0) {
        $('#footer').show();
    }
}


//当前页面加入购物车
function addCart(_self) {
    if (!CheckUserState()) {
        return;
    }

    if ($(_self).hasClass('btn_disabled')) return false;
    if (!$(_self).attr('itemid')) {
        $('#SKUOptions,#SKUOptions a').effect('highlight', 500);
        AlertWarning('请选择商品规格属性！');
        return false;
    }
    var count = parseInt($("#productCount").val());
    if (isNaN(count) || count <= 0) {
        count = 1;
    }
    //获取推广信息

    //未开启sku时的判断库存
    if ($('#hdHasSKU').val().toLocaleLowerCase() == "false") {
        var stock = parseInt($('#hdprodSku').attr('stock'));
        if (stock < count) {
            AlertWarning('库存不足！');
            return false;
        }
    } else {//开启sku时的判断库存
        var stock_num = parseInt($('#stock_num').text());
        if (isNaN(stock_num) || stock_num <= 0 || stock_num < count) {
            AlertWarning('库存不足！');
            return false;
        }
    }
    //加入购物车
    $.ajax({
        type: "POST",
        dataType: "json",
        async: false,
        url: $YSWL.BasePath + "ShoppingCart/AddCart?s=" + new Date().format('yyyyMMddhhmmssS'),
        data: { Sku: $(_self).attr('itemid'), Count: count },
        success: function (resultData) {
            switch (resultData.STATUS) {
                case "SUCCESS":
                    AlertSuccess('添加成功！');
                    dialoghide();
                    return false;
                case "FAILED":
                    switch (resultData.DATA) {
                        case "NOSTOCK":
                            AlertWarning("库存不足！");
                            return false;
                        case "NOSKU":
                        case "NO":
                        default:
                            AlertWarning("服务器繁忙，请稍候再试！");
                            return false;
                    }
                default:
                    AlertWarning("服务器繁忙，请稍候再试！");
                    return false;
            }
        }
    });
}
