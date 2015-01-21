<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Product.Product.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
<style type="text/css">
   .pageFormContent  dd label{ float:none;}
   dl.nowrap dd, .nowrap dd {width: 80%;}
</style>
<script type="text/javascript">
    ///修改生成动态属性
    function SelectTemplateGroup(v, valuejson)
    {
        //alert(v);
        $("#Template a").each(
            function ()
            {
                if ($(this).attr("rel") == v)
                {
                    $("#txtAttributeGroupID").val($(this).attr("rel"));
                    $.post($(this).attr("href"), function (data)
                    {
                        $("#CustomAttr").html(data);                        
                        $.each(valuejson, function (i, item)
                        {
                            $("#" + item.Key).val(item.Values);
                            //alert(item.Key + "=" + item.Values);
                        });
                        initUI($("#CustomAttr"));
                    }, "html");
                    return false;
                }
            });
    }
</script>
<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
	<div layoutH="39" style="float:left; display:block; overflow:auto; width:214px; border:1px solid #CCC">
		 <ul class="tree treeFolder">
			<li><a href="javascript">属性模板</a>
				<ul id="Template">
                    <asp:repeater ID="Rep_List" runat="server">
                    <Itemtemplate><li><a href="<%=Request.GetPath() %>/EditForm.aspx?TempLateID=<%#Eval("id") %>" rel="<%#Eval("id") %>"><%#Eval("GroupName")%></a></li></Itemtemplate>
                    </asp:repeater>					
				</ul>
			</li>	
			</ul>
	</div>
	
	<div id="jbsxBox" class="unitBox" style="margin-left:220px;">
		
		<div class="pageFormContent nowrap" layoutH="56">
        <fieldset>
        <legend>固定属性</legend>
            <asp:textbox runat="server" id="txtAttributeGroupID" CssClass="required" ToolTip="请选择一个属性模板" style="display:none" ></asp:textbox>
           
			<dl>
				<dt>产品名称：</dt>
				<dd>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>产品编码：</dt>
				<dd>
                    <asp:TextBox ID="txtProductNumber" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>所属类别：</dt>
				<dd>
                    <asp:literal runat="server" ID="txtProductClassIDs"></asp:literal>
                </dd>
			</dl>
            <dl>
				<dt>产品图片：</dt>
				<dd>
                    <div style="float:left;width:110px;height:120px; text-align:center;">
                        <img id="PicTitleImg1" src="themes/default/images/waitpic.gif" width="100" height="100" />
                        <asp:textbox runat="server" ID="txt_PicTitle1" style="display:none;"></asp:textbox><br />
                        <input id="uploadButton-txt_PicTitle1-PicTitleImg1" class="Pic_Upload_File" type="button" value="选择图片">
                    </div>
                     <div style="float:left;width:110px;height:120px; text-align:center;">
                        <img id="PicTitleImg2" src="themes/default/images/waitpic.gif" width="100" height="100" />
                        <asp:textbox runat="server" ID="txt_PicTitle2" style="display:none;"></asp:textbox><br />
                        <input id="uploadButton-txt_PicTitle2-PicTitleImg2" class="Pic_Upload_File" type="button" value="选择图片">
                    </div>
                     <div style="float:left;width:110px;height:120px; text-align:center;">
                        <img id="PicTitleImg3" src="themes/default/images/waitpic.gif" width="100" height="100" />
                        <asp:textbox runat="server" ID="txt_PicTitle3" style="display:none;"></asp:textbox><br />
                        <input id="uploadButton-txt_PicTitle3-PicTitleImg3" class="Pic_Upload_File" type="button" value="选择图片">
                    </div>
                     <div style="float:left;width:110px;height:120px; text-align:center;">
                        <img id="PicTitleImg4" src="themes/default/images/waitpic.gif" width="100" height="100" />
                        <asp:textbox runat="server" ID="txt_PicTitle4" style="display:none;"></asp:textbox><br />
                        <input id="uploadButton-txt_PicTitle4-PicTitleImg4" class="Pic_Upload_File" type="button" value="选择图片">
                    </div>
                     <div style="float:left;width:110px;height:120px; text-align:center;">
                        <img id="PicTitleImg5" src="themes/default/images/waitpic.gif" width="100" height="100" />
                        <asp:textbox runat="server" ID="txt_PicTitle5" style="display:none;"></asp:textbox><br />
                        <input id="uploadButton-txt_PicTitle5-PicTitleImg5" class="Pic_Upload_File" type="button" value="选择图片">
                    </div>
               </dd>
			</dl>
            <dl>
				<dt>销售价：</dt>
				<dd>
                    <asp:TextBox ID="txtPrice" runat="server" Width="80%" CssClass="number"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>折扣价：</dt>
				<dd>
                    <asp:TextBox ID="txtRealPrice" runat="server" Width="80%" CssClass="number"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>库存数量：</dt>
				<dd>
                    <asp:TextBox ID="txtTotalCount" runat="server" Width="80%" CssClass="required digits"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>已售数量：</dt>
				<dd>
                    <asp:TextBox ID="txtSellCount" runat="server" Width="80%" CssClass="required" min="0" max="10000000"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>可获积分：</dt>
				<dd>
                    <asp:TextBox ID="txtGetPoint" runat="server" Width="80%" CssClass="required" ToolTip="每购买一件此商品可获得多少点积分（1RMB=100点积分）" min="0" max="100000"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>积分抵用：</dt>
				<dd>
                    <asp:TextBox ID="txtMaxPayPoint" runat="server" Width="80%" CssClass="required" ToolTip="每购买一件此商品最多可拿多少积分来抵现金支付（1RMB=100点积分）" min="0" max="100000"></asp:TextBox>
                </dd>
			</dl>
			<dl>
				<dt>状态：</dt>
				<dd>
                    <asp:dropdownlist ID="txtState" CssClass="combox" runat="server">
                        <asp:ListItem Value="0">未上架</asp:ListItem>
                        <asp:ListItem Value="1">上架中</asp:ListItem>
                        <asp:ListItem Value="2">库存不足</asp:ListItem>
                    </asp:dropdownlist>
                    
                </dd>
			</dl>
            </fieldset>
            <fieldset>
        <legend>自定义属性</legend>
        <div id="CustomAttr">请选择一个属性模板</div>
        </fieldset>
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
    <script type="text/javascript">
        $("#Template a").click(
        function ()
        {
            $("#txtAttributeGroupID").val($(this).attr("rel"));
            $.post($(this).attr("href"), function (data)
            { 
                $("#CustomAttr").html(data);
                initUI($("#CustomAttr"));
            }, "html");
            return false;
        });
        
        ///修改生成动态属性
        function SelectTemplateGroup(v, valuejson)
        {
            //alert(v);
            $("#Template a").each(
            function ()
            {
                if ($(this).attr("rel") == v)
                {
                    $("#txtAttributeGroupID").val($(this).attr("rel"));
                    $.post($(this).attr("href"), function (data)
                    {
                        $("#CustomAttr").html(data);
                        initUI($("#CustomAttr"));
                        $.each(valuejson, function (i, item)
                        {
                            alert(item.Key + "=" + item.Values);
                        });
                    }, "html");
                    return false;
                }
            });
        }        
    </script>
</div>