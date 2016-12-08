<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="AttendanceStudentDetails.aspx.cs" Inherits="Admin_AttendanceStudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="lblMessage"></asp:Label>
    <asp:Button ID="btnBackDetails" runat="server" Text="关闭页面" />
    <asp:GridView ID="gvStudentAttendance" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="TeacherName" HeaderText="任课教师"  ItemStyle-Width="80px"/>
            <asp:BoundField DataField="StudentDepatrment" HeaderText="学生系部" ItemStyle-Width="100px" />
            <asp:BoundField DataField="StudentClass" HeaderText="班级" ItemStyle-Width="100px" />
            <asp:BoundField DataField="StudentID" HeaderText="学号" ItemStyle-Width="80px"/>
            <asp:BoundField DataField="StudentName" HeaderText="姓名" ItemStyle-Width="80px"/>
            <asp:BoundField DataField="Course" HeaderText="缺勤课程" />
            <asp:BoundField DataField="AttendanceType" HeaderText="缺勤类型" ItemStyle-Width="80px"/>
            <asp:BoundField DataField="Week" HeaderText="缺勤时间" ItemStyle-Width="80px"/>
            <asp:BoundField DataField="Time" HeaderText="缺课节次" ItemStyle-Width="80px" />
            <asp:BoundField DataField="SumAttendance" HeaderText="累计缺勤次数" ItemStyle-Width="60px" />
        </Columns>
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="true" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
</asp:Content>

