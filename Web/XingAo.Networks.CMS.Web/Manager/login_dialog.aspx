<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_dialog.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.login_dialog" %>
<div class="pageContent">
	
	<form method="post" action="login_dialog.ashx?r=<%=Request.QueryString["r"] %>" class="pageForm" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<div class="pageFormContent" layoutH="58">
			<div class="unit">
				<label>用户名：</label>
				<input type="text" name="username" size="30" class="required"/>
			</div>
			<div class="unit">
				<label>密　码：</label>
				<input type="password" name="password" size="30" class="required"/>
			</div>
            <div class="unit">
				<label>验证码：</label>
				<input type="text" name="vcode" size="20" class="required" onfocus="ReMakeVerification()" /><img alt="" id="ImgCheck" align="absmiddle" src="/Verification" onclick="this.src='/Verification?r='+new Date()" />
			</div>
		</div>
		<div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">提交</button></div></div></li>
				<li><div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div></li>
			</ul>
		</div>
	</form>
	
</div>
<script type="text/javascript">
    function ReMakeVerification()
    {
        $("#ImgCheck").attr("src",'/Verification?r='+new Date());
    }
</script>
