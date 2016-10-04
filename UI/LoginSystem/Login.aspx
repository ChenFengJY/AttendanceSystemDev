<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginSystem_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录系统</title>
    <style>
        *{margin:0;padding:0;}
        #outer{
            margin:0 auto;
            margin-top:20px;
            width:1000px;
            height:600px;
            background:#eee;
            box-shadow:0 0 10px #0CC;
        }
        #header{
            height:140px;

        }
        #section{
            height:400px;
            position:relative;
        }
        #pic{
            position:absolute;
            top:-50px;/*位置*/
            left:40px;
            width:400px;
            height:500px;
        }
        div.polaroid
        {
            width:250px;
            margin-left:40px;
            padding:10px 10px 20px 10px;
            border:1px solid #BFBFBF;
            background-color:white;
            /* Add box-shadow */
            box-shadow:2px 2px 3px #aaaaaa;
        }

        div.rotate_left
        {
            float:left;
            -ms-transform:rotate(7deg); /* IE 9 */
            -moz-transform:rotate(7deg); /* Firefox */
            -webkit-transform:rotate(7deg); /* Safari and Chrome */
            -o-transform:rotate(7deg); /* Opera */
            transform:rotate(7deg);
        }

        div.rotate_right
        {
            float:left;
            -ms-transform:rotate(-8deg); /* IE 9 */
            -moz-transform:rotate(-8deg); /* Firefox */
            -webkit-transform:rotate(-8deg); /* Safari and Chrome */
            -o-transform:rotate(-8deg); /* Opera */
            transform:rotate(-8deg);
        }



        #main{
            width:40%;
            height:100%;
            box-shadow:0 0 5px #ccc;
            position:relative;
            left:500px;
        }
        #logna{
            width:322px;
            height:37px;
            margin:0 auto;
            padding-top:5px;
            position:relative;
            background:url(../images/logtext.png) no-repeat;
            top:50px;/*更改上下位置*/
        }
        .leftfloat{
            width:43px;
            height:40px;
            float:left;
        }
        .rightfloat{
            float:left;
        }
        #pwdna{
            width:322px;
            height:37px;
            margin:0 auto;
            padding-top:5px;
            position:relative;
            background:url(../images/logtext.png) no-repeat;
            background-position:0 -42px;
            top:80px;/*更改上下位置*/
        }
        #testna{
            width:322px;
            height:42px;
            margin:0 auto;
            position:relative;
            background:url(../images/logtext.png) no-repeat;
            background-position:0 -84px;
            top:110px;/*更改上下位置*/
        }
        #btnna{
            margin:0 auto;
            position:relative;
            top:140px;/*更改上下位置*/
        }
        #footer{
            height:60px;
        }
    </style>
</head>
<body>
    <div id="outer">
        <div id="header"></div>
        <div id="section">
            <div id="pic">
                <div class="polaroid rotate_left">
                    <img src="../images/ballade_dream.jpg" alt="山东商务" width="250" height="160" />
                    <p class="caption">山东商务职业学院</p>
                </div>
                <div class="polaroid rotate_right">
                    <img src="../images/china_pavilion.jpg" alt="山东商务" width="250" height="160" />
                    <p class="caption">山东商务职业学院</p>
                </div>
            </div>
            <div id="main">
                <form id="form1" runat="server">
                    <div>
                        <div id="logna">
                            <div class="leftfloat"></div>
                            <div class="rightfloat">
                            <asp:TextBox ID="TextBox1" runat="server"  Height="30px" Width="268px" Wrap="False" BorderStyle="None" EnableTheming="True" ToolTip="登录"></asp:TextBox></div>
                            </div>
                        <div id="pwdna">
                            <div class="leftfloat"></div>
                            <div class="rightfloat">
                            <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="268px" Wrap="False" BorderStyle="None" EnableTheming="True"></asp:TextBox>
                            </div>
                        </div>
                        <div id="testna">

                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                        </div>
                        <div id="btnna">

                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" />

                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div id="footer"></div>
    </div>
    <script type="text/javascript">

    </script>
</body>
</html>
