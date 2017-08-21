<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Selectcomp.WEB.User.Cart" %>
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
                               return "<a href='CartDetails?OrderId=" + data + "'>" + data + "</a>";
                           },
                           "targets": 
                               0
                       },
                        { "title": "Nombre", "targets": 1 },
                        { "title": "Fecha de creación", "targets": 2 },
                       
                       ]
            })
     
        });        </script>


               
    <h1><b>Carritos de <%: Context.User.Identity.GetUserName()  %> </b></h1>

    <asp:Label ID="lblWarnings" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblWarnings2" runat="server"></asp:Label>


               
            

    <br />
    <asp:GridView ID="GridView1" runat="server" SelectMethod="GetData">
    </asp:GridView>
    <br />
    <asp:Button ID="btnOpenPanel" runat="server" OnClick="btnOpenPanel_Click" Text="Crear Carrito" />
    <br />
<br />
    <br />
    <asp:Panel ID="pnlCreateCart" runat="server" Height="67px" Visible="false" BackColor="#0099FF" BorderStyle="Solid">
        <asp:TextBox ID="tbNombreCarrito" runat="server" MaxLength="50" Width="282px"></asp:TextBox>
        <br />
        <asp:Button ID="btnCreateCart" runat="server" Text="Guardar carrito" OnClick="btnCreateCart_Click" />
        &nbsp;&nbsp;
        <asp:Label ID="lblCreateCart" runat="server"></asp:Label>


    </asp:Panel>
    <br />

</asp:Content>

