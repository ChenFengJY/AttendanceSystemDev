<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadUserInfoToAdmin.aspx.cs" Inherits="Admin_LoadUserInfoToAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="学号" />
            <asp:BoundField HeaderText="姓名" />
            <asp:BoundField HeaderText="班级" />
        </Columns>
    </asp:GridView>
    本校教师 
    
 
   <%--// <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" AllowPaging="true" CellPadding="2" GridLines="None" PageSize="16" OnRowDataBound="gvTeachers_RowDataBound" OnPageIndexChanging="gvTeachers_RowCancelingEdit" OnRowEditing="gvTeacher_RowEditing" OnRowUpdating="gvTeachers_RowUpdating" OnRowDeleting="gvTeacher_RowDeleting" ForeColor="Black" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Size="12px">
       //
            <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="true" />
            
            
            <asp:BoundField  DataField="UserID" HeaderText="教师工号" ReadOnly="true" />
            
            <asp:BoundField HeaderText="教师姓名" />
            <asp:BoundField HeaderText="用户密码" />
            <asp:BoundField HeaderText="教师权限" />
            <asp:BoundField HeaderText="编辑" />
            <asp:BoundField HeaderText="删除" />--%>
        <%--</Columns>
    </asp:GridView>--%>
    
</asp:Content>

