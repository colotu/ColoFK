<%@ Page Language="C#" MasterPageFile="~/Admin/Basic.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="YSWL.MALL.Web.Admin.SNS.Groups.SNS_Groups.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		小组的id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组的名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组的简介
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组成员的人数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupUserCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建者ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreatedUserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建者
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreatedNickName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreatedDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组的logo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupLogo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GroupLogoThumb
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupLogoThumb" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组的背景图片
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupBackground" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		申请创建小组的理由
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblApplyGroupReason" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		0 不推荐 1推荐到小组首页 
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsRecommand" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组话题的个数()
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTopicCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		小组一共有多少个回复(后加)
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTopicReplyCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		状态(0未审核
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		顺序
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSequence" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		预留字段（邀请链接才可加入）
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPrivacy" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		标签
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTags" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




