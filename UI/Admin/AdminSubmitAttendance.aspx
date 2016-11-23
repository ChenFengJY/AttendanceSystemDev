<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSubmitAttendance.aspx.cs" Inherits="Admin_AdminSubmitAttendance" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .backToContent{
            width:auto;
            height:100%;
            /*background:url(https://img1.doubanio.com/view/photo/large/public/p2178029027.jpg) left bottom;*/
            background-size:cover;
            /*background:#00ffff;*/
            /* Permalink - use to edit and share this gradient: http://colorzilla.com/gradient-editor/#f0f9ff+0,cbebff+47,a1dbff+100;Blue+3D+%2313 */
            background: rgb(240,249,255); /* Old browsers */
            background: -moz-linear-gradient(top,  rgba(240,249,255,1) 0%, rgba(203,235,255,1) 47%, rgba(161,219,255,1) 100%); /* FF3.6-15 */
            background: -webkit-linear-gradient(top,  rgba(240,249,255,1) 0%,rgba(203,235,255,1) 47%,rgba(161,219,255,1) 100%); /* Chrome10-25,Safari5.1-6 */
            background: linear-gradient(to bottom,  rgba(240,249,255,1) 0%,rgba(203,235,255,1) 47%,rgba(161,219,255,1) 100%); /* W3C, IE10+, FF16+, Chrome26+, Opera12+, Safari7+ */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f0f9ff', endColorstr='#a1dbff',GradientType=0 ); /* IE6-9 */

        }
        .height{
            height:30px;
        }
        .main{
            width:1100px;
            height:auto;
            margin:0 auto;
            padding:20px;
            box-shadow:0 0 4px 2px #f0f0f0;
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
        .weekInfo table{
            border:1px solid #000;
            border-collapse:collapse;
            width:900px;
            margin:0 auto;
            text-align:center;
        }
        .weekInfo tr{
            width:900px;
            height:50px;
            border:1px solid #000;
        }
        .weekInfo th{
            border-width:2px;
            width:80px;
            font-size:17px;
            border:2px solid #000;
        }
        .weekInfo td{
            border-width:2px;
            width:80px;
            font-size:12px;
            border:1px solid #000;
        }

    </style>

    <div class="backToContent">
        <div class="height"></div>
        <div class="main">
            <div class="thisweek">
                <h2>本周考勤情况</h2>
                <div class="weekInfo">
                    <asp:Repeater ID="thisRepeater" runat="server" OnItemCommand="thisRepeater_ItemCommand">

                        <HeaderTemplate>
                             <table>
                                <tr>
                                    <th>序号</th>
                                    <th>星期</th>
                                    <th>节数</th>
                                    <th>课程名称</th>
                                    <th>班级名称</th>
                                    <th>教学地址</th>
                                    <th>考勤情况</th>
                                    <th>操作</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                                <td>  <%#Container.ItemIndex+1 %></td>
                                <td><asp:Label ID="thisWeekLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseWeek") %>'></asp:Label></td>
                                <td><asp:Label ID="thisTimeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseTime") %>'></asp:Label></td>
                                <td> <asp:Label ID="thisNameLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseName") %>'></asp:Label></td>
                                <td><asp:Label ID="thisClassLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Class") %>'></asp:Label></td>
                                <td><asp:Label ID="thisAddressLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseAddress") %>'></asp:Label></td>
                                <td><asp:Label ID="thisAttendanceLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AttendanceInfo") %>'></asp:Label></td>
                                <td><asp:Button ID="thisButton2" runat="server" Text="编辑" CommandName="thisButton2" OnClick="thisButton2_Click" /></td>
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
                    <asp:Repeater ID="lastRepeater" runat="server">

                        <HeaderTemplate>
                             <table>
                                <tr>
                                    <th>序号</th>
                                    <th>星期</th>
                                    <th>节数</th>
                                    <th>课程名称</th>
                                    <th>班级名称</th>
                                    <th>教学地址</th>
                                    <th>考勤情况</th>
                                    <th>操作</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                                <td>  <%#Container.ItemIndex+1 %></td>
                                <td><asp:Label ID="lastWeekLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseWeek") %>'></asp:Label></td>
                                <td><asp:Label ID="lastTimeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseTime") %>'></asp:Label></td>
                                <td> <asp:Label ID="lastNameLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseName") %>'></asp:Label></td>
                                <td><asp:Label ID="lastClassLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Class") %>'></asp:Label></td>
                                <td><asp:Label ID="lastAddressLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CourseAddress") %>'></asp:Label></td>
                                <td><asp:Label ID="lastAttendanceLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AttendanceInfo") %>'></asp:Label></td>
                                <td><asp:Button ID="lastButton2" runat="server" Text="编辑" /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

