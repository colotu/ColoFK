<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Step.aspx.cs" Inherits="YSWL.Web.Installer.Step" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>云商安装向导</title>
    <link href="/admin/css/admin.css" type="text/css" rel="stylesheet" charset="utf-8">
<link href="/Installer/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Installer/images/install.css" rel="stylesheet" type="text/css" />
        <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
        <link href="/Scripts/jBox/Skins/Blue/jbox.css" rel="stylesheet" type="text/css" />
        <script src="/Scripts/jBox/jquery.jBox-2.3.min.js" type="text/javascript"></script>
        <script src="/Scripts/jBox/i18n/jquery.jBox-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#wizardInstaller_chkSample").css("width", "18px");
            if ($('#HdImg').attr('src') == '/Installer/images/i10.jpg') {
                $('[id$=StartNextImageButton]').click(function () {
                    $.jBox.tip("正在初始化数据，请稍候......", 'loading');
                    return true;
                });
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap">
        <div class="header">
            <div class="header_a">
                <p class="logo">
                   <img src="/Installer/images/logo.png"/></p>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="main">
            <div class="nav" style="margin: 0px;min-width:0px">
                <p>
                <asp:Image ImageUrl="/Installer/images/i9.jpg" runat="server"  ID="HdImg"/>
                </p>
            </div>
            <div class="con">
                <asp:Wizard ID="wizard1" runat="server" Width="100%" DisplaySideBar="False"
                    ActiveStepIndex="0" NavigationStyle-HorizontalAlign="Center" OnFinishButtonClick="wizardInstaller_FinishButtonClick"
                    OnNextButtonClick="wizardInstaller_NextButtonClick" StartNextButtonType="Image" StartNextButtonImageUrl="/Installer/images/i9.png" >
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" AllowReturn="false">
                              <div class="jiance">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td colspan="2">
                                        <div style="color: Red">
                                            <b>
                                                <asp:Label ID="lblErrMessage" runat="server"></asp:Label>
                                            </b>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp; &nbsp; &nbsp;
                                        <p style=" font-size:15px"> <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:InstallerStep,IDS_FormField_SetpDesciption%>"></asp:Literal></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="120" height="40" align="right">
                                        <asp:Literal ID="lbldbServer" runat="server" Text="<%$ Resources:InstallerStep,IDS_FormField_Server%>"></asp:Literal>：
                                    </td>
                                    <td style="height: 23px">
                                        <asp:TextBox ID="txtdbServer" runat="server" Style="width: 200px" Text="(local)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="93" height="40" align="right">
                                        <asp:Literal ID="literalPort" runat="server" Text="<%$ Resources:InstallerStep,IDS_FormField_Port%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdbPort" runat="server" Style="width: 200px" Text="1433"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="93" height="40" align="right">
                                        <asp:Literal ID="lbldbName" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FormField_dbName%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdbName" runat="server" Style="width: 200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="93" height="40" align="right">
                                        <asp:Literal ID="lbldblogin" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FormField_dbLogin%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdbLogin" runat="server" Style="width: 200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="93" height="40" align="right">
                                        <asp:Literal ID="lbldbpasword" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FormField_dbPassword%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:Literal ID="litPassword" runat="server" Visible="False"></asp:Literal>
                                        <asp:TextBox ID="txtdbPassWord" runat="server" Style="width: 200px" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" StepType="Start" AllowReturn="false">
                             <div class="jiance">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td colspan="2">
                                        <div style="color: Red">
                                            <b>
                                                <asp:Label ID="litSetpErrorMessage" runat="server"></asp:Label>
                                            </b>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="120" height="40" align="right">
                                        <asp:Literal ID="lblUserName" runat="server" EnableViewState="False" Text="管理员"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserName" runat="server" Style="width: 200px" Text="admin"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="120" height="40" align="right">
                                        <asp:Literal ID="lblPwd" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_Password%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" Style="width: 200px" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td width="120" height="40" align="right">
                                        <asp:Literal ID="lblPwdAgain" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_ComPassword%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPasswordCompare" runat="server" Style="width: 200px" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="120" height="40" align="right">
                                        <asp:Literal ID="Literal4" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_Email%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Style="width: 200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                       <td width="120" height="40" align="right">
                                            <asp:Literal ID="Literal16" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_DefalutData%>"></asp:Literal>：
                                    </td>
                                    <td>
                                      <div  style=" width:80px">
                                                <asp:CheckBox ID="chkSample" runat="server" Text="添加" Checked="True"  />
                                               </div>
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="zhushi">
                                        <asp:Literal ID="Literal17" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_Zhushi%>"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                     <td width="120" height="40" align="right">
                                        <asp:Literal ID="Literal2" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_SiteName%>"></asp:Literal>：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSiteName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                        <td width="120" height="40" align="right">
                                        <asp:Literal ID="Literal3" runat="server" EnableViewState="False" Text="<%$ Resources:InstallerStep,IDS_FromField_SiteDescription%>"></asp:Literal>：
                                    </td>
                                    <td>
                                       <asp:TextBox ID="txtDesciption" runat="server" TextMode="MultiLine" Rows="3"  CssClass="DesciptionClass"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </asp:WizardStep>
                    </WizardSteps>
                      <NavigationStyle HorizontalAlign="Center" />
            <NavigationButtonStyle  Width="88" Height="28" />
                </asp:Wizard>
            </div>
        </div>
    </div>


    
    <%--  </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
