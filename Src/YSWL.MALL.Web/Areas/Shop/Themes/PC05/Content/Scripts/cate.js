function cateAllFloat() {
    var topAll = $('#cate_all_idx'),
    navUl = $('.nav-ul');
    //if (topAll.length > 0) {
    if ($IsHomePage) { //首页分类展示效果
      
      //显示分类列表
        $(".product-lists").slideDown(function () {
            $('#js-navall').addClass("js-hover");
        });
         
        //点击全部分类
        $('#js-navall').click(function () {
            $(".product-lists").slideToggle(function () {
                $('#js-navall').toggleClass("js-hover");
            });
        });

        //分类跟随屏幕
        var offsetLeft = topAll.width(),
			topAllLeft = topAll.offset().left,
			offsetTop = 120,
			st = 0;
		$(window).scroll(function(){
			st = $(window).scrollTop();
			if(st > offsetTop){
				//var s_w = screen.width;					//显器宽度
				topAll.css({
					'position' : 'fixed',
					'top' : 0,
					'left' : topAllLeft - $(window).scrollLeft() + 'px'
					/*'left' : '50%',
					'margin-left' : (s_w >= 1280 ? '-615px' : -615 + (1280 - s_w) / 2 + 'px')*/
				});
				navUl.css('margin-left', offsetLeft + 'px');
			}
			else{
				topAll.removeAttr('style');
				navUl.removeAttr('style');
			}
        });
 
 //超出浏览器高度显示滚动条
$('[id^="product_cate_"]').css({ 'overflow-y': 'auto', 'max-height': $(window).height() - $('#js-navall').height() - 12 });
 
} else {

       //其他页面分类展示效果
        $('#cate_all_idx').hover(function () {
            $(".product-lists").show();
            $('#js-navall').addClass("js-hover");
        }, function () {
            if (!$('.product-lists').is(':hidden')) {
                $(".product-lists").hide();
                $('#js-navall').removeClass("js-hover");
            }
        });

}
	function scopeOf(proLists, x, y){
		return ((x+$(window).scrollLeft())>=proLists.offset().left && (x+$(window).scrollLeft())<=(parseInt(proLists.offset().left)+parseInt(proLists.width())) && (y+$(window).scrollTop())>=proLists.offset().top && (y+$(window).scrollTop())<=(parseInt(proLists.offset().top)+parseInt(proLists.height())));
	}
};

$(document).ready(function () {
    //子分类显示隐藏
    $('.product-listsA dl').unbind('hover').hover(function () {
        $(this).addClass('on').siblings().removeClass('on');
        $('[id^="product_cate_"]').hide();
        $('#product_cate_' + $(this).attr('cid')).show();
    });
    //鼠标离开
    $('.product-lists').bind('mouseleave', function () {
        $('[id^="product_cate_"]').hide();
        $('.product-listsA dl').removeClass('on');
    });
    //定位子分类框的高度与左边一级分类高度一致
    $('[id^="product_cate_"]').css('min-height', $('.product-lists').height() - $('#d_cate_bmbg').height() - 10);
    //所有分类展示效果
    cateAllFloat();
});


 

