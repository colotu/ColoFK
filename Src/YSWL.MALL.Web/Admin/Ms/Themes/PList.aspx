<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PList.aspx.cs" Inherits="YSWL.MALL.Web.Admin.Ms.Themes.PCList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="http://static.yuns56.cn/css/common.min.css?v=1.0" rel="stylesheet" />
    <link href="http://static.yuns56.cn/lib/msgbox-2.0/css/msgbox.min.css" rel="stylesheet" />
    

    <%--<link href="../../js/colorbox/colorbox.css" rel="stylesheet" />--%>
    <link href="../../../Scripts/Swiper-2.7.6/idangerous.swiper.css" rel="stylesheet" />
    <script src="http://static.yuns56.cn/lib/jquery-2.2.4.min.js"></script>
    <script src="http://static.yuns56.cn/lib/msgbox-2.0/js/msgbox.min.js"></script>
    <script src="http://static.yuns56.cn/lib/yswl.jquery.min.js"></script>
    <script src="../../../Scripts/Swiper-2.7.6/idangerous.swiper.min.js"></script>
    <%--<script src="../../js/colorbox/jquery.colorbox-min.js"></script>--%>
    <link href="http://static.yuns56.cn/lib/colorbox-1.6.4/colorbox.min.css" rel="stylesheet"/>
<script src="http://static.yuns56.cn/lib/colorbox-1.6.4/jquery.colorbox.min.js"></script>
<style>
.swiper-container {
    width: 735px;
    height: 394px;
}
.swiper-slide {
    width: 735px;
    height: 394px;
}
</style> 
</head>
<body>
<!-- 外层包裹的类（实现左右上间隙） -->

<div class="standard-page-wrapper">
  <div class="mall-template pc-mall">
    <div class="template-container" id="tab_a">
      <div class="template-item">
        <div class="template-text">选择模板：</div>
        <div class="right-item">
          <div class="">
            <!-- start 表单切换按钮 -->
            <ul class="toggle-button">
              <li><a class="tab-active" href="javascript:;">B2C模板</a></li>
              <li><a href="javascript:;">B2B模板</a></li>
            </ul>
            <!-- end 表单切换按钮 -->
          </div>
        </div>
      </div>
      <div class="template-item">
        <div class="template-text">访问地址：</div>
        <div class="right-item"><a class="s-lk" href="http://PC01.yuns56.com/">http://PC01.yuns56.com/</a></div>
      </div>
      <div class="template-item">
        <div class="template-text">选择模板样式：</div>
        <div class="right-item">
        <!-- start tab切换主体 -->
          <ul class="template-content">
            <li>
              <div class="template-box selected">
                <div class="s-title">PC01模板-4种颜色可选</div>
                <div class="box-item">
                  <div class="thumbnail-box">
                    <img src='<%#Eval("PreviewPhotoSrc") %>' title="<%#Eval("Description") %>" />
                    <img src="../../img/PC01-orange1.jpg" alt=""/>
                  </div>
                  <div class="thumbnail-box">
                    <img src="../../img/PC01-orange2.jpg" alt=""/>
                  </div>
                </div>
              </div>
              <!-- 未选中 -->
              <div class="template-box">
                <div class="s-title">PC02模板-1种颜色可选</div>
                <div class="box-item">
                  <div class="thumbnail-box">
                    <img src="../../img/PC01-red1.jpg" alt="">
                  </div>
                  <div class="thumbnail-box">
                    <img src="../../img/PC01-red2.jpg" alt="">
                  </div>
                </div>
              </div>
            </li>
            <li class="hidden">
              <div class="template-box selected">
                <div class="s-title">PC01模板-4种颜色可选</div>
                <div class="box-item">
                  <div class="thumbnail-box">
                    <img src="../../img/PC01-orange1.jpg" alt="">
                  </div>
                  <div class="thumbnail-box">
                    <img src="../../img/PC01-orange2.jpg" alt="">
                  </div>
                </div>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- 弹窗 -->
<div style="display:none;">
  <div class="standard-popUp" id="c_box_cont">
    <!--start 弹窗内容 -->
    <div class="s-popUp-content template-content pc-mall">
      <div class="box-item">
          <div class="swiper-container">
            <div class="swiper-wrapper">
              <div class="swiper-slide">
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange1.jpg" alt=""/>
                </div>
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange2.jpg" alt=""/>
                </div>
              </div>
              <div class="swiper-slide">
                <div class="thumbnail-box">
                  <img src="../../img/PC01-red1.jpg" alt=""/>
                </div>
                <div class="thumbnail-box">
                  <img src="../../img/PC01-red2.jpg" alt=""/>
                </div>
              </div>
              <div class="swiper-slide">
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange1.jpg" alt=""/>
                </div>
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange2.jpg" alt=""/>
                </div>
              </div>
              <div class="swiper-slide">
                <div class="thumbnail-box">
                  <img src="../../img/PC01-red1.jpg" alt=""/>
                </div>
                <div class="thumbnail-box">
                  <img src="../../img/PC01-red2.jpg" alt=""/>
                </div>
              </div>
              <div class="swiper-slide">
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange1.jpg" alt=""/>
                </div>
                <div class="thumbnail-box">
                  <img src="../../img/PC01-orange2.jpg" alt=""/>
                </div>
              </div>
            </div>
          </div>
      </div>
      <div class="toggle-color">
        <div class="template-color-box actived tc1 clearfix">
          <span class="small-box"></span>
          <span class="small-box"></span>
          <span class="small-box"></span>
        </div>
        <div class="template-color-box tc2 clearfix">
          <span class="small-box"></span>
          <span class="small-box"></span>
          <span class="small-box"></span>
        </div>
        <div class="template-color-box tc3 clearfix">
          <span class="small-box"></span>
          <span class="small-box"></span>
          <span class="small-box"></span>
        </div>
        <div class="template-color-box tc4 clearfix">
          <span class="small-box"></span>
          <span class="small-box"></span>
          <span class="small-box"></span>
        </div>
        <div class="template-color-box tc5 clearfix">
          <span class="small-box"></span>
          <span class="small-box"></span>
          <span class="small-box"></span>
        </div>
      </div>
    </div>

    <!-- end 弹窗内容 -->
    <!--start 弹窗底部按钮 -->
    <div class="popUp-buttonwrapper popUp-buttonwrapper-bg">
      <button type="submit" class="s-button-default s-btn-def-cancel s-btn-intervals" onclick="return $.colorbox.close();">取消</button>
      <button type="submit" class="s-button-default s-btn-def-submit" >保存</button>
    </div>
    <!--end 弹窗底部按钮 -->
  </div>
</div>
<script>
    //渲染商城模板数据
    $.ajax({
        url: "",
        type: 'POST',
        async: false,
        cache: false,
        dataType: 'json',
        data: {},
        success: function (resultData) {
            if (resultData.STATUS == "SUCCESS") {
                ShowSuccessTip('设置成功');
                _self.addClass('cur').siblings().removeClass('cur');
            } else {
                ShowFailTip('服务器繁忙，请稍候再试！');
            }
        }
    });
    //tab切换效果
    function tab_switch1(ele_id, activeclass) {
        $("#" + ele_id + " .toggle-button").children().each(function () {
            var xh = $(this).index();
            $(this).find("*").click(function () {
                $(this).addClass(activeclass);
                $(this).parent().siblings().find("*").removeClass(activeclass);
                $("#" + ele_id + " .template-content").find("li").addClass("hidden");   
                $("#" + ele_id + " .template-content").find("li").eq(xh).removeClass("hidden");
            })
        });
    }
    //根据ID调用菜单切换函数
    tab_switch1("tab_a", "tab-active");
// 切换模板样式
$(".template-box").click(function(){
  $(this).addClass("selected");
  $(this).siblings(".template-box").removeClass("selected");
  $.colorbox({ inline: true, href: "#c_box_cont", width: 880, overlayClose: false });
    })


// 弹窗切换模板颜色
var tabsSwiper = new Swiper('.swiper-container', {
    onlyExternal: true,    
    speed: 5
})
$(".template-color-box").on('touchstart mousedown', function (e) {
    e.preventDefault()
    $(".template-color-box.actived").removeClass('actived')
    $(this).addClass('actived')
    tabsSwiper.swipeTo($(this).index())
})
$(".template-color-box").click(function (e) {
    e.preventDefault()
})
function switchTemplate() {
}
</script> 
</body>
</html>
