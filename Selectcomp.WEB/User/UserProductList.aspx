<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProductList.aspx.cs" Inherits="Selectcomp.WEB.User.PruebasLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Inicio del ListView --%>
    <asp:ListView ID="lvProducts" runat="server" SelectMethod="lvProducts_GetData" GroupItemCount="4" ItemType="Selectcomp.CORE.Product">
        
        <%-- Layout template--%>
        <LayoutTemplate>
            <h2>Productos</h2>
             <table>
                 <%-- Solución al error del GroupPlaceholder --%>
            <asp:PlaceHolder runat="server" ID="GroupPlaceholder"></asp:PlaceHolder>
        </table>
        </LayoutTemplate>

        <%-- Empty template --%>
        <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No se ha devuelto ningún dato.</td>
                        </tr>
                    </table>
        </EmptyDataTemplate>

        <%-- Group template --%>
        <GroupTemplate>

                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
            
               </GroupTemplate>

        <%-- Item template --%>
       <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="UserProductDetails.aspx?productID=<%#:Item.Id%>">
                                        <img src="../Images/Products/<%#:Item.Image%>"
                                            width="200" height="150" style="border: solid" /></a>
                                </td>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Item.Id%>">
                                        <span>
                                            <%#:Item.Name%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Precio: </b><%#:String.Format("{0:c}", Item.Price)%>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                               <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
                                
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>

     </asp:ListView>
    <%-- Fin del ListView --%>

</asp:Content>
