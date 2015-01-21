<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.LBSMaterial.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
    #IsShow label,#txtKeyType label{float:none;}
    .pageFormContent dd{width:70%;}
</style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">编辑商铺位置</h2>
			<dl>
				<dt>标题：</dt>
				<dd >
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>图文封面：</dt>
				<dd>
                    <div class="Container_Table">
                        <div>
                            <asp:TextBox ID="txtPictureAdrress" runat="server" CssClass="required" ReadOnly="true" ></asp:TextBox>
                            <asp:image runat="server" Id="ShowImage" style="_width:360px;max-width:360px;" CssClass="hide"></asp:image>
                         </div>
                        <div>&nbsp;</div>
                        <div><input type="button" id="uploadButton-txtPictureAdrress-ShowImage" value="选择图片" class="Pic_Upload_File"  />
                            大图片建议尺寸：360像素 * 200像素
                        </div>
                    </div>
                </dd>
			</dl>
           
            <dl>
				<dt>显示图文封面：</dt>
				<dd>
                <asp:radiobuttonlist ID="IsShow" runat="server"  RepeatDirection="Horizontal" >
                    <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:radiobuttonlist>
                  </dd>
			</dl>
            <dl>
				<dt>电话：</dt>
				<dd>
                    <asp:TextBox ID="txtTelPhone" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
           
            <dl>
				<dt>摘要：</dt>
				<dd>
                     <asp:TextBox ID="txtAbstract" TextMode="MultiLine" Height="48px" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>地址：</dt>
				<dd>
                     <asp:TextBox ID="txtAddress" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
                <dt>&nbsp;</dt>
                <dd>
                     <div id="l-map" style="height:300px;width:80%;"></div>
                     <script type="text/javascript">
                         $(function (ex) {
                             var map = new BMap.Map("l-map");
                             if ($("#txtlng").val() != "")
                                 map.centerAndZoom(new BMap.Point($("#txtlng").val(), $("#txtlat").val()), 12);
                             else
                                 map.centerAndZoom("台州", 12); 
                             map.enableScrollWheelZoom();
                             map.addEventListener("click", function (e) {
                                 map.clearOverlays();
                                 var marker1 = new BMap.Marker(new BMap.Point(e.point.lng, e.point.lat));
                                 map.addOverlay(marker1);
                                 $("#txtlng").val(e.point.lng);
                                 $("#txtlat").val(e.point.lat);
                             });
                             var marker1 = new BMap.Marker(new BMap.Point($("#txtlng").val(), $("#txtlat").val()));
                             map.addOverlay(marker1);
                         }); 
                    </script>
                </dd>
            </dl>
            <dl>
				<dt>经纬度</dt>
				<dd>
                    <table>
                        <tr>
                            <td>lng：</td>
                            <td><asp:TextBox ID="txtlng" runat="server"></asp:TextBox></td>
                            <td> lat：</td>
                            <td><asp:TextBox ID="txtlat" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </dd>
			</dl>
            <dl>
				<dt>详细页内容：</dt>
				<dd>
                    <asp:TextBox ID="txtDetailedContent" TextMode="MultiLine" runat="server" CssClass="editor" Width="80%" height="300"></asp:TextBox>
                </dd>
			</dl>
            <dl style="display:none;">
				<dt>原文网址：</dt>
				<dd>
                    <asp:TextBox ID="txtURL" runat="server"  Width="80%"></asp:TextBox>
                </dd>
			</dl>
			
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