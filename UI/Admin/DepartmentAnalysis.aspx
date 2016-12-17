<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentAnalysis.aspx.cs" Inherits="Admin_DepartmentAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    </div>
        
       
       
       
       
       
        <asp:GridView ID="gvXX" runat="server" Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
                <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
          </asp:GridView>
        <asp:PlaceHolder ID="phXX" runat="server" ></asp:PlaceHolder>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="12px">
            <td style="width:24%" align="center" valign="middle">
                        <asp:Button ID="btnXX" runat="server" Text="信息系分析表" OnClick="btnXX_Click"  CssClass="btn"   Font-Size="12px"/>

                </td>
            </asp:Label>
        
        

        <asp:GridView ID="gvKJ" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan"
             BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowDataBound="gvKJ_RowDataBound" Font-Size="12px"  >
            <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
         <asp:PlaceHolder ID="phKJ" runat="server" ></asp:PlaceHolder>
        <asp:Label ID="lblKJ" runat="server" ForeColor="Red" Font-Size="12px">
            <td style="width:24%" align="center" valign="middle">
                       <asp:Button ID="btnKJ" runat="server" Text="会计系图表分析" CssClass="btn" OnClick="btnKJClick" Font-Size="12px" />

            </td>
        </asp:Label>
        
       
        <asp:GridView ID="gvJG" runat="server"  Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
             <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />

        </asp:GridView>
                <asp:PlaceHolder ID="phJG" runat="server"></asp:PlaceHolder>
          <asp:Label ID="lblJG" runat="server" ForeColor="Red" Font-Size="12px">
            <td style="width:24%" align="center" valign="middle">
                 <asp:Button ID="btnJG" runat="server" Text="经管系分析表" OnClick="btnXX_Click"  CssClass="btn"   Font-Size="12px" />
                </td>
            </asp:Label>

       
    
        <asp:GridView ID="gvSP" runat="server"  Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
             <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:PlaceHolder ID="pgSP" runat="server"></asp:PlaceHolder>
          <asp:Label ID="lblSP" runat="server" ForeColor="Red" Font-Size="12px">
            <td style="width:24%" align="center" valign="middle">
                 <asp:Button ID="btnSP" runat="server" Text="食品系分析表" OnClick="btnXX_Click"  CssClass="btn"   Font-Size="12px" />
                </td>
            </asp:Label>
        
              

    
        <asp:GridView ID="gvJX" runat="server" Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
             <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
         <asp:PlaceHolder ID="phJX" runat="server"></asp:PlaceHolder>
          <asp:Label ID="lblJX" runat="server" ForeColor="Red" Font-Size="12px">      
              <td style="width:24%" align="center" valign="middle">
                 <asp:Button ID="btnJX" runat="server" Text="" />
                </td>
              </asp:Label>


        <asp:GridView ID="gvWY" runat="server" Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
          <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
             <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
         <asp:PlaceHolder ID="phWY" runat="server"></asp:PlaceHolder>
        <asp:Label ID="lblWY" runat="server" ForeColor="Red" Font-Size="12px">      
              <td style="width:24%" align="center" valign="middle">
                 <asp:Button ID="btnWY" runat="server" Text="外语系分析表" />
                </td>
              </asp:Label>

       
        <asp:GridView ID="gvJZ" runat="server" Height="133px" OnSelectedIndexChanged="gvXX_SelectedIndexChanged" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField HeaderText="周次" DataField="周次"   ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="系部" DataField="系部"  ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="迟到人数" DataField="迟到人数"  ItemStyle-Width="60px"/>
                <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="旷课人数" DataField="旷课人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="60px" />
                <asp:BoundField HeaderText="合计" DataField="合计"  ItemStyle-Width="60px"/>
              <asp:TemplateField HeaderText="详情" ItemStyle-Width="60px" >
                  <ItemTemplate>
                      <asp:Button ID="btnDetail" CssClass="btn" runat="server" Text="详情" Font-Size="12px" OnClick="btnDetail_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
            </Columns>
             <FooterStyle  BackColor="Tan"/>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="true" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
              </asp:GridView>
             <asp:PlaceHolder ID="phJZ" runat="server"></asp:PlaceHolder>
             <asp:Label ID="lblJZ" runat="server" ForeColor="Red" Font-Size="12px">      
              <td style="width:24%" align="center" valign="middle">
               <asp:Button ID="btnJZ" runat="server" Text="建筑系分析表" />
                </td>
              </asp:Label>
      
       
    </form>
</body>
</html>
