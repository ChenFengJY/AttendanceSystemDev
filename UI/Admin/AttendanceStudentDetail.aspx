<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceStudentDetail.aspx.cs" Inherits="Admin_AttendanceStudentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvStudentAttendance" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7EF" BorderStyle="None" BorderWidth="1px" 
 CellPadding="3" Font-Size="12px" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="TeacherName" HeaderText="任课教师" >
                <ItemStyle Width="80px" />
                </asp:BoundField >
                <asp:BoundField DataField="StudentDepartment" HeaderText="学生系部" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField >
                <asp:BoundField DataField="StudentClass" HeaderText="班级" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField >
                <asp:BoundField DataField="StudentID" HeaderText="学号" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField >
                <asp:BoundField DataField="StudentName" HeaderText="姓名" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField >
                <asp:BoundField DataField="Course" HeaderText="缺勤课程" >
                    <ItemStyle Width="150px" />
                    </asp:BoundField >
                <asp:BoundField DataField="AttendanceType" HeaderText="缺勤类型" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField >
                <asp:BoundField DataField="Week" HeaderText="缺勤时间" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField >
                <asp:BoundField DataField="Time" HeaderText="缺勤节次" >
                    <ItemStyle Width="80px" />
                    </asp:BoundField >
                <asp:BoundField DataField="SumAttendance" HeaderText="累计缺勤次数" >
                    <ItemStyle Width="60px" />
                    </asp:BoundField >
            </Columns>
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" Font-Bold="true" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    
        <asp:Label ID="lblMessage" runat="server" Text="lblMessage"></asp:Label>
        <asp:Button ID="btnBackDetails" runat="server" OnClick="btnBackDetail_Click" Text="关闭页面" />
    
    </div>
    </form>
</body>
</html>
