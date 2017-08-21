<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="Selectcomp.WEB.Admin.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblName" runat="server" Text="Nombre del producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbName" runat="server" ForeColor="Black" MaxLength="100" Width="234px">Añadir un nombre...</asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblBrand" runat="server" Text="Marca del producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbBrand" runat="server" ForeColor="Black" Width="232px">Añadir una marca...</asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblPrice" runat="server" Text="Precio del producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbPrice" runat="server" ForeColor="Black" Width="232px">Añadir un precio...</asp:TextBox>
<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Label ID="lblType" runat="server" Text="Tipo de producto"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlType" runat="server" Width="237px">
    </asp:DropDownList>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblImage" runat="server" Text="Imagen del producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbImage" runat="server" ForeColor="Black" Width="232px">NombreDeLaImagen.png</asp:TextBox>
    <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblDescription" runat="server" Text="Descripción del producto"></asp:Label>
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbDescription" runat="server" Height="120px" Width="434px" TextMode="MultiLine"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblStock" runat="server" Text="Stock del producto"></asp:Label>
&nbsp;&nbsp;
<asp:CheckBox ID="cbStock" runat="server" Checked="True" OnCheckedChanged="cbStock_CheckedChanged" />
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblAmount" runat="server" Text="Cantidad de producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbAmount" runat="server" ForeColor="Black" Width="209px">Añadir una cantidad...</asp:TextBox>
    <br />
     <br />
     <br />
     <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" Text="Modificar" />
     <asp:Label ID="lblSave" runat="server"></asp:Label>
<br />

</asp:Content>
