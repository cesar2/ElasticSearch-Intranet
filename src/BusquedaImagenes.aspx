﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusquedaImagenes.aspx.cs" Inherits="BusquedaImagenes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

      <style type="text/css">  
        .completionList {
        border:solid 1px Gray;
        margin:0px;
        padding:3px;
        height: 120px;
        overflow:auto;
        background-color: #FFFFFF;      
        }

        .listItem {
        color: #191919;
        }

        .itemHighlighted {
        background-color: #ADD6FF;        
        }
    </style>


     <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"> 

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <title>Búsqueda General</title>

</head>
<body>

    <form id="form1" runat="server">   
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager> 

        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/BusquedaGeneral.aspx">Buscador Elástico </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/BusquedaGeneral.aspx">Inicio</a></li>
                        <li><a runat="server" href="~/BusquedaImagenes.aspx">Buscar Imágenes</a></li>
                        <li><a runat="server" href="~/BusquedaAudio.aspx">Buscar Audios</a></li>
                        <li><a runat="server" href="~/BusquedaVideo.aspx">Buscar Vídeos</a></li>
                        <li><a runat="server" href="~/ConfiguracionAdmin.aspx">Configuración</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="container body-content">
            <div class="jumbotron">
                <center>
                <h1>Buscar imágenes <img src="./Imagenes/icono-imagen.png" height="40" width="40"/> </h1>  
                </center>

                <asp:TextBox runat="server" class="form-control input-lg" id="entradaBusquedaimg" type="text" Width="500" style="margin:0 auto;" ></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="entradaBusquedaimg"
                 MinimumPrefixLength="3" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" 
                 ServiceMethod="obtenerSugerencias"   CompletionListCssClass="completionList"
                CompletionListHighlightedItemCssClass="itemHighlighted"
                CompletionListItemCssClass="listItem">
                </ajaxToolkit:AutoCompleteExtender>

                <br />
                <center>
                <p> <asp:Button runat="server" class="btn btn-primary btn-lg" OnClick="busquedaImagenes" Text="Buscar"/> </p>
                </center>
            </div>

            <div>
                <h2> Documentos más visitados: </h2>
                <div id="masvisitados" runat="server" ></div>
            </div>

            <hr />
            <center>
            <footer ">
                <p>&copy; <%: DateTime.Now.Year %> - Buscador Elástico</p>
            </footer>
                </center>
        </div>


    </form>



</body>
</html>