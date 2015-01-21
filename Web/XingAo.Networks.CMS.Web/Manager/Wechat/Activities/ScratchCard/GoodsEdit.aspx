<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsEdit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard.GoodsEdit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
            #IsShow label,#txtKeyType label{float:none;}
    </style>
<div class="pageContent">
	<form id="form1" runat="server" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<div class="pageFormContent nowrap" layoutH="56">
         <h2 class="contentTitle">
            刮刮卡奖品设置</h2>
        <div class="unit">
            <label>
                奖品名：</label>
            <asp:textbox id="txtGoodsName" runat="server" cssclass="required" width="60%"></asp:textbox>
            <asp:hiddenfield id="txtID" runat="server" />
            <asp:hiddenfield id="txtSGuid" runat="server" />
        </div>
        <div class="unit">
            <label>奖品数量：</label>
            <asp:textbox id="txtGoodsCount" runat="server" cssclass="required"></asp:textbox>&nbsp;此奖品允许多少人抽中
        </div>
        <div class="unit">
            <label>已抽数量：</label>
            <asp:textbox id="txtUsedCount" runat="server"></asp:textbox>&nbsp;此奖品已被多少人抽走
        </div>
        <div class="unit" style=" line-height:21px;">
            <label>允许抽中的手机号码：</label>
            <asp:textbox id="txtAllowMob" runat="server" width="40%" height="80" textmode="MultiLine"></asp:textbox>&nbsp;每个手机号码一行，<br />如果不设置则表示所有人均有概率抽中此奖品
        </div>                        			
		</div>
		<div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div></li>
				<li>
					<div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
				</li>
			</ul>
		</div>
	</form>
</div>