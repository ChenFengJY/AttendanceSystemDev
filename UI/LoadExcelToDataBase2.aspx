<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadExcelToDataBase2.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #bgfg {
            background-color:black;
            font-family:Arial, Helvetica, sans-serif;
            margin-bottom:2px;
        }
    </style>
</head>
<body style="height: 548px">
    <form id="form1" runat="server">
    <div>
        <div id="bgfg">
            &nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="导入教师基本信息" ForeColor="White"></asp:Label>
        </div>
         <div style="margin-left: 160px">
             <asp:RadioButton ID="RadioButton1" runat="server" Text="本校教师" />
&nbsp;&nbsp;&nbsp;
             <asp:RadioButton ID="RadioButton2" runat="server" Text="外聘教师" />
        </div>
         <div>
        &nbsp;&nbsp;
             <asp:Label ID="Label2" runat="server" Text="请选择要导入的文件"></asp:Label>
             <asp:FileUpload ID="FileUpload1" runat="server" Width="378px" />
&nbsp;
             <asp:Button ID="Button1" runat="server" Text="导入" Width="61px" />
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="[lblMessage1]"></asp:Label>
        </div>
    </div>

    <div>
        <div id="bgfg">
        &nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" Text="分系部导入授课信息" ForeColor="White"></asp:Label>
            <br />
        </div>
        <div>
            &nbs&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </div>
        <div style="margin-left: 40px">
            <asp:Label ID="Label5" runat="server" Text="请选择要导入的文件"></asp:Label>
            <asp:FileUpload ID="FileUpload2" runat="server" Width="378px" />
&nbsp;
            <asp:Button ID="Button2" runat="server" Text="导入" Width="63px" />
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="[lblMessage2]"></asp:Label>
        </div>
    </div>
     
    <div>
        <div id="bgfg">
            &nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server" Text="导入本学期校历" ForeColor="White"></asp:Label>
        </div>
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="请选择导入的文件"></asp:Label>
            <asp:FileUpload ID="FileUpload3" runat="server" Width="384px" />
            &nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="导入" Width="67px" />
        </div>
        <div>
            <asp:Label ID="Label9" runat="server" Text="[lblMessage5]"></asp:Label>
        </div>
    </div>

        
     <div>
         <div id="bgfg">
             &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label17" runat="server" Text="导入各系部总人数" ForeColor="White"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label11" runat="server" Text="会计系"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="108px"></asp:TextBox>
            <asp:Label ID="Label12" runat="server" Text="信息工程系"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="112px"></asp:TextBox>
            <asp:Label ID="Label13" runat="server" Text="经济管理系"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="119px"></asp:TextBox>
            <asp:Label ID="Label14" runat="server" Text="食品工程系"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Width="115px"></asp:TextBox>
            <asp:Label ID="Label15" runat="server" Text="机械工程系"></asp:Label>
        </div>
          <div>
               <asp:Label ID="Label16" runat="server" Text="Label16"></asp:Label>
        </div>
    </div>
             
     <div>
         <div id="bgfg">
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label18" runat="server" Text="数据预处理" ForeColor="White"></asp:Label>
        </div>
          <div>
        &nbsp;
              <asp:Button ID="Button4" runat="server" Text="分析入库数据" />
&nbsp;&nbsp;&nbsp;
              <asp:Label ID="Label19" runat="server" Text="[lblMessage3]"></asp:Label>
        </div>
          <div>
        &nbsp;
              <asp:Button ID="Button5" runat="server" Text="处理入库数据" />
&nbsp;&nbsp;&nbsp;
              <asp:Label ID="Label20" runat="server" Text="[lblMessage7]"></asp:Label>
        </div>
          <div>
        &nbsp;
              <asp:Button ID="Button6" runat="server" Text="清空入库数据" />
&nbsp;&nbsp;&nbsp;
              <asp:Label ID="Label21" runat="server" Text="[lblMessage4]"></asp:Label>
        </div>
    </div> 
                       
    </form>
</body>
</html>
