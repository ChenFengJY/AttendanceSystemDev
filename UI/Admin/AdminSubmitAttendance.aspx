<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSubmitAttendance.aspx.cs" Inherits="Admin_AdminSubmitAttendance" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .backToContent{
            width:auto;
            height:100%;
            background:#00ffff;
            /*background:url(https://img1.doubanio.com/view/photo/large/public/p2178029027.jpg) left bottom;*/
            background-size:cover;
        }
        .height{
            height:30px;
        }
        .main{
            width:1100px;
            height:auto;
            margin:0 auto;
            padding:20px;
            box-shadow:0 0 2px 1px #f0f0f0;
            background-color:rgba(232,232,232,0.5);
        }
        .thisweek{
            width:1060px;
            height:auto;
        }
        .thisweek h2{
            color:brown;
        }
        .weekInfo{
            width:1000px;
            height:auto;
            min-height:100px;
            _height:100px;
            padding:10px;
            border:1px solid #808080;
        }
    </style>

    <div class="backToContent">
        <div class="height"></div>
        <div class="main">
            <div class="thisweek">
                <h2>本周考勤情况</h2>
                <div class="weekInfo">
                    <asp:Repeater ID="rptCourse" runat="server" OnItemCommand="rptCourse_ItemCommand">

                        <HeaderTemplate>
                            <table >
                                
                        </HeaderTemplate>
                        <ItemTemplate>
                            
                            <tr>
                                <td>
                                    <%#Container.ItemIndex+1 %>
                                </td>
                                <td style="width:40%;height:25px;" align="center">
                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseWeek") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseTime") %>'></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseID") %>'></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseName") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                </div>
            </div>
            <div class="thisweek">
                <h2>上周考勤情况</h2>
                <div class="weekInfo">

                </div>
            </div>
        </div>
    </div>
</asp:Content>

