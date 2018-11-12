<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Giohang.aspx.cs" Inherits="BaitaplonTKW.Giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table><tr>
      <td>Tên sản phẩm:</td>
      <td>
          <asp:Label ID="lblten" runat="server" ></asp:Label></td>
         </tr>
      <tr>
          <td>Số lượng:</td>
          <td>
              <asp:TextBox ID="txtsoluong" runat="server"></asp:TextBox></td>
      </tr>
      <tr><td>
          <asp:Button ID="btncapnhap" runat="server" Text="Cập nhập" OnClick="btncapnhap_Click" /></td></tr>
  </table>
  
    <h2>Giỏ hàng của bạn</h2>
    <asp:GridView ID="grvgiohang" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="grvgiohang_RowDeleting" OnRowEditing="grvgiohang_RowEditing" style="margin-right: 37px" Width="651px">
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
            <asp:BoundField DataField="Thành tiền" HeaderText="Thành tiền" />
             <asp:CommandField EditText="Chỉnh sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True"  />
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
    <table style="width: 387px" ><tr><td>
    <asp:Button ID="btndathang" runat="server" Text="Đặt mua" OnClick="btndathang_Click" /> </td>   
        <td><asp:Button ID="btnmuatiep" runat="server" Text="Mua tiếp" OnClick="btnmuatiep_Click" /></td>
        <td><asp:Button ID="btnxoa" runat="server" Text="Xóa giỏ hàng" OnClick="btnxoa_Click" /></td></tr></table>
</asp:Content>
