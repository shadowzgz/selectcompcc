<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Selectcomp.WEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        &nbsp;
        <img id="imgSelectcompDefault" src="Images/LogoInterfacesLogicPeque.png" style="width: 500px; height: 340px; margin-bottom: 6px; position: relative; top: 0px; left: 0px;" /><br />
        <span style="font-family: Arial; font-weight: bold; font-size: xx-large">&nbsp;</span><span style="font-weight: bold; font-size: xx-large"><span style="font-family: Arial, Helvetica, sans-serif; font-weight: bold">Bienvenido a Selectomp</span></span></div>

    <div class="row">
        <div class="col-md-4">
            <h2>Asistencia a los clientes</h2>
            <p>
                Ponemos a disposición de los clientes un sistema de mensajería novedoso mediente el cual podrán solventar todos sus problemas de una forma rápida y eficaz gracias al trabajo de nuestros excelentes empleados.
            </p>
            <p>
                <a class="btn btn-default" href="/User/Incidences">Acceder al CallCenter &raquo;</a>
                </p>
        </div>
        <div class="col-md-4">
            <h2>Descargue TeamViewer</h2>
            <p>
                Para poder ofrecerle un mejor servicio es posible que necesite el software TeamViewer. En caso de ser necesairo, descárguelo desde este botón.
            </p>
  
            <div style="position:relative; width:120px; height:60px;">
            <a href="http://www.teamviewer.com/link/?url=842558&id=1548730122" style="text-decoration:none;">
            <img src="http://www.teamviewer.com/link/?url=979936&id=1548730122" alt="Descargar versión completa de TeamViewer" title="Descargar versión completa de TeamViewer" border="0" width="120" height="60" />
            <span style="position:absolute; top:25.5px; left:50px; display:block; cursor:pointer; color:White; font-family:Arial; font-size:10px; line-height:1.2em; font-weight:bold; text-align:center; width:65px;">
             Descargar TeamViewer
            </span>
             </a>
</div>
        </div>
    </div>

</asp:Content>
