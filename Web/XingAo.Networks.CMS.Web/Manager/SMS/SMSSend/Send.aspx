<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits=" XingAo.Networks.CMS.Web.Manager.SMS.SMSSend.Send" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
	ul.rightTools {float:right; display:block;}
	ul.rightTools li{float:left; display:block; margin-left:5px}
    .selectUser{ border:#CCC solid 1px; padding:3px; margin:3px; line-height:26px;}
    .del{cursor:pointer; color:#f00; float:right;}
    #sendUserList{overflow:auto; height:98px; border:#ccc solid 1px;}
     #sendUserList div{ display:block; float:left; width:80px;}
    .OptionInfo{ line-height:30px;}
    #BtnSender.disable{ color:Gray;}
</style>
<script src="/Frame/js/Json2.js" type="text/javascript"></script>
<div class="pageContent">
    <div class="pageFormContent" layoutH="56">
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
				<div id="jbsxBox" class="unitBox" style="margin-left:246px; overflow:hidden;">
                <fieldset>
                <legend>短信群发设置（还有可发<asp:literal runat="server" id="LiNum"></asp:literal>条）</legend>
                    
			            <label style="width:95%;">手机号码：<%--<a href="/Wechat/Sms/ImprtPhone" target="dialog"  width="560" height="390" style="color:red">从Excel导入</a>--%><span id="MobCount"></span>
                            <div>
                                <div id="sendUserList"></div>
                            </div>                            
                        </label>
                    
			            <label style="width:95%;">自定义号码：多个手机用英文逗号分隔或换行<br />
                            <textarea id="FTxtMobiles" cols="80" rows="10" style="width:100%"></textarea>
                        </label>
                        
		            
                    <div class="divider"></div>                    
			            <label style="width:95%;">短信内容：(每条短信67个字计算)<a class="btnLook" href="/Manager/SMS/SMSTemplate/MainListPage.aspx" rel="page2" lookupGroup="txtKeys">查找带回</a><br />                           
                            <textarea id="TextMessage" name="TextMessage" cols="80" rows="8"  class="sendwidth" style="width:100%"></textarea>
<div style="clear:both; display:block;"><span id="TxtLength"></span></div>
                        </label>
                        <div class="divider"></div>
                        <div class="OptionInfo"></div>                        
                </fieldset>
				</div>
    </div>
    <div class="formBar">
						<ul>
							<li><div class="buttonActive"><div class="buttonContent"><button type="submit" id="BtnSender">发送</button></div></div></li>
							
						</ul>
					</div>
</div>

<script type="text/javascript">
var Sign='<%=Sign %>';
    $(function (ex)
    {
        //短信内容输入时事件
        $("#TextMessage").keyup(function ()
        {
            var text = $(this).val();
            var length = text.length;
//            var show = "<font color='red'>输入了【" + length + "】个字符，移动通道为67字/条，内容被分割成";
//            show = show + changenum(length, 67) + "条短信；联通通道为70字/条，内容被分割成";
//            show = show + changenum(length, 70) + "条短信；电信通道为70字/条，内容被分割成";
            //            show = show + changenum(length, 70) + "条短信。</font>";
            var show = "<font color='red'>输入了【" + length + "】个字符，签名为“" + Sign + "”,共计" + (length + Sign.length) + "个字符，内容被分割成:" + changenum(length + Sign.length, 67) + "条短信。</font>";
            $("#TxtLength").html(show);

        });
        //统计当前输入的短信内容将会分成多少条短信来发送
        //num:短信内容长度
        //mod:多少个字作为一条短信
        function changenum(num, mod)
        {
            if (num % mod > 0)
                return (num - num % mod) / mod + 1;
            else
                return (num - num % mod) / mod;
        }
        //提交事件
        $("#BtnSender").click(function (ex)
        {
            $("#BtnSender").unbind("click").addClass("disable");
            var mls = "";
            $("#sendUserList div[mobile!='']").each(function (i, n)
            {
                mls += $(n).attr("mobile") + "|" + $(n).attr("name") + ",";
            });
            if ($("#FTxtMobiles").val() != "" || mls != "")
            {
                $.post("/Manager/SMS/SMSSend/SaveDel.ashx", { action: "send", us: mls, FTxtMobiles: $("#FTxtMobiles").val(), TextMessage: $("#TextMessage").val() },
            function (data)
            {
                $(".OptionInfo").html(data);
                alert(data);
                $("#BtnSender").bind("click").removeClass("disable");
            }, "html");
            }
        });

})
function kkk() {
    var json = arguments[0];
    $(json.items).each(function (i, n) {
        if (this.name != undefined && this.text != '' && this.value != '') {
            var vls = this.text.split(" ");
            //CreateSendName(vls[1], vls[0]);
            if (this.check) {
                CreateSendName(vls[1], vls[0]);
            }
            else {
                RemoveSendName(vls[1]);
            }
        }
    });
}
//创建“手机号码”里面的姓名列表
//mobile:手机号码
//name：姓名
    function CreateSendName(mobile, name)
    {
        if ($("#sendUserList").find("[mobile='" + mobile + "']").size() == 0)
        {
            var $n = $("<div title='" + mobile + "'></div>").attr("mobile", mobile).attr("name", name).addClass("selectUser").append($("<span></span>").html(name));
            $n.append($("<span></span>").html("×").addClass("del").click(function (ex)
            {
                var tel = $(this).parent().attr("mobile");
                $(this).parent().remove();
                $("input[name='chkMob'][value='" + tel + "']").parent().parent().find("a").click();
                GetMobCount();
            }));
            $("#sendUserList").append($n);
        }
        GetMobCount();
    }
    //移除“手机号码”里面的姓名列表
    //mobile:手机号码
    function RemoveSendName(mobile) {
    $("#sendUserList").find("[mobile='" + mobile + "']").remove();GetMobCount(); }
    //统计选择或从excel中导入的手机号码个数
    function GetMobCount() {
        $("#MobCount").html("(共" + $("#sendUserList > div").length + "个联系人)");        
    }
</script>
