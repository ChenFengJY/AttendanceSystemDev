<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPwd.aspx.cs" Inherits="Admin_ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .btn _Text{
            left:150px;
            font-size:20px;
            color:red;
            left:100px;
            float:left;
        }
        .change_Pwd{
            margin:10px auto;
            border:1px solid #00ffff;
            padding:20px 30px;
            width:400px;
            
        }
    </style>
    <div class="change_Pwd">
        <br />
        <div>
            <asp:Label ID="Label3" runat="server" Text="用户工号："></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" Text="原密码："></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label5" runat="server" Text="请设置新密码："></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </div>
        <br />
        <div id="btn">
            <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>

