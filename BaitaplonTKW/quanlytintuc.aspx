<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlytintuc.aspx.cs" Inherits="BaitaplonTKW.quanlytintuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="auto-style1" style="margin: auto; padding:  auto">
         <tr><td>Mã bản tin:</td>
            <td>
                <asp:Label ID="lblmabantin" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Tiêu đề:</td>
            <td>
                <asp:TextBox ID="txttieude" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Nội dung tóm tắt:</td>
            <td>
                <asp:TextBox ID="txtndtomtat" runat="server" ></asp:TextBox></td>
        </tr>
        <tr><td>Nội dung tin:</td>
            <td>
                <asp:TextBox ID="txtnoidung" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Hình ảnh:</td>
            <td>
                <asp:FileUpload ID="hinhanh" runat="server"/></td>
        </tr>
        
    </table>
    <table class="auto-style1" style="margin: auto; padding:  auto">
        <tr>
            <td><asp:Button ID="btnthem" runat="server" Text="Thêm tin" OnClick="btnthem_Click" /></td>
            <td><asp:Button ID="btncapnhap" runat="server" Text="Cập nhập" OnClick="btncapnhap_Click" /></td>
            <td><asp:Button ID="btnxoa" runat="server" Text="Xóa tin" OnClick="btnxoa_Click" /></td>
        </tr>
    </table>
    <h2>Danh sách tin tức</h2>

    <asp:GridView ID="grvtin" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="681px" OnRowEditing="grvtin_RowEditing">
        <Columns>
             <asp:TemplateField HeaderText="Mã bản tin" SortExpression="tieude">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mabantin") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblmabantin" runat="server" Text='<%# Bind("mabantin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tiêu đề" SortExpression="tieude">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tieude") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("tieude") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nội dung tóm tắt" SortExpression="ndtomtat">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ndtomtat") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ndtomtat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ngày đăng" SortExpression="ngaydang">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ngaydang") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ngaydang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               
                <ItemTemplate>
                    <asp:LinkButton ID="btnchon" runat="server" CommandName="Edit" Text="Chọn"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
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
