<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlysanpham.aspx.cs" Inherits="BaitaplonTKW.quanlysanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="auto-style1" style="margin: auto; padding:  auto">
        <tr><td>Mã sản phẩm:</td>
            <td>
                <asp:Label ID="lblmasanpham" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Tên sản phẩm:</td>
            <td>
                <asp:TextBox ID="txttensp" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Số lượng:</td>
            <td>
                <asp:TextBox ID="txtsoluong" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Đơn giá:</td>
            <td>
                <asp:TextBox ID="txtdongia" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Trạng thái:</td>
            <td>
                <asp:RadioButtonList ID="rbl_trangthai" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CausesValidation="true">
                            <asp:ListItem Value="False">Hết hàng</asp:ListItem>
                            <asp:ListItem Value="True">Còn hàng</asp:ListItem>
                        </asp:RadioButtonList>
            </td>
        </tr>
       
        <tr><td>Lọai hàng:</td>
            <td>
                <asp:DropDownList ID="ddlloaihang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlloaihang_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr><td>Hãng sản xuất:</td>
            <td>
                <asp:DropDownList ID="ddlhang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlhang_SelectedIndexChanged" ></asp:DropDownList></td>
        </tr>
         <tr><td>Hình ảnh:</td>
            <td>
                <asp:FileUpload ID="hinhanh" runat="server" /></td>
        </tr>
         </table>
    <table class="auto-style1" style="margin: auto; padding:  auto">
        <tr> <td><asp:Button ID="btnthem" runat="server" Text="Thêm sản phẩm" OnClick="btnthem_Click" /></td>
            <td><asp:Button ID="btncapnhap" runat="server" Text="Cập nhập" OnClick="btncapnhap_Click" /></td>
            <td><asp:Button ID="btnxoa" runat="server" Text="Xóa" OnClick="btnxoa_Click" /></td>
           
        </tr>
        <tr><td><asp:Label ID="lblmess" runat="server" ForeColor="Red"></asp:Label></td></tr>
   </table>
    <h2>Danh sách sản phẩm</h2>

    <asp:GridView ID="grvsanpham" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="681px" OnRowEditing="grvsanpham_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Mã sản phẩm" SortExpression="masanpham">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("masanpham") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblma" runat="server" Text='<%# Bind("masanpham") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tensanpham" HeaderText="Tên sản phẩm" SortExpression="tensanpham" />
            
            <asp:BoundField DataField="tenhang" HeaderText="Hãng sản xuất" SortExpression="tenhang" />
            <asp:TemplateField HeaderText="Đơn giá" SortExpression="dongia">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("dongia") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("dongia","{0:0,0}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="soluong" HeaderText="Số lượng" SortExpression="soluong" />
             <asp:BoundField DataField="trangthai" HeaderText="Trạng thái" SortExpression="trangthai" />
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
