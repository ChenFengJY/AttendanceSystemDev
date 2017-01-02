<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DepartmentEachCompare.aspx.cs" Inherits="Admin_DepartmentEachCompare" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #main{
            margin-bottom:50px;
            width:100%;
            height:auto;
            background:white;
        }
        #each_Header{
            width:600px;
            height:50px;
            margin:10px auto;
            padding-top:20px;
            text-align:center;
            font-size:14px;
            line-height:100%;
        }
        .drop_list1{
            width:250px;
            font-size:14px;
        }
        #gredtable{
            margin:0 auto;
            max-width:800px;
        }
        #charts{
            margin:10px auto;
            max-width:800px;
        }
        #chart td{
            width:100%;
            height:350px;
            text-align:center;
        }
        
    </style>
    <script src="../js/lib/Chart-1.0.1-beta.4.js"></script>
    <script>
        var buttomTag = <%=getButtomTag%>;//数组:图表底字段,cs方法执行完执行js方法
        var className = <%=getClassName%>;//数组：分列的名称
        var dataName1 = <%=getDataName1%>;//数组：第一列的数据
        var dataName2 = <%=getDataName2%>;//数组：第二列的数据
        
        var data = {
            labels: buttomTag,
            datasets: [
                {
                    barItemName: className[0],
                    fillColor: "rgba(220,220,220,0.5)",
                    strokeColor: "rgba(220,220,220,1)",
                    data: dataName1
                },
                {
                    barItemName: className[1],
                    fillColor: "rgba(151,187,205,0.5)",
                    strokeColor: "rgba(151,187,205,1)",
                    data: dataName2
                }
            ]
        };
        //更改chart样式
        var defaults={
            // 是否执行动画
            animation : true,
            // 刻度是否显示标签, 即Y轴上是否显示文字
            scaleShowLabels : true,
            // Y轴上的刻度,即文字
            
            axisLabel:{formatter:'{value}%'},
            // 字体
            scaleFontFamily : "'Arial'",
            // 文字大小
            scaleFontSize : 12,
            
        };
        var chartBar = null;
        window.onload = function () {
            var ctx = document.getElementById("myChart").getContext("2d");
            chartBar = new Chart(ctx).Bar(data,defaults);
        }
    </script>
    <div id="main">
        <div id="each_Header">
            <!--从开学至今各系汇总的考勤信息-->
            查询条件：
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drop_list1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>开学至今</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="gredtable">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
             Font-Size="12px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" RowStyle-Height="15px" CellPadding="3"
             OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="系部" DataField="Department" ItemStyle-Width="90px" >
<ItemStyle Width="90px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="在校生人数" DataField="Number" ItemStyle-Width="70px" >
<ItemStyle Width="70px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="旷课人数" DataField="Attendance" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="旷课率" DataField="AttendanceRate" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="迟到人数" DataField="Late" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="迟到率" DataField="LateRate" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="早退人数" DataField="Early" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="早退率" DataField="EarlyRate" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="请假人数" DataField="Leave" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="请假率" DataField="LeaveRate" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="缺勤总数" DataField="Sum" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="总缺勤率" DataField="SumRate" ItemStyle-Width="60px" >
<ItemStyle Width="60px"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <RowStyle ForeColor="#000066" />
            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <PagerStyle BackColor="#669999" Font-Bold="true" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White" />
        </asp:GridView>
        </div>
        <div id="charts">
            <canvas id="myChart" width="800" height="400"></canvas>
        </div>
        <%--<table id="chart">
            <tr>
                <td style="width: 100%; height: 350px">
                   <asp:PlaceHolder ID="phDepartmentEachCompare" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                     <asp:PlaceHolder ID="phAttendance" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phLeave" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phLate" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 350px">
                    <asp:PlaceHolder ID="phEarly" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>--%>
    </div>
</asp:Content>


