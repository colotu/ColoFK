

var index_obj={
	index_init:function(){
		for(i=0; i<shop_skin_data.length; i++){
			var obj=$("#shop_skin_index div").filter('[rel=edit-'+shop_skin_data[i]['Postion']+']');
			if(shop_skin_data[i]['ContentsType']==1){
				var dataImg=eval("("+shop_skin_data[i]['ImgPath']+")");
				var dataUrl=eval("("+shop_skin_data[i]['Url']+")");
				var dataTitle=eval("("+shop_skin_data[i]['Title']+")");
				var _banner='<div class="slider"><div class="flexslider"><ul class="slides">';
				for(var k=0; k<dataImg.length; k++){
					if(dataImg[k].indexOf('http://')!=-1){
						var s='';
					}else if(dataImg[k].indexOf('/u_file/')==-1){
						var s=static_domain;
					}else{
						var s='';
					}
					
					//var s=(dataImg[k].indexOf('/u_file/')==-1)?static_domain:'';
					if(shop_skin_data[i]['NeedLink']==1){
						_banner=_banner+'<li><a href="'+dataUrl[k]+'"><img src="'+s+dataImg[k]+'" alt="'+dataTitle[k]+'" /></a></li>';
					}else{
						_banner=_banner+'<li><img src="'+s+dataImg[k]+'" alt="'+dataTitle[k]+'" /></li>';
					}
				}
				var _banner=_banner+'</ul></div></div>';
				
				obj.find('.img').html(_banner);
				obj.find('.flexslider').flexslider({animation:"slide"});
				$('.flex-control-nav, .flex-direction-nav').remove();
			}else{
				var _Url='', s='';
				if(shop_skin_data[i]['NeedLink']==1){
					_Url=shop_skin_data[i]['Url']?shop_skin_data[i]['Url']:'';
				}
				
				//var s=(shop_skin_data[i]['ImgPath'].indexOf('/u_file/')==-1)?static_domain:'';
				var _Img=_Url?'<a href="'+_Url+'"><img src="'+shop_skin_data[i]['ImgPath']+'" /></a>':'<img src="'+shop_skin_data[i]['ImgPath']+'" />';
				var _Title=_Url?'<a href="'+_Url+'">'+shop_skin_data[i]['Title']+'</a>':shop_skin_data[i]['Title'];
				obj.find('.img').html(_Img);
				obj.find('.text').html(_Title);
			}
		}
		
		if($.isFunction(skin_index_init)){
			skin_index_init();	//风格的首页如果有JS，需全部写入本函数，如果直接写在index.php文件，在后台管理首页广告图片时，会把不必要的JS也执行了
		}
	}
}