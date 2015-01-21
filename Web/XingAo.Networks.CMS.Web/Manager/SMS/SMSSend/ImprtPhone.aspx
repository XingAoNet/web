<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprtPhone.aspx.cs" Inherits=" XingAo.Networks.CMS.Web.Manager.SMS.SMSSend.ImprtPhone" %>

<div class="pageContent">
<script type="text/javascript">
    function call(json) {
        if (json.statusCode == 200) {
            var us = json.message.split(',');
            $(us).each(function (i, n) {
                var m = n.split('|');
                if (m[1] != "" && m[1].length == 11)
                    CreateSendName(m[1], m[0]);
            });
            $.pdialog.closeCurrent();
        }
       
    }
</script>
    <form id="form1" runat="server" class="pageForm required-validate" onsubmit="return iframeCallback(this,call);"  method="post" enctype="multipart/form-data">
       <div class="pageFormContent nowrap" layoutH="56">
        <h2 class="contentTitle">导入手机号</h2>
            <div class="unit">
				<label>导入文件：</label>
                <input id="ExcelFile" name="ExcelFile" type="file" />
			</div>
            <div class="unit">
				<label>工作薄：</label>
               <input id="SheetName" name="SheetName" type="text" value="Sheet1" />
			</div>
            <div class="unit">
             <fieldset>
                <legend>示例：</legend>
                    <div style="margin:10px 20px;">
                        <img src="/Images/info.gif" alt="" />
                    </div>
                </fieldset>
            </div>
       </div>
        <div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">导入</button></div></div></li>
				<li>
					<div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
				</li>
			</ul>
		</div>
    </form>
</div>