<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="sanpham.aspx.cs" Inherits="BaitaplonTKW.sanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
  <tr>
            <td colspan="5"><h2>Danh sách sản phẩm</h2></td>
        </tr>
        <tr>
            
            <td></td>
            <td><asp:Label runat="server" ID="lb1" Text="Hãng"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlhang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged"></asp:DropDownList></td>
            
        </tr>
       
            </table>
        
     <table>
        <tr>
            <td>
                <asp:DataList ID="dtl" runat="server"  Width="127px" Height="58px" RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                       <td>
                       <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("tenanh") %>' Height="180px" Width="180px"/>
                       <br />
                       <b>   <%#Eval("tensanpham") %></b> 
                           <br/>
                       <asp:Label ID="Label2" runat="server" Text='<%#Eval("dongia", "{0:0,00}") %>'></asp:Label>
                      
                       <asp:Label ID="Label3" runat="server" Text="VND"></asp:Label>
                           <br />
                           <asp:HyperLink ID="HyperLink1" runat="server" Text="Xem chi tiết" NavigateUrl='<%# "Chitietsanpham.aspx?x="+Eval("masanpham")%>' Font-Underline="true"
                           ></asp:HyperLink>
                          
                           </td>
                    </ItemTemplate>
                </asp:DataList>
             </td></tr>
         </table>
</asp:Content>
