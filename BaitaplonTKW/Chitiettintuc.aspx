<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Chitiettintuc.aspx.cs" Inherits="BaitaplonTKW.Chitiettintuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="auto-style1" style="color:red;font-style:normal"><i><asp:Label ID="lb" runat="server"></asp:Label></i></h2>
    <asp:DataList ID="dtl" runat="server">
         <ItemTemplate>
                        <table>
                            <tr><td><h2><asp:Label ID="Label5" runat="server" Text='<%#Eval("tieude") %>'></asp:Label></h2></td></tr>
                            <tr><td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("hinhanh") %>' Width="680px"/></td>
                       <tr><td><asp:Label ID="Label1" runat="server" Text='<%#Eval("noidung") %>' Width="680px"></asp:Label ></td></tr>
                           

                         
                     </table>
                       
                    </ItemTemplate>
    </asp:DataList>
    <h3><asp:Label ID="Label2" runat="server" Text="Tin tức khác"></asp:Label></h3>
    <asp:DataList ID="DataList1" runat="server">
         <ItemTemplate>
                        <table>
                            <tr><td><asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("tieude") %> '
                           NavigateUrl='<%# "Chitiettintuc.aspx?x="+Eval("mabantin") %>'
                           >HyperLink</asp:HyperLink></td></tr>
                     </table>
                       
                    </ItemTemplate>
    </asp:DataList>
</asp:Content>
