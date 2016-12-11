<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentAnalysis.aspx.cs" Inherits="Admin_DepartmentAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    </div>
        <asp:PlaceHolder ID="phXX" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phJG" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phSP" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phJX" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phWY" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phJZ" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phKJ" runat="server" ></asp:PlaceHolder>
        <asp:Label ID="lblKJ" runat="server" ForeColor="Red" Font-Size="12px">
            <td style="width:24%" align="center" valign="middle">
                       <asp:Button ID="btnKJ" runat="server" Text="会计系图表分析" CssClass="btn" OnClick="btnKJClick" Font-Size="12px" />

            </td>
        </asp:Label>
        <asp:GridView ID="gvXX" runat="server" Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="gvKJ" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btnXX" runat="server" Text="Button2" OnClick="btnXX_Click" />
        <br />
        <asp:GridView ID="gvJG" runat="server">
        </asp:GridView>
        <asp:Button ID="btnJG" runat="server" Text="Button" />
        <br />
        <asp:GridView ID="gvSP" runat="server">
        </asp:GridView>
        <asp:Button ID="btnSP" runat="server" Text="Button" />
        <br />
        <asp:GridView ID="gvJX" runat="server">
        </asp:GridView>
        <asp:Button ID="btnJX" runat="server" Text="Button" />
        <br />
        <asp:GridView ID="gvWY" runat="server">
        </asp:GridView>
        <asp:Button ID="btnWY" runat="server" Text="Button" />
        <asp:GridView ID="gvJZ" runat="server">
        </asp:GridView>
        <asp:Button ID="btnJZ" runat="server" Text="Button" />
    </form>
</body>
</html>
