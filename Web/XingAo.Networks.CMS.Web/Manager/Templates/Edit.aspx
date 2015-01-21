<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
      <div layoutH="56" style="float:left; display:block; overflow:auto; width:240px; border:solid 1px #CCC; line-height:21px; background:#fff">
        <ul class="tree treeFolder">
            <li><a href="javascript">自定义标签</a>
			    <ul class="dbLabels">
                    <asp:repeater runat="server" ID="Rep_LabelList">
                        <ItemTemplate>
				            <li>
                                <a tname="{$XA_<%#Eval("LableName")%>$}"><%#Eval("LableName")%></a>
                                <ul>
                                    <asp:repeater runat="server" DataSource='<%#Eval("Params") %>'>
                                        <ItemTemplate>
				                            <li>
                                                <a tname="<%#Eval("ParamName").ToString().Replace("@","")+"="+Eval("DefaultValue")%>"><%#Eval("ParamName")%>(<%#Eval("ParamDescription")%>)</a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:repeater>
                                </ul>
                            </li>
                        </ItemTemplate>
                    </asp:repeater>
			    </ul>
		    </li>
		    <li><a href="javascript:;">系统标签</a>
                <ul class="dbLabels">
                     <asp:repeater runat="server" ID="Rep_SysLabelList">
                        <ItemTemplate>
				            <li>
                                <a tname="{$XingAo_<%#Eval("LabelName")%>$}"><%#Eval("LabelName")%></a>
                            </li>
                        </ItemTemplate>
                    </asp:repeater>
                </ul>
            </li>
            <li><a href="javascript:;">公共模块</a>
                <ul class="dbLabels">
                     <asp:repeater runat="server" ID="Rep_CommModelList">
                        <ItemTemplate>
				            <li>
                                <a tname="{$<%#Eval("TemplateName")%>$}"><%#Eval("TemplateName")%></a>
                            </li>
                        </ItemTemplate>
                    </asp:repeater>
                </ul>
            </li>
	    </ul>
      </div>
		<div class="pageFormContent nowrap" layoutH="56">
             <dl>
				<dt>所属分组：</dt>
				<dd>
                     <asp:dropdownlist runat="server" ID="TemplateGroup" CssClass="combox"></asp:dropdownlist>
                </dd>
			</dl>
			<dl>
				<dt>名称：</dt>
				<dd>
                    <asp:TextBox ID="txtTemplateName" runat="server" CssClass="required" Width="80%" MaxLength="50"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>英文名称：</dt>
				<dd>
                    <asp:TextBox ID="txtTemplateEName" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtTemplateType" CssClass="combox">
                        <asp:ListItem Value="0">公共模块</asp:ListItem>
                        <asp:ListItem Value="1">首页模板</asp:ListItem>
                        <asp:ListItem Value="2">列表页模板</asp:ListItem>
                        <asp:ListItem Value="3">详细页模板</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>描述：</dt>
				<dd>
                    <asp:TextBox ID="txtTemplateDescription" runat="server" Width="80%" MaxLength="500"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>模板内容：</dt>
				<dd>
                <div class="tabs" currentIndex="0" eventType="click">
		            <div class="tabsHeader">
			            <div class="tabsHeaderContent">
				            <ul>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(1);"><span>代码模式</span></a></li>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(0);"><span>视图模式</span></a></li>
				            </ul>
			            </div>
		            </div>
		            <div class="tabsContent" style="height:350px;">
			            <div><asp:TextBox ID="txtTemplateHtml" runat="server" TextMode="MultiLine" 
                        Height="340px" Width="98%"></asp:TextBox></div>	
                        <div></div>		           
		            </div>
		            <div class="tabsFooter">
			            <div class="tabsFooterContent"></div>
		            </div>
	            </div>
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
<script src="Script/htmlformat.js" type="text/javascript"></script>
<script src="Script/TextInsert.js" type="text/javascript"></script>
<script type="text/javascript">
    $("ul.dbLabels a").click(function (ex) {
        if (EditMode == 1)
            $("#txtTemplateHtml").insertAtCaret($(this).attr("tname"));
        else
            editor.insertHtml($(this).attr("tname"));
    })
    var editor;
    var head = "";
    var body = "";
    var foot = "";
    var EditMode = 1;
    function ShowHiddenEditor(rel) {
        var TxtTemplate = $("#txtTemplateHtml");
        EditMode = rel;
        if (rel == 0) {
            var TemplateHtml = TxtTemplate.val();
            var matches = TemplateHtml.match(/^(([\s\S]*)<body>)([\s\S]*)(<\/body>([\s\S]*)<\/html>)/);
            if (matches.length > 4) {
                head = matches[1];
                body = matches[3];
                foot = matches[4];
            }
           
            TxtTemplate.val(body);

            editor = KindEditor.create("#txtTemplateHtml",
            {
                resizeType: 0,
                filterMode: false,
                wellFormatMode: false,
                uploadJson: 'kindeditor417/DotNet/upload_json.ashx',
                fileManagerJson: 'kindeditor417/DotNet/file_manager_json.ashx',
                allowFileManager: true,
                afterBlur: function () { editor.sync();},
                items: ["image", "flash", "media", "table", "hr", "link", "unlink", "insertfile"]
                //image 	图片
                //flash 	Flash
                //media 	视音频
                //table 	表格
                //hr 	插入横线
                //emoticons 	插入表情
                //link 	超级链接
                //unlink 	取消超级链接
                //fullscreen 	全屏显示
                //about 	关于
                //print 	打印
                //code 	插入程序代码
                //map 	Google地图
                //baidumap 	百度地图
                //lineheight 	行距
                //clearhtml 	清理HTML代码
                //pagebreak 	插入分页符
                //quickformat 	一键排版
                //insertfile 	插入文件
                //template 	插入模板
                //anchor 	插入锚点

            });
            $(".buttonActive button[type='submit'],.tabsHeaderContent a").click(
            function ()
            {
                editor.sync();
            });
            setTimeout(function ()
            {
                $(".tabsContent div:first").show().attr().siblings().hide();
            }, 200);
        }
        else if (rel == 1) {
            KindEditor.remove("#txtTemplateHtml", 0);
            TxtTemplate.val(head + TxtTemplate.val()+foot);
           
        }        
        return false;
    }    
</script>