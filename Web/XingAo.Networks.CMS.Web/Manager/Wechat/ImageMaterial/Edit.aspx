<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.ImageMaterial.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
           #IsShowTime label, #IsShow label,#txtKeyType label{float:none;}
    </style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">编辑图文自定义内容</h2>
            <div class="unit">
                <label>关键词：</label>
                <asp:TextBox ID="txtKeys" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                <asp:HiddenField ID="txtID" runat="server" />
                <asp:HiddenField ID="txtWWGuid" runat="server" />
            </div>

            <div class="unit" style="display:none;">
                <label>关键词类型：</label>
                <asp:radiobuttonlist ID="txtKeyType" runat="server">
                 <asp:ListItem Value="0" Selected="True">完全匹配，用户输入的和此关键词一样才会触发!</asp:ListItem>
                <asp:ListItem Value="1">包含匹配 (只要用户输入的文字包含本关键词就触发！)</asp:ListItem>
               </asp:radiobuttonlist>
            </div>

            <div class="unit">
                <label>标题：</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
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
                 <a class="add" href="/Manager/Wechat/MaterialFamily/Edit.aspx" target="dialog" height="320">添加类别</a>        
                 </td></tr></table>
            </div>

            <div class="unit">
                <label>排序号：</label>
                <asp:TextBox ID="txtOrderID" runat="server" width="20%" maxlength="5"></asp:TextBox>
            </div>
            
            <div class="unit">
                <label>详细页显示编辑时间：</label>
                 <asp:radiobuttonlist ID="IsShowTime" runat="server" RepeatDirection="Horizontal" >                 
                         <asp:ListItem Value="0">否</asp:ListItem>   
                         <asp:ListItem Value="1" Selected="True">是</asp:ListItem>                     
                    </asp:radiobuttonlist>
            </div>

            <div class="unit">
                <label>图文封面：</label>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHeader" runat="server" CssClass="required" ReadOnly="true" Width="200"></asp:TextBox>
                            <asp:TextBox ID="txtThumbnailHeader" runat="server" style=" display:none;"></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" style="_width:180px;width:180px;max-width:360px;display:none;" CssClass="hide"></asp:image>
                            </td>
                        <td>&nbsp;</td>
                        <td>
                            <input type="button" id="uploadButton-txtHeader-ShowImage-txtThumbnailHeader" value="选择图片" class="Pic_Upload_File"   name="Thumbnail"  />
                        </td>
                        <td>大图片建议尺寸：360像素 * 200像素</td>
                    </tr>
                </table>
            </div>

            <div class="unit">
                <label>详细页显示图文封面：</label>
                 <asp:radiobuttonlist ID="IsShow" runat="server"  RepeatDirection="Horizontal" >
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
                 <asp:TextBox ID="txtDetailedContent" runat="server" CssClass="editor" TextMode="MultiLine" Text="<p></p>" Width="80%" height="300"></asp:TextBox>
            </div>

             <div class="unit">
                <label>跳转链接：</label>
                <asp:TextBox ID="txtUrl" runat="server"  Width="80%"></asp:TextBox>
            </div>

            <div class="unit" style="display:none;">
            <label>当前图文地址：</label>
                  <asp:textbox id="CurrentUrl" runat="server" width="50%"></asp:textbox>
                  <input type="button" onclick="copyToClipboard();" value="复制"/>
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
