<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartDetails.aspx.cs" Inherits="Selectcomp.WEB.User.CartDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="../Content/DataTables/css/jquery.dataTables.css" rel="stylesheet" />
    <script src=<%: ResolveUrl("~/Scripts/DataTables/jquery.dataTables.js") %>></script>

    <Script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_GridView1").DataTable({
                "oLanguage": { "sUrl": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Spanish.json" },

                "columnDefs": [
                       {
                           "render": function (data, type, row) {
                               return "<a href='CartDetails?OrderLineId=" + data + "'>" + data + "</a>";
                           },
                           "targets": 
                               0
                       },
                        { "title": "Producto", "targets": 1 },
                        { "title": "Precio unitario", "targets": 2 },
                       
                       ]
            })
     
        });        </script>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("¿Quieres borrar este carrito?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>


    <%--<asp:GridView ID="GridView1" runat="server" SelectMethod="GetData">
    </asp:GridView>--%>

     <br />
     <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" style="text-align: center" CssClass="titleLabel"></asp:Label>
     <br />
     <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="OrderLineId">
        <Columns>
            <asp:BoundField DataField="OrderLineId" HeaderText="Identificador" SortExpression="OrderLineId" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="OrderLineName" HeaderText="OrderLineName" SortExpression="OrderLineName" />
            <asp:BoundField DataField="OrderLineProductPrice" HeaderText="OrderLineProductPrice" SortExpression="OrderLineProductPrice" />
            <asp:BoundField DataField="units" HeaderText="Unidades" SortExpression="units" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        DeleteCommand="DELETE FROM [OrderLines] WHERE ([OrderLineId] = @OrderLineId)" 
        SelectCommand="SELECT [units], [ProductId], [OrderLineProductPrice], [OrderLineName], [OrderLineId], [OrderId] FROM [OrderLines] WHERE ([OrderId] = @OrderId)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="OrderId" QueryStringField="OrderId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:Label ID="lblNull" runat="server" Text=""></asp:Label>







     <br />







     El precio total es de







     <asp:Label ID="lblTotalPrice" runat="server" Font-Size="Large" style="font-weight: 700"></asp:Label>
     &nbsp;€.<br />
     <asp:ImageButton ID="imgbtnPurchase" runat="server" Height="80px" ImageAlign="Middle" cssClass="titleLabel" ImageUrl="~/Images/btnComprar.png" OnClick="imgbtnPurchase_Click" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="btnRemoveCart" runat="server" OnClick="btnRemoveCart_Click" Text="Eliminar carrito" OnClientClick = "Confirm()" />
     <br />







     <br />
     <asp:Panel ID="pnlPurchase" runat="server" Visible="False" BorderStyle="Outset" BackImageUrl="~/Images/pnlPurchaseBackgroundLight.png">
         <p style="margin-left: 40px">
             &nbsp;&nbsp;
         </p>
         <p style="margin-left: 40px">
             Rellene los siguientes campos obligatorios para proceder con la compra del carrito:<br style="margin-left: 120px" />
             <br />
             &nbsp;
             <asp:Label ID="lblPurchaseName" runat="server" style="font-weight: 700" Text="Nombre: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseName" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseSurname" runat="server" style="font-weight: 700" Text="Apellidos: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseSurname" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;&nbsp;<asp:Label ID="lblPurchaseCountry" runat="server" style="font-weight: 700" Text="País: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseCountry" runat="server" Width="350px"></asp:TextBox>
             &nbsp;<br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseCity" runat="server" style="font-weight: 700" Text="Ciudad: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseCity" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseAddress" runat="server" style="font-weight: 700" Text="Dirección: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseAddress" runat="server" Width="750px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchasePostalCode" runat="server" style="font-weight: 700">Código postal: </asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchasePostalCode" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseTlf1" runat="server" style="font-weight: 700" Text="Teléfono 1: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseTlf1" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseTlf2" runat="server" style="font-weight: 700" Text="Teléfono 2: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:TextBox ID="tbPurchaseTlf2" runat="server" Width="350px"></asp:TextBox>
             <br style="margin-left: 40px" />
             <br style="margin-left: 40px" />
             &nbsp;
             <asp:Label ID="lblPurchaseCreditCard" runat="server" style="font-weight: 700" Text="Nº Tarjeta de crédito: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseCreditCard" runat="server" Width="350px"></asp:TextBox>
             <br />
             <br />
             &nbsp;
             <asp:Label ID="lblPurchaseEmail" runat="server" style="font-weight: 700" Text="Email: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="tbPurchaseEmail" runat="server" Width="350px"></asp:TextBox>
         </p>
         <p style="margin-left: 40px">
             &nbsp;</p>
         <p style="margin-left: 40px">
             <asp:Button ID="btnCompletePurchase" runat="server" Height="33px" OnClick="btnCompletePurchase_Click" Text="Finalizar compra" />
             &nbsp;&nbsp;
             <asp:Label ID="lblInfoPurchase" runat="server"></asp:Label>
             <br />
         </p>
     </asp:Panel>
     <br />
     <br />







</asp:Content>
