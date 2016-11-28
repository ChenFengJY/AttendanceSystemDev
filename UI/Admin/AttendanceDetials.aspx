<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AttendanceDetials.aspx.cs" Inherits="Admin_AttendanceDetials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style type="text/css">
        #form1 {
            height: 441px;
        }
    </style>

    <div>
        <asp:Label ID="lblAttendanceMessage" runat="server" Text="lblAttendanceMessage"></asp:Label><br />
        <asp:Label ID="lblLateMessage" runat="server" Text="lblLateMessage"></asp:Label><br />
        <asp:Label ID="lblEarlyMessage" runat="server" Text="lblEarlyMessage"></asp:Label><br />
        <asp:Label ID="lblLeaveMessage" runat="server" Text="lblLeaveMessage"></asp:Label><br />
        <asp:Label ID="lblResultMessage" runat="server" Text="lblResultMessage"></asp:Label><br />
        <asp:Label ID="lblMessage" runat="server" Text="lblMessage"></asp:Label><br />
        <asp:Button ID="btnClose" runat="server" Text="返回主页面" />
        <asp:Button ID="btnAtten" runat="server" Text="上报考勤结果" OnClick="btnAtten_Click" />
        <asp:CheckBox ID="CheckIsRecord" runat="server" Text="教学异动" />
        <select id="Select1" name="D1">
            <option>因故调课</option>
        </select><asp:Button ID="btnUnNormal" runat="server" Text="确定" />

        <asp:GridView ID="gvAttendanceDetails" runat="server" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="StudentID" 
            DataSourceID="SqlDataSourceAttendanceDetails" GridLines="Horizontal" Font-Size="12px" 
            OnRowDataBound="gvAttendanceDetails_RowDataBound" >
            
            <RowStyle  BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="StudentDepartment" HeaderText="所属系部"  ItemStyle-Width="100px" SortExpression="StudentDeparment"/>
                <asp:BoundField DataField="t4" HeaderText="班级"  ItemStyle-Width="100px" SortExpression="t4"/>
                <asp:BoundField DataField="StudentID" HeaderText="学号"  ItemStyle-Width="100px" ReadOnly="true" SortExpression="StudentID"/>
                <asp:BoundField DataField="StudentName" HeaderText="姓名"  ItemStyle-Width="100px" SortExpression="StudentName"/>
                <asp:TemplateField HeaderText="出勤情况">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdNormal" runat="server" GroupName="g1" Text="正常" Checked="true" AutoPostBack="true" />
                        <asp:RadioButton ID="rdoLate" runat="server" GroupName="g1" Text="迟到"  AutoPostBack="true" />
                        <asp:RadioButton ID="rodAbsence" runat="server" GroupName="g1" Text="旷课"  AutoPostBack="true" />
                         <asp:RadioButton ID="rdoEarly" runat="server" GroupName="g1" Text="早退"  AutoPostBack="true"/>
                         <asp:RadioButton ID="rdoLeave" runat="server" GroupName="g1" Text="请假"  AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="true" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#3F7F7F7" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceAttendanceDetails" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SdbiAttentionSystemConnectionString %>" 
            SelectCommand="SELECT [StudentDepartment],[StudentID],[StudentName],[t4] FROM [TabTeacherAllCourse] WHERE (([TeacherId] = @TeacherID ) AND (CourseWeek = @CourseWeek ) AND (CourseTime = @CourseTime ))">
            <SelectParameters>
                <asp:sessionParameter Name="TeacherID" SessionField="UserID" Type="String" />
                <asp:SessionParameter Name="CourseWeek" SessionField="CourseWeek" TYpe="String" />
                <asp:SessionParameter Name="CourseTime" SessionField="CourseTime" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div>
            
        </div>
    </div>


</asp:Content>

