<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Sms.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
	ul.rightTools {float:right; display:block;}
	ul.rightTools li{float:left; display:block; margin-left:5px}
    .selectUser{ border:#999 solid 1px; padding:2px; margin:3px 3px 0px 3px; line-height:26px;}
    .del{cursor:pointer; color:#f00;}
    #sendUserList{height:98px; overflow:auto;}
</style>

<div class="pageContent" style="padding:5px">
	<div class="tabs">
		<div class="tabsHeader">
			<div class="tabsHeaderContent">
				<ul>
					<li><a href="javascript:;"><span>手机短信发送</span></a></li>
				</ul>
			</div>
		</div>
		<div class="tabsContent"  layoutH="39" >
			<div>
				<div layoutH="120" style="float:left; display:block; overflow:auto; width:240px; border:solid 1px #CCC; line-height:21px; background:#fff">
				    <ul class="tree treeCheck userlist" oncheck="kkk"><!-- collapse-->
						<li><a href="javascript:;">手机号码</a>
							<ul>
                                <asp:repeater runat="server" ID="acclist">
                                    <ItemTemplate>
                                        <li><a><%#Eval("GroupName")%></a>
                                            <ul>
                                                <asp:repeater runat="server" DataSource='<%#Eval("Members") %>'>
                                                    <ItemTemplate>
                                                        <li><a tname="UserID" tvalue="<%#Eval("Id")%>"><%#Eval("TName")%> <%#Eval("mobile")%></a></li>
                                                    </ItemTemplate>
                                                </asp:repeater>
                                            </ul>
                                        </li>
                                    </ItemTemplate>
                                </asp:repeater>
							</ul>
						</li>
				     </ul>
				</div>

                <div id="jbsxBox" class="unitBox" style="margin-left:246px;">
                    <div style="font-size:14px; margin-top:10px; margin-bottom:5px">会员：</div>
                    <div id="sendUserList"></div>
					<div style="font-size:14px; margin-top:10px; margin-bottom:5px">自定义号码： </div>
                    <textarea id="FTxtMobiles" cols="80" rows="10"></textarea>
                    <div style="font-size:14px; margin-top:10px; margin-bottom:5px">短信信息：</div>
                     <div>
                        <span id="length"></span>
                        <textarea id="TextMessage" name="TextMessage" cols="80" rows="8"  class="sendwidth"></textarea>
                    </div>
                    <div>
                        <input name="SendMobile" id="SendMobile" type="checkbox" value="1"                            checked="checked" />发送短信
                        <input name="SendWx" id="SendWx" type="checkbox" value="1" />发送微信
                    </div>
                    
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
    function kkk() {
        var json = arguments[0];
        $(json.items).each(function (i, n) {
            if (this.name != undefined && this.text != '' && this.value != '') {
                var vls = this.text.split(" ");
                CreateSendName(vls[1], vls[0],this.value);
                if (this.check) { }
                else {
                    $("#sendUserList").find("[mobile='" + vls[1] + "']").remove();
                }
            }
        });

    }

    $(function (ex) {
        $("#BtnSender").click(function (ex) {
            var usersID = "";
            $.each($("#sendUserList span.selectUser"), function (i, n) {
                usersID += $(this).attr("UserID") + ","
            });
            if (usersID != "" || $("#FTxtMobiles").val()!="") {
                $.post("SMS/SaveDel.ashx", { UserID: usersID, FTxtMobiles: $("#FTxtMobiles").val(), TextMessage: $("#TextMessage").val(), SendMobile: $("#SendMobile").is(":checked") ? 1 : 0, SendWx: $("#SendWx").is(":checked") ? 1 : 0 },
            function (data) {
                $(".OptionInfo").html(data);

            }, "html");
            }
        });

    })

    function CreateSendName(mobile, name,value) {
        if ($("#sendUserList").find("[mobile='" + mobile + "']").size() == 0) {
            var $n = $("<span></span>").attr("mobile", mobile).attr("UserID", value).addClass("selectUser").append($("<span></span>").html(name));
            $n.append($("<span></span>").html("×").addClass("del").click(function (ex) {
                $(".userlist input[type='checkbox'][value='" + mobile + "']").attr("checked", false).parent().removeClass("checked").addClass("unchecked");
                $(this).parent().remove();
            }));
            $("#sendUserList").append($n);
        }
    }
</script>