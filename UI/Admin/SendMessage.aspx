<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="Admin_SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div>

            

            通知用户：<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>全校教师</asp:ListItem>
                <asp:ListItem>所有系部教师</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="ListBox1" runat="server" Height="98px" Width="670px"></asp:ListBox>
            <br />
            <asp:Button ID="Button1" runat="server" Height="23px" Text="发布" Width="69px" />

            

        </div>
        发布通知&nbsp;&nbsp;
    </div>
    
</asp:Content>

