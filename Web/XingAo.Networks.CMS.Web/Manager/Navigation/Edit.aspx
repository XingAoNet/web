<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Navigation.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>所属栏目：</dt>
				<dd>
                    <asp:dropdownlist ID="txtPID" runat="server" CssClass="combox required"></asp:dropdownlist>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            	<dl>
	        <dt>
		        栏目名称
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtName" runat="server" CssClass="required" width="80%"></asp:TextBox>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        栏目英文名
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtEName" runat="server" customvalid="LettersonlyAndDigits()" title="只能输入字母与数字" width="80%"></asp:TextBox>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        图片导航
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtPic" runat="server"></asp:TextBox>
                <input id="uploadButton-txtPic" value="选择图片" class="Pic_Upload_File" type="button">
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        图片导航
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtPicHover" runat="server" ToolTip="当鼠标放上去时的图片">
                </asp:TextBox><input id="uploadButton-txtPicHover" value="选择图片" class="Pic_Upload_File" type="button">
	        </dd>
        </dl>
	    <asp:panel runat="server" ID="IndexTemplate">
	        <dl>
	        <dt>
		        首页模板
	        ：</dt>
	        <dd>
		        <asp:dropdownlist runat="server" ID="txtIndexTemplate" CssClass="combox" width="40%"></asp:dropdownlist>
                *只用于显示首页的模板
	        </dd>
        </dl>
        </asp:panel>
        <asp:panel runat="server" ID="SelectTemplate">
	        <dl>
	        <dt>
		        列表页模板
	        ：</dt>
	        <dd>
		        <asp:dropdownlist runat="server" ID="txtListTemplate" CssClass="combox"></asp:dropdownlist>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        详细页模板
	        ：</dt>
	        <dd>
		        <asp:dropdownlist runat="server" ID="txtInfoTemplate" CssClass="combox"></asp:dropdownlist>
	        </dd>
        </dl>
        </asp:panel>
	        <dl>
	        <dt>
		        外部链接
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtOutLink" runat="server" width="80%" value="#"></asp:TextBox>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        链接打开方式
	        ：</dt>
	        <dd>
                <asp:dropdownlist runat="server" ID="txtTarget" CssClass="combox">
                    <asp:ListItem Value="">默认</asp:ListItem>
                    <asp:ListItem Value=" target=&quot;_blank&quot;">新窗口</asp:ListItem>
                    <asp:ListItem Value=" target=&quot;_parent&quot;">父窗口</asp:ListItem>
                    <asp:ListItem Value=" target=&quot;_top&quot;">框架</asp:ListItem>
                </asp:dropdownlist>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        顶部显示
	        ：</dt>
	        <dd>
		        <asp:dropdownlist runat="server" ID="txtShowInTopNavigation" CssClass="combox">
                    <asp:ListItem Value="1">在网站顶部导航上显示此栏目</asp:ListItem>
                    <asp:ListItem Value="0">在网站顶部导航上不显示此栏目</asp:ListItem>
                </asp:dropdownlist>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        左侧显示
	        ：</dt>
	        <dd>
		        <asp:dropdownlist runat="server" ID="txtShowInLeftNavigation" CssClass="combox">
                    <asp:ListItem Value="1">在网站左侧导航上显示此栏目</asp:ListItem>
                    <asp:ListItem Value="0">在网站左侧导航上不显示此栏目</asp:ListItem>
                </asp:dropdownlist>
	        </dd>
        </dl>
            <dl>
	        <dt>
		        搜索引擎关键字
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtSearchEngineKeyWords" width="60%" runat="server" MaxLength="250" ToolTip="如果此栏目为首页或列表页时有效"></asp:TextBox><span style="color:Red;"> * 如果此栏目为首页或列表页时有效</span>
	        </dd>
        </dl>
	        <dl>
	        <dt>
		        搜索引擎描述
	        ：</dt>
	        <dd>
		        <asp:TextBox id="txtSearchEngineDescription" width="60%" runat="server" MaxLength="250" ToolTip="如果此栏目为首页或列表页时有效"></asp:TextBox><span style="color:Red"> * 如果此栏目为首页或列表页时有效</span>
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
<script type="text/javascript">
    $("#txtName").blur(
	function ()
	{

	    var name = $(this).val();
	    $.post("Navigation/GetNavigationEName.ashx",
		{ "Name": name },
		function (data)
		{
		    $("#txtEName").val(data);
		}
		, "html");
});
function LettersonlyAndDigits(element)
{
    var value = $("#txtEName").val();
    return /^([A-Za-z]|\d)+$/i.test(value);
}
</script>