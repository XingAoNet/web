<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="XingAo.Software.Web.UserCenter.Accout.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
        	<h3>基本信息</h3>
		</div>
     	<div class="content">
			<span>
        		<label>生日：</label>
                <select id="idYear" name="year" class="select input-s"></select>
                <select id="idMonth" name="month" class="select input-s"></select>
                <select id="idDay" name="day" class="select input-s"></select>
            </span>
        	<span>
        		<label>血 型：</label>
                <select name="bloodtype" class="select input-l">
                    <option value="-1">请选择</option>
                    <option value="A" >A型</option>
                    <option value="B" >B型</option>
                    <option value="AB">AB型</option>
                    <option value="O" >O型</option>
                </select>
        	</span>
        	<span>
                <label>家乡：</label>
                <select id="idProvince" name="province" class="select input-l"></select>
                <select id="idCity" name="city" class="select input-l"></select>
        	</span>
        	<span>
                <label>Q Q：</label>
                <input type="text" name="qq" maxLength="20" value="">
        	</span>
        	<span>
                <label>兴趣爱好：</label>
                <input type="checkbox" id="" name="" />唱歌
                <input type="checkbox" id="" name="" />跳舞
                <input type="checkbox" id="" name="" />喝酒
                <input type="checkbox" id="" name="" />骰子
                <input type="checkbox" id="" name="" />划拳
                <input type="checkbox" id="" name="" />弹琴
        	</span>
            <span>
            	<label>&nbsp;</label>
                <input type="submit" id="submit" name="submit" value="提交" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>
