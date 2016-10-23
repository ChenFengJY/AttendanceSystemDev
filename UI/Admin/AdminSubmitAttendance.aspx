<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSubmitAttendance.aspx.cs" Inherits="Admin_AdminSubmitAttendance" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="thisweek">
        本周授课信息：

     
         
        <br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SdbiAttentionSystemConnectionString %>" SelectCommand="SELECT [Course], [IsAttendance] FROM [TabTeacherAttendance] WHERE ([TeacherID] = @TeacherID)">
            <SelectParameters>
                <asp:Parameter DefaultValue="123" Name="TeacherID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
    <div class="lastweek">上周考勤情况：<br />
    </div>
</asp:Content>

