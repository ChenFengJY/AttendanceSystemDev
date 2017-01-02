 <%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="Admin_SendMessage" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .container {
            margin-top:0px auto;
            width:100%;
        }
        .top {
            width:100%;
            height:20px;
            font-size：15px;
            background:#424242;
            color:white;
        }
        .content {
            width:100%;
            height:100%;
            background:#E0E0E0;
            padding-left:20px;
        }

    </style>
    <div style="height: 296px" class="container">
        <div class="top">
            <asp:Label ID="Label2" runat="server" Text="&nbsp;&nbsp;发布通知"></asp:Label>
        </div>
        <div class="content">
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="院系领导" OnCheckedChanged="CheckBox1_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox2" runat="server" Text="各系辅导员" OnCheckedChanged="CheckBox2_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox3" runat="server" Text="本学期有课所有教师" OnCheckedChanged="CheckBox3_CheckedChanged" />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="200px"  Width="70%">
                    <asp:TextBox ID="TextBox1" runat="server" Height="200px"  Width="70%" OnTextChanged="TextBox1_TextChanged" TextMode="MultiLine"></asp:TextBox>
            </asp:Panel><br />
             <asp:Button ID="Button1" runat="server" Text="发送" BackColor="Aqua" BorderColor="#FF0066" OnClick="Button1_Click1" />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
         </div>
    </div>
    
</asp:Content>

