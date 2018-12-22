//使用此文件需引入  1./Scripts/jquery.cookie.js
//                             2./Scripts/inflate.js  解压缩
//获取商品已加入购物车的数量 
function getProdListCartNums() {
    var cartDataJsonArray = GetCartDataJsonArray();
    if (cartDataJsonArray == null)//购物车无数据 则返回
        return false;
    var num;
    var pid;
    //循环需要显示已加入购物车数量的商品
    $('.prod_shopcart_num').each(function () {
        $(this).removeClass('prod_shopcart_num');//防止下拉加载更多后再次被计算
        num = 0;
        pid = parseInt($(this).attr('pid'));
        $.each(cartDataJsonArray, function (index, item) {
            if (item.productId == pid) {
                num += item.quantity;
            }
        });
        if (num <= 0) {
            return;
        }
        if (num > 99) {
            $(this).text('99+').show();
        } else {
            $(this).text(num).show();
        }
    });
}

//获取购物车数据列表
function GetCartDataJsonArray() {
    //js 获取购物车中的商品
    var shoppingcartIndex = $.cookie('yswl_v1.2_shoppingcart_index_' + GetCurrentUserId());
    var cartDataCookieDataKeys = utf8to16(zip_inflate(base64decode(decodeURIComponent(shoppingcartIndex))));
    //购物车key数组
    var cartDataCookieDataKeyArray = new Array();
    if (cartDataCookieDataKeys == null || cartDataCookieDataKeys.length <= 0) {
        return null;
    }
    cartDataCookieDataKeyArray = cartDataCookieDataKeys.split(',');
    if (cartDataCookieDataKeyArray.length <= 0) {
        return null;
    }
    //购物车数据
    var cartDataCookieData = eval(utf8to16(zip_inflate(base64decode(decodeURIComponent($.cookie(cartDataCookieDataKeyArray[0]))))));
    for (var i = 1; i < cartDataCookieDataKeyArray.length; i++) {
        //合并数据
        $.merge(cartDataCookieData, eval(utf8to16(zip_inflate(base64decode(decodeURIComponent($.cookie(cartDataCookieDataKeyArray[i])))))));
    }
    return cartDataCookieData;
}
var base64DecodeChars = new Array(
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
    52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,
    -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,
    -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
    41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1);
//编码的方法
function base64encode(str) {
    var out, i, len;
    var c1, c2, c3;
    len = str.length;
    i = 0;
    out = "";
    while (i < len) {
        c1 = str.charCodeAt(i++) & 0xff;
        if (i == len) {
            out += base64EncodeChars.charAt(c1 >> 2);
            out += base64EncodeChars.charAt((c1 & 0x3) << 4);
            out += "==";
            break;
        }
        c2 = str.charCodeAt(i++);
        if (i == len) {
            out += base64EncodeChars.charAt(c1 >> 2);
            out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
            out += base64EncodeChars.charAt((c2 & 0xF) << 2);
            out += "=";
            break;
        }
        c3 = str.charCodeAt(i++);
        out += base64EncodeChars.charAt(c1 >> 2);
        out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
        out += base64EncodeChars.charAt(((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6));
        out += base64EncodeChars.charAt(c3 & 0x3F);
    }
    return out;
}
//解码的方法
function base64decode(str) {
    var c1, c2, c3, c4;
    var i, len, out;
    len = str.length;
    i = 0;
    out = "";
    while (i < len) {

        do {
            c1 = base64DecodeChars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c1 == -1);
        if (c1 == -1)
            break;

        do {
            c2 = base64DecodeChars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c2 == -1);
        if (c2 == -1)
            break;
        out += String.fromCharCode((c1 << 2) | ((c2 & 0x30) >> 4));

        do {
            c3 = str.charCodeAt(i++) & 0xff;
            if (c3 == 61)
                return out;
            c3 = base64DecodeChars[c3];
        } while (i < len && c3 == -1);
        if (c3 == -1)
            break;
        out += String.fromCharCode(((c2 & 0XF) << 4) | ((c3 & 0x3C) >> 2));

        do {
            c4 = str.charCodeAt(i++) & 0xff;
            if (c4 == 61)
                return out;
            c4 = base64DecodeChars[c4];
        } while (i < len && c4 == -1);
        if (c4 == -1)
            break;
        out += String.fromCharCode(((c3 & 0x03) << 6) | c4);
    }
    return out;
}
function utf8to16(str) {
    var out, i, len, c;
    var char2, char3;
    out = "";
    len = str.length;
    i = 0;
    while (i < len) {
        c = str.charCodeAt(i++);
        switch (c >> 4) {
            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
                // 0xxxxxxx 
                out += str.charAt(i - 1);
                break;
            case 12: case 13:
                // 110x xxxx　 10xx xxxx 
                char2 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
                break;
            case 14:
                // 1110 xxxx　10xx xxxx　10xx xxxx 
                char2 = str.charCodeAt(i++);
                char3 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x0F) << 12) |
                ((char2 & 0x3F) << 6) |
                ((char3 & 0x3F) << 0));
                break;
        }
    }
    return out;
}
function utf16to8(str) {
    var out, i, len, c;
    out = "";
    len = str.length;
    for (i = 0; i < len; i++) {
        c = str.charCodeAt(i);
        if ((c >= 0x0001) && (c <= 0x007F)) {
            out += str.charAt(i);
        } else if (c > 0x07FF) {
            out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
            out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
        } else {
            out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
        }
    }
    return out;
}

//获取当前登录用户的UserId
function GetCurrentUserId() {
    var userId = -1;
    $.ajax({
        url: $YSWL.BasePath + "Account/GetCurrentUserId",
        type: 'post',
        dataType: 'text',
        async: false,
        success: function (resultData) {
            userId = resultData;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert(errorThrown);
        }
    });
    return userId;
}