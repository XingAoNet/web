<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialFamilyPage.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Sources.MaterialFamilyPage" %>
<%@ Import Namespace="XingAo.Core" %>

<script type="text/javascript">
    function getNode() {
        var n = $('input[name=orgId]:checked');
        if (n.size()>0) {
            var _n = n.val().split('_');
            $.bringBack({ txtKeys: 'Limit_' + $("#LimitNum").val() + "_" + _n[0], txtKeys_text: _n[1], 'txtSource': 'MaterialFamily', 'txtIMId': _n[0] })
        }
        
    }
</script>
<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>返回最新记录数：<input type="text" id="LimitNum" value="1" /></td>
                <td>
                <div class="buttonActive"><div class="buttonContent"><button type="button" onclick="getNode();">确定</button></div></div></td>
			</tr>
		</table>
	</div>
<div class="pageContent">
	 <table class="table" layoutH="118" targetType="dialog" width="100%">
	    <thead>
		    <tr>
			    <th width="30"></th>
                <th width="160">栏目名</th>
			    <th>描述</th>
		    </tr>
	    </thead>
        <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate> 
                <tr>
                    <td><input type="radio" name="orgId" value="<%#Eval("Id")%>_<%#Eval("Name")%>"/></td>
                    <td><%#Eval("Name")%></td>
                    <td><%#Eval("Describe")%></td>
                </tr>  
            </ItemTemplate>
        </asp:repeater>
    </table>
</div>