<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPwd.aspx.cs" Inherits="Admin_ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .btn _Text{
            left:150px;
            font-size:20px;
            color:red;
            left:100px;
            float:left;
        }
        </style>
    <br />
    <div><asp:Label ID="Label3" runat="server" Text="用户工号"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="27px"></asp:TextBox></div>
    <br />
    <div><asp:Label ID="Label4" runat="server" Text="原密码"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
    <br />
    <div><asp:Label ID="Label5" runat="server" Text="请设置新密码"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></div>
    <div><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></div>
    <div id="btn"><asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" /></div>



</asp:Content>

