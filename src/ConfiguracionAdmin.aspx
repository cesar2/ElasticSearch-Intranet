<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfiguracionAdmin.aspx.cs" Inherits="ConfiguracionAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">



     <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"> 

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

     <script>
        $(document).ready(function(){
            $("#Indexaciones").hide();
            $("#indexacionGeneral").hide();
            $("#indexacionDpto").hide();
            $("#indexacionServidor").hide();
            $("#indexacionPorTipoDeArchivo").hide();
            $("#indexacionPrioritaria").hide();

            $("#Actualizaciones").hide();
            $("#actualizacionGeneral").hide();
            $("#actualizacionDpto").hide();
            $("#actualizacionServidor").hide();
            $("#actualizacionPorTipoDeArchivo").hide();
            $("#actualizacionPrioritaria").hide();

            $("#Borrado").hide();
            $("#borradoPorDpto").hide();
            $("#borradoPorUrl").hide();
            $("#borradoGeneral").hide();
            $("#borradoTipoArchivo").hide();
            $("#borradoPorServidor").hide();

        });

        function showactualizar() {
            if ($("#Actualizaciones").is(":visible")) {
                $("#Actualizaciones").hide();
            } else {
                $("#Actualizaciones").show();
            }
            
        }

        function showindexar() {
            if ($("#Indexaciones").is(":visible")) {
                $("#Indexaciones").hide();
            } else {
                $("#Indexaciones").show();
            }
        }

        function showBorrar() {
            if ($("#Borrado").is(":visible")) {
                $("#Borrado").hide();
            } else {
                $("#Borrado").show();
            }
        }

        function showindexarGeneral() {
            if ($("#indexacionGeneral").is(":visible")) {
                $("#indexacionGeneral").hide();
            } else {
                $("#indexacionGeneral").show();
            }
         }

         function showindexarPorServidor() {
             if ($("#indexacionServidor").is(":visible")) {
                 $("#indexacionServidor").hide();
             } else {
                 $("#indexacionServidor").show();
             }
         }

         function showindexarPorDpto() {
             if ($("#indexacionDpto").is(":visible")) {
                 $("#indexacionDpto").hide();
             } else {
                 $("#indexacionDpto").show();
             }
         }

        function showindexarTipoArchivo() {
            if ($("#indexacionPorTipoDeArchivo").is(":visible")) {
                $("#indexacionPorTipoDeArchivo").hide();
            } else {
                $("#indexacionPorTipoDeArchivo").show();
            }
        }

        function showindexarSemilla() {
            if ($("#indexacionPrioritaria").is(":visible")) {
                $("#indexacionPrioritaria").hide();
            } else {
                $("#indexacionPrioritaria").show();
            }
        }

        function showBorrar() {
            if ($("#Borrado").is(":visible")) {
                $("#Borrado").hide();
            } else {
                $("#Borrado").show();
            }
        }

        function showBorradoGeneral() {
            if ($("#borradoGeneral").is(":visible")) {
                $("#borradoGeneral").hide();
            } else {
                $("#borradoGeneral").show();
            }
         }

         function showBorradoPorServidor() {
             if ($("#borradoPorServidor").is(":visible")) {
                 $("#borradoPorServidor").hide();
             } else {
                 $("#borradoPorServidor").show();
             }
         }

         function showBorradoPorDpto() {
             if ($("#borradoPorDpto").is(":visible")) {
                 $("#borradoPorDpto").hide();
             } else {
                 $("#borradoPorDpto").show();
             }
         }

         
         function showBorradoPorUrl() {
             if ($("#borradoPorUrl").is(":visible")) {
                 $("#borradoPorUrl").hide();
             } else {
                 $("#borradoPorUrl").show();
             }
         }

        function showBorradoPorTipo() {
            if ($("#borradoTipoArchivo").is(":visible")) {
                $("#borradoTipoArchivo").hide();
            } else {
                $("#borradoTipoArchivo").show();
            }
         }

         //--------------
         function showactualizacionGeneral() {
             if ($("#actualizacionGeneral").is(":visible")) {
                 $("#actualizacionGeneral").hide();
             } else {
                 $("#actualizacionGeneral").show();
             }
         }

         function showactualizacionServidor() {
             if ($("#actualizacionServidor").is(":visible")) {
                 $("#actualizacionServidor").hide();
             } else {
                 $("#actualizacionServidor").show();
             }
         }
         
         function showactualizacionDpto() {
             if ($("#actualizacionDpto").is(":visible")) {
                 $("#actualizacionDpto").hide();
             } else {
                 $("#actualizacionDpto").show();
             }
         }

         function showactualizacionTipo() {
             if ($("#actualizacionPorTipoDeArchivo").is(":visible")) {
                 $("#actualizacionPorTipoDeArchivo").hide();
             } else {
                 $("#actualizacionPorTipoDeArchivo").show();
             }
         }

         function showactualizacionUrl() {
             if ($("#actualizacionPrioritaria").is(":visible")) {
                 $("#actualizacionPrioritaria").hide();
             } else {
                 $("#actualizacionPrioritaria").show();
             }
         }
         
         


    </script>

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
            <div class="jumbotron">
        <h1>Configuración  <img src="./Imagenes/icono-admin.png" height="40" width="40"/> </h1>  

        <h2 onclick="showindexar()"> Indexaciones </h2>
        <div id="Indexaciones">
            <h3  onclick="showindexarGeneral()"> Indexación general</h3>
            <div id="indexacionGeneral" title="Indexar todos los tipos de documentos desde la dirección raíz.">
                <p> <asp:Button runat="server" class="btn btn-primary btn-md" OnClick="indexacionGeneral" Text="Indexar" /> </p>
            </div>

            <h3 onclick="showindexarPorServidor()"> Indexación por servidor </h3>
            <div id="indexacionServidor">
                 <asp:DropDownList runat="server" ID="listaservidores">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="servidorIntranet1"> Servidor1 </asp:listitem>
                    <asp:listitem value ="servidorIntranet2"> Servidor2 </asp:listitem>
                </asp:DropDownList>

                <br />
                <br />
                <p> <asp:Button runat="server" class="btn btn-primary btn-md" OnClick="indexacionGeneral" Text="Indexar"/> </p>
            </div>

            <h3 onclick="showindexarPorDpto()"> Indexación por departamento </h3>
            <div id="indexacionDpto">
                <asp:DropDownList runat="server" ID="listadptos">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="Algebra"> Algebra </asp:listitem>
                    <asp:listitem value ="Analisis Matematico"> Analisis Matematico </asp:listitem>
                    <asp:listitem value ="Electronica y tecnologia de computadores"> Electronica y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Teoria de la senal, telematica y comunicaciones"> Teoria de la senal, telematica y comunicaciones </asp:listitem>
                    <asp:listitem value ="Arquitectura y tecnologia de computadores"> Arquitectura y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Ciencias de la computacion e inteligencia artificial"> Ciencias de la computacion e inteligencia artificial </asp:listitem>
                    <asp:listitem value ="Lenguajes y sistemas informaticos"> Lenguajes y sistemas informaticos </asp:listitem>
                </asp:DropDownList>

                <br />
                <br />
                <p> <asp:Button runat="server" class="btn btn-primary btn-md" OnClick="indexacionGeneral" Text="Indexar"/> </p>

            </div>
            <h3 onclick="showindexarTipoArchivo()"> Indexación por tipo de archivo </h3>
            <div id="indexacionPorTipoDeArchivo">
                <asp:DropDownList runat="server" ID="listaTipos">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="hipertexto"> Hipertexto </asp:listitem>
                    <asp:listitem value ="texto"> Texto </asp:listitem>
                    <asp:listitem value ="imagen"> Imagen </asp:listitem>
                    <asp:listitem value ="audio"> Audio </asp:listitem>
                    <asp:listitem value ="video"> Video </asp:listitem>
                </asp:DropDownList>

                <br />
                <br />
                <p> <asp:Button runat="server" class="btn btn-primary btn-md" OnClick="indexacionGeneral" Text="Indexar"/> </p>
            </div>
            <h3 onclick="showindexarSemilla()"> Indexación por URL prioritaria</h3>
            <div id="indexacionPrioritaria">
                <p> URL : <asp:TextBox runat="server" style="width: 800px" MaxLength="800" ID="semilla" >  </asp:TextBox></p> 
                <p> <asp:Button runat="server" class="btn btn-primary btn-md" OnClick="indexacionGeneral" Text="Indexar"/> </p>
            </div>
        </div>


        <h2  onclick="showactualizar()" > Actualizaciones </h2>
        <div id="Actualizaciones">
            <h3 onclick="showactualizacionGeneral()"> Actualización general</h3>
            <div id="actualizacionGeneral"> 
                <asp:Button runat="server" class="btn btn-warning btn-md" OnClick="actualizacionGeneral" Text="Actualizar"/> 
            </div>

            <h3  onclick="showactualizacionServidor()"> Actualización por servidor</h3>
            <div id="actualizacionServidor"> 
                <asp:DropDownList runat="server" ID="servidorActualizar">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="servidorIntranet1"> Servidor1 </asp:listitem>
                    <asp:listitem value ="servidorIntranet2"> Servidor2 </asp:listitem>
                </asp:DropDownList>
                <asp:Button runat="server" class="btn btn-warning btn-md" OnClick="actualizacionGeneral" Text="Actualizar"/> 
            </div>

            <h3  onclick="showactualizacionDpto()"> Actualización por departamento</h3>
            <div id="actualizacionDpto"> 
                <asp:DropDownList runat="server" ID="dptoActualizar">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="Algebra"> Algebra </asp:listitem>
                    <asp:listitem value ="Analisis Matematico"> Analisis Matematico </asp:listitem>
                    <asp:listitem value ="Electronica y tecnologia de computadores"> Electronica y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Teoria de la senal, telematica y comunicaciones"> Teoria de la senal, telematica y comunicaciones </asp:listitem>
                    <asp:listitem value ="Arquitectura y tecnologia de computadores"> Arquitectura y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Ciencias de la computacion e inteligencia artificial"> Ciencias de la computacion e inteligencia artificial </asp:listitem>
                    <asp:listitem value ="Lenguajes y sistemas informaticos"> Lenguajes y sistemas informaticos </asp:listitem>
                </asp:DropDownList>
                <asp:Button runat="server" class="btn btn-warning btn-md" OnClick="actualizacionGeneral" Text="Actualizar"/> 
            </div>

            <h3  onclick="showactualizacionTipo()"> Actualización por tipo de archivo</h3>
            <div id="actualizacionPorTipoDeArchivo"> 
                <asp:DropDownList runat="server" ID="tipoActualizar">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="hipertexto"> Hipertexto </asp:listitem>
                    <asp:listitem value ="texto"> Texto </asp:listitem>
                    <asp:listitem value ="imagen"> Imagen </asp:listitem>
                    <asp:listitem value ="audio"> Audio </asp:listitem>
                    <asp:listitem value ="video"> Video </asp:listitem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button runat="server" class="btn btn-warning btn-md" OnClick="actualizacionGeneral" Text="Actualizar"/> 
            </div>

            <h3  onclick="showactualizacionUrl()"> Actualización por url prioritaria</h3>
            <div id="actualizacionPrioritaria">
                <p> URL : <asp:TextBox runat="server" style="width: 800px" MaxLength="800" ID="actualizacionPorUrl" >  </asp:TextBox></p> 
                <asp:Button runat="server" class="btn btn-warning btn-md" OnClick="actualizacionGeneral" Text="Actualizar"/> 
            </div>
        </div>



        <h2 onclick="showBorrar()">  Borrado </h2>
        <div id="Borrado">
            <h3 onclick="showBorradoGeneral()">  Borrado general </h3>
            <div id="borradoGeneral">
            <p style="color:red"> <asp:Button runat="server" class="btn btn-danger btn-md" OnClick="borradoGeneral" Text="BORRAR TODO"/>  ATENCIÓN: SE BORRARÁN TODOS LOS DOCUMENTOS.</p>
            </div>

            <h3  onclick="showBorradoPorServidor()"> Borrado por servidor </h3>
            <div id="borradoPorServidor">
                <asp:DropDownList runat="server" ID="borradoServ">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="servidorIntranet1"> Servidor1 </asp:listitem>
                    <asp:listitem value ="servidorIntranet2"> Servidor2 </asp:listitem>
                </asp:DropDownList>
                <br />
                <br />
                <p style="color:red"> <asp:Button runat="server" class="btn btn-danger btn-md" OnClick="borradoPorServidor" Text="BORRAR"/>  ATENCIÓN: SE BORRARÁN TODOS LOS DOCUMENTOS.</p>

            </div>
            <h3  onclick="showBorradoPorDpto()" >Borrado por departamento</h3>
            <div id="borradoPorDpto">
                <asp:DropDownList runat="server" ID="listaBorradoDpto">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="Algebra"> Algebra </asp:listitem>
                    <asp:listitem value ="Analisis Matematico"> Analisis Matematico </asp:listitem>
                    <asp:listitem value ="Electronica y tecnologia de computadores"> Electronica y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Teoria de la senal, telematica y comunicaciones"> Teoria de la senal, telematica y comunicaciones </asp:listitem>
                    <asp:listitem value ="Arquitectura y tecnologia de computadores"> Arquitectura y tecnologia de computadores </asp:listitem>
                    <asp:listitem value ="Ciencias de la computacion e inteligencia artificial"> Ciencias de la computacion e inteligencia artificial </asp:listitem>
                    <asp:listitem value ="Lenguajes y sistemas informaticos"> Lenguajes y sistemas informaticos </asp:listitem>
                </asp:DropDownList>
                <br />
                <br />
                <p style="color:red"> <asp:Button runat="server" class="btn btn-danger btn-md" OnClick="borradoPorDpto" Text="BORRAR"/>  ATENCIÓN: SE BORRARÁN TODOS LOS DOCUMENTOS.</p>

            </div>

            <h3 onclick="showBorradoPorTipo()"> Borrado por tipo de archivo </h3>
            <div id="borradoTipoArchivo">
                <asp:DropDownList runat="server" ID="BorradodeTipo">
                    <asp:ListItem value =""> Todos </asp:ListItem>
                    <asp:listitem value ="hipertexto"> Hipertexto </asp:listitem>
                    <asp:listitem value ="texto"> Texto </asp:listitem>
                    <asp:listitem value ="imagen"> Imagen </asp:listitem>
                    <asp:listitem value ="audio"> Audio </asp:listitem>
                    <asp:listitem value ="video"> Video </asp:listitem>
                </asp:DropDownList>
                <br />
                <p style="color:red"> <asp:Button runat="server" class="btn btn-danger btn-md" OnClick="borradoPorTipo" Text="BORRAR"/>  ATENCIÓN: SE BORRARÁN TODOS LOS DOCUMENTOS.</p>
            </div>
            <h3 onclick="showBorradoPorUrl()"> Borrado por url prioritaria</h3>
            <div id="borradoPorUrl">
                <p> URL : <asp:TextBox runat="server" style="width: 800px" MaxLength="800" ID="borradoUrl" >  </asp:TextBox></p> 
                <p style="color:red"> <asp:Button runat="server" class="btn btn-danger btn-md" OnClick="borradoPorUrl" Text="BORRAR"/>  ATENCIÓN: SE BORRARÁN TODOS LOS DOCUMENTOS.</p>
            </div>
        </div>
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