<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainInfo.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Sources.mainInfo" %>

<div class="pageContent">
    <div layoutH="3" style="float:left; display:block; overflow:auto; width:120px; border:solid 1px #CCC; line-height:21px; background:#fff">
	    <ul class="tree treeFolder">
		    <li><a href="/Manager/Wechat/Sources/TextListPage.aspx" checked="true" target="ajax" rel="jbsxBox">文本回复</a></li>
			<li><a href="/Manager/Wechat/Sources/ImageTextListPage.aspx" target="ajax" rel="jbsxBox">图文回复</a></li>
			<li><a href="/Manager/Wechat/Sources/ActiveList.aspx" target="ajax" rel="jbsxBox">微活动</a></li>
            <li><a href="/Manager/Wechat/Sources/BigWheelListPage.aspx" target="ajax" rel="jbsxBox">大转盘</a></li>
            <li><a href="/Manager/Wechat/Sources/ScratchCardListPage.aspx" target="ajax" rel="jbsxBox">大转盘</a></li>
		</ul>
    </div>	
    <div id="jbsxBox" class="unitBox" style="margin-left:125px;"></div>
</div>
<script type="text/javascript">
    $(function (ex)
    {
        window.setTimeout(function () { $(".tree a[checked='true']").click(); }, 50);
    });
</script>
