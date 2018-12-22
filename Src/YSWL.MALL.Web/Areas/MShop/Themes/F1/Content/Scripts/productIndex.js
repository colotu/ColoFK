/**
* $itemname$.js
*
* 功 能： [N/A]
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  $time$  $username$    初版
*
* Copyright (c) $year$ YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

	var curTypeId = 0;
		var curFoodId = 0;
						curTypeId = 3843;
		
		var myScroll;
		var myScroll2;
		var myScroll3;

		function loaded() {
			myScroll = new IScroll("#wrapper", {
				click: true,
			});
			
			myScroll2 = new IScroll('#wrapper2', {
				eventPassthrough: false,
				preventDefault: false,
				useTransition: false,
			});
		}

		function loaded2() {
			myScroll3 = new IScroll("#wrapper3", {
				click: true,
			});
		}

		function scale(padding, border) {
		    var srcWidth = $( window ).width() - 50,
		        srcHeight = $( window ).height() - 100,
		        ifrPadding = 2 * padding,
		        ifrBorder = 2 * border,
		       	w, h;
		   
			    w = srcWidth;
			    h = srcHeight;

			    return {
			        'width': w - ( ifrPadding + ifrBorder ),
			        'height': h - ( ifrPadding + ifrBorder )
			    };
		}

		$('#shopindex-page').on("pageshow", function() {
		    //弹窗相关
		    $("#popupFoodinfo").on({
		        popupbeforeposition: function() {
		            var size = scale(15, 1),
		                w = size.width;
		            h = size.height;

		            $("#wrapper3").css("width", w);
		            $("#wrapper3").css("height", h);
		        },
		        popupafteropen: function() {
		            hideLoader();

		            //初始化滚动条相关的东西
		            setTimeout(function() { loaded2(); }, 200);
		        },
		        popupafterclose: function() {
		            $("#wrapper3").css("width", 0);
		            $("#wrapper3").css("height", 0);
		        },
		    });

		    //初始化滚动条相关的东西
		    setTimeout(function() { loaded(); }, 200);

		    document.getElementById('shopindex-page').addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
		});
 
		function showfoodinfo(food_id){
			showLoader();
            $.ajax({
		        type: "post",
		        url: $YSWL.BasePath+"p/d/"+food_id+"?viewName=_Detail",
		        dataType : "html",  
		        cache : false,
		        async: false,
		        success: function(resultData) {
		            $('#foodinfo-content').html(resultData);
		            setTimeout(function() {
		                  $('#popupFoodinfo').popup('open');
		            },100);
                    }
		    });
		    hideLoader(); 
		}

		function closefoodinfo(){
			$('#popupFoodinfo').popup('close');
		}

        var getCartTotalPrice=function(){
            $.ajax({
		        type: "post",
		        url:  $YSWL.BasePath + 'ShoppingCart/GetCartTotalPrice',
		        dataType : "json",  
		        cache : false,
		        async: false,
		        success: function(resultData) {
                       $('#order_totalnum').text(resultData.Quantity);//购物车数量
                       $('#order_totalprice').text(resultData.TotalAdjustedPrice);//购物车商品金额  
                    }
		    });
           
        };
        
        //减
		var order_dec_onclick = function(pid) {
            var count = parseInt($("#order_num_"+pid).text());
		    var itemId= $('#td_product_' + pid).attr('cartItemid');
		    if (count <= 0) {
		        return false;
		    }
            if (count == 1) {//删除
                 $.ajax({
                type: "POST",
                dataType: "text",
                async: false,
                url: $YSWL.BasePath +"ShoppingCart/RemoveItem",
                data: { ItemIds: itemId },
                success: function (data) {
                    if (data != "No") {
                         $("#foodattention_"+pid).removeClass('foodattention-active').addClass('foodattention');
                         $("#order_num_" + pid).text(count-1);
                         getCartTotalPrice();
                    } else {
                        ShowFailTip("服务器繁忙，请稍候再试！");
                    }
                }
             });
            } else {//修改
                $.ajax({
                    type: "POST",
                    dataType: "text",
                    async: false,
                    url: $YSWL.BasePath + "ShoppingCart/UpdateItemCount?s=" + new Date().format('yyyyMMddhhmmssS'),
                    data: { ItemId: itemId, Count: count - 1 },
                    success: function(data) {
                        if (data != "No") {
                            $("#order_num_" + pid).text(count-1);
                            getCartTotalPrice();
                        } else {
                            ShowFailTip("服务器繁忙，请稍候再试！");
                        }
                    }
                });
            }
		};
		
        //加
		var order_plus_onclick = function(pid) {
            var count =parseInt($("#order_num_"+pid).text());
		    if (count > 0) {
		        //修改	
		        var itemId= $('#td_product_' + pid).attr('cartItemid');
                $.ajax({
                type: "POST",
                dataType: "text",
                async: false,
                url: $YSWL.BasePath + "ShoppingCart/UpdateItemCount?s=" + new Date().format('yyyyMMddhhmmssS'),
                data: { ItemId: itemId, Count: count + 1 },
                success: function(data) {
                    if (data != "No") {
                        $("#order_num_" + pid).text(count+1);
                        getCartTotalPrice();
                    } else {
                        ShowFailTip("服务器繁忙，请稍候再试！");
                    }
                  }
              }); 
		    } else {
		        //添加
		        count = 1;
		        $.ajax({
                type: "POST",
                dataType: "json",
                async: false,
                url: $YSWL.BasePath + "ShoppingCart/AddCart?s=" + new Date().format('yyyyMMddhhmmssS'),
                data: { Productid: pid, Count: count },
                success: function(resultData) {
                    switch(resultData.STATUS) {
                         case "SUCCESS":
                            $('#td_product_' + pid).attr('cartItemid',resultData.DATA);
                            $("#order_num_" + pid).text(count);
                            $('#foodattention_' + pid).removeClass('foodattention').addClass('foodattention-active');
                            getCartTotalPrice();
                            return false;
                         case "FAILED":
                                switch (resultData.DATA) {
                                   case "NOSTOCK":
                                        ShowFailTip("库存不足！");
                                        return false;
                                   case "NOSKU":
                                   case "NO":
                                   default :
                                        ShowFailTip("服务器繁忙，请稍候再试！");
                                        return false;
                             }
                         default :
                            ShowFailTip("服务器繁忙，请稍候再试！");
                            return false;        
                    }
                  }
              });
            }
 
		};
		
	//显示
	 var foodtitleClick = function (pid) {
         var isOpenSku = $('#hidIsOpenSku').val();
         if (isOpenSku.toLowerCase() == "true") {//到详细页
             window.location.href = $YSWL.BasePath + "p/d/" + pid;
         } else {//直接显示加入购物车
             var $foodPid = $('#fooddetail_' + pid);
             if ($foodPid.is(":visible")) { //是否处于可见状态 
                 $foodPid.hide();
             } else {
                 $('[id^="fooddetail_"]').hide();
                 $('#fooddetail_' + pid).show();
             }
         }
     };
	 
	 //点击分类
     var foodtypeClick = function (cid) {
         window.location.href = $YSWL.BasePath + "p/" + cid;
     };
     
 
        //给已加入到购物车中的商品添加样式
		var activeCartProduct = function() {
		     $.ajax({
                type: "post",
                dataType: "text",
                async: false,
                url: $YSWL.BasePath + "ShoppingCart/GetCartList?s=" + new Date().format('yyyyMMddhhmmssS'),
                success: function(Data) {
                    $('#hidCartJson').val(Data);
                }
              });
           
              var hidCartVal=$('#hidCartJson').val();
		    //  $('[id^="foodattention_"]').removeClass('foodattention-active').addClass('foodattention');
		       if (hidCartVal) {
		            var json=JSON.parse(hidCartVal);
		            var jsonData = json.DATA;
		            var pid;
		            for(var i=0;i<jsonData.length;i++) {
		                pid = jsonData[i].productId;
		                if ($('#divfooditem_'+pid)) {//页面上存在此商品
                           $('#td_product_' + pid).attr('cartItemid',jsonData[i].itemId);
		                   $("#order_num_" + pid).text(jsonData[i].quantity);
                           $('#foodattention_' + pid).removeClass('foodattention').addClass('foodattention-active');
		                };
		           }
		        }
		};
 
    $(function() {
           if ($('#foodtype_' + $('#hidcid').val()).length > 0) {
              $('#foodtype_' + $('#hidcid').val()).addClass('active'); //选中当前分类
           }
        
        $('#order_next_text').click(function() {
             $.ajax({
		        type: "post",
		        url:  $YSWL.BasePath + 'ShoppingCart/GetCartTotalPrice',
		        dataType : "json",  
		        cache : false,
		        async: false,
		        success: function(resultData) {
		            if (parseInt(resultData.Quantity) > 0) {
		                location.href = $YSWL.BasePath + "Order/SubmitOrder";
		            } else {
		                ShowFailTip("您购物车中还没有商品,请先挑选喜欢的商品.");
		            }

		        }
		    });
        });


          // $('#foodListPage a').attr("data-ajax", "false");

		     getCartTotalPrice();
		     var isOpenSku = $('#hidIsOpenSku').val();
		     if (isOpenSku.toLowerCase() == "false") {//未开启sku，则回执已加入购物车效果
		         activeCartProduct();
		     }
		});	