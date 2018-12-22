<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" 
    CodeBehind="Modify.aspx.cs" Inherits="YSWL.MALL.Web.Admin.SNS.Groups.SNS_Groups.Modify"  Title="修改页" %>
<%@ Register TagPrefix="YSWL" Namespace="YSWL.Web.Validator" Assembly="YSWL.Web.Validator" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/admin/js/validate/pagevalidator.css" type="text/css" />
    <script type="text/javascript" src="/admin/js/validate/pagevalidator.js"></script>
    <link href="/admin/js/jquery.uploadify/uploadify-v3.1/uploadify.css" rel="stylesheet"
        type="text/css" />
    <script src="/admin/js/jquery.uploadify/uploadify-v3.1/jquery.uploadify-3.1.min.js"
        type="text/javascript"></script>
    <link href="/admin/js/jquery.uploadify/uploadify-v2.1.0/uploadify.css" rel="stylesheet"
        type="text/css" />
    <script src="/admin/js/jquery.uploadify/uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"
        type="text/javascript"></script>
    <!--jQueryUploadify Start-->
    <script type="text/javascript">
        $(document).ready(function () {
            $("#imgURL").attr('src', $("[id$='txtGroupLogo']").val());

            $("#uploadify").uploadify({
                'uploader': '/admin/js/jquery.uploadify/uploadify-v2.1.0/uploadify.swf',
                'script': '/CMSContent.aspx?action=uploadico',
                'cancelImg': '/admin/js/jquery.uploadify/uploadify-v2.1.0/cancel.png',
                'buttonImg': '/admin/images/uploadfile.png',
                'folder': 'UploadFile',
                'queueID': 'fileQueue',
                'auto': true,
                'multi': true,
                'fileExt': '*.jpg;*.gif;*.png;*.bmp',
                'fileDesc': 'Image Files (.JPG, .GIF, .PNG)',
                'queueSizeLimit': 1,
                'sizeLimit': 1024 * 1024 * 10,
                'onInit': function () {
                },

                'onSelect': function (e, queueID, fileObj) {
                },
                'onComplete': function (event, queueId, fileObj, response, data) {
                    var jsonData = eval("(" + response.split('|')[1] + ")");
                    switch (jsonData.Status) {
                        case "OK":
                            //将获取的值放在隐藏隐藏域中，供后台调用
                            $("#imgURL").attr("src", jsonData.SavePath);
                            $("[id$='txtGroupLogo']").val(jsonData.SavePath);
                            break;
                        case "Failed":
                            alert(jsonData.ErrorMessage);
                            break;
                    }
                }
            });
        });
    </script>
    <!--jQueryUploadify End-->
    <!--Select2 Start-->
    <link href="/Admin/js/select2-2.1/select2.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/select2-2.1/select2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () { $("[id$='dropParentID']").select2(); });
    </script>
    <!--Select2 End-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newslistabout">
        <div class="newslist_title">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="borderkuang">
                <tr>
                    <td bgcolor="#FFFFFF" class="newstitle">
                        <asp:HiddenField runat="server" ID="groupId"/>
                        <asp:Literal ID="Literal1" runat="server" Text="编辑小组" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" class="newstitlebody">
                        <asp:Literal ID="Literal2" runat="server" Text="您可以编辑小组" />
                    </td>
                </tr>
            </table>
        </div>
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tr>
                            <td class="td_class">
                                <asp:Literal ID="Literal3" runat="server" Text="小组名称" />：
                            </td>
                            <td>
                              <asp:TextBox runat="server" ID="txtGroupName"></asp:TextBox>
                            </td>
                        </tr>
                                                <tr>
                            <td class="td_class">
                                <asp:Literal ID="Literal17" runat="server" Text="小组描述" />：
                            </td>
                            <td>
                              <asp:TextBox ID="txtGroupDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="td_class" style="margin-top: 10px;">
                                <asp:Literal ID="Literal18" runat="server" Text="小组Logo" />：
                            </td>
                            <td height="25">
                                <asp:HiddenField ID="txtGroupLogo" runat="server" />
                                <div id="Div1">
                                </div>
                                <input type="file" name="uploadify" id="uploadify" />
                                <div class="msgNormal" style="margin-left: 100px; position: relative; margin-top: -32px;">
                                    <asp:Literal ID="Literal19" runat="server" Text="请将图片大小控制在10M以内！"></asp:Literal>
                                </div>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="td_class">
                            </td>
                            <td height="25">
                                <img id="imgURL" style="width: 120px; height: 120px;" />
                            </td>
                        </tr>
                        <tr>
                           <td class="td_class" style="margin-top: 10px;">
                                <asp:Literal ID="Literal4" runat="server" Text="标签" />：
                            </td>
                               <td height="25">
                               <asp:CheckBoxList runat="server" ID="chkTagsList" RepeatColumns="5" CellPadding="3" align="left" />
                               <td/>
                        </tr>
                        <tr>
                            <td class="td_class">
                            </td>
                            <td height="25">
                                <asp:Button ID="btnCancle" runat="server" CausesValidation="false" Text="<%$Resources:Site,btnCancleText %>"
                                    class="adminsubmit_short" OnClick="btnCancle_Click"></asp:Button>
                                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Site, btnSaveText %>"
                                    OnClick="btnSave_Click"  class="adminsubmit_short">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <YSWL:ValidatorContainer runat="server" ID="ValidatorContainer" />
</asp:Content>