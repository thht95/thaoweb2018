<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Trangchu.aspx.cs" Inherits="BaitaplonTKW.Trangchu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Untitled.png"  Width="740px" Height="300px"/>
    <h3><asp:Label ID="lb1" runat="server" Text="TIN TỨC NỔI BẬT"></asp:Label></h3>
    <table>
       <tr><td> <asp:DataList ID="dtl" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                       <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("hinhanh") %>' Height="200px" Width="240px"/>
                       <br/><asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("tieude") %> '
                           NavigateUrl='<%# "Chitiettintuc.aspx?x="+Eval("mabantin") %>'
                           >HyperLink</asp:HyperLink>
                       <br/><asp:Label ID="Label2" runat="server" Text='<%#Eval("ndtomtat") %>'></asp:Label></td>
                    </ItemTemplate>
                </asp:DataList></td></tr>
        </table>
</asp:Content>
