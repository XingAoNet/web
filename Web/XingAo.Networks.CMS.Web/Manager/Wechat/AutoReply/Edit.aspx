<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.AutoReply.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
<div class="pageContent">
	<div class="pageFormContent nowrap" layoutH="56">
        <dl>
		    <dt>回复名称：</dt>
		    <dd>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                <asp:HiddenField ID="txtID" runat="server" />
            </dd>
	    </dl>
        <dl>
		    <dt>键值：</dt>
		    <dd>
                <asp:TextBox ID="txtReplyKey" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </dd>
            </dl>
        
        <dl>
		    <dt>描述：</dt>
		    <dd>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                    Height="40px" Width="80%"></asp:TextBox>
            </dd>
	    </dl>
        <dl>
		    <dt>图片：</dt>
		    <dd>
                <asp:TextBox ID="txtPicUrl" runat="server" Width="80%"></asp:TextBox>
                <input type="button" id="uploadButton-txtPicUrl" value="选择图片" class="Pic_Upload_File">
            </dd>
	    </dl>
        <dl>
		    <dt>外部链接：</dt>
		    <dd>
                <asp:TextBox ID="txtUrl" runat="server" Width="80%"></asp:TextBox>
            </dd>
	    </dl>
        <dl>
		    <dt>回复内容：</dt>
		    <dd>
                <asp:TextBox ID="txtReplyContent" runat="server" CssClass="editor" TextMode="MultiLine" 
                    Height="360px" Width="760"></asp:TextBox>
            </dd>
	    </dl>
     </div>
	  <div class="formBar">
		    <ul>
			    <li><div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div></li>
			    <li>
				    <div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
			    </li>
		    </ul>
	    </div>
</div>

</form>