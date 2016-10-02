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
            height:140px;

        }
        #section{
            height:400px;
            position:relative;
        }
        #main{
            width:40%;
            height:100%;
            box-shadow:0 0 5px #ccc;
            position:relative;
            
            left:500px;
        }
        #logna{
            margin:0 auto;
            width:322px;
            height:42px;
            background:url(../images/logtext.png);
            position:relative;
            top:50px;
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
            <div id="main">
                <form id="form1" runat="server">
                    <div>
                        <div id="logna">
                            
                        </div>
                        <div id="pwdna"></div>
                        <div id="btna"></div>
                    </div>
                </form>
            </div>
        </div>
        <div id="footer"></div>
    </div>
    
</body>
</html>
