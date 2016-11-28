 <%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="Admin_SendMessage" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
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
        }
    </style>
    <div style="height: 296px">
        <div class="top">
            <asp:Label ID="Label2" runat="server" Text="发布通知"></asp:Label>
        </div>
        <div class="content">
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="院系领导" OnCheckedChanged="CheckBox1_CheckedChanged" />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="各系辅导员" OnCheckedChanged="CheckBox2_CheckedChanged" />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="本学期有课所有教师" OnCheckedChanged="CheckBox3_CheckedChanged" />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="200px"  Width="700px">
                    <asp:TextBox ID="TextBox1" runat="server" Height="200px"  Width="700px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
             </asp:Panel>
             <asp:Button ID="Button1" runat="server" Text="发送成功" BackColor="Aqua" BorderColor="#FF0066" OnClick="Button1_Click1" />
            <asp:Label ID="Label6" runat="server" Text="lalMessage"></asp:Label>
         </div>
    </div>
    
    
</asp:Content>

