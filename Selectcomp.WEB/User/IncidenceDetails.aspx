<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceDetails.aspx.cs" Inherits="Selectcomp.WEB.User.IncidenceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>&nbsp;Detalles de la incidencia</h1>
    <asp:Panel ID="pnlDetails" runat="server">
        <strong><span style="font-size: 16pt">Asunto de la incidencia:</span></strong>
        <asp:Label ID="lblSubject" runat="server"></asp:Label>
        <br />
        <span style="font-size: 16pt">Fecha de creación:</span>
        <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
        &nbsp; /&nbsp; <span style="font-size: 16pt">Fecha de cierre:</span>
        <asp:Label ID="lblCloseDate" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="pnlAdminDetails" runat="server" BackColor="#CCFFFF" BorderStyle="Inset" Visible="False">
            <span style="font-size: 16pt"><strong>Detalles de administrador<br /> 
            <br />
            </strong><span>Estado:
            <asp:Label ID="lblAdminStatus" runat="server"></asp:Label>
            &nbsp;&nbsp; Prioridad:
            <asp:Label ID="lblAdminPriority" runat="server"></asp:Label>
            <br />
            </span></span><span style="font-size: 13pt"><strong>Estado de la incidencia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></span><span style="font-size: 16pt">
            <asp:DropDownList ID="ddlStatus" runat="server" style="font-size: 13pt" Width="153px">
            </asp:DropDownList>
            <br />
            </span><span style="font-size: 13pt"><strong>Prioridad de la incidencia:&nbsp;&nbsp; </strong></span>&nbsp;<asp:DropDownList ID="ddlIncidencePriority" runat="server" Height="19px" Width="152px">
            </asp:DropDownList>
            <br />
            <span style="font-size: 13pt"><strong>Nota interna del Administrador:</strong></span><br />
            <asp:TextBox ID="tbInternalNote" runat="server" Height="164px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSaveAdminDetails" runat="server" OnClick="btnSaveAdminDetails_Click" Text="Guardar" />
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlMessages" runat="server">
        </asp:Panel>
        <br />
        Nuevo mensaje:
        <asp:TextBox ID="tbNewMessage" runat="server" Height="164px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSaveNewMessage" runat="server" OnClick="btnSaveNewMessage_Click" Text="Guardar" />
        <asp:Label ID="lblNewMessage" runat="server"></asp:Label>
    </asp:Panel>
    




</asp:Content>
