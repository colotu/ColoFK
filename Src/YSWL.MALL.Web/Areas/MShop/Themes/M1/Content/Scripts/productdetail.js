
$(function () {
    $("#plus").click(function () {
        var count = parseInt($("#productCount").val()) + 1;
        $("#productCount").val(count);
    });
    $("#subtract").click(function () {
        var count = parseInt($("#productCount").val());
        if (count > 1) {
            count = count - 1;
        }
        $("#productCount").val(count);
    });
    $("#btnAddToCart").click(function () {
        //暂时是需要登录才能购买
        if ($(this).hasClass('addCart-gray')) return false;
        if (!$(this).attr('itemid')) {
            $('#SKUOptions,#SKUOptions a').effect('highlight', 500);
            ShowFailTip('请选择商品规格属性！');
            return false;
        }
        var count = parseInt($("#productCount").val());
        //获取推广信息

        //未开启sku时的判断库存
        if ($('#hdHasSKU').val().toLocaleLowerCase() == "false") {
            var stock = parseInt($('#hdprodSku').attr('stock'));
            if (stock < count) {
                ShowFailTip('库存不足！');
                return false;
            }
        }

        if (Shop_BuyMode && Shop_BuyMode == "BuyNow") {
            //立刻购买
            location.href = $YSWL.BasePath + "Order/SubmitOrder?sku=" + $(this).attr('itemid') + "&Count=" + count + "&r=" + $.getUrlParam("r"); 
        } else {
            location.href = $YSWL.BasePath + "ShoppingCart/AddCart?sku=" + $(this).attr('itemid') + "&Count=" + count + "&r=" + $.getUrlParam("r") ;
        }
    });





    //收藏操作
    $("#btnProductFav").click(function () {
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
                        ShowSuccessTip('您已经收藏了该商品，请不要重复收藏');
                    } else if (data == "True") {
                        ShowSuccessTip('收藏商品成功');
                    } else {
                        ShowFailTip('服务器繁忙，请稍候再试！');
                    }
                }
            });
        }
    });
    GetPvCount($("#hdProductId").val());

    //开启分仓
    if ($('#hdIsMultiDepot').length > 0 && $('#hdIsMultiDepot').val().toLocaleLowerCase() == "true") {
        loadDeliveryAreas();

        //获取分仓商品库存
        getDepotProdSkus();
    }
 

});
//判断是否含有禁用词
function ContainsDisWords(desc) {
    var isContain = false;
    $.ajax({
        url: $YSWL.BasePath +"Partial/ContainsDisWords",
        type: 'post', dataType: 'text', timeout: 10000,
        async: false,
        data: { Desc: desc },
        success: function (resultData) {
            if (resultData == "True") {
                isContain = true;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ShowFailTip("操作失败：" + errorThrown);
        }
    });
    return isContain;
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

    //商家商品不走分仓
    if (parseInt($('#hdsuppId').val()) > 0) {
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
    $('#btnAddToCart').attr('disabled', 'disabled').addClass('addCart-gray').text('该商品已售罄');
    $('#iteminfo #divBuyInfo').hide();
    $('#iteminfo #divSelectInfo').empty();
}

//有库存
function inStock() {
    $('#btnAddToCart').removeAttr('disabled', 'disabled').removeClass('addCart-gray').text($('#btnAddToCart').attr('DefaultText'));
    $('#iteminfo #divBuyInfo').show();
    $('#iteminfo #divSelectInfo').empty();
};

//设置单品页配送地区
 function setProdDetailDeliveryAreas (regoinId) {
    setDeliveryAreas(regoinId);
    getDepotProdSkus();
}

