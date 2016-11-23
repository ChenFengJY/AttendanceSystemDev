<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadUserInfoToAdmin.aspx.cs" Inherits="Admin_LoadUserInfoToAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

    </style>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="学号" />
            <asp:BoundField HeaderText="姓名" />
            <asp:BoundField HeaderText="班级" />
        </Columns>
    </asp:GridView>
    本校教师<br />
&nbsp;<%-- <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" AllowPaging="true" CellPadding="2" GridLines="None" PageSize="16" OnRowDataBound="gvTeachers_RowDataBound" OnPageIndexChanging="gvTeachers_RowCancelingEdit" OnRowEditing="gvTeacher_RowEditing" OnRowUpdating="gvTeachers_RowUpdating" OnRowDeleting="gvTeacher_RowDeleting" ForeColor="Black" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Size="12px">
       //
            <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="true" />
            
            
            <asp:BoundField  DataField="UserID" HeaderText="教师工号" ReadOnly="true" />
            
            <asp:BoundField HeaderText="教师姓名" />
            <asp:BoundField HeaderText="用户密码" />
            <asp:BoundField HeaderText="教师权限" />
            <asp:BoundField HeaderText="编辑" />
            <asp:BoundField HeaderText="删除" />--%><%--</Columns>
    </asp:GridView>--%><asp:Label ID="Label6" runat="server" Text="查询范围" Font-Size="12px"></asp:Label>
        <asp:DropDownList ID="ddlLimit" runat="server"  Font-Size="12px" Height="55px" Width="336px" AutoPostBack="True">
            <asp:ListItem>所有记录</asp:ListItem>
              <asp:ListItem>按部门查询</asp:ListItem>
              <asp:ListItem>按教师工号查询</asp:ListItem> 
             <asp:ListItem>按教师姓名查询</asp:ListItem>
               <asp:ListItem>按权限查询</asp:ListItem>
        </asp:DropDownList>
 <asp:Label runat="server" Text="查询条件" ID="Lable7" Font-Size="12px" ></asp:Label>
    <asp:TextBox ID="txtLimit" runat="server" Font-Size="12px" Width="100px"></asp:TextBox><asp:Button ID="btnQuery" runat="server" Height="25px" Text="查询" Width="100px" CssClass="btn" OnClick="btnQuery_Click" Font-Size="12px" />
    <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" CellPadding="3" AllowSorting="True" PageSize="16" OnRowDataBound="gvTeachers_RowDataBound"
         OnPageIndexChanging="gvTeachers_PageIndexChanging" OnRowEditing="gvTeachers_RowEditing"
         OnRowDeleting="gvTeachers_RowDeleting" OnRowUpdating="gvTeachers_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" Font-Size="12px" Height="155px" Width="682px" BorderStyle="None">

        <Columns>
            <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="true" />
           
           
            <asp:BoundField DataField="UserID" HeaderText="教师工号"  ReadOnly="true"/>
            <asp:BoundField DataField="UserName" HeaderText="教师姓名" ReadOnly="true" />
            <asp:BoundField DataField="UserPWD" HeaderText="用户密码"  Visible="false"/>
            <asp:BoundField DataField="Role" HeaderText="教师权限" />
            <asp:CommandField HeaderText="编辑"  />
            <asp:CommandField HeaderText="删除"   />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
       
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
       
    </asp:GridView>
   <table >
       <tr>
           <td style="width:50px"></td>
           <td style="width:65px" align="right">
               
       
   </table>
    </td>
    <td style="width:125px">
        </td>
    <td style="width:60px" align="right">
        </td>
    <td style="width:100px">  
    </td>
    <td style="width:100px"></td>
    </tr>
    <tr>

        <td colspan="6" align="left">

        </td>
    </tr>
    <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Size="12px" ForeColor="Red" ></asp:Label>
    </td></tr>
    </table>
    
   
   
   
    
    
   
   
   
</asp:Content>


