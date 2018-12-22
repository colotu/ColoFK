/************************************工具函数************************************/
function jsTrim(str) 
{
	return str.replace(/(^\s*)|(\s*$)/g,"");
}

//将小数点清零
function returnFloat0(value) 
{      
	value = Math.round(parseFloat(value));
    return value;
}
 
 //保留一位小数点
function returnFloat1(value) 
{    
	value = Math.round(parseFloat(value) * 10) / 10;
    if (value.toString().indexOf(".") < 0)
    	value = value.toString() + ".0";
    return value;
}
 
  //保留两位小数点
function returnFloat(value)
{    
	value = Math.round(parseFloat(value) * 100) / 100;
    if (value.toString().indexOf(".") < 0) 
    {
    	value = value.toString() + ".00";
    }
    return value;
}

/************************************ 全局js ***********************************/
//显示加载器  
function showLoader() {
    $.mobile.loading('show', {
        text: '加载中...',		//加载器中显示的文字  
        textVisible: false,	//是否显示文字  
        theme: 'a',			//加载器主题样式a-e  
        textonly: false,	//是否只显示文字  
        html: ""			//要显示的html内容，如图片等  
    });
}

//隐藏加载器
function hideLoader()
{
    //隐藏加载器
    $.mobile.loading('hide');
}

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
//检查是否登录
var CheckUserState = function () {
    var islogin;
    var url = $.getUrlMiddle();
    $.ajax({
        url: $YSWL.BasePath + "Account/AjaxIsLogin",
        type: 'post',
        dataType: 'text',
        async: false,
        success: function (resultData) {
            if (resultData != "True") {
                //dialog层中项的设置
                location.href = $YSWL.BasePath + "a/l?returnUrl=" + url;
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

//收藏操作
var productFav = function(pid) {
    if (CheckUserState()) {
        $.ajax({
            type: "POST",
            dataType: "text",
            url: $YSWL.BasePath + "u/AjaxAddFav",
            async: false,
            data: { ProductId: pid },
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
};
 
 
