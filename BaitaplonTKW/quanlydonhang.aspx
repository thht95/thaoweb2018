<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site3.Master" AutoEventWireup="true" CodeBehind="quanlydonhang.aspx.cs" Inherits="BaitaplonTKW.quanlydonhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="auto-style1" style="margin: auto; padding:  auto">
         <tr><td>Mã đơn hàng:</td>
            <td>
                <asp:Label ID="lblma" runat="server"></asp:Label></td>
        </tr>
        <tr><td>Trạng thái:</td>
           <td> <asp:RadioButtonList ID="rbl_trangthai" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CausesValidation="true">
                            <asp:ListItem Value="Da gui">Chờ duyệt</asp:ListItem>
                            <asp:ListItem Value="Dang van chuyen">Đang vận chuyển</asp:ListItem>
                        </asp:RadioButtonList></td>
        </tr>
        <tr>
           <td> <asp:Button ID="btngui" runat="server" Text="Duyệt" OnClick="btngui_Click" /></td></tr>
    </table>
    <h2>Danh sách đơn hàng</h2>
    <asp:GridView ID="grvdonhang" runat="server" AutoGenerateColumns="False" OnRowEditing="grvdonhang_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Mã đơn hàng">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("madonhang") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblma" runat="server" Text='<%# Bind("madonhang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tennguoinhan" HeaderText="Người nhận" />
            <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
            <asp:BoundField DataField="tinhtrang" HeaderText="Trạng thái" />
            <asp:BoundField DataField="ngaylap" HeaderText="Ngày lập" />
            <asp:CommandField EditText="Chọn" ShowEditButton="True" />
        </Columns>
          </asp:GridView>
</asp:Content>
