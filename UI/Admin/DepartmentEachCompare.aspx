<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DeleteAllData.aspx.cs" Inherits="Admin_DeleteAllData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../css/adminStyletoDele.css" rel="stylesheet" type="text/css" />
    <div class="main">
        <fieldset>
            <legend style="width: 93px">数据图表</legend>
            

        </fieldset>
        <table>
            <tr>
                <td style="width:100%;height:350px" align="center">
<asp:PlaceHolder ID="phDepartmentEachCompare" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        <tr>
            <td align="center" style="width:100%;height:350px">
<asp:PlaceHolder ID="phAttendance" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
        
        <tr>
            <td align="center" style="width:100%;height:350px">
  <asp:PlaceHolder ID="phLeave" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
      <tr>
          <td align="center" style="width:100%;height:16px">
<asp:PlaceHolder ID="phLate" runat="server"></asp:PlaceHolder>
          </td>
      </tr>
        <tr>
            <td align="center" style="width:100%;height:350px">
 <asp:PlaceHolder ID="phEarly" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
       
           </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Height="44px">
        
             <Columns>
                <asp:BoundField HeaderText="系部"  DataField="系部" ItemStyle-Width="90px"/>
                <asp:BoundField HeaderText="在校生人数" DataField="在校生人数" ItemStyle-Width="70px" />
                <asp:BoundField HeaderText="旷课人次" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课率"  DataField="旷课率" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="迟到人次" DataField="迟到人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="迟到率"  DataField="迟到率" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人次"  DataField="早退人数" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退率" DataField="早退率" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="请假人数"  DataField="请假人数" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="请假率"  DataField="请假率" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="总缺勤数"  DataField="总缺勤数" ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="总缺勤率"  DataField="总缺勤率" ItemStyle-Width="60px"/>
            </Columns>
            <RowStyle ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            
           <SelectedRowStyle BackColor="#669999" Font-Bold="true" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White" />
        </asp:GridView>
        
    </div>
</asp:Content>