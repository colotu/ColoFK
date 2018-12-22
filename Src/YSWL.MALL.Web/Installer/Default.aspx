<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YSWL.Web.Installer.Default" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>安装向导</title>

<link href="/Installer/css/style.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
<link href="/Scripts/jBox/Skins/Blue/jbox.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jBox/jquery.jBox-2.3.min.js" type="text/javascript"></script>
<script src="/Scripts/jBox/i18n/jquery.jBox-zh-CN.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#btnNext").click(function() {
            window.location = "/Installer/Check.aspx?type=accepted";
            $.jBox.tip("正在检测安装环境，请稍候...", 'loading');
        });
    })
</script>
</head>
<body>
<div id="wrap">
  <div class="header">
     <div class="header_a">
       <p class="logo"><img src="/Installer/images/logo.png"/></p>
     <div class="clear"></div>
     </div>
  </div>
  <div class="main">
     <!-- <h1>Fixed Header Slide</h1> -->
     <%--<script type="text/javascript">
         $(document).ready(function () {
             // 1. grab a bunch of variables
             var $container = $('#box');
             var $headers = $container.find('h2');
             var zIndex = 2;
             var containerTop = $container.offset().top + parseInt($container.css('marginTop')) + parseInt($container.css('borderTopWidth'));
             var $fakeHeader = $headers.filter(':first').clone();

             // 2. absolute position on the h2, and fix the z-index so they increase
             $headers.each(function () {
                 // set position absolute, etc
                 var $header = $(this), height = $header.outerHeight(), width = $header.outerWidth();

                 zIndex += 2;

                 $header.css({
                     position: 'absolute',
                     width: $header.width(),
                     zIndex: zIndex
                 });

                 // create the white space
                 var $spacer = $header.after('<div />').next();
                 $spacer.css({
                     height: height,
                     width: width
                 });
             });

             // 3. bind a scroll event and change the text of the take heading
             $container.scroll(function () {
                 $headers.each(function () {
                     var $header = $(this);
                     var top = $header.offset().top;

                     if (top < containerTop) {
                         $fakeHeader.text($header.text());
                         $fakeHeader.css('zIndex', parseInt($header.css('zIndex')) + 1);
                     }
                 });
             });

             // 4. initialisation
             $container.wrap('<div class="box" />');
             $fakeHeader.css({ zIndex: 1, position: 'absolute', width: $headers.filter(':first').width() });
             $container.before($fakeHeader.text($headers.filter(':first').text()));

         });
</script>--%>

     <div class="box_box">
        <div class="box" id="box">
        <h2><%=strTitle%>授权许可协议</h2>
        <p>云商未来（北京）科技有限公司为<%=strTitle%>的开发商，依法独立拥有<%=strTitle%>的著作权。<%=strTitle%>的官方网站为 <a href="http://www.ys56.com"  target="_blank">http://www.ys56.com</a>，是<%=strTitle%>产品的开发商。
<%=strTitle%>著作权受到法律和国际公约保护。使用者：无论个人或组织、盈利与否、用途如何（包括以学习和研究为目的），均需仔细阅读本协议，在理解、同意、并遵守本协议的全部条款后，方可开始使用<%=strTitle%>。
本授权协议适用于<%=strTitle%>各个版本，云商未来（北京）科技有限公司拥有对本授权协议的最终解释权。

<h3>协议许可的权利</h3>

<p>您可以在协议规定的约束和限制范围内修改<%=strTitle%>源代码(如果被提供的话)或界面风格以适应您的网站要求。 
您拥有使用本软件构建的网站中全部会员资料、文章及相关信息的所有权，并独立承担与文章内容的相关法律义务。 
获得商业授权之后，您可以将本软件应用于商业用途，同时依据所购买的授权类型中确定的技术支持期限、技术支持方式和技术支持内容，自购买时刻起，在技术支持期限内拥有通过指定的方式获得指定范围内的技术支持服务。商业授权用户享有反映和提出意见的权力，相关意见将被作为首要考虑，但没有一定被采纳的承诺或保证。
</p>
<h3>协议规定的约束和限制</h3>

<p>未获商业授权之前，不得将本软件用于商业用途（包括但不限于政府、企业网站、经营性网站、以营利为目或实现盈利的网站）。购买商业授权请登陆 <a href="http://www.ys56.com"  target="_blank">http://www.ys56.com</a>参考相关说明。
不得对本软件或与之关联的商业授权进行出租、出售、抵押或发放子许可证。 
无论如何，即无论用途如何、是否经过修改或美化、修改程度如何，只要使用<%=strTitle%>的整体或任何部分，未经书面许可，网站页面页脚处的<%=strTitle%>名称和 <a href="http://www.ys56.com"  target="_blank">http://www.ys56.com</a>的链接都必须保留，而不能清除或修改，除非您获得云商公司授权许可。 
您同意不对<%=strTitle%>进行修改制作衍生作品、反编译、逆向工程、反汇编，或以其他方式试图从本“软件”取得源代码，或从“软件”文档中摘取其实质部分作其他应用。
禁止在<%=strTitle%>的整体或任何部分基础上以发展任何派生版本、修改版本或第三方版本用于重新分发。 
如果您未能遵守本协议的条款，您的授权将被终止，所被许可的权利将被收回，并承担相应法律责任。
</p>
<h3>有限担保和免责声明</h3>

<p>本软件及所附带的文件是作为不提供任何明确的或隐含的赔偿或担保的形式提供的。 
用户出于自愿而使用本软件，您必须了解使用本软件的风险，在尚未购买产品技术服务之前，我们不承诺提供任何形式的技术支持、使用担保，也不承担任何因使用本软件而产生问题的相关责任。 
云商未来（北京）科技有限公司不对使用本软件构建的网站中的文章或信息承担责任。 
有关<%=strTitle%> 最终用户授权协议、商业授权与技术服务的详细内容，均由云商官方网站独家提供。云商未来（北京）科技有限公司拥有在不事先通知的情况下，修改授权协议和服务价目表的权力，修改后的协议或价目表对自改变之日起的新授权用户生效。
</p>
<h3>协议终止</h3>
<p>
电子文本形式的授权协议如同双方书面签署的协议一样，具有完全的和等同的法律效力。您一旦开始安装<%=strTitle%>，即被视为完全理解并接受本协议的各项条款，在享有上述条款授予的权力的同时，受到相关的约束和限制。协议许可范围以外的行为，将直接违反本授权协议并构成侵权，我们有权随时终止授权，责令停止损害，并保留追究相关责任的权力。
</p>
<p>
云商未来（北京）科技有限公司保留所有权利。
</p></div>
     </div>
     <div class="footer">
        <div class="footer_b" style=" text-align:center; width:680px"><a href="javascript:void(0)" id="btnNext"><img src="/Installer/images/i5.png"/></a></div>
     <div class="clear"></div>
     </div>
  <div class="clear"></div>
  </div>
</div>
</body>
</html>
