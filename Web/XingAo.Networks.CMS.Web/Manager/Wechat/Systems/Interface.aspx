<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Interface.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Systems.Interface" %>

<div class="pageContent">
    <div class="pageFormContent nowrap">
        <h2 class="contentTitle">微信接口</h2>
         <div class="unit">
			<label>Url：</label>
            <asp:literal runat="server" ID="ApiLi"></asp:literal>
		 </div>
         <div class="unit">
			<label>Token：</label>
            <asp:literal runat="server" ID="TokeLi"></asp:literal>
		 </div>
        <div class="unit">
            <label>&nbsp;</label>
            复制上面链接拷贝到公众微信平台高级接口开发者中心，填写URL和Token
            <div><img src="/images/Token.jpg"  alt="" /></div>
         </div>
    </div>
</div>