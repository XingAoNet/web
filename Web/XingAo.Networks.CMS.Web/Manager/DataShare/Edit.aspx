<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.DataShare.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<div layoutH="30" style="float:left; display:block; overflow:auto; width:240px; border:solid 1px #CCC; line-height:21px; background:#fff">
<style>
    #jbsxBox{ line-height:normal;}
    #jbsxBox div{ height:auto;line-height:normal;}
.TabList{ width:200px; float:left; border:1px solid #CCC; margin:3px; padding:3px; font-size:16px; font-weight:bold; line-height:33px;}
.Clear{ clear:left;}
.TabList ul{ width:95%; margin:auto; overflow:hidden;}
.TabList li{ height:22px; line-height:22px; cursor:pointer;font-size:12px; font-weight:normal;}
.TabList li:hover{ background:#CCC}
</style>
	<ul class="tree treeCheck treeFolder" oncheck="DrawTable">
        <li><a href="javascript">用户自定义表</a>
			<ul>
            
                <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>
				<li><a tvalue="TID_<%#Eval("ID")%>|<%#Eval("TabName")%>"  tname="TID"><%#Eval("ChineseName")%></a></li>
                </ItemTemplate>
                </asp:repeater>
			</ul>
		</li>
		<li><a href="javascript">系统开放表</a>
            <ul>
                <li><a href="LableDesign/Designer.aspx?TName=<%=Server.UrlEncode(XingAo.Core.StringOption.Encrypt("XA_CMS_WebNavigation")) %>" target="ajax" rel="jbsxBox">网站栏目表</a></li>
            </ul>
        </li>
		</ul>
</div>
				
<div id="jbsxBox" class="unitBox" style="margin-left:246px; overflow:auto;">
	<div style=" line-height:normal;"></div>
    
    <div style=" line-height:normal;">
    <fieldset>
    <legend>sql语句</legend>
    <asp:textbox runat="server" ID="SqlTxt" Height="80px" 
    TextMode="MultiLine" Width="90%"></asp:textbox>
        <asp:hiddenfield runat="server" ID="txtID"></asp:hiddenfield>
    </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>调用名称</legend>
        <asp:textbox runat="server" ID="txtMethodName" Width="90%" CssClass="required"></asp:textbox>
        </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>数据类型</legend>
            <asp:dropdownlist runat="server" ID="txtMethodType" Width="90%" CssClass="combox required">
                <asp:ListItem Value="1">数据列表</asp:ListItem>
                <asp:ListItem Value="2">取单条数据</asp:ListItem>
                <asp:ListItem Value="3">更新数据（包括插入与修改</asp:ListItem>
                <asp:ListItem Value="4">删除数据</asp:ListItem>
            </asp:dropdownlist>
        </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>字段</legend>
        <asp:textbox runat="server" ID="txtFields" Width="90%" CssClass="required"></asp:textbox>
        </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>表</legend>
        <asp:textbox runat="server" ID="txtTables" Width="90%" CssClass="required"></asp:textbox>
        </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>条件</legend>
        <asp:textbox runat="server" ID="txtWhereStr" Width="90%"></asp:textbox>
        </fieldset>
    </div>  
    <div>
        <fieldset>
        <legend>排序</legend>
        <asp:textbox runat="server" ID="txtOrderBy" Width="90%"></asp:textbox>
        </fieldset>
    </div>
    <div>
        <fieldset>
        <legend>描述</legend>
        <asp:textbox runat="server" ID="txtDescriptions" Width="90%" MaxLength="550"></asp:textbox>
        </fieldset>
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
    var jbsxBox = $("#jbsxBox > div:first");
    function DrawTable(data)
    {
        if (data.checked)
        {
            var len = data.items.length;
            if (len != undefined)//父级操作时
            {
                for (var i in data.items)
                    if (data.items[i].value != "on")
                    {

                        CreateDataTableFieldsList(data.items[i].value.replace("TID_", ""), data.items[i].text);
                    }
            }
            else
            {
                CreateDataTableFieldsList(data.items.value.replace("TID_", ""), data.items.text);
            }
        }
        else
        {
            var len = data.items.length;
            if (len != undefined)//父级操作时
            {
                for (var i in data.items)
                {
                    $("#" + data.items[i].value.split("|")[0]).remove();
                }
            }
            else
            {
                $("#" + data.items.value.split("|")[0]).remove();
            }
        }
    }



    function CreateDataTableFieldsList(TableID, Title, TableName)
    {
        var TID_Name = TableID.split("|")
        var Tid = TID_Name[0];
        $.post("DBManager/GetFields.ashx?TID=" + Tid,
        function (data)
        {
            if (data != undefined && data.length > 0)
            {
                var listhtml = "<div id='TID_" + Tid + "' class='TabList'><ul id='" + TID_Name[1] + "'>" + Title;
                for (var i in data)
                {
                    listhtml += '<li title="' + data[i].Description + '"><input type="checkbox" id="TID_' + Tid + '" name="TID_' + Tid + '" value="' + data[i].FieldName + '">' + data[i].FieldName + '(' + data[i].ChineseName + ')' + '</li>'
                }
                listhtml += '</ul></div><div class="Clear"></div>';
                $(jbsxBox).find(".Clear").remove();
                $(listhtml).appendTo(jbsxBox);
                $("#" + TID_Name[1]).children("li").click(
                function (event)
                {
                    var checked = !$(this).children("input").attr("checked");
                    $(this).children("input").attr("checked", checked);
                    CreateSql();
                });
                $("#" + TID_Name[1]).find("input").change(
                function (event)
                {
                    $(this).parent("li").click();
                });

            }
        },
        "json");
    }

    function CreateSql()
    {
        var TableCount = 0;
        var allTableFields = "";
        var allTables = "";
        $(".TabList").each(
        function (index)
        {
            var haveChecked = false;
            if ($(this).find("input[type='checkbox']:checked").size() > 0)
            {
                allTables += $(this).find("ul").attr("id") + "|";
                $(this).find("input[type='checkbox']:checked").each(
                function ()
                {
                    allTableFields += $(this).val() + ",";
                });
                TableCount++;
                allTableFields += "|";
            }
        });
        if (allTableFields.length > 0)
            allTableFields = allTableFields.substring(0, allTableFields.length - 2);
        if (allTables.length > 0)
            allTables = allTables.substring(0, allTables.length - 1);
        var sql = "";
        if (TableCount == 1)
        {
            sql = "select " + allTableFields.replace("|", "") + " from [" + allTables.replace("|", "") + "]";
        }
        else if (TableCount > 1)
        {
            var tabArray = allTables.split("|");
            var fieldArray = allTableFields.split("|");
            sql = "select ";
            var TablesStr = " from ";
            for (i = 0; i < tabArray.length; i++)//循环表
            {
                var tableOthName = String.fromCharCode(i + 65);
                TablesStr = TablesStr.replace("{INNER JOIN}", "INNER JOIN");
                TablesStr += tabArray[i] + " as " + tableOthName + " {INNER JOIN} ";
                tableOthName += ".";
                var currentTableFields = fieldArray[i].split(",");
                for (j = 0; j < currentTableFields.length; j++)
                    if (currentTableFields[j].replace(" ", "") != "")
                        sql += tableOthName + currentTableFields[j] + ",";
            }
            TablesStr = TablesStr.replace("{INNER JOIN}", "on xxxx.xxxx=xxxxxxx.xxxxx");
            sql = sql.substring(0, sql.length - 1) + TablesStr;
        }
        $("#SqlTxt").val(sql);
        SplitSql(sql);
    }
    function SplitSql(sql)
    {
        re = /^select\s+(?:([\x00-\xFF]+\s+))from\s+(?:(\S+))(?:((\s+(where|and)\s+\S+(\=|>|<)\S+)+)?)(\s+order\s+by\s+(?:[\x00-\xFF]+))?/im;
        r = re.exec(sql);
        //alert("fields=" + r[1] + "\ntable=" + r[2] + "\nwhere=" + r[3] + "\norder=" + r[6]);
        $("#txtFields").val(r[1] == undefined ? "" : r[1]);
        $("#txtTables").val(r[2] == undefined ? "" : r[2]);
        $("#txtWhereStr").val(r[3]==undefined ? "" : r[3].toLowerCase().replace(" where ", ""));
        $("#txtOrderBy").val(r[7]==undefined ? "" : r[7].toLowerCase().replace(" order by ", ""));
    }
    $("#SqlTxt").keyup(
    function ()
    {
        SplitSql($(this).val());
    });
</script>