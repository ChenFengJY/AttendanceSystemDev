<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="GetMessage.aspx.cs" Inherits="Teacher_GetMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <style>
        .backToContent{
            width:auto;
            height:100%;
           
        }
        .height{
            height:30px;
        }
        .main{
            width:1100px;
            height:auto;
        }
        
        .news{
            width:1000px;
            height:auto;
            margin:0 auto;
            min-height:100px;
            
            padding:20px;
            margin-bottom:60px;
            border:1px solid #808080;
            box-shadow:0 0 4px 2px #f0f0f0;
            background-color:rgba(232,232,232,0.5);
        }
        .news table{
            border:1px solid #000;
            border-collapse:collapse;
            width:900px;
            margin:0 auto;
            text-align:center;
        }
        .news tr{
            width:900px;
            height:50px;
            border:1px solid #000;
        }
        .news th{
            border-width:2px;
            width:80px;
            font-size:17px;
            border:2px solid #000;
        }
        .news td{
            border-width:2px;
            width:80px;
            font-size:12px;
            border:1px solid #000;
        }

    </style>
    <div class="backToContent">
        <div class="height"></div>
        <div class="news">
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
        </div>

    </div>
    
</asp:Content>

