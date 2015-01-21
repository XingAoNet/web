<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin.Main" %>
<%@ Import Namespace="XingAo.Networks.CMS.Common" %>

<div class="pageContent" style="padding:5px">
	<div class="panel" defH="40">
		<h1>微信信息</h1>
		<div>
            <asp:literal runat="server" Id="Li_Name"></asp:literal>
        </div>
	</div>
	<div class="divider"></div>
    <div style="float:left; display:block; overflow:auto; width:160px; border:solid 1px #CCC; line-height:21px; background:#fff;height:350px;">
        <form id="form" runat="server">        
        <asp:hiddenfield runat="server" ID="TxtID"></asp:hiddenfield>
        <table class="searchContent">
			<tr>
                <td> 所属分组：</td>
				<td>
                    <asp:dropdownlist runat="server" CssClass="combox" ID="GroupDroupDown"></asp:dropdownlist>
				</td>
			</tr>
		</table>
        </form>
        <div id="w_AccountList" class="unitBox"></div>
    </div>
	<div class="tabs">
		<div class="tabsHeader">
			<div class="tabsHeaderContent">
				<ul>
					<li><a href="javascript:;"><span>文本</span></a></li>
					<li><a href="javascript:;"><span>语音</span></a></li>
					<li><a href="javascript:;"><span>图片</span></a></li>
					<li><a href="javascript:;"><span>位置</span></a></li>
					<li><a href="javascript:;"><span>关注</span></a></li>
                    <li><a href="javascript:;"><span>取消关注</span></a></li>
                    <li><a href="javascript:;"><span>菜单</span></a></li>
				</ul>
			</div>
		</div>
		<div class="tabsContent">
			<div>
                <input id="TextAccount" type="text" style=" width: 178px;" /><br />
                <textarea id="TextContent" style="width: 368px; height:86px;"></textarea>
                <input id="BtnSender" type="button" value="发送" />
            </div>
	
			<div>语音</div>
			
			<div>图片</div>
			
			<div>位置</div>

            <div>关注</div>

            <div>取消关注</div>

            <div>菜单</div>
		</div>
        <div class="OptionInfo"></div>
		<div class="tabsFooter">
			<div class="tabsFooterContent"></div>
		</div>
	</div>
	
</div>

<script type="text/javascript">
    $(function (ex) {
       // AjaxPost($("#GroupDroupDown").val(), 0);
        $("#GroupDroupDown").change(function (eex) {
            AjaxPost($(this).val(), 0);
        })
        $("#BtnSender").click(function (ex) {
            $.post("Wechat/WeiXin/SaveDel.ashx", { action: "text", id: $("#TxtID").val(), Msg: $("#TextContent").val(), fakeid: $("#TextAccount").val() },
            function (data) {
                $(".OptionInfo").html(data);

            }, "html");
        });

    })

    function AjaxPost(groupid, numPerPage) {
        $.post("Wechat/WeiXin/Accounts.aspx", { id: $("#TxtID").val(), groupid: groupid, numPerPage: numPerPage },
            function (data) {
                $("#w_AccountList").html(data);
                $("#w_AccountList .panelBar a").click(function (ex) {
                    AjaxPost(groupid, $(this).attr("ref"));
                });
                var $p = $(document);
                $("#w_AccountList table.table", $p).jTable();
                $("#w_AccountList input[name=ids]").click(function (ex) {
                    if ($(this).is(":checked")) {
                        $("#TextAccount").val($(this).val());
                    }

                });
              
            }, "html");
    }
</script>
