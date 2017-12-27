<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultadoBusquedaVideo.aspx.cs" Inherits="ResultadoBusquedaVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"> 

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

     <link href="http://vjs.zencdn.net/c/video-js.css" rel="stylesheet">
    <script src="http://vjs.zencdn.net/c/video.js"></script>

    <title>Búsqueda General</title>

    <style type="text/css">
    div.video {
    border-style: groove;
    margin-bottom: 30px;
    padding-left: 8px;
    padding-top: 8px;
    }   
    </style>

    <script>

        function actualizahits(url) {
            var params = '{ url: ' + JSON.stringify(url) + '}';
            $.ajax({
                type: "POST",
                url: "ResultadoBusquedaGeneral.aspx/actualizarhits",
                data: params,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                }
            });
        }


        function actualizarEtiquetas(url, etiquetas) {
           // alert(url);
            var bla = $('#' + etiquetas).val();
            //alert(bla);
            var params = '{ url: ' + JSON.stringify(url) + ', etiquetasnuevas: ' + JSON.stringify(bla) + '}';
            $.ajax({
                type: "POST",
                url: "ResultadoBusquedaVideo.aspx/actualizarEtiquetas",
                data: params,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
            });
        }


    </script>

</head>
<body>

    <form id="form1" runat="server">   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
            
            <br />
             <br />
    
            <div>
                <center>
                <h3>Buscar Vídeos <img src="./Imagenes/icon-elasticsearch.png"  width="32px" height="32px"/> </h3> 
                </center>
                <asp:TextBox runat="server" class="form-control input-lg" id="entradaBusquedavideo" type="text"  Width="500" style="margin:0 auto;"></asp:TextBox>
                <br />
                <center>
                <p> <asp:Button runat="server" class="btn btn-primary btn-lg" OnClick="busquedaVideo" Width="" Text="Buscar"/> </p>
                </center>
            </div>

            <center>
                <h3 style="width: 800px; margin: 0 auto;"> Resultado de la búqueda: </h3>
            <div  id="informacionBusqueda" runat="server" style="width: 800px; margin: 0 auto;">  </div>
            </center>


            <div id="resultadoBusquedaVideos" runat="server" style="width: 800px; margin: 0 auto;">

            </div>

            <br style="clear:both" />
            <br />

            <center>
            <div id="divpaginacion" runat="server" style="width: 50%; margin: 0 auto;"> </div>
            </center>

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