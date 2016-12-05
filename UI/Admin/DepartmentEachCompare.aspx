<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="DepartmentEachCompare.aspx.cs" Inherits="Admin_DepartmentEachCompare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="12px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:BoundField HeaderText="系部" DataField="系部" ItemStyle-Width="90px" />
            <asp:BoundField HeaderText="在校生人数" DataField="在校生人数" ItemStyle-Width="70px" />
            <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="旷课人数" DataField="旷课率" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="迟到人数" DataField="迟到人数" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="迟到率" DataField="迟到率" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="早退率" DataField="早退率" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="请假率" DataField="请假率" ItemStyle-Width="60px" />
            <asp:BoundField HeaderText="缺勤总数" DataField="缺勤总数" ItemStyle-Width="60px" />
             <asp:BoundField HeaderText="总缺勤率" DataField="总缺勤率" ItemStyle-Width="60px" />
        </Columns>
        <RowStyle ForeColor="#000066" />
        <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <PagerStyle BackColor="#669999" Font-Bold="true" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White" />
    </asp:GridView>
     <asp:PlaceHolder ID="phDepartmentEachCompare" runat="server"></asp:PlaceHolder>
     <asp:PlaceHolder ID="phAttendance" runat="server"></asp:PlaceHolder>
     <asp:PlaceHolder ID="phLeave" runat="server"></asp:PlaceHolder>
     <asp:PlaceHolder ID="phLate" runat="server"></asp:PlaceHolder>
     <asp:PlaceHolder ID="phEarly" runat="server"></asp:PlaceHolder>
       <tr>
        <td style="width:100%;height:350" align="center">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
     <tr>
        <td style="width:100%;height:350" align="center">
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </td>
         </tr>
     <tr>
        <td style="width:100%;height:350" align="center">
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            </td>
         </tr>
     <tr>
        <td style="width:100%;height:350" align="center">
    <asp:PlaceHolder ID="phLeate" runat="server"></asp:PlaceHolder>
            </td>
         </tr>
     <tr>
        <td style="width:100%;height:350" align="center">
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            </td>
         </tr>
</asp:Content>


