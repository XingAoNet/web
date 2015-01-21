<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.DataShare.Users.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
#txtAllowCallList{ width:95%;}
#txtAllowCallList li{ float:left; border:1px solid #B8D0D6; padding:3px; margin:3px;}
</style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>用户名：</dt>
				<dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="txtPrivateKey" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>密钥：</dt>
				<dd>
                    <asp:TextBox ID="txtKeys" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <br /><div class="button" onclick="ReMakeKey(); return false;"><div class="buttonContent"><button>重新生成</button></div></div>                    
                </dd>
			</dl>
            <dl>
				<dt>调用函数：</dt>
				<dd>
                    <asp:literal runat="server" ID="txtAllowCall"></asp:literal>
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
    function ReMakeKey()
    {
        $.post("DataShare/Users/MakeKey.ashx",
        function (data)
        {
            var v = data.split("^");
            $("#txtKeys").val(v[0]);
            $("#txtPrivateKey").val(v[1]);
        },
        "text");
    }
    $("#txtKeys").dblclick(
    function ()
    {
        var clipBoardContent = $(this).val();
        copyToClipboard(clipBoardContent);
        //window.clipboardData.setData("Text", clipBoardContent);
        alertMsg.info("密钥已复制到剪切板，您可贴粘至其它地方保存。");
    });

    ///复制文本框内容
    function copyToClipboard(txt)
    {
        if (window.clipboardData)
        {
            window.clipboardData.clearData();
            clipboardData.setData("Text", txt);

        } else if (navigator.userAgent.indexOf("Opera") != -1)
        {
            window.location = txt;
        } else if (window.netscape)
        {
            try
            {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e)
            {
                alert("在复制内容到剪切板时被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将 'signed.applets.codebase_principal_support'设置为'true'");
            }
            var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
            if (!clip)
                return;
            var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
            if (!trans)
                return;
            trans.addDataFlavor("text/unicode");
            var str = new Object();
            var len = new Object();
            var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
            var copytext = txt;
            str.data = copytext;
            trans.setTransferData("text/unicode", str, copytext.length * 2);
            var clipid = Components.interfaces.nsIClipboard;
            if (!clip)
                return false;
            clip.setData(trans, null, clipid.kGlobalClipboard);
        }
    }
</script>