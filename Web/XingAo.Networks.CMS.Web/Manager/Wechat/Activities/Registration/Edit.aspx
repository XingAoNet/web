<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.Registration.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
    #pertable td{height:26px;}
    #pertable .textInput{width:200px; }
    .formInput_del{ background:url('/Images/delete.gif') no-repeat; float:left; width:26px; height:26px; display:block; cursor:pointer;}
    #txtCanUse label{float:none;}
</style>
<script type="text/javascript">
    $(function (e) {
        $('#pertable span.formInput_del').live('click', function () {
            $(this).parent().parent().remove();
        });
        $("#BtnPercontent").click(function (ex) {
            $("#pertable").append("<tr><td><input class='required textInput' name='percontent'/><span class='formInput_del'></span></td></tr>");
        });
    });
    </script>


<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">报名活动</h2>
            <div class="unit">
	            <label>关键字：</label>
                <asp:TextBox ID="txtKeys" runat="server" CssClass="required" Width="80%"></asp:TextBox>
            </div>
            <div class="unit">
                <label>标题：</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                <asp:HiddenField ID="txtID" runat="server" />
                <asp:HiddenField ID="txtAGuid" runat="server" />
            </div>

                <div class="unit">
	            <label>所属类别：</label>
                     <table>
                 <tr>
                        <td>
                 <asp:dropdownlist ID="txtParentID" runat="server"></asp:dropdownlist>
                     </td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td>
                 <a class="add" href="/Manager/Wechat/MaterialFamily/Edit.aspx" target="dialog" height="320">添加类别</a>        
                 </td></tr></table>
            </div>
                <div class="unit">
	            <label>排序号：</label>
                <asp:TextBox ID="txtOrderID" runat="server" Width="20%" maxlength="5"></asp:TextBox>
            </div>
            <div class="unit">
                <label>活动图片：</label>
                <table border="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPictueAddress" runat="server" CssClass="required" ReadOnly="true" Width="200"></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" style="_width:360px;max-width:360px;" CssClass="hide"></asp:image>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <input type="button" id="uploadButton-txtPictueAddress-ShowImage" value="选择图片" class="Pic_Upload_File"  />
                        </td>
                        <td>大图片建议尺寸：360像素 * 200像素</td>
                    </tr>
                </table>
            </div>
            <div class="unit">
	            <label>活动时间：</label>
                <table>
                    <tr>
                        <td><asp:textbox runat="server" CssClass="date" name="txtStartTime" id="txtStartTime" dateFmt="yyyy-MM-dd HH:mm:ss" readonly=true></asp:textbox></td>
                        <td>---</td>
                        <td><asp:textbox runat="server" CssClass="date" name="txtEndTime" id="txtEndTime" dateFmt="yyyy-MM-dd HH:mm:ss" readonly=true></asp:textbox></td>
                    </tr>
                </table>
            </div>
           <div class="unit">
				<label>状态：</label>
                <asp:radiobuttonlist id="txtCanUse" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>     
                <asp:ListItem Value="0">关闭</asp:ListItem>                
                </asp:radiobuttonlist>
            </div>

            <div class="unit">
	            <label>活动描述：</label>
                    <asp:TextBox ID="txtAbstract" runat="server" CssClass="required" Width="80%" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="unit">
	            <label>活动内容：</label>
                <asp:TextBox ID="txtDetailedContent" runat="server" CssClass="required editor" Width="80%" height="300px" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="unit">
	            <label>人数上限：</label>
                    <asp:TextBox ID="txtPersonNum" runat="server" CssClass="required" Width="30%"></asp:TextBox>
            </div>

            <div class="unit">
	            <label>报名表单：</label>
                <table id="pertable">
                    <tr><td><input class="required textInput" name="percontent2" value="联系人" readonly="readonly"/></td></tr>
                    <tr><td><input class="required textInput" name="percontent2" value="手机号" readonly="readonly"/></td></tr>
                    <%=perhtml %>
                </table>
                <div>
                    <label>&nbsp;</label>
                    <input type="button" value="添加" id="BtnPercontent" /> 
                </div>
            </div>
            <div class="unit" style="display:none;">
            <label>当前活动地址：</label>
                  <asp:textbox id="CurrentUrl" runat="server" width="50%"></asp:textbox>
                  <input type="button" onclick="copyToClipboard();" value="复制"/>
             </div>
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
<script type="text/javascript" >
    $("input[name='percontent']").keyup(
        function () {
            var per = $(this).val();
            var reg = new RegExp(",", "g"); //创建正则RegExp对象   
            var newstr = per.replace(reg, "，");
            $(this).val(newstr);
        }
     );
</script>