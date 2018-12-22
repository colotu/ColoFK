<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuppAreasDropList.ascx.cs" Inherits="YSWL.MALL.Web.Controls.SuppAreasDropList" %>
<script src="/Scripts/jquery/jquery.guid.js" type="text/javascript"></script>
<div><asp:HiddenField ID="hfSelectedNode" runat="server" /></div>
<script src="/Scripts/jquery/maticsoft.selectnode.js" handle="/ShopSuppArea.aspx" isnull="<%= this.IsNull.ToString().ToLower() %>" type="text/javascript"></script>