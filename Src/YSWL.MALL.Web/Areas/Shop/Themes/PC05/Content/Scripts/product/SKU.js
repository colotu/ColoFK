﻿//(function () {

    //保存最后的组合结果信息
    var SKUResult = {};
    //获得对象的key

    function getObjKeys(obj) {
        if (obj !== Object(obj)) throw new TypeError('Invalid object');
        var keys = [];
        for (var key in obj)
            if (Object.prototype.hasOwnProperty.call(obj, key))
                keys[keys.length] = key;
        return keys;
    }

    //把组合的key放入结果集SKUResult

    function add2SKUResult(key, sku) {
        if (SKUResult[key]) { //SKU信息key属性·
            SKUResult[key].count += sku.count;
            SKUResult[key].prices.push(sku.price);
            SKUResult[key].rankprices.push(sku.rankprice);
            SKUResult[key].skus.push(sku.sku);
        } else {
            SKUResult[key] = {
                count: sku.count,
                prices: [sku.price],
                rankprices: [sku.rankprice],
                skus: [sku.sku]
            };
        }
    }

    //对一条SKU信息进行拆分组合

    function combineSKU(skuKeyAttrs, cnum, sku) {
        var len = skuKeyAttrs.length;
        for (var i = 0; i < len; i++) {
            var key = skuKeyAttrs[i];
            for (var j = i + 1; j < len; j++) {
                if (j + cnum <= len) {
                    var tempArr = skuKeyAttrs.slice(j, j + cnum); //安装组合个数获得属性值·
                    var genKey = key + "," + tempArr.join(","); //得到一个组合key
                    add2SKUResult(genKey, sku);
                }
            }
        }
    }

    var dataDefault;
    //初始化得到结果集

    function initSKU() {
        SKUResult = {};//重置sku数据
        var data = $('#SKUOptions #SKUDATA').val();
        //        if (!data) {
        //            //静态化 Ajax加载SKU
        //            $.ajax({
        //                url: $YSWL.BasePath + 'Product/GetSKUInfos',
        //                type: 'post',
        //                dataType: 'json',
        //                timeout: 0,
        //                async: true,
        //                data: { ProductId: $('#hdProductId').val()},
        //                success: function (resultData) {
        //                    data = resultData;
        //                },
        //                error: function (xmlHttpRequest, textStatus, errorThrown) {
        //                }
        //            });
        //        }
        if (!data) return;
        data = jQuery.parseJSON(data);
        dataDefault = data.Default;
        var dataSKU = data.SKUDATA;

        var i, j, skuKeys = getObjKeys(dataSKU);
        for (i = 0; i < skuKeys.length; i++) {
            var skuKey = skuKeys[i]; //一条SKU信息key
            var sku = dataSKU[skuKey]; //一条SKU信息value
            var skuKeyAttrs = skuKey.split(","); //SKU信息key属性值数组
            var len = skuKeyAttrs.length;

            //Fix SKU KEY NO SORT BEN ADD 20131112
            skuKeyAttrs.sort(function (value1, value2) {
                return parseInt(value1) - parseInt(value2);
            });
            skuKey = skuKeyAttrs.join(',');

            //对每个SKU信息key属性值进行拆分组合
            for (j = 0; j < len; j++) {
                //单个属性值作为key直接放入SKUResult
                add2SKUResult(skuKeyAttrs[j], sku);
                //对本组SKU信息key属性进行组合，组合个数为j
                (j > 0 && j < len - 1) && combineSKU(skuKeyAttrs, j, sku);
            }

            //结果集接放入SKUResult
            SKUResult[skuKey] = {
                count: sku.count,
                prices: [sku.price],
                rankprices: [sku.rankprice],
                skus: [sku.sku]
            };
        }
    }

    //初始化用户选择事件
    $(function () {
        if ($('#SKUOptions #SKUDATA').length != 1) return;
        InitializationSku();
        $('#SKUOptions .SkuItems').click(function () {
            var self = $(this);
            if (self.attr('disabled')) return false;

            var btnAddToCart = $('#SKUOptions').parent().find('#btnAddToCart');
            self.toggleClass('hover').siblings().removeClass('hover');

            //取消选择SKU图片时, 还原显示商品第一个主图
            var imgSel = self.find('img:eq(0)'), imgurl;
            if (self.hasClass('hover') && imgSel.length == 1) {
                imgurl = imgSel.attr('largeurl');
            }
            //            else {
            //                imgurl = $('.J_carousel_item:eq(0) img').attr('src');
            //            }
            if (imgurl) {
                imgurl = imgurl.replace('T350x350_', 'T300X390_');
                $('#samllImg').attr('jqimg', imgurl).attr('src', imgurl);

               // $("#samllImg").find("img").eq(0).attr({ ref: imgurl.replace('T32x32_', 'T300X390_'), jqimg: imgurl.replace('T32x32_', 'T300X390_'), original: imgurl.replace('T32x32_', 'T300X390_'), src: imgurl.replace('T32x32_', 'T300X390_') });
            }

            var selectedObjs = $('#SKUOptions .hover');
            if (selectedObjs.length) {
                //获得组合key价格
                var selectedIds = [];
                var selectValueStr = '已选择';
                var selectFormat = '<span class="h ml10">{0}</span>';
                selectedObjs.each(function () {
                    selectedIds.push($(this).attr('AttrId'));
                    selectValueStr += selectFormat.format('“' + $(this).attr('alt') + '”');
                });
                selectedIds.sort(function (value1, value2) {
                    return parseInt(value1) - parseInt(value2);
                });
                var len = selectedIds.length;
                if (!SKUResult[selectedIds.join(',')]) return false;
                var prices = SKUResult[selectedIds.join(',')].prices;
                //会员价格
                var rankprices = SKUResult[selectedIds.join(',')].rankprices;
                var maxrankPrice = Math.max.apply(Math, rankprices);
                var minrankPrice = Math.min.apply(Math, rankprices);

                var maxPrice = Math.max.apply(Math, prices);
                var minPrice = Math.min.apply(Math, prices);
                $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #stylePrice').text(
                    maxPrice > minPrice ? minPrice.toFixed(2) + "-" + maxPrice.toFixed(2) : maxPrice.toFixed(2));
                $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #rankPrice').text(
                    maxrankPrice > minrankPrice ? minrankPrice.toFixed(2) + "-" + maxrankPrice.toFixed(2) : maxrankPrice.toFixed(2));

                //用已选中的节点验证待测试节点 underTestObjs
                $('#SKUOptions .SkuItems').not(selectedObjs).not(self).each(function () {
                    var siblingsSelectedObj = $(this).siblings('#SKUOptions .hover');
                    var testAttrIds = []; //从选中节点中去掉选中的兄弟节点
                    if (siblingsSelectedObj.length) {
                        var siblingsSelectedObjId = siblingsSelectedObj.attr('AttrId');
                        for (var i = 0; i < len; i++) {
                            (selectedIds[i] != siblingsSelectedObjId) && testAttrIds.push(selectedIds[i]);
                        }
                    } else {
                        testAttrIds = selectedIds.concat();
                    }
                    testAttrIds = testAttrIds.concat($(this).attr('AttrId'));
                    testAttrIds.sort(function (value1, value2) {
                        return parseInt(value1) - parseInt(value2);
                    });
                    if (!SKUResult[testAttrIds.join(',')]) {
                        Status_SKUItem(this, false);
                    } else {
                        Status_SKUItem(this, true);
                    }
                });

                var skus = SKUResult[selectedIds.join(',')].skus;
                //添加购物车 设置 sku 数据
                if (selectedObjs.length == $('#SKUOptions .AttrItems').length &&
                    skus && skus.length == 1) {
                    $('#div_stock').show().find('#stock_num').text(SKUResult[selectedIds.join(',')].count);
                    btnAddToCart.attr('itemid', skus[0]);
                } else {
                    $('#div_stock').hide().find('#stock_num').text('');
                    btnAddToCart.attr('itemid', '');
                }
                //设置已选择
                $('#iteminfo #divSelectInfo').html(selectValueStr);

            } else {
                //设置默认价格
                $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #stylePrice').text(
                    dataDefault.maxPrice > dataDefault.minPrice ?
                        dataDefault.minPrice.toFixed(2) + "-" + dataDefault.maxPrice.toFixed(2) :
                        dataDefault.maxPrice.toFixed(2));
                $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #rankPrice').text(
                    dataDefault.maxRankPrice > dataDefault.minRankPrice ?
                        dataDefault.minRankPrice.toFixed(2) + "-" + dataDefault.maxRankPrice.toFixed(2) :
                        dataDefault.maxRankPrice.toFixed(2));
                //设置属性状态
                $('#SKUOptions .SkuItems').each(function () {
                    if (SKUResult[$(this).attr('AttrId')]) {
                        Status_SKUItem(this, true);
                    } else {
                        Status_SKUItem(this, false);
                    }
                });
                //清空已选择
                $('#iteminfo #divSelectInfo').empty();
                btnAddToCart.attr('itemid', '');
            }
        });

    });


    function InitializationSku() {
        initSKU();
        $('#SKUOptions .SkuItems').each(function () {
            var self = $(this);
            var attrId = self.attr('AttrId');
            if (!SKUResult[attrId]) {
                Status_SKUItem(self, false);
            } else {
                Status_SKUItem(self, true);
            }
        });

        if ($('#SKUOptions .SkuItems').length == $('#SKUOptions .SkuItems[disabled]').length) {
            $('#SKUOptions').parent().find('#btnAddToCart').removeClass('addCart').addClass('addCart-gray');
            $('#iteminfo #divBuyInfo').hide();
            $('#iteminfo #divSelectInfo').empty();
            $('#iteminfo #closeArrivingNotifyMess').show();
        } else {
            $('#SKUOptions').parent().find('#btnAddToCart').removeClass('addCart-gray').addClass('addCart').attr('itemid','');
            $('#iteminfo #divBuyInfo').show();
            $('#iteminfo #divSelectInfo').empty();
            $('#iteminfo #closeArrivingNotifyMess').hide();
        }
        $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #stylePrice').text(
            dataDefault.maxPrice > dataDefault.minPrice ?
                dataDefault.minPrice.toFixed(2) + "-" + dataDefault.maxPrice.toFixed(2) :
                dataDefault.maxPrice.toFixed(2));

        $('#SKUOptions').parents('.Productinfo:eq(0)').find('.productinfo-txt #rankPrice').text(
            dataDefault.maxRankPrice > dataDefault.minRankPrice ?
                dataDefault.minRankPrice.toFixed(2) + "-" + dataDefault.maxRankPrice.toFixed(2) :
                dataDefault.maxRankPrice.toFixed(2));

    }


    function Status_SKUItem(target, enabled) {
        if (enabled) {
            var skuItem = $(target).removeAttr('disabled').removeClass('none');
            skuItem.attr('title', skuItem.attr('alt'));
            skuItem.find('img:eq(0)').attr('title', skuItem.attr('alt'));
        } else {
            var skuItem = $(target).attr('disabled', 'disabled').removeClass('hover').addClass('none');
            skuItem.attr('title', skuItem.attr('alt') + ' 已售罄');
            skuItem.find('img:eq(0)').attr('title', skuItem.attr('alt') + ' 已售罄');
        }
    }
//})();