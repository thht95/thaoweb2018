<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Site1.Master" AutoEventWireup="true" CodeBehind="Chitietsanpham.aspx.cs" Inherits="BaitaplonTKW.Chitietsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2 class="auto-style1" style="color:red;font-style:normal"><i><asp:Label ID="lb" runat="server"></asp:Label></i></h2>
  <h2><asp:Label ID="Label5" runat="server" Text="Chi tiết sản phẩm"></asp:Label></h2>
     
           
           <table><tr><td><asp:Image ID="tenanh" runat="server" ImageUrl='<%#Eval("tenanh") %>' Height="200px" Width="200px"/></td>
                         
                            <td><asp:Label ID="tsp" runat="server" Text="Tên sản phẩm:" Width="150px" ></asp:Label><br />
                                <asp:Label ID="Label4" runat="server" Text="Hãng:" Width="150px" ></asp:Label><br />
                                <asp:Label ID="Label8" runat="server" Text="Đơn giá:" Width="150px" ></asp:Label><br />
                                <asp:Label Text="Trạng thái:" runat="server" ID="lbltt"></asp:Label><br />
                                <asp:Label ID="Label1" runat="server" Text="Số lượng:" Width="150px" ></asp:Label><br />

                            </td>
                                   <td><asp:Label ID="sanpham" runat="server" Text='<%#Eval("tensanpham") %>'></asp:Label><br />
                                       <asp:Label ID="tenhang" runat="server" Text='<%#Eval("tenhang") %>'></asp:Label><br />
                                        <asp:Label ID="dongia" runat="server" Text='<%#Eval("dongia") %>'></asp:Label><asp:Label ID="Label3" runat="server" Text="VND"></asp:Label><br />
                                        <asp:Label ID="trangthai" runat="server" Text='<%#Eval("trangthai") %>'></asp:Label><br />
                                       <asp:TextBox runat="server" ID="txtSoluong"></asp:TextBox>
                                        <asp:DropDownList ID="ddlsoluong" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
                             </td></tr>
                         <tr><td></td><td><asp:Button ID="btnthem" runat="server" Text="Thêm vào giỏ" OnClick="btnthem_Click"/></td>
                             <td><asp:Button ID="btnmuangay" runat="server" Text="Mua ngay" OnClick="btnmuangay_Click"/>
                             </td></tr>
                        </table>
   <table>
        <tr>
            <td colspan="5"><h2><asp:Label ID="Label6" runat="server" Text="Sản phẩm liên quan"></asp:Label></h2></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server"  Width="127px" Height="58px" RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                       <td>
                       <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("tenanh") %>' Height="180px" Width="180px"/>
                       <br />
                       <b>   <%#Eval("tensanpham") %></b> 
                           <br/>
                       <asp:Label ID="Label2" runat="server" Text='<%#Eval("dongia", "{0:0,0}") %>'></asp:Label>
                      
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
