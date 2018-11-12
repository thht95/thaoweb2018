<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Timkiemsanpham.aspx.cs" Inherits="BaitaplonTKW.Timkiemsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <table>
  <tr>
            <td colspan="5"><h2>Kết quả tìm kiếm</h2></td>
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
                       <asp:Label ID="Label2" runat="server" Text='<%#Eval("dongia") %>'></asp:Label>
                      
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
