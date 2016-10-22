<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadExcelToDataBase.aspx.cs" Inherits="LoadExcelToDataBase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:RadioButton ID="rdoTeacher" runat="server" Text="本校教师" />
        <asp:RadioButton ID="rdoOther" runat="server" Text="外聘教师" />
    
    </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="请选择要导入的文件"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="导入" />
        </p>
        <asp:Label ID="lblMessage1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <p>
            <asp:Label ID="Label2" runat="server" Text="选择要导入的文件"></asp:Label>
            <asp:FileUpload ID="FileUpload2" runat="server" />
        </p>
    </form>
</body>
</html>
