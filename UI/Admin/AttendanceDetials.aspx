<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceDetials.aspx.cs" Inherits="Admin_AttendanceDetials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 441px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="lblAttendanceMessage"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="lblLateMessage"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="lblEarlyMessage"></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text="lblLeaveMessage"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Text="lblResultMessage"></asp:Label><br />
        <asp:Label ID="Label6" runat="server" Text="lblMessage"></asp:Label><br />
        <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="返回主页面" />
        <asp:Button ID="btnAtten" runat="server" Text="上报考勤结果" />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="教学异动" />
        <select id="Select1" name="D1">
            <option>因故调课</option>
        </select><asp:Button ID="Button2" runat="server" Text="确定" />
        <asp:GridView ID="gvAttendanceDetails" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="StudentID" DataSourceID="SqlDataSourceAttendatnceDetails" GridLines="Horizontal" OnRowDataBound="gvAttendanceDetails_RowDataBound" Font-Size="12px">
            <RowStyle  BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="StudentDepartment" HeaderText="所属系部"  ItemStyle-Width="100px" SortExpression="StudentDeparment"/>
                <asp:BoundField DataField="t4" HeaderText="班级"  ItemStyle-Width="100px" SortExpression="t4"/>
                <asp:BoundField DataField="t4" HeaderText="学号"  ItemStyle-Width="100px" ReadOnly="true" SortExpression="StudentID"/>
                <asp:BoundField DataField="t4" HeaderText="姓名"  ItemStyle-Width="100px" SortExpression="StudentName"/>
                <asp:TemplateField HeaderText="出勤情况">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdNormal" runat="server" GroupName="g1" Text="正常" Checked="true" AutoPostBack="true" OnCheckedChanged="rdo_CheckedChange" />
                        <asp:RadioButton ID="rdoLate" runat="server" GroupName="g1" Text="迟到"  AutoPostBack="true" OnCheckedChanged="rdo_CheckedChange" />
                        <asp:RadioButton ID="rodAbsence" runat="server" GroupName="g1" Text="旷课"  AutoPostBack="true" OnCheckedChanged="rdo_CheckedChange" />
                         <asp:RadioButton ID="rdoEarly" runat="server" GroupName="g1" Text="早退"  AutoPostBack="true" OnCheckedChanged="rdo_CheckedChange" />
                         <asp:RadioButton ID="rdoLeave" runat="server" GroupName="g1" Text="请假"  AutoPostBack="true" OnCheckedChanged="rdo_CheckedChange" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="true" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#3F7F7F7" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceAttendanceDetails" runat="server" ConnectionString="<%$ConnectionStrings:SDBISASConnectionString2 %>" SelectCommand="SELECT DISTINCT[StudentDepartment],[StudentID],[StudentName],[t4]FROM[TabAllCourses]WHERE(([TeacherID]=@TeacherID)AND[Course]=@Course)AND[TimeAndArea]=@TimeAndArea))">
        <SelectParameters>
            <asp:sessionParameter Name="TeacherID" SessionField="UserID" Type="String" />
            <asp:SessionParameter Name="COurse" SessionField="CurrentCourse" TYpe="String" />
            <asp:SessionParameter Name="TimeAndArea" SessionField="WeekRange" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
    <div>
    
    </div>
    </form>
</body>
</html>
