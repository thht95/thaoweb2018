<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlyloaihang.aspx.cs" Inherits="BaitaplonTKW.quanlyhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" style="margin: auto; padding:  auto">
        <tr><td>Mã loại hàng</td>
            <td>
                <asp:Label ID="lblmaloaihang" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Tên loại hàng</td>
            <td>
                <asp:TextBox ID="txttenloaihang" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>
            <asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" /></td>
            <td>
            <asp:Button ID="btncapnhap" runat="server" Text="Cập nhập" OnClick="btncapnhap_Click" /></td>
            <td>
            <asp:Button ID="btnxoa" runat="server" Text="Xóa" OnClick="btnxoa_Click" /></td>
        </tr>
       <tr><td><asp:Label ID="lblmess" runat="server" ForeColor="Red"></asp:Label></td></tr>
    </table>


    <h2>Danh sách Loại hàng</h2>
    <asp:GridView ID="grvloaihang" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="681px" OnRowEditing="grvloaihang_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Mã loại hàng" SortExpression="maloaihang">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("maloaihang") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblmaloaihang" runat="server" Text='<%# Bind("maloaihang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tenloaihang" HeaderText="Tên loại hàng" SortExpression="tenloaihang" />
            <asp:CommandField EditText="Chọn" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
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
    
     
</asp:Content>
