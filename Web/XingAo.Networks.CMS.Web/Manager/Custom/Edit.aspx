<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Custom.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
            <asp:hiddenfield runat="server" ID="txt_ID"></asp:hiddenfield>
            <asp:hiddenfield runat="server" ID="Fields_List"></asp:hiddenfield> 
            <asp:literal runat="server" ID="FormHtml"></asp:literal>
           
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
if (DefaultV != undefined)
{
    for (var key in DefaultV[0])
    {
        var id = "#txt_" + key;
        var value = DefaultV[0][key];
        if ($(id).attr("type") == "checkbox")
        {
            var CheckedObj = $("input [name='" + id.replace("#", "") + "',value='" + value + "']");
            if (CheckedObj.length > 0)
                CheckedObj.attr("checked", true);
            else
                $("input [name='" + id.replace("#", "") + "']").first().attr("checked", true);
        }               
        else
        {
            if (typeof value == "string") {
                if (value.indexOf("Dat") > 0)
                    $(id).val(new Date(parseInt(value.match(/-?\d+/g))).formatDate("yyyy-MM-dd"));
                else
                    $(id).val(value);
            }
            else
                $(id).val(value);
        }
    }
    $("a[lookupgroup]").each(function(index, element) {
        var CurObj=$(element);
		var url=CurObj.attr("href");
		var lookFor=CurObj.attr("lookupgroup");
		$.post(url,
		{"JsonOnly":1,"ID":$("input[type='hidden'][lookFor='"+lookFor+"']").val()},
		function(data)
		{
			$("input[lookFor='"+lookFor+"']").eq(1).val(data);
		},"html");
    });
}
var EachCount = $(".Bind").length;
var EachedCount = -1;
$(".Bind").each(
function (index)
{
    var attr = $(this).attr("DataBind").split("^");   
    var items = attr[1].split("|");
    var SelectObj = $(this);
    if (items.length > 1)
    {
        if (SelectObj.is("select"))
        {
            for (i = 0; i < items.length; i += 2)
            {
                $("<option value='" + items[i + 1] + "'>" + items[i] + "</option>").appendTo(SelectObj);
            }
            if (attr[0] != undefined && attr[0] != ""&& attr[0].split("|")[0]!="")//允许不绑定数据时，可以为空或|||形式
            {
                $.post("Custom/DataBindDataProviders.ashx",
                { "par": attr[0] },
		        function (data)
		        {
		            if (!data.IsErr)
		            {
		                var pars = attr[0].split("|");
		                for (var row in data.Data)
		                {
		                    var _id = eval("data.Data[row]." + pars[1]);
		                    var _value = eval("data.Data[row]." + pars[2]);
		                    $("<option value='" + _id + "'>" + _value + "</option>").appendTo(SelectObj);
		                }
		                if (DefaultV != undefined)
		                {
		                    try
		                    {
		                        SelectObj.val(DefaultV[0][SelectObj.attr("id").replace("txt_", "")]);
		                    }
		                    catch (e) { }
		                }
		            }

		        }, "json");
            }
            else
            {
                if (DefaultV != undefined)
                {
                    try
                    {
                        SelectObj.val(DefaultV[0][SelectObj.attr("id").replace("txt_", "")]);
                    }
                    catch (e) { }
                }
            }
        }
        else if (SelectObj.attr("type") == "checkbox")
        {
            var parentObj = SelectObj.parent();
            var cloneItems = SelectObj.clone();
            var tempid = cloneItems.attr("id");
            parentObj.children().remove();
            var i = 0;
            for (i = 0; i < items.length; i += 2)
            {
                cloneItems.attr("id", tempid + i);
                cloneItems.val(items[i + 1]);
                cloneItems.appendTo(parentObj);
                parentObj.html(parentObj.html() + items[i] + "&nbsp;");
            }
            if (attr[0] != undefined && attr[0] != "")
            {
                $.post("Custom/DataBindDataProviders.ashx",
                { "par": attr[0] },
		        function (data)
		        {
		            if (!data.IsErr)
		            {
		                var pars = attr[0].split("|");
		                for (var row in data.Data)
		                {
		                    i++;
		                    var _id = eval("data.Data[row]." + pars[1]);
		                    var _value = eval("data.Data[row]." + pars[2]);
		                    cloneItems.attr("id", tempid + i);
		                    cloneItems.val(_id);
		                    cloneItems.appendTo(parentObj);
		                    parentObj.html(parentObj.html() + _value + "&nbsp;");
		                }
		                if (DefaultV != undefined)
		                {
		                    try
		                    {
		                        var value = "," + DefaultV[0][SelectObj.attr("id").replace("txt_", "")] + ",";
		                        var objname = SelectObj.attr("name");
		                        $("input[name='" + objname + "']").each(
                                function (index, element)
                                {
                                    if (value.indexOf("," + $(this).val() + ",") >= 0)
                                    {
                                        $(this).attr("checked", "true");
                                    }
                                });
		                    }
		                    catch (e) { }
		                }
		            }

		        }, "json");
            }
            else
            {
                if (DefaultV != undefined)
                {
                    try
                    {
                        var value = "," + DefaultV[0][SelectObj.attr("id").replace("txt_", "")] + ",";
                        var objname = SelectObj.attr("name");
                        $("input[name='" + objname + "']").each(
                        function (index, element)
                        {
                            if (value.indexOf("," + $(this).val() + ",") >= 0)
                            {
                                $(this).attr("checked", "true");
                            }
                        });
                    }
                    catch (e) { }
                }
            }
        }
    }
    EachedCount = index;
});
var ClearDefaultVInterval = setInterval(//一直等待所有项赋值都完成时再清空默认值
function ()
{
    if (EachCount == EachedCount)
    {
        clearInterval(ClearDefaultVInterval);
        DefaultV = undefined;
    }
},
500);


Date.prototype.formatDate = function (format)
{
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
 (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
 RegExp.$1.length == 1 ? o[k] :
 ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}      
</script>
</div>
