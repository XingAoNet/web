<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageEdit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Attention.ImageEdit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
    #IsShow label,#txtKeyType label{float:none;}
</style>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">关注时图文回复内容</h2>
           <div class="unit">
                <label>标题：</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="TxtType" value="1" runat="server" />
            </div>            
            
            <div class="unit">
                <label>所属类别：</label>
                 <table>
                 <tr>
                        <td>
                 <asp:dropdownlist ID="txtParentID" runat="server"></asp:dropdownlist>
                     </td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td>
                 <a class="add" href="/Wechat/Material/MaterialFamily/Edit.aspx target="dialog" height="320">添加类别</a>        
                 </td></tr></table>
            </div>
            <div class="unit" style="display:none;">
                <label>排序号：</label>
                <asp:TextBox ID="txtOrderID" runat="server" CssClass="required" Width="80%">1000</asp:TextBox>
            </div>
           
            <div class="unit">
                <label>图文封面：</label>
                 <table border="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHeader" runat="server" CssClass="required" ReadOnly="true" Width="200"></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" CssClass="hide" style="width:180px; height:100px; max-width:360px;display:none;"></asp:image>
                            </td>
                        <td>&nbsp;</td>
                        <td>
                            <input type="button" id="uploadButton-txtHeader-ShowImage"  value="选择图片" class="Pic_Upload_File"  />
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

            <div class="unit">
                <label>图文详细页内容：</label>
               <asp:TextBox ID="txtDetailedContent" runat="server" CssClass="editor" TextMode="MultiLine" height="300" width="80%"></asp:TextBox>
            </div>
            <div class="unit">
                <label>跳转链接：</label>
               <asp:TextBox ID="txtOtherURL" runat="server" width="80%"></asp:TextBox>
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