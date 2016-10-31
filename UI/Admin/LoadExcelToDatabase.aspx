<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadExcelToDatabase.aspx.cs" Inherits="Admin_LoadExcelToDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    导入数据
    <asp:Label ID="Label3" runat="server" Text="导入文件"></asp:Label>
    <asp:FileUpload ID="FileUpload_xls" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导入" />
&nbsp;<br />
&nbsp;
</asp:Content>

