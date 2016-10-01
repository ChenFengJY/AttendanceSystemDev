<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginSystem_Login" %>

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
            height:200px;
        }
        #section{
            height:300px;
        }
        #main{
            margin:0 auto;
            width:60%;
            height:100%;
            background:#abcdef;
        }
        #footer{
            height:100px;
        }
    </style>
</head>
<body>
    <div id="outer">
        <div id="header"></div>
        <div id="section">
            <div id="main">
                <form id="form1" runat="server">
                    <div>
    
                    </div>
                </form>
            </div>
        </div>
        <div id="footer"></div>
    </div>
    
</body>
</html>
