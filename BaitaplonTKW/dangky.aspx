<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="dangky.aspx.cs" Inherits="BaitaplonTKW.dangky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:RequiredFieldValidator ID="re1" ControlToValidate="txtuser" runat="server" ErrorMessage="Tên đăng nhập không được để trống"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="re2" ControlToValidate="txtPass" runat="server" ErrorMessage="Mật khẩu không được để trống"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="re3" ControlToValidate="txtrePass" runat="server" ErrorMessage="Vui lòng nhập lại mật khẩu"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="re4" ControlToValidate="txtemail" runat="server" ErrorMessage="Email không được để trống"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="com" runat="server" ControlToCompare="txtPass" Operator="Equal" ControlToValidate="txtrePass" ErrorMessage="Xác nhận mật khẩu không khớp" ForeColor="Red"></asp:CompareValidator>
    <table class="auto-style1" style="margin: auto; padding: auto">
            <tr><td colspan="2"><h2>Đăng ký thành viên:</h2></td></tr>
     <tr><td>Tên đăng nhập(*):</td>
        <td><asp:TextBox ID="txtuser" runat="server"></asp:TextBox></td>
    </tr>
            <tr><td>Mật khẩu(*):</td>
        <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr><td>Nhập lại mật khẩu(*):</td>
        <td><asp:TextBox ID="txtrePass" runat="server"></asp:TextBox></td>
    </tr>
            <tr><td>Email(*):</td>
        <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
    </tr>
            <tr><td>Ngày sinh:</td>
       <td><input type="date" name="birthday" id="ngaysinh"></td>
    </tr>
          
            <tr class="dn"><td>Giới tính:</td>
        <td><asp:RadioButton ID="rdbmale" runat="server" Text="Nam" GroupName="gender"/><br />
                 <asp:RadioButton ID="rdbfemale" runat="server" Text="Nữ" GroupName="gender" /></td>
    </tr>
            
    <tr><td><asp:Button ID="btnsubmit" Text="Gửi" runat="server" OnClick="btnsubmit_Click"/></td></tr>
            
        </table>
</asp:Content>
