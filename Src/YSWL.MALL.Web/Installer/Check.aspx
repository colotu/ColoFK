<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="YSWL.Web.Installer.Check" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>环境检测</title>

<link href="/Installer/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/Scripts/jBox/Skins/Blue/jbox.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jBox/jquery.jBox-2.3.min.js" type="text/javascript"></script>
    <script src="/Scripts/jBox/i18n/jquery.jBox-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnNextStep").click(function () {
                var isPassed = $("#IsChechPass").val();
                if (isPassed == "True") {
                    window.location = "/Installer/Step.aspx";
                }
                else {
                    alert("环境检查未通过，请检查您的系统环境");
                }
            });
            $("#btnCheck").click(function () {
                $.jBox.tip("正在重新检测安装环境，请稍候...", 'loading');
            });
        })
    </script>
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
        <p><img src="/Installer/images/i6.jpg"/></p>
     </div>
        <div class="con">
            <h2 style="padding-top: 30px">
                环境检测</h2>
            <asp:HiddenField ID="IsChechPass" runat="server" />
            <table cellpadding="0" cellspacing="3" border="0" class="jiance" style="">
                <tr>
                    <td colspan="2">
                        <div class="msgNormal" style="color: Gray">
                            <b>
                                <asp:Literal ID="Label3" runat="server">Tip：.NET 版本要求是4.5.2以上，数据库要求是 SQL Server 2008 及以上</asp:Literal>
                            </b>
                        </div>
                    </td>
                </tr>
                <tr style=" display:none">
                    <td style="height: 23px; width: 360px">
                        操作系统
                    </td>
                    <td style="height: 23px">
                        <asp:Image ID="imgSystem" runat="server" ImageUrl="/Installer/images/ok.gif" />
                    </td>
                </tr>
                   <tr style="height: 36px">
                    <td class="inputstyle">
                        .NET 版本
                    </td>
                    <td>
                        <asp:Image ID="imgNetVersion" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                <tr style="display: none">
                    <td class="inputstyle">
                        SQL Server数据库版本
                    </td>
                    <td>
                        <asp:Image ID="imgSqlVersion" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
              <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Upload目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgUpload" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                   <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Temp目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgTemp" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
               <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        User目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgUser" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                 <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Gravatar目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgGravatar" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                 <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Scripts目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgScripts" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                  <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Content目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgContent" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
                
                <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Admin目录读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgAdmin" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
              <tr style="height: 36px">
                    <td class="inputstyle" style="height: 23px">
                        Web.config文件读写权限
                    </td>
                    <td>
                        <asp:Image ID="imgConfig" runat="server" ImageUrl="/Installer/images/error.gif" />
                    </td>
                </tr>
            </table>
            </div>

            <div class="footer">
     <div class="footer_a"><a href="javascript:void(0)" id="btnNextStep">  <img src="/Installer/images/i9.png" /></a></div>
        <div class="footer_b"> <asp:Button ID="btnCheck" runat="server" Text="重新检测"  
                CssClass="ButtonClass"  Height="28px"
                            OnClick="btnCheck_Click" Width="111px" /></div>
     <div class="clear"></div>
     </div>
  <div class="clear"></div>
            <%--<div class="cons">
                <ul>
                    <li style="display: none"><a href="Default.aspx">
                        <img src="/Installer/images/4.jpg" /></a></li>
                    <li><a href="javascript:void(0)" id="btnNextStep">
                        <img src="/Installer/images/5.jpg" /></a></li>
                    <li>
                        <asp:Button ID="btnCheck" runat="server" Text="重新检测"  CssClass="adminsubmit"
                            OnClick="btnCheck_Click" />
                    </li>
                </ul>
            </div>--%>
        </div>
    </div>
    </form>
</body>
</html>
