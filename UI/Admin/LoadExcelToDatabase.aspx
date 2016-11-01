<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadExcelToDatabase.aspx.cs" Inherits="Admin_LoadExcelToDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .content {
            margin: 0;
            padding: 0;
            font-family: "Microsoft YaHei"，Arial, Helvetica, sans-serif;
        }

        .clear {
            clear: both;
        }

        .teacher_Info {
            width: 48%;
            height: 160px;
            margin-left: 5px;
            float: left;
            background: #f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
        }

            .teacher_Info:hover {
                box-shadow: 0px 0px 3px 2px #ccc;
            }

        .tea_top {
            width: 100%;
            height: 40px;
            font-size: 16px;
            text-indent: 2em;
            line-height: 40px;
            background-image: linear-gradient(to top,#fff,#15E7A9);
        }

        .tea_cen {
            width: 100%;
            height: 50px;
            text-align: center;
            background: #abcdef;
        }

        .tea_btm {
            width: 100%;
            height: 60px;
            text-align: center;
            background: #abcdef;
        }

        .teach_Info {
            width: 48%;
            height: 160px;
            background: #f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
            margin-right: 5px;
            float: right;
        }

        .float_le {
            margin-left: 1%;
            width: 56%;
            height: 300px;
            background: #f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
            float: left;
        }

        .school_Day {
            height: auto;
            margin: 5px auto;
            border: 1px solid #f00;
            margin-left: 5px;
            margin-bottom: 20px;
        }

        .scl_top {
            width: 100%;
            height: 40px;
            font-size: 16px;
            text-indent: 2em;
            line-height: 40px;
            background-image: linear-gradient(to top,#fff,#15E7A9);
        }

        .scl_cen {
            width: 100%;
            height: 60px;
        }

        .department_peo {
            height: auto;
            margin: 0 auto;
            border: 1px solid #f00;
            margin-right: 5px;
        }

        .float_ri {
            margin-right: 1%;
            width: 40%;
            height: 300px;
            float: right;
            background: #f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
        }
    </style>
    <div class="content">
        <div class="teacher_Info">

            <div class="tea_top">
                <h3>导入教师基本信息</h3>
            </div>
            <div class="tea_cen">
                <asp:RadioButton ID="rdoTeacher" runat="server" Text="本校教师" GroupName="teacherClass" />
                &nbsp;&nbsp;&nbsp;
             <asp:RadioButton ID="rdoOther" runat="server" Text="外聘教师" GroupName="teacherClass" />
            </div>
            <div class="tea_btm">
                <h4>请选择要导入的文件</h4>
                <asp:FileUpload ID="FileUploadTeacher" runat="server" />
                <asp:Button ID="BtnImpotTeachers" runat="server" Text="导入" Width="61px" OnClick="BtnImportTeachers_Click" />
                <asp:Label ID="lblMessage1" runat="server" Text="lblMessage1"></asp:Label>
            </div>
        </div>

        <div class="teach_Info">
            <div class="tea_top">
                <h3>分系部导入授课信息</h3>
            </div>
            <div class="tea_cen">
                <asp:DropDownList ID="ddlDepartmentName" runat="server">
                    <asp:ListItem Selected="True">教务处</asp:ListItem>
                    <asp:ListItem>信息工程系</asp:ListItem>
                    <asp:ListItem>会计系</asp:ListItem>
                    <asp:ListItem>机械工程系</asp:ListItem>
                    <asp:ListItem>建筑工程系</asp:ListItem>
                    <asp:ListItem>基础教学部</asp:ListItem>
                    <asp:ListItem>经济管理系</asp:ListItem>
                    <asp:ListItem>商务外语系</asp:ListItem>
                    <asp:ListItem>食品工程系</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="tea_btm">
                <h4>请选择要导入的文件</h4>
                <asp:FileUpload ID="FileUploadCourse" runat="server" />
                <asp:Button ID="BtnImportCourse" runat="server" Text="导入" Width="63px" OnClick="BtnImportCourse_Click" />
                <asp:Label ID="lblMessage2" runat="server" Text="lblMessage2"></asp:Label>
            </div>
        </div>
        <div class="clear"></div>

        <div class="float_le">
            <div class="school_Day">
                <div class="scl_top">
                    <h3>导入本学期校历</h3>
                </div>
                <div class="scl_cen">
                    <h4>请要选择导入的文件</h4>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                    &nbsp;
                <asp:Button ID="Button3" runat="server" Text="导入" Width="67px" OnClick="Button3_Click" />
                    <asp:Label ID="lblMessage5" runat="server" Text="lblMessage5"></asp:Label>
                </div>
            </div>


            <div class="department_peo">
                <div class="tea_top">
                    <h4>导入各系部总人数</h4>
                </div>
                <div>
                    <asp:Label ID="Label11" runat="server" Text="会计系"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="108px"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Label6"></asp:Label>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="信息工程系"></asp:Label>
                    &nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="108px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="经济管理系"></asp:Label>
                    &nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="108px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="食品工程系"></asp:Label>
                    &nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Width="108px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="机械工程系"></asp:Label>
                    &nbsp;
                <asp:TextBox ID="TextBox5" runat="server" Width="108px"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="float_ri">
            <div class="tea_top">
                <h3>数据预处理</h3>
            </div>
            <div>
                &nbsp;
              <asp:Button ID="Button4" runat="server" Text="分析入库数据" />
                &nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblMessage3" runat="server" Text="[lblMessage3]"></asp:Label>
            </div>
            <div>
                &nbsp;
              <asp:Button ID="Button5" runat="server" Text="处理入库数据" />
                &nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblMessage7" runat="server" Text="[lblMessage7]"></asp:Label>
            </div>
            <div>
                &nbsp;
              <asp:Button ID="btnClearPreData" runat="server" Text="清空入库数据" />
                &nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblMessage4" runat="server" Text="[lblMessage4]"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

