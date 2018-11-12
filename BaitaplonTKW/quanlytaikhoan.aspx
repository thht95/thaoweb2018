<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlytaikhoan.aspx.cs" Inherits="BaitaplonTKW.quanlytaikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="auto-style1" style="margin: auto; padding:  auto">
         <tr><td>Mã tài khoản:</td>
            <td>
                <asp:Label ID="lblma" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Tên tài khoản:</td>
            <td>
                <asp:TextBox ID="txtten" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Pass:</td>
            <td>
                <asp:TextBox ID="txtpass" runat="server" ></asp:TextBox></td>
        </tr>
        <tr><td>Email:</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Ngày sinh:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td>Giới tính:</td>
           <td> <asp:RadioButtonList ID="rbl_gioitinh" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CausesValidation="true">
                            <asp:ListItem Value="False">Nam</asp:ListItem>
                            <asp:ListItem Value="True">Nữ</asp:ListItem>
                        </asp:RadioButtonList></td>
        </tr>
        <tr><td>Quyền:</td>
            <td>
               <asp:RadioButtonList ID="rbl_quyen" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CausesValidation="true">
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Thành viên</asp:ListItem>
                        </asp:RadioButtonList></td>
        </tr>
    </table>
    <table class="auto-style1" style="margin: auto; padding:  auto">
        <tr>
            <td><asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" /></td>
            <td><asp:Button ID="btncapnhap" runat="server" Text="Cập nhập" OnClick="btncapnhap_Click" /></td>
            <td><asp:Button ID="btnxoa" runat="server" Text="Xóa" OnClick="btnxoa_Click" /></td>
        </tr>
    </table>
    <h2>Danh sách tài khoản</h2>
    <asp:GridView ID="grvtaikhoan" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowEditing="grvtaikhoan_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Mã tài khoản">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mataikhoan") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblma" runat="server" Text='<%# Bind("mataikhoan") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tentaikhoan" HeaderText="Tên tài khoản" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="pass" HeaderText="Pass" />
            <asp:BoundField DataField="tenquyen" HeaderText="Quyền" />
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
