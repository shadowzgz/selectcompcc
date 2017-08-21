<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Selectcomp.WEB.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>&nbsp;</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Soporte:</strong>   <a href="mailto:Support@example.com">Support@selectcomp.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@selectcomp.com</a>
    </address>
</asp:Content>
