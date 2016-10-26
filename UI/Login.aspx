<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginSystem_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="./css/slide-unlock.css" rel="stylesheet" />
    <title>系统登录</title>
    <style type="text/css">
        html {
            overflow-y: scroll;
            vertical-align: baseline;
        }

        body {
            font-family: Microsoft YaHei,Segoe UI,Tahoma,Arial,Verdana,sans-serif;
            font-size: 12px;
            color: #fff;
            height: 100%;
            line-height: 1;
            background: #999;
        }

        * {
            margin: 0;
            padding: 0;
        }

        ul, li {
            list-style: none;
        }

        h1 {
            font-size: 30px;
            font-weight: 700;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }

        .login-box {
            width: 410px;
            margin: 120px auto 0 auto;
            text-align: center;
            padding: 30px;
            background: url(images/mask.png);
            border-radius: 10px;
        }

            .login-box .name, .login-box .password, .login-box .code, .login-box .remember {
                font-size: 16px;
                text-shadow: 0 1px 2px rgba(0,0,0,.1);
            }

                .login-box .remember input {
                    box-shadow: none;
                    width: 15px;
                    height: 15px;
                    margin-top: 25px;
                }


            .login-box label {
                display: inline-block;
                width: 70px;
                text-align: right;
                vertical-align: middle;
            }

        .vercode {
            width: 120px;
            height: 42px;
            margin-top: 25px;
            padding: 0px 15px;
            border: 1px solid rgba(255,255,255,.15);
            border-radius: 6px;
            color: #fff;
            letter-spacing: 2px;
            font-size: 16px;
            background: transparent;
        }
 

        .login-box img {
            width: 148px;
            height: 42px;
            border: none;
        }

        .vCode {
            background: url(images/vercode.jpg);
            font-family: Arial;
            font-style: italic;
            color: blue;
            font-size: 30px;
            margin-top: 26px;
            border: 0;
            letter-spacing: 3px;
            font-weight: bolder;
            float: right;
            cursor: pointer;
            width: 148px;
            height: 42px;
            line-height: 42px;
            text-align: center;
            vertical-align: middle;
        }

        .input {
            width: 270px;
            height: 42px;
            margin-top: 25px;
            padding: 0px 15px;
            border: 1px solid rgba(255,255,255,.15);
            border-radius: 6px;
            color: #fff;
            letter-spacing: 2px;
            font-size: 16px;
            background: transparent;
        }

        .button {
            cursor: pointer;
            width: 100%;
            height: 44px;
            padding: 0;
            margin-top:26px;
            background: #ef4300;
            border: 1px solid #ff730e;
            border-radius: 6px;
            font-weight: 700;
            color: #fff;
            font-size: 24px;
            letter-spacing: 15px;
            text-shadow: 0 1px 2px rgba(0,0,0,.1);
        }

        .input:focus {
            outline: none;
            box-shadow: 0 2px 3px 0 rgba(0,0,0,.1) inset,0 2px 7px 0 rgba(0,0,0,.2);
        }

        .button:hover {
            box-shadow: 0 15px 30px 0 rgba(255,255,255,.15) inset,0 2px 7px 0 rgba(0,0,0,.2);
        }

        .screenbg {
            position: fixed;
            bottom: 0;
            left: 0;
            z-index: -999;
            overflow: hidden;
            width: 100%;
            height: 100%;
            min-height: 100%;
        }

            .screenbg ul li {
                display: block;
                list-style: none;
                position: fixed;
                overflow: hidden;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                z-index: -1000;
                float: right;
            }

            .screenbg ul a {
                left: 0;
                top: 0;
                width: 100%;
                height: 100%;
                display: inline-block;
                margin: 0;
                padding: 0;
                cursor: default;
            }

            .screenbg a img {
                vertical-align: middle;
                display: inline;
                border: none;
                display: block;
                list-style: none;
                position: fixed;
                overflow: hidden;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                z-index: -1000;
                float: right;
            }

        .bottom {
            margin: 8px auto 0 auto;
            width: 100%;
            position: fixed;
            text-align: center;
            bottom: 0;
            left: 0;
            overflow: hidden;
            padding-bottom: 8px;
            color: #ccc;
            word-spacing: 3px;
            zoom: 1;
        }

            .bottom a {
                color: #FFF;
                text-decoration: none;
            }

                .bottom a:hover {
                    text-decoration: underline;
                }
    </style>
    <script src="js/jquery-1.12.1.min.js"></script>
    <script src="js/jquery.slideunlock.js"></script>
    <script>
        var flag = false;
        $(function () {
            var slider = new SliderUnlock("#slider", {
                successLabelTip: "验证成功"
            }, function () {
                flag = true;
            });
            slider.init();
        })
        function checking() {
            if (flag == false)
                alert("请拖动滑块验证");
            return flag;
        }
    </script>
    <script type="text/javascript" src="js/checkCode.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".screenbg ul li").each(function () {
                $(this).css("opacity", "0");
            });
            $(".screenbg ul li:first").css("opacity", "1");
            var index = 0;
            var t;
            var li = $(".screenbg ul li");
            var number = li.size();
            function change(index) {
                li.css("visibility", "visible");
                li.eq(index).siblings().animate({ opacity: 0 }, 3000);
                li.eq(index).animate({ opacity: 1 }, 3000);
            }
            function show() {
                index = index + 1;
                if (index <= number - 1) {
                    change(index);
                } else {
                    index = 0;
                    change(index);
                }
            }
            t = setInterval(show, 6000);
            //根据窗口宽度生成图片宽度
            var width = $(window).width();
            $(".screenbg ul img").css("width", width + "px");
        });
    </script>

</head>

<body>

    <!-- scripts -->



    <!-- stats.js -->
    <div class="screenbg">
        <div id="particles-js"></div>

        <script src="js/particles.min.js"></script>
        <script src="js/lib/app.js"></script>
        <ul>
            <li><a href="javascript:;">
                <img src="images/bj1.jpg" /></a></li>
            <li><a href="javascript:;">
                <img src="images/bj2.jpg" /></a></li>
            <li><a href="javascript:;">
                <img src="images/bj3.jpg" /></a></li>
        </ul>
    </div>
    <div class="login-box">

        <h1>山东商务职业学院考勤系统</h1>

        <form id="form1" runat="server">
            <div class="name">
                <label>账  号：</label>
                <asp:TextBox ID="userName" runat="server" AutoCompleteType="Office" CssClass="input"></asp:TextBox>
            </div>
            <div class="password">
                <label>密  码：</label>
                <asp:TextBox runat="server" MaxLength="16" ID="password" CssClass="input" TextMode="Password"></asp:TextBox>
            </div>
            <div class="code">
                <div id="slider">
                    <div id="slider_bg"></div>
                    <span id="label"></span><span id="labelTip">拖动滑块验证</span>
                </div>
            </div>
            <div class="login">
                <asp:Button ID="Button1" OnClientClick="return checking()" runat="server" Text="登录" CssClass="button" OnClick="Button1_Click" ClientIDMode="Inherit" />
            </div>
        </form>
    </div>

    <div class="bottom">
        ©2016 Leting 关于IC
        P软一03组ChenFengJY<img width="13" height="16" src="images/copy_rignt_24.png" />
    </div>


</body>


</html>
