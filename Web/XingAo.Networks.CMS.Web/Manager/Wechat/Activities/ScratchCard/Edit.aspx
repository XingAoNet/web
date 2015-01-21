<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<style type="text/css">
             #txtCanUse label{float:none;}
    </style>
<div class="pageContent">
    <form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
    <div class="pageFormContent nowrap" layouth="56">
        <h2 class="contentTitle">
            刮刮卡活动</h2>
        <div class="unit">
            <label>
                关键字：</label>
            <asp:textbox id="txtKeys" runat="server" cssclass="required" width="80%"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                标题：</label>
            <asp:textbox id="txtTitle" runat="server" cssclass="required" width="80%"></asp:textbox>
            <asp:hiddenfield id="txtID" runat="server" />
            <asp:hiddenfield id="txtSGuid" runat="server" />
        </div>
        <div class="unit">
            <label>
                所属类别：</label>
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
            <label>
                活动图片：</label>
            <table border="0">
                <tr>
                    <td>
                        <asp:textbox id="txtPictureAddress" runat="server" cssclass="required" readonly="true"
                            width="200"></asp:textbox>
                        <asp:image runat="server" id="ShowImage" style="_width:360px;_height:200px;max-width: 360px;max-height:200px;" cssclass="hide"></asp:image>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="uploadButton-txtPictureAddress-ShowImage" value="选择图片" class="Pic_Upload_File" />
                    </td>
                    <td>
                        大图片建议尺寸：360像素 * 200像素
                    </td>
                </tr>
            </table>
        </div>
        <div class="unit">
            <label>
                活动时间：</label>
            <table>
                <tr>
                    <td>
                        <asp:textbox runat="server" cssclass="date" name="txtStartTime" id="txtStartTime"
                            datefmt="yyyy-MM-dd HH:mm:ss" readonly="true"></asp:textbox>
                    </td>
                    <td>
                        ---
                    </td>
                    <td>
                        <asp:textbox runat="server" cssclass="date" name="txtEndTime" id="txtEndTime" datefmt="yyyy-MM-dd HH:mm:ss"
                            readonly="true"></asp:textbox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="unit">
            <label>
                状态：</label>
                 <asp:radiobuttonlist id="txtCanUse" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>     
                <asp:ListItem Value="0">关闭</asp:ListItem>                
                </asp:radiobuttonlist>
        </div>
        <div class="unit">
            <label>
                排序号：</label>
            <asp:textbox id="txtOrderID" runat="server" width="30%"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                简介：</label>
            <asp:textbox id="txtAbstract" runat="server" cssclass="required" width="80%" textmode="MultiLine"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                背景图：</label>   
                 <div style="width: 80%;margin-left:130px;">
                 <div style="position: absolute;">   
                        <asp:textbox id="txtCardBG" runat="server" cssclass="required" readonly="true" width="200"></asp:textbox>
                        <asp:image runat="server" id="ShowCardBG" cssclass="ImgAreaSelect hide" coordinate="txtCardBGSelect"></asp:image>
                        <input type="hidden" name="txtCardBGSelect" style="width:640px;" id="txtCardBGSelect" runat="server" />               
                        <input type="button" style="margin-left:10px;" id="uploadButton-txtCardBG-ShowCardBG" value="选择图片" class="Pic_Upload_File" />
                   </div>
            </div>
        </div>
        <div class="unit">
            <label>
                详细内容：</label>
            <asp:textbox id="InHmtl" runat="server" cssclass="required editor" width="80%" height="300"
                textmode="MultiLine"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                默认奖品：</label>
            <asp:textbox id="txtDefaultGoods" runat="server" cssclass="required" width="30%"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                每天抽奖次数：</label>
            <asp:textbox id="txtPersonNum" runat="server" cssclass="required" width="30%"></asp:textbox>
        </div>
        <div class="unit">
            <label>
                总票数：</label>
            <asp:textbox id="txtTotalCount" runat="server" cssclass="required" width="30%"></asp:textbox>
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
