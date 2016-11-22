<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoadExcelToDatabase.aspx.cs" Inherits="Admin_LoadExcelToDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .content {
            width:100%;
            height:auto;
            min-width:1100px;
            min-height:500px;
            padding:10px 0 0 0;
            font-family: "Microsoft YaHei"，Arial, Helvetica, sans-serif;
        }

        .clear {
            clear: both;
            width:100%;
        }
        .con_to_top{
            height:180px;
            width:1100px;
            margin:0 auto;
            
        }
        .teacher_Info {
            width: 48%;
            height: 160px;
            margin-left: 1%;
            float: left;
            background:#f0f0f0;
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
            width: 90%;
            padding: 10px 20px;
            text-align:left;
        }

        .tea_btm {
            width: 90%;
            margin-left:10px;
            margin-top:10px;
        }
        .dispose_Info{
            margin:20px auto;
            width:350px;
            height:300px;
            background:#f0f0f0;
            box-shadow: 0px 0px 2px #ccc;
        }
        .dispose_Info:hover {
            box-shadow: 0px 0px 3px 3px #ccc;
        }
        .course_Info{
            width: 48%;
            height: 160px;
            background:#f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
            margin-right: 1%;
            float: right;
        }
        .course_Info:hover {
            box-shadow: 0px 0px 3px 2px #ccc;
        }

        .con_to_bot{
            width:1100px;
            margin:0 auto;
            height:300px;
        }
        .float_le {
            margin-left: 1%;
            width: 48%;
            height: 300px;
            float: left;
        }

        .school_Day {
            height: 120px;
            margin-bottom:5px;
            background:#f0f0f0;
            box-shadow: 0px 0px 1px #ccc;
            margin-bottom: 20px;
        }
        .school_Day:hover {
            box-shadow: 0px 0px 3px 2px #ccc;
        }

        .department_peo {
            height: 280px;
            background:#f0f0f0;
            width:48%;
            float:right;
            margin-right:1%;
            box-shadow: 0px 0px 1px #ccc;
        }
        .department_peo:hover {
            box-shadow: 0px 0px 3px 2px #ccc;
        }
        .peo_cen{
            width:80%;
            height:auto;
            margin-left:60px;
            margin-top:10px;
        }
        .peo_cen_left{
            width:45%;
            float:left;
            margin-left:2%;
        }
        
        .peo_left{
            float:left;
            margin-top:8px;
        }
        .peo_right{
            float:right;
            margin-top:8px;
        }
    </style>
    <div class="content">
        <div class="con_to_top">
            <div class="teacher_Info">
                <div class="tea_top">
                    <h3>导入教师基本信息</h3>
                </div>
                <div class="tea_cen">
                    <asp:RadioButton ID="rdoTeacher" runat="server" Text="本校教师" GroupName="teacherClass" />
                    <asp:RadioButton ID="rdoOther" runat="server" Text="外聘教师" GroupName="teacherClass" />
                </div>
                <div class="tea_btm">
                    <h4>请选择要导入的文件</h4>
                    <asp:FileUpload ID="FileUploadTeacher" runat="server" />
                    <asp:Button ID="BtnImpotTeachers" runat="server" Text="导入" Width="61px" OnClick="BtnImportTeachers_Click" />
                    <asp:Label ID="lblMessage1" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="course_Info">
                <div class="tea_top">
                    <h3>分系部导入授课信息</h3>
                </div>
                <div class="tea_cen">
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
                <div class="tea_btm">
                    <h4>请选择要导入的文件</h4>
                    <asp:FileUpload ID="FileUploadCourse" runat="server" />
                    <asp:Button ID="BtnImportCourse" runat="server" Text="导入" Width="63px" OnClick="BtnImportCourse_Click" />
                    <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                </div>
            </div>
            
        </div>

        <div class="con_to_bot">
            <div class="float_le">
                <div class="school_Day">
                    <div class="tea_top">
                        <h3>导入本学期校历</h3>
                    </div>
                    <div class="tea_cen">
                        <h4>请选择要导入的文件</h4>
                        <asp:FileUpload ID="FileUploadCalendar" runat="server" />
                        <asp:Button ID="Button3" runat="server" Text="导入" Width="67px" OnClick="BtnImportCalendar_Click" />
                        <asp:Label ID="lblMessage5" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="school_Day">
                    <div class="tea_top">
                        <h3>数据预处理</h3>
                    </div>
                    <div class="tea_cen">
                      <asp:Button ID="Button5" runat="server" Text="处理入库数据" OnClick="Button5_Click" />
                      <asp:Label ID="lblMessage7" runat="server" Text=""></asp:Label>
                      <asp:Button ID="btnClear" runat="server" Text="清空导入数据库" OnClick="btnClear_Click" />
                    </div>
                </div>
            </div>
            <div class="department_peo">
                <div class="tea_top">
                    <h3>导入各系部总人数</h3>
                </div>
                <div class="peo_cen">
                    <div class="peo_cen_left">
                        <div>
                            <asp:Label ID="LabelKJ" runat="server" Text="会计系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtKJ" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelJC" runat="server" Text="基础教学部" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtJC" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelJG" runat="server" Text="经济管理系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtJG" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelJX" runat="server" Text="机械工程系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtJX" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelJW" runat="server" Text="教务处" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtJW" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                    </div>

                    <div class="peo_cen_left">
                        <div>
                            <asp:Label ID="LabelJZ" runat="server" Text="建筑工程系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtJZ" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelSW" runat="server" Text="商务外语系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtSW" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelSP" runat="server" Text="食品工程系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtSP" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                        <div>
                            <asp:Label ID="LabelXX" runat="server" Text="信息工程系" CssClass="peo_left"></asp:Label>
                            <asp:TextBox ID="txtXX" runat="server" Width="108px" CssClass="peo_right"></asp:TextBox>
                            <div class="clear"></div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="tea_btm">
                    <asp:Button ID="Button6" runat="server" OnClick="BtnDepartmentCount_Click" Text="导入" />
                    <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="clear"></div>
        </div>

    </div>
</asp:Content>

