<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="AttendanceDetials.aspx.cs" Inherits="Admin_AttendanceDetials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        * {
            margin: 0 auto;
            text-align: center;
        }

        #form1 {
            height: 441px;
        }
    </style>
    <script>
        
    </script>

    <div>
        <div>
            <asp:label id="lblAttendanceMessage" runat="server" text=""></asp:label>
            <br />
            <asp:label id="lblLateMessage" runat="server" text=""></asp:label>
            <br />
            <asp:label id="lblEarlyMessage" runat="server" text=""></asp:label>
            <br />
            <asp:label id="lblLeaveMessage" runat="server" text=""></asp:label>
            <br />
            <asp:label id="lblResultMessage" runat="server" text=""></asp:label>
            <br />
            <asp:label id="lblMessage" runat="server" text=""></asp:label>
            <br />
        </div>

        <asp:button id="btnClose" runat="server" text="返回主页面" onclientclick="return confirm('确定取消提交并退出？')" onclick="btnClose_Click" />
        <asp:button id="btnAtten" runat="server" text="上报考勤结果" onclientclick="return confirm('确定提交？')" onclick="btnAtten_Click" />
        <asp:checkbox id="CheckIsRecord" runat="server" text="教学异动" />
        <select id="Select1" name="D1">
            <option>因故调课</option>
        </select><asp:button id="btnUnNormal" runat="server" text="确定" />

        <asp:updatepanel id="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:SqlDataSource ID="SqlDataSourceAttendanceDetails" runat="server" ConnectionString="<%$ ConnectionStrings:SdbiAttentionSystemConnectionString %>" SelectCommand="SELECT [StudentDepartment],[StudentID],[StudentName],[t4] FROM [TabTeacherAllCourse] WHERE (([TeacherId] = @TeacherID ) AND (CourseWeek = @CourseWeek ) AND (CourseTime = @CourseTime ))">
                    <SelectParameters>
                        <asp:SessionParameter Name="TeacherID" SessionField="UserID" Type="String" />
                        <asp:SessionParameter Name="CourseWeek" SessionField="CourseWeek" Type="String" />
                        <asp:SessionParameter Name="CourseTime" SessionField="CourseTime" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:GridView ID="gvAttendanceDetails" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="StudentID" DataSourceID="SqlDataSourceAttendanceDetails" Font-Size="12px" GridLines="Vertical" OnRowDataBound="gvAttendanceDetails_RowDataBound" Width="1000px">
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="StudentDepartment" HeaderText="所属系部" ItemStyle-Width="100px" SortExpression="StudentDeparment">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="t4" HeaderText="班级" ItemStyle-Width="100px" SortExpression="t4">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentID" HeaderText="学号" ItemStyle-Width="100px" ReadOnly="true" SortExpression="StudentID">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="姓名" ItemStyle-Width="100px" SortExpression="StudentName">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="出勤情况">
                            <ItemTemplate>
                                <asp:RadioButton ID="rdoNormal" runat="server" AutoPostBack="true" Checked="true" GroupName="g1" OnCheckedChanged="rdo_CheckChange" Text="正常" />
                                <asp:RadioButton ID="rdoLate" runat="server" AutoPostBack="true" GroupName="g1" OnCheckedChanged="rdo_CheckChange" Text="迟到" />
                                <asp:RadioButton ID="rdoAbsence" runat="server" AutoPostBack="true" GroupName="g1" OnCheckedChanged="rdo_CheckChange" Text="旷课" />
                                <asp:RadioButton ID="rdoEarly" runat="server" AutoPostBack="true" GroupName="g1" OnCheckedChanged="rdo_CheckChange" Text="早退" />
                                <asp:RadioButton ID="rdoLeave" runat="server" AutoPostBack="true" GroupName="g1" OnCheckedChanged="rdo_CheckChange" Text="请假" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="true" ForeColor="White" />
                    <HeaderStyle BackColor="#000084" Font-Bold="true" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </ContentTemplate>
        </asp:updatepanel>
        <div>
        </div>
    </div>


</asp:Content>

