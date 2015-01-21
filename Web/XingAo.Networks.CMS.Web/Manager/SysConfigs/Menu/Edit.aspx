<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu.Edit"%>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56" >
            <dl>
				<dt>所属菜单：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="drParentMenu">
                        <asp:ListItem Value="" Text="顶级菜单"></asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
			<dl>
				<dt>菜单中文名：</dt>
				<dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>菜单英文名：</dt>
				<dd>
                    <asp:TextBox ID="txtEnglishName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>链接地址：</dt>
				<dd>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
              <dl>
				<dt>新窗口标识：</dt>
				<dd>
                    <asp:TextBox ID="txtRel" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
               <dl>
				<dt>菜单排序号：</dt>
				<dd>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="digits" Width="20%"></asp:TextBox>
                </dd>
			</dl>
               <dl>
				<dt>打开窗口：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtTarget" CssClass="required">
                        <asp:ListItem Value="navTab" Text="选项窗口"></asp:ListItem>
                        <asp:ListItem Value="dialog" Text="对话框"></asp:ListItem>
                        <asp:ListItem Value="_blank" Text="新窗口"></asp:ListItem>
                        <%--ccj:不清楚干嘛用，先注释掉--%>
                        <%--<asp:ListItem Value="ExecUrl" Text="执行窗口"></asp:ListItem>--%>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>菜单属性：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="PageType" CssClass="required">
                        <asp:ListItem Value="0" Text="菜单页"></asp:ListItem>
                        <asp:ListItem Value="1" Text="操作页"></asp:ListItem>
                        <asp:ListItem Value="2" Text="一般执行页"></asp:ListItem>
                    </asp:dropdownlist>
                    <input type="checkbox" ID="IsViewMenu" value="1" runat="server" />显示在菜单
                </dd>
			</dl>
          <dl>
				<dt>操作权限：</dt>
				<dd style="width:80%; padding-left:100px;">
                    <span style="color:Red;">* 可操作后台菜单权限，只有在此处添加后，管理员组里才会出现对应的权限；</span>
                    <ul>
                       <asp:repeater runat="server" ID="ListOption">
                        <ItemTemplate> 
                            <li style="float:left; width:140px; line-height:26px;">
                                <input name="OptionsNum" value="<%#Container.DataItem %>" type="checkbox" <%#CheckOption(Container.DataItem.ToString()) %> /><%#Option(Container.DataItem.ToString())%>
                            </li>
                        </ItemTemplate>    
                        </asp:repeater>
                    </ul>
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
	</form>
</div>