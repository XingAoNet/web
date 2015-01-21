<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Collect.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>采集名：</dt>
				<dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>采集时间：</dt>
				<dd>
                    <asp:TextBox ID="txtTime" runat="server" Width="80%"  Cssclass="date" dateFmt="HH:mm:ss" readonly="true"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>采集地址：</dt>
				<dd>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="url required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>采集正则：</dt>
				<dd style="width:80%;">
                    <asp:TextBox ID="txtReg" runat="server" CssClass="required" Width="70%"></asp:TextBox>&nbsp;&nbsp;正则匹配参数：(< ?content >?)
                </dd>
			</dl>
            <dl>
				<dt>上传内容表：</dt>
				<dd style="width:80%;">
                  <asp:dropdownlist runat="server" id="TableDropDown"></asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>采集内容正则：</dt>
				<dd style="width:80%;">
                    <asp:TextBox ID="txtContentReg" runat="server" CssClass="required" Width="70%"></asp:TextBox>&nbsp;&nbsp;正则匹配参数：(< ?content >?)
                </dd>
			</dl>
            <dl>
				<dt>状态：</dt>
				<dd style="width:80%;">
                    <asp:checkbox runat="server" id="CkUse" Text="" ></asp:checkbox>使用
                </dd>
			</dl>
	        <div class="divider"></div>
		    <h3 class="contentTitle">采集内容规则</h3>
		    <div class="tabs">
			    <div class="tabsHeader">
				    <div class="tabsHeaderContent">
					    <ul>
						    <li class="selected"><a href="javascript:void(0)"><span>内容标签</span></a></li>
					    </ul>
				    </div>
			    </div>
			    <div class="tabsContent" style="height: 300px;">
				    <div>
					    <table class="list nowrap itemDetail" addButton="新建内容标签" width="100%">
						    <thead>
							    <tr>
								    <th type="text" name="items" size="12"  fieldClass="required">参数名</th>
								    <th type="text" name="itemsReg"  size="80" fieldClass="required">正则【匹配参数：(< ?content >?)】</th>
                                    <th type="lookup" id="FiledLookFor" name="org.FiledName"  lookupGroup="org" lookupUrl="DBManager/GetTableFields.ashx" suggestUrl="DBManager/GetTableFields.ashx" suggestFields="FiledName" postField="keywords" size="12">字段</th>

                                    <th type="text" name="defaultVal" size="12">默认值</th>
								    <th type="del" width="70">操作</th>
							    </tr>
						    </thead>
						    <tbody>
                                <asp:repeater runat="server" id="ParamList">
                                 <ItemTemplate>          
                                     <tr class=unitBox> 
                                        <td><input class="required textInput" size="12" name="items" value="<%#Eval("ParamName") %>" /></td> 
                                        <td><input class="required textInput" size="80" name="itemsReg" value="<%#StringOption.HTML_Code(Eval("Expression").ToString()) %>"  /></td> 
                                        <td><input class="required textInput" size="12" name="org.FiledName" value="<%#Eval("InsertField") %>"  /></td> 
                                        <td><input class="textInput" size="12" name="defaultVal" value="<%#Eval("defaultValue") %>"  /></td> 
                                        <td><a class="btnDel " href="javascript:void(0)">删除</a></td>
                                      </tr> 
                                    </ItemTemplate>
                                </asp:repeater>
                            </tbody>
					    </table>
				    </div>
			    </div>
			    <div class="tabsFooter">
				    <div class="tabsFooterContent"></div>
			    </div>
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
<script type="text/javascript">
    $(function (ex) {
        var drID = $("#TableDropDown").val();
        $("#FiledLookFor").attr("suggestUrl", "DBManager/GetTableFields.ashx?TID=" + drID).attr("lookupUrl", "DBManager/GetTableFields.ashx?TID=" + drID);
        $("#TableDropDown").change(function (ex) {
            $("#FiledLookFor").attr("suggestUrl", "DBManager/GetTableFields.ashx?TID=" + $(this).val()).attr("lookupUrl", "DBManager/GetTableFields.ashx?TID=" + $(this).val());
            var $p = $(document);

            $("table.itemDetail").attr("addButton", $("#TableDropDown").find("option:selected").text())
            $("table.itemDetail tr:gt(0)").remove();
            $(".ItemAddBtn").remove();
            $("table.itemDetail", $p).itemDetail();
        });
    })
</script>