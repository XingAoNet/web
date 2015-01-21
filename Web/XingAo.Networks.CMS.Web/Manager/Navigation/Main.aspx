<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Navigation.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keyString" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
    <%--高级检索--%>
    <%--<input type="hidden" name="classID" value="<%=ClassID %>" />
    <input type="hidden" name="searchTitle" value="<%=SearchTitle %>" />
    <input type="hidden" name="startDate" value="<%=StartDate %>" />
    <input type="hidden" name="endDate" value="<%=EndDate %>" />
    <input type="hidden" name="setTop" value="<%=SetTop %>" />
    <input type="hidden" name="Pass" value="<%=Pass %>" />--%>
</form>


<div class="pageHeader">
<style>
.BeginMove{ background:#CCC;}
.move{ cursor:move;}
.height30{ height:60px; line-height:60px;}
.height30 td{ height:60px; line-height:60px;}
</style>
	<form onsubmit="return navTabSearch(this);" action="<%=Request.GetPath() %>/main.aspx" method="post"><%--基于Manager目录开始的路径--%>
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					栏目名：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
			</tr>
		</table>
		<div class="subBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">查询</button></div></div></li>
			</ul>
		</div>
	</div>
	</form>
</div>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar"> 
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>" target="dialog" width="1000" height="500" title="添加栏目信息" rel="nav_add"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>&id={sid}" target="dialog" width="1000" height="500" title="修改栏目信息" rel="nav_edit" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
                <th width="50" align="center">排序</th>
				<th width="150">栏目名称</th>
				<th width="80">英文名</th>
                <th width="80">编码</th>
                <th>外部链接</th>
                <th width="80">打开方式</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>" type="checkbox" <%#Eval("id").ToString()=="1"?"disabled=\"true\"":""%>></td>
                <td><a href="Navigation/Move.ashx?Par=<%#Eval("ID") %>|1" target="ajaxTodo">↑</a>&nbsp;&nbsp;<a href="Navigation/Move.ashx?Par=<%#Eval("ID") %>|0" target="ajaxTodo">↓</a></td>
				<td class="DropAble"><%#Eval("code").ToString().Length>4?"|".PadRight(Eval("code").ToString().Length/4*3,'-'):""%><%#Eval("Name")%></td>
				<td><%#Eval("eName")%></td>
                <td><%#Eval("code")%></td>
				<td><%#Eval("outLink")%></td>	
                <td><%#Eval("target")%></td>			
			</tr>
            </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
		<div class="pages">
			<span>显示</span>
			<select class="combox" name="numPerPage" onchange="navTabPageBreak({numPerPage:this.value})">
				<option value="20">20</option>
				<option value="50">50</option>
				<option value="100">100</option>
				<option value="200">200</option>
			</select>
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize-1)/PageSize%>页</span>

		</div>
	<div id="moveContent" style="position:absolute; width:600px; border:3px solid red; top:0; left:0; display:none; background:#FFF; padding:5px;"></div>	
		
        <div class="pagination" targetType="navTab" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>
<script language="javascript" type="text/javascript"> 
//因项目进度需要，卢小阳于2013年9月25日 08:34:17暂时注释下以“以拖拉方式实现栏目排序”功能，改用上下移动方式
//setTimeout("drop()",2000);
//var IsDown=false;
//var Offset=$(".pageContent").offset();
//var trList=$("tr[target='sid']");
//function drop()
//{
//	$(".DropAble").mousedown(
//	  function()
//	  {
//		  $(this).addClass("move");
//		  var code=$(this).siblings("td:eq(2)").children("div").html();
//		  var index=$(this).parents("tr").index();
//		  $("tr[target='sid']").each(function(index2)
//		  {
//			  if(index2>=index)
//			  {
//				  var tr=$(this);
//				  if(tr.children("td:eq(3)").children("div").html().indexOf(code)==0)
//				  {
//					  tr.addClass("BeginMove");
//				  }
//				  else
//					  return false;
//			  }
//		  });
//		  IsDown=true;
//	  });
//}

//$(document).mousemove(
//function(e)
//{
//	if(IsDown)
//	{		
//		if($("#moveContent").html()=="")
//		{
//			$(document).bind("selectstart",function(){return false;});
//			var html="<table>"
//			$(".BeginMove").each(function(index, element) {
//				html+="<tr>"+$(this).html()+"</tr>";
//			});
//			html+="<table>";
//			$("#moveContent").html(html).show();
//			$(".BeginMove").hide();
//			$(".DropAble").mousemove(
//			function(ev)
//			{
//				if(!$(this).hasClass("height30"))
//					$(this).addClass("height30");
//				$("#moveContent").html(ev.clientY);
//			}).mouseout(
//			function()
//			{
//				$(".height30").removeClass("height30");
//			});
//		}
//		$("#moveContent").css({left:(e.clientX-Offset.left+5)+"px",top:(e.clientY-Offset.top+5)+"px"});		
//	}
//}).mouseup(
//function()
//{
//	IsDown=false;
//	$("#moveContent").html("").css("display","none");
//	$(".BeginMove").show().removeClass("BeginMove");
//	$(".move").removeClass("move");
//	$(".DropAble").unbind("mousemove").unbind("mouseout").removeClass("height30");
//	$(document).unbind("selectstart");
//});

</script>

