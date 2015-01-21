<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.BigWheel.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
    #prizetable td{height:26px;}
    #prizetable .textInput{width:200px; }
    #prizetable {text-align:center;}
    .formInput_del{ background:url('/Images/delete.gif') no-repeat; float:left; width:26px; height:26px; display:block; cursor:pointer;}
     #txtCanUse label{float:none;}
</style>
<script type="text/javascript">
    $(function (e)
    {
        $('#prizetable span.formInput_del').live('click', function ()
        {
            $(this).parent().parent().remove();
        });
        $("#BtnPrizecontent").click(function (ex)
        {
            var n;
            n = document.getElementsByName("prizecontent");
            if (n.length < 12)
                $("#prizetable").append("<tr><td><input class='textInput' name='prizecontent'/></td><td><span class='formInput_del'></span></td></tr>");
            else
                alert("奖品最多只能输入12个");
        });
    });
    $("#BtnAdd").click(function ()
    {
        var check = true;
        $("input[name='prizecontent']").each(function ()
        {
            if ($(this).val() == "")
            {
                check = false;
                alert("请输入完整的奖品信息！")
                return false;
            }
        });
        return check;
    });
    </script>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">编辑大转盘活动内容</h2>
            <div class="unit">
            <label>关键字：</label>
                    <asp:TextBox ID="txtKeys" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="txtBGuid" runat="server" />
            </div>
            <div class="unit">
            <label>标题：</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
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
                    <asp:TextBox ID="txtOrderID" runat="server" Width="20%"></asp:TextBox>
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
                <label>活动图片：</label>
                <table border="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPictueAddress" runat="server" CssClass="required" ReadOnly="true" Width="200"></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" width="200" height="110" CssClass="hide"></asp:image>
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
            <label>简介：</label>
                    <asp:TextBox ID="txtAbstract" runat="server" CssClass="required" Width="80%" TextMode="MultiLine" Height="48px"></asp:TextBox>
            </div>
            <div class="unit">
            <label>详细内容：</label>
                  <asp:TextBox id="txtDetailedContent" runat="server" CssClass="required editor" Width="80%" height="300" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="unit">
            <label>每天最大摇奖次数：</label>
                  <asp:TextBox id="txtDayNum" runat="server" CssClass="required" width="80%"></asp:TextBox>
            </div>
            <div class="unit">
                <label>奖品设置：</label>
                <table id="prizetable">
                    <%=Prizehtml%>
                </table>
                <div>
                    <label>&nbsp;</label>
                    <input type="button" value="添加" id="BtnPrizecontent" /> 
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
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit" id="BtnAdd">保存</button></div></div></li>
				<li>
					<div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
				</li>
			</ul>
		</div>
	</form>
</div>