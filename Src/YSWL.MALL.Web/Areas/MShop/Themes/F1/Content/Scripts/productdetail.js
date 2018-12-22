
$(function () {
    $("#plus").click(function () {
        var count = parseInt($("#productCount").text()) + 1;
        $("#productCount").text(count);
    });
    $("#subtract").click(function () {
        var count = parseInt($("#productCount").text());
        if (count > 1) {
            count = count - 1;
        }
        $("#productCount").text(count);
    });
    $("#btnAddToCart").click(function () {
        //暂时是需要登录才能购买
        if ($(this).hasClass('addCart-gray')) return false;
        if (!$(this).attr('itemid')) {
            ShowFailTip('请选择商品规格属性！');
            return false;
        }
        var count = parseInt($("#productCount").text());
 //未开启sku时的判断库存
        if ($('#hdHasSKU').val().toLocaleLowerCase() == "false") {
            var stock = parseInt($('#hdprodSku').attr('stock'));
            if (stock < count) {
                ShowFailTip('库存不足！');
                return false;
            }
        }
        $.ajax({
            type: "POST",
            dataType: "json",
            async: false,
            url: $YSWL.BasePath + "ShoppingCart/AddCart?s=" + new Date().format('yyyyMMddhhmmssS'),
            data: { Sku: $(this).attr('itemid'), Count: count },
            success: function (resultData) {
                switch (resultData.STATUS) {
                    case "SUCCESS":
                        ShowSuccessTip("添加成功！");
                        setTimeout(function () {
                            location.href = $YSWL.BasePath + "p";
                        }, 200);
                        return false;
                    case "FAILED":
                        switch (resultData.DATA) {
                            case "NOSTOCK":
                                ShowFailTip("库存不足！");
                                return false;
                            case "NOSKU":
                            case "NO":
                            default:
                                ShowFailTip("服务器繁忙，请稍候再试！");
                                return false;
                        }
                    default:
                        ShowFailTip("服务器繁忙，请稍候再试！");
                        return false;
                }
            }
        });
      });
 
  //开启分仓
    if ($('#hdIsMultiDepot').length > 0 && $('#hdIsMultiDepot').val().toLocaleLowerCase() == "true") {
        loadDeliveryAreas();

        //获取分仓商品库存
        getDepotProdSkus();
    }
 
 });

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
                    $('#div_stock').css('display', 'inline-block').find('#stock_num').text('0');
                    noStock();
                } else { //有库存
                    $('#div_stock').css('display', 'inline-block').find('#stock_num').text(resultData);
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






