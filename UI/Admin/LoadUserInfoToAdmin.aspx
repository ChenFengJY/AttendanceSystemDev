<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadUserInfoToAdmin.aspx.cs" Inherits="Admin_LoadUserInfoToAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        #main{
            width:100%;
            height:100%;
            min-height:400px; 
            text-align:center;
            Font-Size:12px;

            /* Permalink - use to edit and share this gradient: http://colorzilla.com/gradient-editor/#f7fbfc+0,d9edf2+40,add9e4+100;Blue+3D+%231 */
            background: rgb(247,251,252); /* Old browsers */
            background: -moz-linear-gradient(top,  rgba(247,251,252,1) 0%, rgba(217,237,242,1) 40%, rgba(173,217,228,1) 100%); /* FF3.6-15 */
            background: -webkit-linear-gradient(top,  rgba(247,251,252,1) 0%,rgba(217,237,242,1) 40%,rgba(173,217,228,1) 100%); /* Chrome10-25,Safari5.1-6 */
            background: linear-gradient(to bottom,  rgba(247,251,252,1) 0%,rgba(217,237,242,1) 40%,rgba(173,217,228,1) 100%); /* W3C, IE10+, FF16+, Chrome26+, Opera12+, Safari7+ */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f7fbfc', endColorstr='#add9e4',GradientType=0 ); /* IE6-9 */            
        }
        .toHead{
            padding-top:20px;
            min-width:500px;
            height:50px;
            
        }
        .toCen{
            width:800px;
            min-width:500px;
            margin:0 auto;
        }

    </style>
    <div id="main">
        <div class="toHead">
            <span>查询范围</span>

            <asp:DropDownList ID="ddlLimit" runat="server"  Height="20px" Width="336px" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlLimit_SelectedIndexChanged" >
                <asp:ListItem Selected="True">所有记录</asp:ListItem>
                <asp:ListItem>按部门查询</asp:ListItem>
                <asp:ListItem>按教师工号查询</asp:ListItem> 
                <asp:ListItem>按教师姓名查询</asp:ListItem>
                <asp:ListItem>按权限查询</asp:ListItem>
            </asp:DropDownList>

            <asp:Label runat="server" Text="查询条件" ID="Lable7" ></asp:Label>
            <asp:TextBox ID="txtLimit" runat="server" Width="100px"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" Height="25px" Text="查询" Width="100px" CssClass="btn" OnClick="btnQuery_Click" />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>
        </div>

        <div class="toCen">
            <!-- 说明：
                AllowPaging="True"自动分页 PageSize="16"每页16行
                ItemStyle-Width 固定表的列宽

                -->
            <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" CellPadding="3" AllowSorting="True" PageSize="16" AllowPaging="True" 
                OnRowDataBound="gvTeachers_RowDataBound"
                OnPageIndexChanging="gvTeachers_PageIndexChanging" 
                OnRowEditing="gvTeachers_RowEditing"
                OnRowDeleting="gvTeachers_RowDeleting" 
                OnRowUpdating="gvTeachers_RowUpdating" 
                BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" Height="155px" Width="682px" BorderStyle="None" OnRowCancelingEdit="gvTeachers_RowCancelingEdit">

                <Columns>
                    <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="true" ItemStyle-Wrap="false" ItemStyle-Width="100px" >
<ItemStyle Wrap="False" Width="100px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="教师工号"  ReadOnly="true" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UserName" HeaderText="教师姓名" ReadOnly="true" ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UserPWD" HeaderText="用户密码"  Visible="false" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="教师权限">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlTeacherRole" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                            </asp:DropDownList>
                            
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabTeacherRole" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="60px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
       
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            </asp:GridView>
        </div>
        <!--
       <table >
           <tr>
                <td style="width:50px"></td>
                <td style="width:65px" align="right">
                </td>
                <td style="width:125px">
                </td>
                <td style="width:60px" align="right">
                </td>
                <td style="width:100px">  
                </td>
                <td style="width:100px"></td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                </td>
            </tr>
    
        </table>
        -->
    </div>
</asp:Content>


