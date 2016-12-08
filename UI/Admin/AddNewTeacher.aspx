<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddNewTeacher.aspx.cs" Inherits="Admin_AddNewTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .backToContent{
            width:auto;
            height:100%;
            background:url(https://img1.doubanio.com/view/photo/large/public/p2178029027.jpg) left bottom;
            background-size:cover;
        }
        .height{
            height:50px;
        }
        .table{
            width:300px;
            height:420px;
            border:1px #c3c3c3 solid;
            background:#fff;
            margin-left:150px;   
            font-size:16px;   
        }
        .totitle{
            color:burlywood;
            text-align:center;
            margin:4px;
        }
        .toform{
            width:250px;
            margin:5px auto;
            border-top:1px solid #c3c3c3;
        }
        .toform lable{
            margin:10px 0px;
        }
        .toform div{
            margin:10px 0px;
        }
        .new_tea .toleft{
            width:60px;
            height:30px;
            text-align:center;
        }
        .new_tea .toright{
            width:200px;
            height:30px;
            text-align:center;
        }
        .dropDown{
            width:100%;
            height:30px;
            
        }
        .textBox{
            width:100%;
            height:26px;
        }
    </style>
    <div class="backToContent">
        <div class="height"></div>
        <div class="table">
            <h2 class="totitle">新增教师</h2>
            <div class="toform">
                <lable >教师类型</lable>
                <div>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="dropDown" >
                        <asp:ListItem>本校教师</asp:ListItem>
                        <asp:ListItem>外聘教师</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <lable>所属部门</lable>
                <div>
                    <asp:DropDownList ID="ddlDepartmentName" runat="server">
                        <asp:ListItem Selected="True">会计系</asp:ListItem>
                        <asp:ListItem>基础教学部</asp:ListItem>
                        <asp:ListItem>经济管理系</asp:ListItem>
                        <asp:ListItem>机械工程系</asp:ListItem>
                        <asp:ListItem>教务处</asp:ListItem>
                        <asp:ListItem>建筑工程系</asp:ListItem>
                        <asp:ListItem>商务外语系</asp:ListItem>
                        <asp:ListItem>食品工程系</asp:ListItem>
                        <asp:ListItem>信息工程系</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <lable>教师工号</lable>
                <div>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox"></asp:TextBox>
                </div>
                <lable>教师姓名</lable>
                &nbsp;<div><asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox></div>
                <lable>密码</lable>
                <div><asp:TextBox ID="TextBox3" runat="server" CssClass="textBox"></asp:TextBox></div>
                <lable>性别</lable>
                <div><asp:DropDownList ID="ddlSex" runat="server" ></asp:DropDownList></div>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click1" Text="确定" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>
    
    
    
  
  

    

    
    
    </asp:Content>

