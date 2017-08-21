<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProductDetails.aspx.cs" Inherits="Selectcomp.WEB.Admin.AdminProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:FormView ID="productDetail" runat="server" ItemType="Selectcomp.CORE.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.Name %> - Administrador</h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <a href="ModifyProduct.aspx?productID=<%#:Item.Id%>"><img src="../Images/Products/<%#:Item.Image%>" style="border:solid; height:300px" alt="<%#:Item.Name %>" /></a>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <span><b>Marca:</b>&nbsp;<%#:Item.Brand %><br /><br /><b>Descripción:</b><br /><%#:Item.Description %><br /><br /><span><b>Precio:</b>&nbsp;<%#: String.Format("{0:c}", Item.Price) %></span><br /><br /><span><b>Número de producto: </b>&nbsp;<%#:Item.Id %></span><br /><br /></td>
                </tr>
                
            </table>
        </ItemTemplate>
    </asp:FormView>
     <br />
     <br />
        
    <%-- Final del ListView --%>


     <asp:Button ID="btnDeleteProduct" runat="server" Text="Borrar producto" OnClick="btnDeleteProduct_Click1" />
<%--    <asp:Button ID="btnModify" runat="server" Text="Modificar" href="ModifyProduct.aspx?productID=<%#:Item.Id%>"/>--%>

    &nbsp;<br />
     <br />
     <br />
     <br />

    <asp:Button ID="btnAddToCart" runat="server" Text="Añadir al carrito" OnClick="btnAddToCart_Click" />

     <br /><br />
     

    <asp:Panel ID="pnlCarts" runat="server" ScrollBars="Auto" Width="100%" Height="162px" Visible="false" BackColor="#0099FF" BorderColor="Black" BorderWidth="3px">
        <asp:Label ID="lblAñadir" runat="server" Text="Seleccione el carrito en el que quiere añadir el producto:" Font-Bold="True" Font-Italic="False" Font-Size="Large"></asp:Label>


        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="201px" DataSourceID="SqlDataSource1" DataTextField="OrderName" DataValueField="OrderId">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [OrderName], [OrderId] FROM [Orders] WHERE ([User_Id] = @User_Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblUserID" DefaultValue="0" Name="User_Id" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblUserID" runat="server" ></asp:Label>
        <br />

        <asp:Label ID="lblNumberUnits" Text="Número de unidades:" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="tbNumberUnits" Text="1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbNumberUnits" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <br />
        <br />


    </asp:Panel>
</asp:Content>
