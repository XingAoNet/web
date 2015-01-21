<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Groups.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
<style type="text/css">
    #SideBar ul,#web_menuOpt ul{ padding-left:20px;}
    #SideBar li,#web_menuOpt li{ margin:5px 20px 5px 0; border:1px solid #FFF}
    #SideBar li:hover,#web_menuOpt li:hover{ border:1px dashed #75AED0}
   </style>

	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>分组名称：</dt>
				<dd>
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <fieldset>
            <legend>可操作前台栏目</legend>
                <div id="web_menuOpt"><asp:literal runat="server" ID="Navigation"></asp:literal></div>
            </fieldset>
            <fieldset>
            <legend>可操作后台菜单</legend>
                <asp:literal runat="server" ID="SystemMenu"></asp:literal>
            </fieldset>
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
    <script type="text/javascript">
        $("#SideBar input[type='checkbox']").click(
function ()
{
    var value = $(this).attr("checked");
    if (value)//选中操作
    {
        $(this).parents("li").each(
		function ()
		{
		    if ($(this).find("li:first").length > 0)
		        $(this).find("input:first").attr("checked", true);
		});
        if ($(this).parent("li").find("li:first").length > 0)
            $(this).parent("li").find("input").attr("checked", true);
    }
    else//取消选中操作
    {
        var StartI = 1;
        if ($(this).parent("li").find("li:first").length == 0)
            StartI = 0;
        else
            $(this).parent("li").find("input").attr("checked", false);
        $(this).parents("li").each(
		function ()
		{
		    var objLI_Input = $(this).find("input");
		    for (i = StartI; i < objLI_Input.length; i++)
		    {
		        var input = $(objLI_Input).eq(i);
		        var HaveSelected = false;
		        if ($(input).attr("checked"))
		        {
		            HaveSelected = true;
		            break;
		        }
		    }
		    StartI = 1;
		    if (HaveSelected)
		    {
		        return false;
		    }
		    else
		    { $(objLI_Input).eq(0).attr("checked", false); }
		}
		);
    }
    $("#SideBar input[disabled='disabled']").attr("checked", false);
});


        $("#SideBarCheckAll").click(
function ()
{
    var v = !($(this).attr("checked") == undefined);
    $("#SideBar input[type='checkbox']").attr("checked", v);
    $("#SideBar input[disabled='disabled']").attr("checked", false);
});




        $("#web_menuOpt input[type='checkbox']").click(
function ()
{
    var value = $(this).attr("checked");
    if (value)//选中操作
    {
        $(this).parents("li").each(
		function ()
		{
		    if ($(this).find("li:first").length > 0)
		        $(this).find("input:first").attr("checked", true);
		});
        if ($(this).parent("li").find("li:first").length > 0)
            $(this).parent("li").find("input").attr("checked", true);
    }
    else//取消选中操作
    {
        var StartI = 1;
        //if ($(this).val().indexOf("_") > 0)
        if ($(this).parent("li").find("li:first").length == 0)
            StartI = 0;
        else
            $(this).parent("li").find("input").attr("checked", false);
        $(this).parents("li").each(
		function ()
		{
		    var objLI_Input = $(this).find("input");
		    var HaveSelected = false;
		    for (i = StartI; i < objLI_Input.length; i++)
		    {
		        var input = $(objLI_Input).eq(i);
		        if ($(input).attr("checked"))
		        {
		            HaveSelected = true;
		            break;
		        }
		    }
		    StartI = 1;
		    if (HaveSelected)
		    {
		        return false;
		    }
		    else
		    { $(objLI_Input).eq(0).attr("checked", false); }
		}
		);
    }
    $("#SideBar input[disabled='disabled']").attr("checked", false);
});
        $("#WebMenuCheckAll").click(
function ()
{
    var v = !($(this).attr("checked") == undefined);
    $("#web_menuOpt input[type='checkbox']").attr("checked", v);
    $("#web_menuOpt input[disabled='disabled']").attr("checked", false);
});
</script>

</div>