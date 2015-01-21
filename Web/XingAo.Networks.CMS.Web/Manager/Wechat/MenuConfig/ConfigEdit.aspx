<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigEdit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.MenuConfig.ConfigEdit"%>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
.radio label{float:none;}
</style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">授权设置</h2>
            <dl style="display:none;">
				<dt>账号：</dt>
				<dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="70%"></asp:TextBox>
                </dd>
			</dl>
            <dl style="display:none;">
				<dt>密码：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="required" Width="70%"></asp:TextBox>
                </dd>
			</dl>
            <div class="unit">
                <label>公众号名称：</label>
                 <asp:TextBox ID="txtChatName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </div>
            <div class="unit">
                 <label>公众号原始id：</label>
                 <asp:TextBox ID="txtSourceId" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </div>

            <div class="unit">
                 <label>微信号：</label>
                 <asp:TextBox ID="txtChatNumber" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </div>
            

			<dl>
				<dt>应用id：</dt>
				<dd>
                    <asp:TextBox ID="txtAppId" runat="server" CssClass="" Width="70%"></asp:TextBox>公众平台申请到的AppId
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>应用密钥：</dt>
				<dd>
                    <asp:TextBox ID="txtAppSecret" runat="server" CssClass="" Width="70%"></asp:TextBox>公众平台申请到的AppSecret
                </dd>
			</dl>
            <dl>
                
				<dt>微信接口：</dt>
				<dd>
                   <a href="./Wechat/Systems/Interface.aspx"  target="dialog" rel="navTab_Api" height="300" width="600">查看接口URL</a>
                </dd>
			</dl>
            <div class="unit">
                 <label>微信号类型：</label>
                 <div class="radio">
                <asp:RadioButtonList ID="RadioButAccountType" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">服务号</asp:ListItem>
                    <asp:ListItem Value="0">订阅号</asp:ListItem>
                    <asp:ListItem Value="2">订阅号（已认证）</asp:ListItem>
                </asp:RadioButtonList></div>
            </div>
             <div class="unit">
                 <label>头像地址（url）：</label>
                  <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHeader" runat="server" CssClass="required" ReadOnly="true" Width="80%"></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" style="_width:120px;max-width:120px;" CssClass="hide"></asp:image>
                        </td>
                        <td>&nbsp;</td>
                        <td><input type="button" id="uploadButton-txtHeader-ShowImage" value="选择图片" class="Pic_Upload_File"  /></td>
                    </tr>
                </table>
            </div>
            <div class="unit">
                 <label>二维码：</label>
                 <table>
                    <tr>
                        <td>
                                <asp:TextBox ID="txtErWei" runat="server" CssClass="required" ReadOnly="true" Width="80%"></asp:TextBox>
                                <asp:image runat="server" Id="ShowErWeiImage" style="_width:120px;max-width:120px;" CssClass="hide"></asp:image>
                        </td>
                        <td>&nbsp;</td>
                        <td><input type="button" id="uploadButton-txtErWei-ShowErWeiImage" value="选择图片" class="Pic_Upload_File"  /></td>
                    </tr>
                </table>
            </div>
            <div class="unit" style="display:none;">
                 <label>地区：</label>
                 <asp:dropdownlist runat="server" id="TxtProvince"></asp:dropdownlist>
                    <asp:dropdownlist runat="server" id="TxtCity"></asp:dropdownlist>
                    <asp:DropDownList ID="TxtAddress" runat="server" class="DropDownList"></asp:DropDownList>
                    <script src="/Manager/Wechat/Scripts/jsAddress.js" type="text/javascript"></script>
                    <script type="text/javascript">
                        addressInit('TxtProvince', 'TxtCity', 'TxtAddress', '浙江', '台州市', '路桥区');
                    </script>
            </div>
           <div class="unit">
                 <label>公众号邮箱：</label>
                 <asp:TextBox ID="txtMail" runat="server" CssClass="required" Width="80%"></asp:TextBox>
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