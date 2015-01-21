<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.DefaultSettings.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
    #IsShow label,#txtKeyType label{float:none;}
</style>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">无匹配时默认回复</h2>
            <div class="unit">
                <label>标题：</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="TxtType" value="1" runat="server" />
            </div>
            <div class="unit">
                <label>图文封面：</label>
                 <table border="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHeader" runat="server" ReadOnly="true" Width="200"></asp:TextBox>
                            <asp:image runat="server" Id="DefaultSetShowImage" CssClass="hide" style="_width:360px;max-width:360px;display:none;"></asp:image>
                            </td>
                        <td>&nbsp;</td>
                        <td>
                            <input type="button" id="uploadButton-txtHeader-DefaultSetShowImage"  value="选择图片" class="Pic_Upload_File"  />
                        </td>
                        <td>大图片建议尺寸：360像素 * 200像素</td>
                    </tr>
                </table>
            </div>

             <div class="unit">
                <label>详细页显示图文封面：</label>
                 <asp:radiobuttonlist ID="IsShow" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                         <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:radiobuttonlist>
            </div>

            <div class="unit">
                <label>摘要：</label>
                <asp:TextBox ID="txtAbstract" runat="server" CssClass="required" Width="80%" 
                        TextMode="MultiLine" Height="48px"></asp:TextBox>
            </div>
            
            <div class="图文详细页内容">
                <label>图文详细页内容：</label>
                <asp:TextBox ID="txtContent" runat="server" CssClass="editor" TextMode="MultiLine" height="300" width="80%"></asp:TextBox>
             </div>

             <div class="unit">
                <label>链接其他地址：</label>
                <asp:TextBox ID="txtUrl" runat="server"  Width="80%"></asp:TextBox>
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