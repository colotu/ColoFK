<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complete.aspx.cs" Inherits="YSWL.Web.Installer.Complete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>完成</title>
    <link href="/Installer/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap">
        <div class="header">
     <div class="header_a">
       <p class="logo"><img src="/Installer/images/logo.png"/></p>
     <div class="clear"></div>
     </div>
  </div>
        <div class="main">
            <div class="nav">
                   <p><img src="/Installer/images/i11.jpg" /></p>
            </div>
            <div class="con">
                <h2 style="font-size: 16px; font-family: @微软雅黑;">
                    安装成功</h2>
                <div style="font-size: 14px; font-family: @微软雅黑; line-height: 24px; width: 540px">
                    恭喜! 您已经成功安装，为了安全，请及时删除install目录下的aspx文件
                    <br />
                    登录 <a href="/Admin/login.aspx">管理后台</a> 进行站点设置,或者点击进入 <a href="/">首页 </a>。 为了保障安全，强烈建议到YSWL官方网站下载安装程序
                </div>
            </div>
            <div class="footer">
                <div class="footer_a">
                    <a href="/">
                        <img src="/Installer/images/i12.png" /></a></div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
