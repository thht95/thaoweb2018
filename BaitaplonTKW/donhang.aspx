<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="donhang.aspx.cs" Inherits="BaitaplonTKW.donhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Đơn hàng của bạn</h2>
    <asp:GridView ID="grvdonhang" runat="server" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField HeaderText="Mã sản phẩm">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Mã sản phẩm]") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblma" runat="server" Text='<%# Bind("[Mã sản phẩm]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="Tên sản phẩm" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="Tên hãng" HeaderText="Tên hãng" />
            <asp:BoundField DataField="Số lượng" HeaderText="Số lượng" />
            <asp:BoundField DataField="Đơn giá" HeaderText="Đơn giá" />
            <asp:BoundField DataField="Thành tiền" HeaderText="Thành tiền" DataFormatString="{0:0,0}" />
            
        </Columns>
      

        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />

    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Tổng tiền:  "></asp:Label><asp:Label ID="lbltong" runat="server" ></asp:Label>
    <table>
        <tr><td></td></tr>
         <tr><td></td></tr>
        <tr><td class="auto-style1" style="width: 632px"><h2>THÔNG TIN NGƯỜI NHẬN</h2></td></tr>
        <tr>
            <td class="auto-style1" style="width: 632px">Họ tên:</td>
            <td class="auto-style1" style="width: 479px">
                <asp:TextBox ID="txtten" runat="server" Width="284px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 632px">Địa chỉ:</td>
            <td class="auto-style1" style="width: 479px">
                <asp:TextBox ID="txtdiachi" runat="server" Width="282px"></asp:TextBox></td>
        </tr> 
        <tr>
            <td class="auto-style1" style="width: 632px">Số điện thoại:</td>
            <td class="auto-style1" style="width: 479px">
                <asp:TextBox ID="txtsdt" runat="server" Width="284px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 632px">Hình thức thanh toán:</td>
            <td class="auto-style1" style="width: 479px">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Chuyển khoản</asp:ListItem>
                    <asp:ListItem>Thanh toán khi nhận hàng</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btndathang" runat="server" Text="Đặt hàng" OnClick="btndathang_Click" />
            </td>
            <td>
                <asp:Button ID="btnquaylai" runat="server" Text="Quay lại giỏ hàng" OnClick="btnquaylai_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
