<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Advertising.AD.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
<style type="text/css">
#txtShowType label{ float:right;}
#txtShowType input{ float:left}
</style>
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>名称：</dt>
				<dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>显示类型：</dt>
				<dd>
                    <asp:radiobuttonlist ID="txtShowType" runat="server" 
                        RepeatDirection="Horizontal" CssClass="required">
                        <asp:ListItem Value="0" Selected="True">普通</asp:ListItem>
                        <asp:ListItem Value="1">固定浮动式</asp:ListItem>
                        <asp:ListItem Value="2">全屏飘浮式</asp:ListItem>
                    </asp:radiobuttonlist>
                </dd>
			</dl>
            <dl>
				<dt>所属分组：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtGroupID" CssClass="required"></asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>输出：</dt>
				<dd>
                    <asp:checkbox runat="server" id="outputCk" Text="脚本输出"></asp:checkbox>
                </dd>
			</dl>
            <dl>
				<dt>广告内容：</dt>
				<dd style="width:75%;">
                    <div class="tabs" currentIndex="0" eventType="click">
		            <div class="tabsHeader">
			            <div class="tabsHeaderContent">
				            <ul>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(1);"><span>代码模式</span></a></li>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(0);"><span>视图模式</span></a></li>
				            </ul>
			            </div>
		            </div>
		            <div class="tabsContent" style="height:260px;">
			            <div>
                            <asp:TextBox ID="txtHtml" runat="server" TextMode="MultiLine" 
                        Height="250px" Width="98%"></asp:TextBox></div>	
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
        <div id="ShowDemo" style=" position:absolute; top:5px; right:5px; max-width:500px; text-align:right; display:none; border:3px solid #CCC"><img src="Advertising/AD/1.jpg" width="424" height="405" alt="" /></div>
        <script type="text/javascript">
            function ShowHiddenEditor(rel)
            {
                var TxtTemplate = $("#txtHtml");                
                if (rel == 0)
                {
                    var TemplateHtml = TxtTemplate.val();
                    editor = KindEditor.create("#txtHtml",
                    {
                        resizeType: 0,
                        filterMode: false,
                        wellFormatMode: false,
                        uploadJson: 'kindeditor417/DotNet/upload_json.ashx',
                        fileManagerJson: 'kindeditor417/DotNet/file_manager_json.ashx',
                        allowFileManager: true,
                        items: ["image", "flash", "media", "table", "hr", "link", "unlink", "insertfile"],
                        afterBlur: function () { editor.sync(); }
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
                else if (rel == 1)
                {
                    KindEditor.remove("#txtHtml", 0);                    
                }
                return false;
            }			
            $("input[name='txtShowType']").change(
            function ()
            {
                CreateForm($(this).val());
            }); 
            var JsonParDefaultValue=<%=JsonParDefaultValue%>;
            function CreateForm(v)
            {
                $("input[name='txtShowType']").each(
                function()
                {
                    if($(this).val()==v)
                    {
                        $(this).attr("checked",true);
                        return false;
                    }
                });
                $(".JsonArea").remove();
				$("#ShowDemo").html("").hide();
                if (v == "1")
                {
                    var html = '<dl class="JsonArea"><dt>关闭左间距：</dt><dd><input name="JsonPar_CloseLeft" type="text" value="-98px" title="" class="required" />当广告处于关闭状态时，广告层距离屏幕左侧的间距<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';					
                    html += '<dl class="JsonArea"><dt>左间距：</dt><dd><input name="JsonPar_Left" type="text" value="1px" class="required" />广告层距离屏幕左侧的间距<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';
					html += '<dl class="JsonArea"><dt>底间距：</dt><dd><input name="JsonPar_Bottom" type="text" value="30px" class="required" />广告层距离屏底部的间距<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';
                    html += '<dl class="JsonArea"><dt>头部图片：</dt><dd><input name="JsonPar_OpenTitlePic" id="JsonPar_OpenTitlePic" type="text" value="" class="required" /><input type="button" id="uploadButton-JsonPar_OpenTitlePic" value="选择图片" class="Pic_Upload_File" />&nbsp;广告头部（不包括关闭按钮）的图片地址<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';
					html += '<dl class="JsonArea"><dt>头部关闭图片：</dt><dd><input name="JsonPar_ClosePic" id="JsonPar_ClosePic" type="text" value="" class="required" /><input type="button" id="uploadButton-JsonPar_ClosePic" value="选择图片" class="Pic_Upload_File" />&nbsp;广告头关闭按钮的图片地址<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';
					html += '<dl class="JsonArea"><dt>关闭后图片：</dt><dd><input name="JsonPar_CloseShowPic" id="JsonPar_CloseShowPic" type="text" value="" class="required" /><input type="button" id="uploadButton-JsonPar_CloseShowPic" value="选择图片" class="Pic_Upload_File" />&nbsp;广告头关闭后显示图片地址<span class="JsonParHelper" style="cursor:pointer;  font-weight:bold; color:blue">?</span></dd></dl>';
                    $(html).insertAfter($("input[name='txtShowType']").eq(0).parents("dl"));
					$(".JsonParHelper").click(function()
					{
						$('#ShowDemo').html('<img src="Advertising/AD/1.jpg" width="424" height="405" alt="" />').show().click(function(){$(this).html("").hide();});
					});
					
                    // [{"CloseLeft":"-98px","Left":"1px","OpenTitlePic":"/images/AdTitle_{1}.gif","ClosePic":"/images/AdClose_{1}.gif","CloseShowPic":"/images/AdSmall_{1}.gif","Bottom":"30px"}];  
                }
                else if(v==2)//全屏浮动                
				{
                    var html = '<dl class="JsonArea"><dt>起始横坐标：</dt><dd><input name="JsonPar_StartX" type="text" value="50" title="" class="required digits" />当广告显示时初始X坐标值</dd></dl>';					
                    html += '<dl class="JsonArea"><dt>起始纵坐标：</dt><dd><input name="JsonPar_StartY" type="text" value="60" class="required digits" />当广告显示时初始Y坐标值</dd></dl>';
					html += '<dl class="JsonArea"><dt>移动距离：</dt><dd><input name="JsonPar_Step" type="text" value="1" class="required digits" />每次移动距离</dd></dl>';
                    html += '<dl class="JsonArea"><dt>移动时间：</dt><dd><input name="JsonPar_Delay" type="text" value="10" class="required digits" />每多少时间移动一次（单位毫秒）</dd></dl>';
                    $(html).insertAfter($("input[name='txtShowType']").eq(0).parents("dl"));
                    //var ConfigJson_｛１｝=[｛"StartX":"50","StartY":"60","Step":"1","Delay":"10"｝]; 
				}
                if(JsonParDefaultValue.length>0)
				{
					$(".JsonArea input[type='text']").each(function(index, element) 
					{
                        var name=$(element).attr("name").replace("JsonPar_","");
						$(this).val(JsonParDefaultValue[0][name]);
                    });
				}
				initUI(".pageFormContent");
            }
        </script>
        
	</form>
</div>