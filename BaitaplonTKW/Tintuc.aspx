﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Tintuc.aspx.cs" Inherits="BaitaplonTKW.Tintuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <h3><asp:Label ID="lb1" runat="server" Text="TIN TỨC"></asp:Label></h3>
    <table>
       <tr><td> <asp:DataList ID="dtl" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                    <ItemTemplate>
                       <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("hinhanh") %>' Width="680px"/>
                       <br/><asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("tieude") %> '
                           NavigateUrl='<%# "Chitiettintuc.aspx?x="+Eval("mabantin") %>'
                           >HyperLink</asp:HyperLink>
                       <br/><asp:Label ID="Label2" runat="server" Text='<%#Eval("ndtomtat") %>'></asp:Label>
                          </td>
                    </ItemTemplate>
                </asp:DataList></td></tr>
        </table>
</asp:Content>
