<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="BaitaplonTKW.dannhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <table class="auto-style1" style="margin: auto; padding:  auto">
       
       <tr><td>Tên đăng nhập:</td></tr>
       <tr><td>
           <asp:TextBox ID="txtuser" runat="server"></asp:TextBox></td>
           
       </tr>

       <tr><td>Mật khẩu:</td></tr>
        <tr><td>
           <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox></td>
         </tr>
       <tr><td>Nhập lại mật khẩu:</td></tr>
        <tr><td>
           <asp:TextBox ID="txtrepass" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
       
        
    <tr>  <td> <asp:Button ID="submit" runat="server" Text="Gửi" OnClick="submit_Click"/></td></tr>
   </table>
</asp:Content>
