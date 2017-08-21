<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminIncidences.aspx.cs" Inherits="Selectcomp.WEB.Admin.AdminIncidences" %>
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
                                return "<a href='../User/IncidenceDetails?IncidenceId=" + data + "'>" + data + "</a>";
                            },
                            "targets":0
                        },
                    ]
                });

        });
    </Script>




    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IncidenceId" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="IncidenceId" HeaderText="IncidenceId" InsertVisible="False" ReadOnly="True" SortExpression="IncidenceId" />
            <asp:BoundField DataField="IncidenceType" HeaderText="IncidenceType" SortExpression="IncidenceType" />
            <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="IncidenceTitle" HeaderText="IncidenceTitle" SortExpression="IncidenceTitle" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [IncidenceId], [IncidenceType], [Priority], [Status], [IncidenceTitle] FROM [Incidences]"></asp:SqlDataSource>






</asp:Content>
