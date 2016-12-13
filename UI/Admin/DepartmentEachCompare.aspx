<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DepartmentEachCompare.aspx.cs" Inherits="Admin_DepartmentEachCompare" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #main{
            width:100%;
            height:auto;
        }
        #chart{
            margin:0 auto;
        }
        #chart td{
            width:100%;
            height:350px;
            text-align:center;
        }
    </style>
    <div id="main">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
             Font-Size="12px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
             OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="系部" DataField="Department" ItemStyle-Width="90px" />
                <asp:BoundField HeaderText="在校生人数" DataField="Number" ItemStyle-Width="70px" />
                <asp:BoundField HeaderText="旷课人数" DataField="Attendance" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课率" DataField="AttendanceRate" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="迟到人数" DataField="Late" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="迟到率" DataField="LateRate" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="早退人数" DataField="Early" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="早退率" DataField="EarlyRate" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="Leave" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假率" DataField="LeaveRate" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="缺勤总数" DataField="Sum" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="总缺勤率" DataField="SumRate" ItemStyle-Width="60px" />
            </Columns>
            <RowStyle ForeColor="#000066" />
            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <PagerStyle BackColor="#669999" Font-Bold="true" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White" />
        </asp:GridView>

        <table id="chart">
            <tr>
                <td style="width: 100%; height: 350px">
                   <asp:PlaceHolder ID="phDepartmentEachCompare" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                     <asp:PlaceHolder ID="phAttendance" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phLeave" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phLate" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phEarly" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


