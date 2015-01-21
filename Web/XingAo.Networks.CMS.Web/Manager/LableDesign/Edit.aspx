<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.LableDesign.Edit" %>
<style type="text/css">
    #jbsxBox{ line-height:normal;}
    #jbsxBox div{ height:auto;line-height:normal;}
    .TabList{ width:200px; float:left; border:1px solid #CCC; margin:3px; padding:3px; font-size:16px; font-weight:bold; line-height:33px;}
    .Clear{ clear:left;}
    .TabList ul{ width:95%; margin:auto; overflow:hidden;}
    .TabList li{ height:22px; line-height:22px; cursor:pointer;font-size:12px; font-weight:normal;}
    .TabList li:hover{ background:#CCC}
    .dragspandiv, .dragspandiv_alt, .dragspandiv_ctrl, .spanfixdiv, .nodediv, .havechilediv, .attribdiv, .alertspandiv
    {
        text-align: center;
        height: 20px;
        line-height: 20px;
        overflow: hidden;
        padding: 0 4px;
    }
    .dragspandiv
    {
        filter: alpha(opacity=80);
        opacity: 0.8;
        background-color: #E5C0E4;
        border: 1px solid #D495D2;
    }
    .dragspandiv_alt
    {
        background-color: #CCFFCC;
        opacity: 0.8;
        filter: alpha(opacity=80);
        border: 1px solid #00FF00;
    }
    .dragspandiv_ctrl
    {
        background-color: #CCCCFF;
        opacity: 0.8;
        filter: alpha(opacity=80);
        border: 1px solid #0000FF;
    }
    .spanfixdiv
    {
        margin: 4px auto;
        background-color: #FFFBF5;
        border: 1px solid #F6B9D6;
        cursor: pointer;
        cursor: hand;
        height: 20px;
        width: 160px;
    }
    #fixdiv
    {
        margin: 7px;
    }
    .nodediv
    {
        background-color: #FFFBF5;
        border: 1px solid #F6B9D6;
        cursor: pointer;
        cursor: hand;
    }
    .havechilediv
    {
        background-color: #FFCCCC;
        border: 1px solid #FF2222;
        cursor: pointer;
        cursor: hand;
        font-weight: bolder;
    }
    .attribdiv
    {
        background-color: #F5FFF5;
        border: 1px solid #B9F6D6;
        cursor: pointer;
        cursor: hand;
    }
    .finaltxt
    {
        border: 1px solid #F6B9D6;
    }
    .nodefixdiv
    {
        background-color: #FFFBF5;
        border: 1px solid #F6B9D6;
        cursor: pointer;
        cursor: hand;
    }
    .alertspandiv
    {
        background-color: #FFEBE5;
        border: 1px solid #F6B9D6;
    }
    #rightMenu
    {
        visibility: hidden;
        padding: 2px;
        background-color: menu;
        cursor: default;
        position: absolute;
        z-index: 900;
        border-right: 1px solid #aaa;
        border-bottom: 1px solid #aaa;
        border-top: 1px solid #fff;
        border-left: 1px solid #fff;
        font-size: 14px;
        word-break: keep-all;
    }
    .menuItem
    {
        display: block;
        padding: 3px;
    }
    .htmlEdit{float:left;width:80%;}
    .fileds{float:left; width:15%;border:#ccc solid 1px; margin-left:5px; padding:5px;}
    .filed{border:#999 solid 1px; margin:5px 5px; padding:5px; line-height:20px; cursor:pointer;}
    .toolFunction{ height:300px; overflow:auto;}
</style>
<div class="pageContent">
    <form id="form1" runat="server" action="" onsubmit="return validateCallback(this, dialogAjaxDone);"  class="pageForm required-validate">
    <div layoutH="39" style="float:left; display:block; overflow:auto; width:240px; border:solid 1px #CCC; line-height:21px; background:#fff">
	    <ul class="tree treeFolder">
            <li><a href="javascript">用户自定义表</a>
			    <ul class="dbtable">
                    <asp:repeater runat="server" ID="Rep_List">
                        <ItemTemplate>
				            <li>
                                <a tname="<%#Eval("TabName")%>"><%#Eval("ChineseName")%></a>
                                <ul>
                                    <asp:repeater runat="server" DataSource='<%#Eval("CustomTableFields") %>'>
                                        <ItemTemplate>
				                            <li>
                                                <a tname="<%#Eval("FieldName")%>"><%#Eval("FieldName")%>(<%#Eval("ChineseName")%>)</a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:repeater>
                                </ul>
                            </li>
                        </ItemTemplate>
                    </asp:repeater>
			    </ul>
		    </li>
		    <li><a href="javascript:;">系统开放表</a>
                <ul>
                    <li><a href="LableDesign/Designer.aspx?TName=<%=Server.UrlEncode(XingAo.Core.StringOption.Encrypt("XA_CMS_WebNavigation")) %>" target="ajax" rel="jbsxBox">网站栏目表</a></li>
                </ul>
            </li>
	    </ul>
    
        <div class="toolFunction">
         <div class="spanfixdiv" code="@Routes_ParamName" outype="4" title="路由参数">路由参数</div>

            <div class="spanfixdiv" code="@Request_UrlParamName" outype="4" title="URL参数">URL参数</div>
            <div class="spanfixdiv" code="{@UrlPager}" outype="4" title="分页">分页</div>

            <div class="spanfixdiv" code="&lt;xsl:attribute name=&quot;attributename&quot;&gt;
    &lt;!-- Content:template --&gt;
    &lt;/xsl:attribute&gt;" outype="4" title="向元素添加属性">attribute</div>
            <div class="spanfixdiv" code="&lt;xsl:attribute-set name=&quot;name&quot;&gt;
    &lt;!-- Content:xsl:attribute* --&gt;
    &lt;/xsl:attribute-set&gt;" outype="4" title="创建命名的属性集">attribute-set</div>
            <div class="spanfixdiv" code="&lt;xsl:call-template name=&quot;templatename&quot;&gt;
            &lt;!-- Content:xsl:with-param* --&gt;
            &lt;/xsl:call-template&gt;" outype="4" title="调用一个指定的模板">call-template</div>
            <div class="spanfixdiv" code="&lt;xsl:value-of select=&quot;&quot;/&gt;" outype="4" title="提取选定节点的值">value-of</div>
            <div class="spanfixdiv" code="&lt;a&gt;
            &lt;xsl:attribute name=&quot;href&quot;&gt;&lt;/xsl:attribute&gt;
            &lt;xsl:attribute name=&quot;title&quot;&gt;&lt;/xsl:attribute&gt;
            &lt;xsl:attribute name=&quot;target&quot;&gt;_blank&lt;/xsl:attribute&gt;
            &lt;/a&gt;" outype="4" title="超连接元素">a</div>
            <div class="spanfixdiv" code="&lt;xsl:element name=&quot;img&quot;&gt;
            &lt;xsl:attribute name=&quot;src&quot;&gt;&lt;/xsl:attribute&gt;
            &lt;xsl:attribute name=&quot;width&quot;&gt;&lt;/xsl:attribute&gt;
            &lt;xsl:attribute name=&quot;height&quot;&gt;&lt;/xsl:attribute&gt;
            &lt;xsl:attribute name=&quot;border&quot;&gt;0&lt;/xsl:attribute&gt;&lt;/xsl:element&gt;" outype="4" title="图象元素">img</div>
             
            <div class="spanfixdiv" code="&lt;xsl:for-each select=&quot;&quot;&gt;&lt;/xsl:for-each&gt;" outype="4" title="变量循环">for-each</div><div class="spanfixdiv" code="&lt;xsl:text disable-output-escaping=&quot;yes&quot;&gt;&lt;/xsl:text&gt;" outype="4" title="格式化字符输出">text</div>
             
            <div class="spanfixdiv" code="&lt;xsl:if test=&quot;&quot;&gt;&lt;/xsl:if&gt;" outype="4" title="条件标签">if</div>
                                    <div class="spanfixdiv" code="&lt;xsl:choose&gt;
            &lt;xsl:when test=&quot;&quot;&gt;
            &lt;/xsl:when&gt;
            &lt;xsl:otherwise&gt;
            &lt;/xsl:otherwise&gt;
            &lt;/xsl:choose&gt;" outype="4" title="条件循环">choose</div>
                
            <div class="spanfixdiv" code="&lt;xsl:variable name=&quot;&quot;/&gt;" outype="4" title="变量定义">variable</div>
             
            <div class="spanfixdiv" code="&lt;xsl:param name=&quot;&quot;/&gt;" outype="4" title="变量引入">param</div>
            <div class="spanfixdiv" code="&lt;xsl:with-param name=&quot;&quot;&gt;&lt;/xsl:with-param&gt;" outype="4" title="变量传递">with-Param</div>
             
            <div class="spanfixdiv" code="&lt;xsl:template match=&quot;&quot;&gt;&lt;/xsl:template&gt;" outype="4" title="循环模板定义">template</div>
            <div class="spanfixdiv" code="position()" outype="4" title="循环位置">position()</div>
            <div class="spanfixdiv" code="contains(字符1,字符2)" outype="4" title="目标字符中是否存在指定的字符">contains()</div>
            <div class="spanfixdiv" code="string-length(字符)" outype="4" title="字符长度">string-length()</div>
            <div class="spanfixdiv" code="substring-before(字符,分隔符)" outype="4" title="返回分隔符前面的子串">substring-before()</div>
            <div class="spanfixdiv" code="substring-after(字符,分隔符)" outype="4" title="返回分隔符后面的子串">substring-after()</div>
            <div class="spanfixdiv" code="disable-output-escaping=&quot;yes&quot;" outype="4" title="尖括号将不进行转换">HTML编码输出</div>
            <div class="spanfixdiv" code="xmlns:pe=&quot;labelproc&quot;" outype="4" title="扩展函数命名空间">扩展函数命名空间</div>
            <div class="spanfixdiv" code="xmlns:ms=&quot;urn:schemas-microsoft-com:xslt&quot;" outype="4" title="MS命名空间">MS命名空间</div>
            <div class="spanfixdiv" code="xmlns:js=&quot;urn:the-xml-files:xslt-js&quot;" outype="4" title="JS命名空间">JS命名空间</div>
            <div class="spanfixdiv" code="xmlns:csharp=&quot;urn:the-xml-files:xslt-csharp&quot;" outype="4" title="C#命名空间">C#命名空间</div>
            <div class="spanfixdiv" code="xmlns:vb=&quot;urn:the-xml-files:xslt-vb&quot;" outype="4" title="VB命名空间">VB命名空间</div>
        </div>   
    </div>
				
    <div id="jbsxBox" layoutH="39" class="unitBox" style="margin-left:246px; overflow:auto;">
    <asp:HiddenField ID="txtID" runat="server" />
        <div style=" line-height:normal;">
            <fieldset>
                <legend>标签名</legend>
                <asp:textbox runat="server" ID="txtLableName" Width="60%"></asp:textbox>
            </fieldset>
        </div>
        <div style=" line-height:normal;">
            <fieldset>
                <legend>标签描述</legend>
                <asp:textbox runat="server" ID="txtLabelDescription" Height="30px" TextMode="MultiLine" Width="60%"></asp:textbox>
                
            </fieldset>
        </div>
        <div style=" line-height:normal;">
            <fieldset>
                <legend>解析方式</legend>
                <asp:radiobuttonlist runat="server" RepeatDirection="Horizontal" ID="AnalyzeJX">
                    <asp:ListItem Value="Text">文本解析</asp:ListItem>
                    <asp:ListItem Value="Xsl" Selected="True">Xsl解析</asp:ListItem>
                    
                </asp:radiobuttonlist>
            </fieldset>
        </div>

        <div style=" line-height:normal;">
            <fieldset>
                <legend>设置标签参数</legend>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>参数名称</td>
                        <td>默认值</td>
                        <td>参数说明</td>
                        <td>操作</td>
                    </tr>
                    <asp:repeater runat="server" id="Rp_LabelParam">
                        <ItemTemplate>
				            <tr>
                                <td><%#Eval("ParamName")%></td>
                                <td><%#Eval("DefaultValue")%></td>
                                <td><%#Eval("ParamDescription")%></td>
                                <td>
                                    <input type='button' value='编辑' class='Param_edit'/>
                                    <input type='button' value='保存' class='Param_keep' style="display:none;"/>
                                    <input type='button'  value='删除' class='Param_del'/>
                                    <input type='hidden' name='p_Param' value="<%#Eval("Id")+"|"+Eval("ParamName")+"|"+Eval("DefaultValue")+"|"+Eval("ParamDescription")%>|" />
                                    <input type='hidden' value='<%#Eval("Id")%>' name='p_Id'/>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:repeater>
                    <tr>
                        <td><input type="text" name="p_Name" value="@" /> 参数名以@开头</td>
                        <td><input type="text" name="p_value" /></td>
                        <td><input type="text" name="p_desc" /></td>
                        <td>
                            <input type="button" class="addParam" value="添加" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style=" line-height:normal;">
            <fieldset>
                <legend>sql语句</legend>
                <div class="htmlEdit">
                    <asp:textbox runat="server" ID="SqlTxt" Height="30px"  TextMode="MultiLine" Width="99%"></asp:textbox>
                </div>
                <asp:checkbox runat="server" Id="IsPager" Text="启动分页" Value="1"></asp:checkbox>
                <span id="SpanPageSize" style="display:none;">每页记录数：<asp:textbox runat="server" id="TxtPageSize" width="30"></asp:textbox> </span><br />
                <input id="CreateFiled" type="button" value="生成字段" />
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>标签代码</legend>
                <div class="tabs htmlEdit" currentIndex="0">
		            <div class="tabsHeader">
			            <div class="tabsHeaderContent">
				            <ul>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(1);"><span>代码模式</span></a></li>
					            <li><a href="javascript:;" onclick="ShowHiddenEditor(0);"><span>预览</span></a></li>
				            </ul>
			            </div>
		            </div>
		            <div class="tabsContent" >
			            <div>
                            <asp:textbox runat="server" ID="LabelTxt" Height="258px" TextMode="MultiLine" Width="99%"></asp:textbox>
                        </div>	
                        <div style="padding:5px;">
                            <iframe style="height:258px;width:99%;" id="RendFrm" frameborder="0" src="about:blank;"></iframe>
                        </div>		           
		            </div>
		            <div class="tabsFooter">
			            <div class="tabsFooterContent"></div>
		            </div>
	            </div>
                <div class="fileds">
                    <div val="DataTable/Rows" class="filed">DataTable/Rows</div>
                </div>
            </fieldset>             
        </div>			
    </div>
    <div class="formBar">
	    <ul>
  		    <li><div class="button"><div class="buttonContent"> <button id="BtnFormat" type="button">格式化</button></div></div></li>      
		    <li><div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div></li>
		    <li>
			    <div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
		    </li>
	    </ul>
    </div>

</form>
</div>
<script src="Script/jsformat.js" type="text/javascript"></script>
<script src="Script/htmlformat.js" type="text/javascript"></script>
<script src="Script/TextInsert.js" type="text/javascript"></script>

<script type="text/javascript">
    function ShowHiddenEditor(rel) {
        var param="";
        $("input[name='p_Param']").each(function (n) {
            param+=$(this).val()+",";
        });
        if (rel == 0) {
            $.post("LableDesign/Rendering.ashx", { sql: $("#" + sqlAreaid).val(), Template: $("#" + editAreaid).val(), param: param, IsPage: $("#IsPager").is(":checked") ? 1 : 0, PageSize: $("#TxtPageSize").val(), Analyze: $("#AnalyzeJX").val() },
            function (data) {
                if (data != undefined) {
                    $("#RendFrm").contents().find("body").html(data)
                }
            }, "html");
        }
    }

    function OpenSize(obj) {
        if ($(obj).is(":checked"))
            $("#SpanPageSize").show();
        else
            $("#SpanPageSize").hide();
    }
    var editAreaid = "LabelTxt";
    var sqlAreaid = "SqlTxt";
    $(function (ex) {
        OpenSize($("#IsPager"));
        $("#IsPager").change(function (n) {
            OpenSize(this);
        });
        $(".Param_edit").die().live("click", function () {
            $(this).closest('td').siblings().html(function (i, html) {
                return '<input type="text" value=' + html + ' />';
            });
            $(this).hide();
            $(this).parent().find('.Param_keep').show();
        });
        $(".Param_keep").die().live("click", function () {
            var list = $(this).parent().parent().find("td :input[type='text']");
            var _param = "";
            $.each(list, function (i, obj) {
                $(obj).parent().html($(obj).val());
                _param += $(obj).val() + "|";
            });
            var t_parent = $(this).parent().parent();
            t_parent.find("td :input[name='p_Param']").val("0|" + _param);
            t_parent = null;
            list = null;
            $(this).hide();
            $(this).parent().find('.Param_edit').show();
        });

        $(".Param_del").die().live("click", function () {
            $(this).parent().parent().remove();
        });

        $(".addParam").click(function () {
            var t_this = $(this).parent().parent().clone(false);
            t_this.insertBefore($(this).parent().parent());
            t_this.find(".addParam").parent().html("").append($("<input type='button' value='编辑' class='Param_Edit'/>"))
		      .append($("<input type='button' value='保存' class='Param_keep'/>"))
		      .append($("<input type='button'  value='删除' class='Param_del'/>"))
              .append($("<input type='hidden' name='p_Param'/>"))
              .append($("<input type='hidden' value='0' name='p_Id'/>"));
            t_this.find(".Param_keep").click();
            $(this).parent().parent().find("td :input[type='text']:gt(0)").val("");
            $(this).parent().parent().find("td :input[type='text']:lt(1)").val("@");
        });

        $("div.spanfixdiv").click(function (ex) {
            $("#" + editAreaid).insertAtCaret($(this).attr("code"));
        });

        $("#CreateFiled").click(function (ex) {
            addFiled();
        });
        $("div.filed").click(function (ex) {
            $("#" + editAreaid).insertAtCaret($(this).html());
        });
        $("#BtnFormat").click(function (ex) {
            var js_source = $("#" + editAreaid).val().replace(/^\s+/, '');
            var tabsize = 4;
            var tabchar = ' ';

            if (js_source && js_source.charAt(0) === '<') {
                $("#" + editAreaid).val(style_html(js_source, tabsize, tabchar, 80));
            } else {
                $("#" + editAreaid).val(js_beautify(js_source, tabsize, tabchar));
            }
        });
        $("ul.dbtable a").click(function (ex) {
            $("#" + sqlAreaid).insertAtCaret($(this).attr("tname"));
        });

       // addFiled();
     
    });

    function addFiled() {
        var sql = $("#SqlTxt").val();
        if (sql != "") {
            re = /^select\s+(?:([\x00-\xFF]+\s+))from\s+(?:(\S+))(?:((\s+(where|and)\s+\S+\=\S+)+)?)(\s+order\s+by\s+(?:[\x00-\xFF]+))?/im;
            r = re.exec(sql);
            $("div.fileds:gt(0)").empty();
            alert(r.length);
            if (r.length > 1) {
                if (r[1] != undefined) {
                    $.each(r[1].substring(0, r[1].length - 1).split(","), function (i, filedName) {
                        if (filedName != "") {
                            var f = filedName;
                            if (filedName.indexOf(" as ") > -1)
                                f = filedName.substring(filedName.indexOf("as") + 1);
                            else {
                                if (filedName.indexOf(".") > -1) {
                                    f = filedName.substring(filedName.indexOf(".") + 1);
                                }
                            }
                            if (f.indexOf(" ") > -1)
                                f = f.substring(f.indexOf(" ") + 1);

                            var fs = $("div.fileds").find("div[val='" + filedName + "']");
                            if (fs.size() == 0)
                                $("div.fileds").append($("<div></div>").addClass("filed").html(f).attr("val", f).click(function (ex) {
                                    $("#" + editAreaid).insertAtCaret($(this).html());
                                }));
                        }
                    });

                }
            }
        }
    }

</script>
    