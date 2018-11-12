<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlyhang.aspx.cs" Inherits="BaitaplonTKW.quanlyloaihang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" style="margin: auto; width: 450px;">
        <tr><td>Mã hãng sản xuất</td>
            <td>
                <asp:label ID="lblmahang" runat="server"></asp:label></td>
        </tr>
        <tr><td>Tên hãng sản xuất</td>
            <td>
                <asp:TextBox ID="txttenhang" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Loại hàng</td>
            <td>
                <asp:DropDownList ID="ddlloaihang" runat="server"></asp:DropDownList>
                
            </td>
            <td><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/quanlyloaihang.aspx" Text="Thêm loại hàng mới"></asp:HyperLink></td>
        </tr>
        <tr><td>
            
            <asp:Button ID="Button2" runat="server" Text="Thêm" /></td>
            <td><asp:Button ID="Button1" runat="server" Text="Cập nhập" /></td>
            <td>
            <asp:Button ID="btnxoa" runat="server" Text="Xóa" /></td>
        </tr>
        <tr><td><asp:Label ID="lblmess" runat="server" ForeColor="Red"></asp:Label></td></tr>
    </table>


    <h2>Danh sách Hãng sản xuất</h2>

    <asp:GridView ID="grvhang" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="681px" OnRowEditing="grvhang_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Mã hãng" SortExpression="mahang">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mahang") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblmahang" runat="server" Text='<%# Bind("mahang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tenhang" HeaderText="Hãng sản xuất" SortExpression="tenhang" />
             <asp:BoundField DataField="tenloaihang" HeaderText="Loại hàng" SortExpression="tenloaihang" />
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
