<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidences.aspx.cs" Inherits="Selectcomp.WEB.User.Incidences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%: ResolveUrl("~/Content/DataTables/css/jquery.dataTables.css") %>" rel="stylesheet" />
    <script src=<%: ResolveUrl("~/Scripts/DataTables/jquery.dataTables.js") %>></script>
    
    <Script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_GridView1").DataTable(
                {
                    "oLanguage": { "sUrl": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Spanish.json" },
                    "columnDefs": [
                        {
                            "render": function (data, type, row) {
                                return "<a href='IncidenceDetails?IncidenceId=" + data + "'>" + data + "</a>";
                            },
                            "targets":0
                        },
                        { "title": "Tipo", "targets": 1 },
                        { "title": "Estado", "targets": 2 },
                        { "title": "Asunto de la incidencia", "targets": 3 },


                    ]
                });

        });
    </Script>







    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SelectMethod="GridView1_GetData" DataKeyNames="IncidenceId">
            <Columns>
                <asp:BoundField DataField="IncidenceId" HeaderText="IncidenceId" InsertVisible="False" ReadOnly="True" SortExpression="IncidenceId" />
                <asp:BoundField DataField="IncidenceType" HeaderText="IncidenceType" SortExpression="IncidenceType" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="IncidenceTitle" HeaderText="IncidenceTitle" SortExpression="IncidenceTitle" />
            </Columns>
            
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [IncidenceId], [IncidenceType], [Status], [IncidenceTitle] FROM [Incidences] WHERE ([User_Id] = @User_Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblUserId" DefaultValue="null" Name="User_Id" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblUserId" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="btnCreateIncidence" runat="server" OnClick="btnCreateIncidence_Click" Text="Crear incidencia" Width="167px" Height="52px" />
    </p>
    <asp:Panel ID="pnlCreateIncidence" runat="server" Visible="False">
        Crear una nueva incidencia:<br />
        <br />
        Nombre de la incidencia:
        <asp:TextBox ID="tbIncidenceName" runat="server" Width="251px"></asp:TextBox>
        <br />
        <br />
        Tipo de incidencia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlIncidenceType" runat="server" Height="30px" Width="200px">
        </asp:DropDownList>
        <br />
        <br />
        Texto de la incidencia:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbIncidenceText" runat="server" Height="164px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSaveNewIncidence" runat="server" Height="29px" OnClick="btnSaveNewIncidence_Click" Text="Guardar incidencia" />
        &nbsp;<asp:Label ID="lblResult" runat="server"></asp:Label>
        <br />
    </asp:Panel>







</asp:Content>
