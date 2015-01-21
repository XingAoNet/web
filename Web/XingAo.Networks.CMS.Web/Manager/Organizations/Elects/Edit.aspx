<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Organizations.Elects.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
	ul.rightTools {float:right; display:block;}
	ul.rightTools li{float:left; display:block; margin-left:5px}
</style>

<div class="pageContent">

   <form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
	   <div class="pageFormContent nowrap" layoutH="58">	  
        <dl>
			<dt>时间：</dt>
			<dd>
                <asp:TextBox ID="txtDate" runat="server" CssClass="date" size="30" ></asp:TextBox><a class="inputDateButton" href="javascript:;">选择</a>
                <asp:HiddenField ID="txtID" runat="server" />
            </dd>
		</dl>
        <dl>
			<dt>主题：</dt>
			<dd>
                <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </dd>
		</dl>
        <dl>
			<dt>主持人：</dt>
			<dd>
                <asp:TextBox ID="txthost" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </dd>
		</dl>
        <dl>
			<dt>纲要：</dt>
			<dd>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                    Height="100px" Width="80%"></asp:TextBox>
            </dd>
		</dl>
    </div>
        <div class="formBar rightTools">
	    <ul>
		    <li><div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div></li>
		    <li>
			    <div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
		    </li>
	    </ul>
        </div>
    </form>

</div>