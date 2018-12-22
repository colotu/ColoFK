
//判断是否含有禁用词
function ContainsDisWords(desc) {
    var isContain = false;
    $.ajax({
        url: $YSWL.BasePath + "Partial/ContainsDisWords",
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

var CheckUserState4UserType = function () {
    var islogin;
    $.ajax({
        url: $YSWL.BasePath + "User/CheckUserState4UserType",
        type: 'post',
        dataType: 'text',
        timeout: 10000,
        async: false,
        success: function (resultData) {
            if (resultData == "Yes") {
                islogin = true;
                return true;
            } else if (resultData == "Yes4AA") {
                $.jBox.tip('管理员不能操作, 请您更换普通帐号再试!');
                $(".jbox-button").hide();
                islogin = false;
                return false;
            } else {

                islogin = false;
                return false;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });

    return islogin;
};
var CheckUserLogin = function () {
    var islogin;
    $.ajax({
        url: $YSWL.BasePath + "User/CheckUserState",
        type: 'post',
        dataType: 'text',
        timeout: 10000,
        async: false,
        success: function (resultData) {
            if (resultData != "Yes") {
                islogin = false;
                return false;
            } else {
                islogin = true;
                return true;

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
    return islogin;
};
 
$(function () {
    //商品咨询
    $(".btnAddConsult").die("click").live("click", function () {
        if (CheckUserState()) {
            var dialogOpts = {
                title: "商品咨询",
                width: 400,
                modal: true,
                buttons: {
                    "确定": function () {
                        submitAjaxAddConsult();
                    }
                }
            };
            $("#divAjaxConsults").dialog(dialogOpts);
        }
    });
    //商品评论
    $(".btnAddComment").die("click").live("click", function () {
        if (CheckUserState()) {
            var dialogOpts = {
                title: "商品评论",
                width: 400,
                modal: true,
                buttons: {
                    "确定": function () {
                        submitAjaxAddComment();
                    }
                    //                        "取消": function () {
                    //                            //  $(this).dialog("close"); //关闭层
                    //                            $("#divAjaxComments").dialog("close");
                    //                        }

                }
            };
            $("#divAjaxComments").dialog(dialogOpts);
        }
    });



    //放大镜
    jqzoom();

    //左右轮换
    qh();



    //收藏操作
    $("#btnProductFav").click(function () {
        if (CheckUserState()) {
            var productId = $(this).attr("productId");
            $.ajax({
                type: "POST",
                dataType: "text",
                url: $YSWL.BasePath + "UserCenter/AjaxAddFav",
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

    //优惠套装切换
    $('#combo_div #ul_detail_list li').click(function () {
        $(this).siblings().removeClass('scurr');
        $(this).addClass('scurr');
        $('#combo_div .div_access_item').hide();
        $('#combo_div #' + $(this).attr('item')).show();
    });

    //组合配件切换
    $('#parts_div #parts_suit li').click(function () {
        $(this).siblings().removeClass('scurr');
        $(this).addClass('scurr');
        $('#parts_div .div_access_item').hide();
        $('#parts_div #' + $(this).attr('item')).show();
    });

    //配件 加入购物车
    $(".acce_cart_btn").click(function () {
        if (!$(this).attr('itemid')) {
            return false;
        }
        location.href = $YSWL.BasePath + "ShoppingCart/AddCart?sku=" + $(this).attr('itemid');
    });


    //商品详情信息切换
    $("#goodss_ul li").click(function () {
        if ($(this).hasClass('hover')) {
            return;
        }
        $("#goodss_ul li").removeClass('hover');
        var itemid = $(this).addClass('hover').attr('item');
        switch (itemid) {
            case "1":
                $('.produt_detail_qh').show();
                break;
            case "2":
                $('.produt_detail_qh:first').hide().nextAll().show();
                break;
            case "3":
                $('.produt_detail_qh').eq(2).show().prevAll('.produt_detail_qh').hide();
                break;
            case "4":
                $('.produt_detail_qh:last').prevAll('.produt_detail_qh').hide();
                break;
        }
    });
    
    
    
    //开启分仓
    if ($('#hdIsMultiDepot').length>0 && $('#hdIsMultiDepot').val().toLocaleLowerCase() == "true") {
            loadDeliveryAreas();
            
            //获取分仓商品库存
            getDepotProdSkus();
        }

    
    

 
});

function submitAjaxAddConsult() {
    var productId = $("#hdProductId").val();
    var content = $("#txtConsult").val();
    if (content == "") {
        ShowFailTip('请填写咨询内容！');
        return;
    }
    if (ContainsDisWords(content)) {
        ShowFailTip('您输入的内容含有禁用词，请重新输入！');
        return;
    }
    $.ajax({
        type: "POST",
        dataType: "text",
        url: $YSWL.BasePath + "UserCenter/AjaxAddConsult",
        data: { ProductId: productId, Content: content },
        success: function (data) {
            if (data == "True") {
                ShowSuccessTip('咨询成功！请等待管理员回复');
                $("#divAjaxConsults").dialog("close");
                $(".ui-dialog").empty();
            } else {
                ShowFailTip('服务器繁忙，请稍候再试！');
            }
        }
    });
}

function submitAjaxAddComment() {
    var productId = $("#hdProductId").val();
    var productName = $("#hdProductName").val();
    var content = $("#txtComment").val();
    if (content == "") {
        ShowFailTip('请填写评论内容！');
        return;
    }
    if (ContainsDisWords(content)) {
        ShowFailTip('您评论的内容含有禁用词，请重新输入！');
        return;
    }
    $.ajax({
        type: "POST",
        dataType: "text",
        url: $YSWL.BasePath + "UserCenter/AjaxAddComment",
        data: { ProductId: productId, Content: content, ProductName: productName },
        success: function (data) {
            if (data == "True") {
                ShowSuccessTip('评论成功!');
                $("#divAjaxComments").dialog("close");
                $(".ui-dialog").empty();
            } else {
                ShowFailTip('服务器繁忙，请稍候再试！');
            }
        }
    });
}

if ($.browser.msie && ($.browser.version == "7.0" ||  $.browser.version == "8.0")) {
    String.prototype.trim = function () {
        return this.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
    }
}


//加密用户名
function encryption($userNameList) {
    $userNameList.each(function () {
        var self = $(this);
        var self_length = self.text().trim().length;
        var self_text = self.text().trim();
        if (self_length >= 7) {
            self.text(self_text.substring(0, 3) + "****" + self_text.substring(7, self_length));
        } else if (self_length > 3) {
            self.text(self_text.substring(0, 2) + "****");
        } else {
            self.text('****');
        }
        self.show();
    });
}


//放大镜
function jqzoom() {
    var samllImg = $('#samllImg');
    samllImg.after('<span class="mark"></span>');
    samllImg.after('<span class="float_layer"></span>');
    var zodiv = $('.jqzoomdiv');
    var omak = $('.mark');
    var box = $('.jqzoom');
    var smalls = $('.goodsbigbox');
    var olayer = $('.float_layer');
    var bigimg = $('.jqzoomdiv img');
    var bigimgsrc = $('#samllImg').attr('jqimg');
    bigimg.attr('src', bigimgsrc)
    //console.log(bigimgsrc);
    omak.hover(function () {
        olayer.css('display', 'block');
        zodiv.css('display', 'block');
        bigimgsrc = $('#samllImg').attr('jqimg');
        $('.jqzoomdiv img').attr('src', bigimgsrc);
    }, function () {
        olayer.css('display', 'none');
        zodiv.css('display', 'none');
    });
    omak.mousemove(function (e) {
        var oEvent = e || event;
        var l = e.pageX - box.offset().left - olayer.width() / 2;
        var t = e.pageY - box.offset().top - olayer.height() / 2; ;
        if (l < 0) {
            l = 0;
        }
        if (l > box.width() - olayer.width()) {
            l = box.width() - olayer.width() - 4;
        }
        if (t < 0) {
            t = 0;
        }
        if (t > box.height() - olayer.height()) {
            t = box.height() - olayer.height() - 4;
        }
        olayer.css({ left: l + 'px', top: t + 'px' });
        var prenX = l / (smalls.width() - olayer.width());
        var prenY = t / (smalls.height() - olayer.height());
        //document.title=prenX+"|"+prenY;
        bigimg.css({ left: -prenX * (bigimg.width() - zodiv.width()) + 'px', top: -prenY * (bigimg.height() - zodiv.height()) + 'px' })

    });
}

//左右轮换
function qh() {
    var prev = $('.prev');
    var next = $('.next');
    var oul = $('.nowss');
    var olis = $('.nowss li');
    var liWidth = 63;
    var now = 0;
   // var prentWidth = $('.nowss').width();
    var len = $('.nowss li').length;
    $('.nowss').width(len * liWidth);
    //var oulWidth = $('.nowss').width();
    //var widthCha = oulWidth - prentWidth;
    var bigshow = $('#samllImg');
    next.click(function () {
        if (now == len - 1) {
            now = 0;
        } else {
            now++;
        }
        tshow(now);
    });

    prev.click(function () {
        if (now == 0) {
            now = len - 1;
        } else {
            now--;
        }
        tshow(now);
    });
    olis.click(function () {
        now = $('.nowss li').index(this);
        tshow(now);
    });
    function tshow(i) {
        $('.nowss li').removeClass('hover').eq(i).addClass('hover');
        var imgurl = $('.nowss li img').eq(i).attr('src').replace('T81X81_', 'T350X350_');
        $("#samllImg").attr({ jqimg: imgurl , src: imgurl });
//        if (now * liWidth < widthCha) {
//            $('.nowss').css({ left: -now * liWidth + 'px' });

//        } else {
//            $('.nowss').css({ left: -widthCha + 'px' });

//        }

        var src = olis.eq(i).attr('jslogsrc');
        var jqzoomsrc = olis.eq(i).attr('jqimg');
        bigshow.attr('src', src);
        bigshow.attr('jqimg', jqzoomsrc);
    }
}

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
}


//无库存
function noStock() {
    $('#SKUOptions').parent().find('#btnAddToCart').removeClass('addCart').addClass('addCart-gray');
    $('#iteminfo #divBuyInfo').hide();
    $('#iteminfo #closeArrivingNotifyMess').text("非常抱歉, 此商品已售罄!");
    $('#iteminfo #closeArrivingNotifyMess').show();
}

//有库存
function inStock() {
    $('#SKUOptions').parent().find('#btnAddToCart').removeClass('addCart-gray').addClass('addCart');
    $('#iteminfo #divBuyInfo').show();
    $('#iteminfo #closeArrivingNotifyMess').hide();
}

//设置单品页配送地区
function setProdDetailDeliveryAreas(regoinId) {
    setDeliveryAreas(regoinId);
    getDepotProdSkus();
}
