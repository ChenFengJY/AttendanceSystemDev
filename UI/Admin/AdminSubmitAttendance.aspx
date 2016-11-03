<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSubmitAttendance.aspx.cs" Inherits="Admin_AdminSubmitAttendance" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .backToContent{
            width:auto;
            height:100%;
            background:url(https://img1.doubanio.com/view/photo/large/public/p2178029027.jpg) left bottom;
            background-size:cover;
        }
        .height{
            height:30px;
        }
        .main{
            width:90%;
            height:90%;
            margin:0 auto;
            box-shadow:0 0 2px 1px #f0f0f0;
            background-color:rgba(232,232,232,0.5);
        }
        .thisweek{
            width:100%;
            height:auto;
            padding:2%;
        }
        .thisweek h2{
            color:brown;
        }
        .weekInfo{
            width:96%;
            height:200px;
        }
    </style>

    <div class="backToContent">
        <div class="height"></div>
        <div class="main">
            <div class="thisweek">
                <h2>本周考勤情况</h2>
                <div class="weekInfo">
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

