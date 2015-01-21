<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Organizations.OrgMembers.Main" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
 	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
     <asp:hiddenfield runat="server" ID="TxtOrgId"></asp:hiddenfield>
    <div class="pageFormContent" layoutH="97">
		<div class="tabs">
			<div class="tabsHeader">
				<div class="tabsHeaderContent">
					<ul>
						<li class="selected"><a href="javascript:void(0)"><span>所属成员</span></a></li>
					</ul>
				</div>
			</div>
			<div class="tabsContent" style="height: 150px;">
				<div>
					<table class="list nowrap itemDetail" addButton="添加成员" width="100%">
						<thead>
							<tr>
                            <th type="lookup" name="orgName" lookupGroup="org" lookupUrl="Members/LookForMember.aspx" size="80" fieldClass="required">姓名</th>
                  
								<th type="del" width="60">操作</th>
							</tr>
						</thead>
						<tbody>
                            <asp:repeater runat="server" id="ParamList">
                                 <ItemTemplate>          
                                     <tr class=unitBox> 
                                        <td>
                                            <input type="hidden"  name="DbID" value="<%#Eval("Id") %>"  />
                                            <input type="hidden"  name="id" value="<%#Eval("MemberId") %>"  />
                                            <input class="required textInput" size="80" name="orgName" value="<%#Eval("MemberName") %>"  />
                                        </td> 
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
			<li><div class="button"><div class="buttonContent"><button class="close" type="button">关闭</button></div></div></li>
		</ul>
	</div>
    </form>
</div>