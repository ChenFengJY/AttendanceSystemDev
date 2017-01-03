<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="GetMessage.aspx.cs" Inherits="Teacher_GetMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>序号</th>
                    <th>时间</th>
                    <th>消息</th>
                    <th>标记</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Container.ItemIndex+1 %></td>
                <td>
                    <asp:Label ID="timeLab" Text='<%#DataBinder.Eval(Container.DataItem,"MessageTime") %>' runat="server" /></td>
                <td>
                    <asp:Label ID="messageLab" Text='<%#DataBinder.Eval(Container.DataItem,"Message") %>' runat="server" /></td>
                <td>
                    <asp:Button ID="tabLab" Text='<%#DataBinder.Eval(Container.DataItem,"MessageStatus") %>' runat="server" CommandName="tablab" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
    <asp:Label ID="labwl" runat="server" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SdbiAttentionSystemConnectionString %>" SelectCommand="SELECT [MessageTime], [Message], [MessageStatus] FROM [TabMessage] WHERE ([UserID] = @UserID)">
        <SelectParameters>
            <asp:SessionParameter Name="UserID" SessionField="UserID" Type="String" DefaultValue="''" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

