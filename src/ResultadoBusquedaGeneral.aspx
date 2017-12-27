<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultadoBusquedaGeneral.aspx.cs" Inherits="ResultadoBusquedaGeneral" %>

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

        img {
    margin-bottom:20px;
}

img:hover {
  filter: none; /* IE6-9 */
  -webkit-filter: grayscale(0); /* Google Chrome, Safari 6+ & Opera 15+ */
 
}

    </style>



    <script>

        function mostrarTodos(id) {
            $('#resultadogeneral').show();
            $('#resultadofiltro').html("");

            var s = document.getElementsByTagName('a');
            for (i = 0; i < s.length; i++) {
                s[i].setAttribute("style", "font-weight:normal");
            }
            document.getElementById(id).style.fontWeight = 900;
        }

    function mifuncion(id) {
        $('#resultadogeneral').hide();
        $('#resultadofiltro').html("");
        var s = document.getElementsByTagName('a');
        for (i = 0; i < s.length; i++) {
            s[i].setAttribute("style", "font-weight:normal");
        }
        document.getElementById(id).style.fontWeight = 900;
        var params = '{ nombre: ' + JSON.stringify(id) + '}';
        $.ajax({
            type: "POST",
            url: "ResultadoBusquedaGeneral.aspx/AplicarFiltro",
            data: params,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (data) {
                $('#resultadofiltro').html(data.d);
                params = '{ nombre: ' + JSON.stringify(id) + '}';
                $.ajax({
                    type: "POST",
                    url: "ResultadoBusquedaGeneral.aspx/PaginacionDeFiltro",
                    data: params,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (data) {
                        $('#paginacionnormal').hide();
                        $('#paginacionfiltro').html(data.d);
                    }
                });
            } 
        });


    };


    function pruebas() {
        $.ajax({
            type: "POST",
            url: "ResultadoBusquedaGeneral.aspx/PaginacionDeFiltro",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (data) {
                $('#paginacionnormal').hide();
                $('#paginacionfiltro').html(data.d);
            }
        });


    }



    function mostrarPaginaN(id) {
        var a = id;

        if (a != 0) {
            var params = '{ n: ' + JSON.stringify(id) + '}';

            $.ajax({
                type: "POST",
                url: "ResultadoBusquedaGeneral.aspx/MostrarPaginaN",
                data: params,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (data) {
                    $('#resultadogeneral').hide();
                    $('#resultadopaginaN').html(data.d);
                }
            });


        } else if (a == 0) {
            $('#resultadogeneral').show();
            $('#resultadopaginaN').html('');
        }


    }

    function mostrarPaginaDeFiltroN(id, nom) {
        $('#resultadofiltro').html("");
        var a = id;
            var params = '{ filtro: ' + JSON.stringify(nom) + ', n:' + JSON.stringify(id)+'}';
            $.ajax({
                type: "POST",
                url: "ResultadoBusquedaGeneral.aspx/MostrarPaginaFiltroN",
                data: params,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (data) {
                    $('#resultadogeneral').hide();
                    $('#resultadofiltro').html(data.d);
                }
            });



    }

    
    function actualizahits(url) {
        var params = '{ url: ' + JSON.stringify(url) + '}';
        $.ajax({
            type: "POST",
            url: "ResultadoBusquedaGeneral.aspx/Actualizarhits",
            data: params,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            }
        });
    }
</script>

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
            <br />
             <div style="width: 800px; margin: 0 auto;">
        <center>
        <h2 style="margin: 0 auto;">Buscador para Intranets <img src="./Imagenes/icon-elasticsearch.png"  width="32px" height="32px"/></h2> 
            </center>
         
        <asp:TextBox runat="server" class="form-control input-lg" id="entradaBusqueda" type="text"  Width="500" style="margin: 0 auto;"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="entradaBusqueda"
         MinimumPrefixLength="3" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" 
         ServiceMethod="obtenerSugerencias"   CompletionListCssClass="completionList"
         CompletionListHighlightedItemCssClass="itemHighlighted"
         CompletionListItemCssClass="listItem">
        </ajaxToolkit:AutoCompleteExtender>
        <br />
        <center>
        <p> <asp:Button runat="server" class="btn btn-primary btn-lg" OnClick="Busquedanormal" Width="" Text="Buscar" style="margin: 0 auto;"/> </p>
            </center>
                 <br />
    </div>


    <div class="container" id="resultadoImagenes" runat="server" style="width: 800px; margin: 0 auto;">     
    </div>


    <br />
  


    <div class="container"  style="width: 800px; margin: 0 auto;">
        <div class="row">
            <div class="col-xs-6">
                <h3> Resultado de la búqueda: </h3>
                <div  id="informacionBusqueda" runat="server">  </div>
            </div>
            <div class="col-xs-6">
                <div id="agrs" runat="server">
                </div>
            </div>
        </div>
    </div>

    

    <br style="clear:both" />
    <br />

    <div id="resultadofiltro" style="width: 800px; margin: 0 auto;" >

    </div>
    <div id="resultadogeneral" style="width: 800px; margin: 0 auto;" >
        <p id="ResultadoDeBusquedaGeneral" runat="server" style="width: 800px; margin: 0 auto;"> </p>
    </div>

    <div id="resultadopaginaN" style="width: 800px; margin: 0 auto;" >
    </div>


    <center>
        <div id="paginacionnormal">
            <div class="container"  id="divpaginacion" runat="server" style="width: 50%; margin: 0 auto;"> </div>
        </div>
        <div id="paginacionfiltro">
        <div class="container"  id="divpaginacionfiltro" runat="server" style="width: 50%; margin: 0 auto;"> </div>
        </div>
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