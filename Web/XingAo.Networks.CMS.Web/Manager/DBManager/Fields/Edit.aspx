<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.DBManager.Fields.Edit" ValidateRequest="false" %>
<style type="text/css">
dd input,dd select{ width:60%}
</style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<div class="pageFormContent nowrap" layoutH="56">
			<fieldset>
            <legend>数据库</legend>
            <dl class="ShowInForm">
				<dt>是否主键：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtIsPrimaryKey" CssClass="combox">
                        <asp:ListItem  Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:dropdownlist>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="txtTID" runat="server" />
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>是否系统字段：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtIsSystemField" CssClass="combox">
                        <asp:ListItem  Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:dropdownlist>
                   
                </dd>
			</dl>
            <dl>
				<dt>英文名：</dt>
				<dd>
                    <asp:TextBox ID="txtFieldName" runat="server" CssClass="required"></asp:TextBox>
                    
                </dd>
			</dl>
            <dl>
				<dt>中文名：</dt>
				<dd>
                    <asp:TextBox ID="txtChineseName" runat="server" CssClass="required"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>描述：</dt>
				<dd>
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="100"></asp:TextBox>
                </dd>
			</dl>
			<dl>
				<dt>数据类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDataType" CssClass="combox required"></asp:dropdownlist></dd>
			</dl>
            <dl>
				<dt>长度：</dt>
				<dd>
                <asp:textbox runat="server" ID="txtLeng" MaxLength="5" ToolTip="所选择数据类型的长度，若无像int这些没有长度的请保持为空"></asp:textbox>0为max.如：varchar(max)即varchar(8000)</dd>
			</dl>
            <dl class="ShowInForm">
				<dt>默认值：</dt>
				<dd>
                    <asp:textbox runat="server" ID="txtDefaultValue"></asp:textbox>
                </dd>
			</dl>
            </fieldset>
            
            <fieldset>
            <legend>编辑界面</legend>
            <dl>
				<dt>在后台显示：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtShowInForm" CssClass="combox">
                        <asp:ListItem Selected="True" Value="1">在编辑界面中显示</asp:ListItem>
                        <asp:ListItem Value="0">不在编辑界面中显示</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>显示方式：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtUseTag_P" CssClass="combox">
                        <asp:ListItem Selected="True" Value="1">一行显示多个表单项</asp:ListItem>
                        <asp:ListItem Value="0">一行只显示一个表单项</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>显示分割线：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDrawLin" CssClass="combox">
                        <asp:ListItem Selected="True" Value="1">在此表单项后绘制分割线</asp:ListItem>
                        <asp:ListItem Value="0">不显示</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>表单名称：</dt>
				<dd>
                    <asp:textbox runat="server" ID="txtFormTxt" ToolTip="在网站后台表单时，表单前面的名称，如此处的‘在后台显示、表单名称、表单类型’（不能为空）" CssClass="required"></asp:textbox>
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>表单类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtFormControlType" CssClass="combox">
                        
                    </asp:dropdownlist>
                </dd>
			</dl>       
            <dl class="ShowInForm">
				<dt>数据绑定：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtDataBind"></asp:TextBox>
                    <br />
                    表名|绑定值|绑定文本^自定义绑定文本|自定义值|自定义绑定文本2|自定义值2...
                </dd>
			</dl> 
            <dl class="ShowInForm">
				<dt>控件宽度：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtWidth"></asp:TextBox>?px或？%,空为不设置
                </dd>
			</dl> 
            <dl class="ShowInForm">
				<dt>控件高度：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtHeight"></asp:TextBox>?px或？%,空为不设置
                </dd>
			</dl>      
            <dl class="ShowInForm">
				<dt>数据验证：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDataValidation" CssClass="combox"></asp:dropdownlist>
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>验证对象或大小：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtDataValidationConparTo" CssClass="combox"></asp:TextBox>
                    <br />
                    数据验证类别为与某控件相等时或比较大小等类型时有效
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>显示序号：</dt>
				<dd>
                    <asp:textbox runat="server" ID="txtShowFormIndex" ToolTip="在后台生成表单时的顺序(必须是整数)" CssClass="required digits">0</asp:textbox>(越大越靠前)
                </dd>
			</dl>
            </fieldset>
            <fieldset>
            <legend>列表界面</legend>
            <dl>
				<dt>在后台显示：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtShowList" CssClass="combox">
                        <asp:ListItem Selected="True" Value="1">在列表页中显示</asp:ListItem>
                        <asp:ListItem Value="0">不在列表页中显示</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>表头名称：</dt>
				<dd>
                    <asp:TextBox ID="txtDisplayTitleText" runat="server" CssClass="required"></asp:TextBox>
                    
                </dd>
			</dl>
            <dl>
				<dt>表头宽度：</dt>
				<dd>
                    <asp:TextBox ID="txtTitleWidth" runat="server" CssClass="digits"></asp:TextBox>空为自适应宽度
                    
                </dd>
			</dl>
            <dl>
				<dt>表头对齐方式：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtAlign" CssClass="combox">
                        <asp:ListItem Selected="True" Value="">默认</asp:ListItem>
                        <asp:ListItem Value="left">左对齐</asp:ListItem>
                        <asp:ListItem Value="center">居中</asp:ListItem>
                        <asp:ListItem Value="right">右对齐</asp:ListItem>
                    </asp:dropdownlist>
                    
                </dd>
			</dl>
            <dl>
				<dt>数据对齐方式：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDataItemAlign" CssClass="combox">
                        <asp:ListItem Selected="True" Value="">默认</asp:ListItem>
                        <asp:ListItem Value="left">左对齐</asp:ListItem>
                        <asp:ListItem Value="center">居中</asp:ListItem>
                        <asp:ListItem Value="right">右对齐</asp:ListItem>
                    </asp:dropdownlist>
                    
                </dd>
			</dl>
            <dl>
				<dt>超链接：</dt>
				<dd>
                    <asp:TextBox ID="txtHrefLink" runat="server"></asp:TextBox>空为不设置<br />格式：&lt;a href=&quot;{Dir}/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>&ID={字段名}&amp;TID={Req_TID}&quot;&gt;{0}&lt;/a&gt;<br />
                    {Dir}--后台目录<br />
                    {Req_TID}--Request.QueryString[&quot;TID&quot;](TID为参数名，可任意变更)</dd>
			</dl>
            <dl>
				<dt>值转义表达式：</dt>
				<dd>
                    <asp:TextBox ID="txtDisplayValue" runat="server"></asp:TextBox>空为不设置<br />
                    格式：{0}==1?&quot;是&quot;:&quot;否&quot;【注意：只支持三目运算符来转义,同时带有转义与格式化时，格式化优先执行】</dd>
			</dl>
            <dl>
				<dt>值格式化：</dt>
				<dd>
                    <asp:TextBox ID="txtFormat" runat="server" ></asp:TextBox>空为不设置<br />
                    例如：时间格式化yyyy-MM-dd,货币格式化0.00【注意：只支持三目运算符来转义,同时带有转义与格式化时，格式化优先执行】</dd>
			</dl>
            <dl>
				<dt>显示序号：</dt>
				<dd>
                    
                    <asp:textbox runat="server" ID="txtShowListIndex" ToolTip="在后台生成列表页时的顺序(必须是整数)" CssClass="required digits">0</asp:textbox>(越大越靠前)
                    
                </dd>
			</dl>
            </fieldset>

             <fieldset>
            <legend>列表搜索项</legend>
            <dl>
				<dt>显示：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtShowSearch" CssClass="combox">
                        <asp:ListItem Value="1">在普通搜索项上显示</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">不在搜索项上显示</asp:ListItem>
                        <asp:ListItem Value="2">在高级搜索项上显示</asp:ListItem>
                        <asp:ListItem Value="3">在普通与高级搜索项上同时显示</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>显示名称：</dt>
				<dd>
                    <asp:textbox runat="server" ID="txtBeforControlText" CssClass="required"></asp:textbox>
                </dd>
			</dl>
            <dl>
				<dt>显示类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtSearchFormControlType" CssClass="combox">
                        <asp:ListItem Selected="True" Value="1">单行文本框</asp:ListItem>
                        <asp:ListItem Value="2">下拉框</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl class="ShowInForm">
				<dt>数据绑定：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtSearchFormDataBind"></asp:TextBox>
                    <br />
                    表名|绑定值|绑定文本^自定义绑定文本|自定义值|自定义绑定文本2|自定义值2...
                </dd>
			</dl>
            <dl>
				<dt>操作类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtSeachOpt" CssClass="combox00">
                        <asp:ListItem Value="＝'{0}'">等于</asp:ListItem>
                        <asp:ListItem Value="＞">大于</asp:ListItem>
                        <asp:ListItem Value="＞＝">大于等于</asp:ListItem>
                        <asp:ListItem Value="＜">小于</asp:ListItem>
                        <asp:ListItem Value="＜＝">小于等于</asp:ListItem>
                        <asp:ListItem Value="like '{0}%'">左模糊查找（like 'xxx%'）</asp:ListItem>
                        <asp:ListItem Value="like '%{0}'">右模糊查找（like '%xxx'）</asp:ListItem>
                        <asp:ListItem Value="like '%{0}%'">全模糊查找（like '%xxx%'）</asp:ListItem>
                        <asp:ListItem Value="in ({0})">包括（in(xxx,xxx)）</asp:ListItem>
                    </asp:dropdownlist>  
                </dd>
			</dl>
            <dl>
				<dt>排序号：</dt>
				<dd>
                    <asp:textbox runat="server" ID="txtShowSearchOrder" CssClass="required digits">0</asp:textbox>在搜索项内排序顺序（越大越靠前）
                </dd>
			</dl>
            </fieldset>
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
