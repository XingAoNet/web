<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
	ul.rightTools {float:right; display:block;}
	ul.rightTools li{float:left; display:block; margin-left:5px}
</style>

<div class="pageContent" style="padding:5px">
	<div class="panel" defH="40">
		<h1>微信基本信息</h1>
		<div>
			微信编号：<input type="text" name="patientNo" />
			<ul class="rightTools">
				<li><a class="button" target="dialog" href="demo/pagination/dialog1.html" mask="true"><span>绑定微信号</span></a></li>
			</ul>
		</div>
	</div>
	<div class="divider"></div>
    
	<div class="tabs">
		<div class="tabsHeader">
			<div class="tabsHeaderContent">
				<ul>
					<li><a href="javascript:;"><span>我的微信</span></a></li>
				</ul>
			</div>
		</div>
		<div class="tabsContent">
			<div>
	
				<div layoutH="146" style="float:left; display:block; overflow:auto; width:240px; border:solid 1px #CCC; line-height:21px; background:#fff">
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
                 <div id="w_AccountList" class="unitBox">
                    <table>
		                <thead>
			                <tr>
				                <th width="22"><input type="checkbox" name="ids" value="" group="ids" class="checkboxCtrl"></th>
				                <th width="120">账号</th>
				                <th width="100">备注</th>
			                </tr>
		                </thead>
		                <tbody>
                            <asp:repeater runat="server" ID="Rep_List">
                                <ItemTemplate>            
			                        <tr target="sid" rel="<%#Eval("ID") %>">
				                        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox" /></td>
				                        <td><%#Eval("nick_name")%></td>
				                        <td><%#Eval("remark_name")%></td>				
			                        </tr>
                                </ItemTemplate>
                            </asp:repeater>
		                </tbody>
	                </table>
	                <div class="panelBar">
                        <asp:literal runat="server" Id="LiPager"></asp:literal>
	                </div>
                 
                 </div>
				    
				</div>
                <div id="jbsxBox" class="unitBox" style="margin-left:246px;">
                     <textarea id="TextContent" style="width: 500px; height:200px;"></textarea>
                      <input id="BtnSender" type="button" value="发送" />
                        <div class="OptionInfo"></div>
				</div>
	
			</div>
		</div>
		<div class="tabsFooter">
			<div class="tabsFooterContent"></div>
		</div>
	</div>
</div>
<script type="text/javascript">
    $(function (ex) {
        $("#w_AccountList .panelBar a").click(function (ex) {
            AjaxPost(0, $(this).attr("ref"));
        });


        $("#GroupDroupDown").change(function (eex) {
            AjaxPost($(this).val(), 0);
        })
        $("#BtnSender").click(function (ex) {
            var ids = "";
            $("#w_AccountList input[name='ids']:checked").each(function (i, n) {
                if ($(this).val()!="")
                    ids +=$(this).val()+ ",";
            });
            $.post("Wechat/WeiXin/SaveDel.ashx", { action: "text", id: $("#TxtID").val(), Msg: $("#TextContent").val(), fakeid: ids },
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
                $("#w_AccountList :button.checkboxCtrl, :checkbox.checkboxCtrl", $p).checkboxCtrl($p);

            }, "html");
    }
</script>