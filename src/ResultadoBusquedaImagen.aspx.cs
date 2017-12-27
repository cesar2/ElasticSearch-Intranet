using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultadoBusquedaImagen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
        mostrarPaginaN(sender, e);
    }

    public void mostrarPaginaN(object sender, EventArgs e){
        String estadisticasBusqueda = "";
        string result = "";
        string paginacion = "";
        string images = "";
        int resultados_por_pagina = 20;
        float milisegundos = (int)Session["tiempotranscurrido"];
        List<ResultadoDeBusqueda> resultados_imagenes = (List<ResultadoDeBusqueda>)Session["imagenes"];
        string etiquetas = "";
        for (int i = 0; i < resultados_imagenes.Count; i++){

            images += "<div class=\"gallery_product col-lg-4 col-md-4 col-sm-4 col-xs-6 filter sprinkle \">";
            images += "<center>";
            images += "<a href=\"" + resultados_imagenes[i].urlRuta + "\" target=\"_blank\"> <img  class=\"foto\" src=\"" + resultados_imagenes[i].urlRuta + "\" width=\"180\" height=\"180\" > </a> <br>";
            images += "Altura: " + resultados_imagenes[i].pixelesAltura + " px <br>";
            images += "Anchura: " + resultados_imagenes[i].pixelesAnchura + " px <br>";
            if (resultados_imagenes[i].etiquetas != null && resultados_imagenes[i].etiquetas.Count > 0){
                etiquetas = string.Join(",", resultados_imagenes[i].etiquetas);
                if (etiquetas.Equals("") == false)
                    images += "<p> Etiquetas: " + etiquetas + "<p>";
            }
            images += "<input class=\"form-control input-md\" type=\"text\"\" placeholder=\"Etiquetas separadas por ,\" id=\"" + i + "\"> </br>";
            images += "<button runat = \"server\" class=\"btn btn-success btn-sm\"  OnClick=\"actualizarEtiquetas('" + resultados_imagenes[i].urlRuta + "'," + i + ")\"> <span class=\"glyphicon glyphicon-plus\"></span></button>";
            images += "</center>";
            images += "</div>";


        }

        resultadoImagenes.InnerHtml = images;

        int total_resultados = resultados_imagenes.Count;
        int num_paginas = (int)(total_resultados / resultados_por_pagina);

        if (total_resultados < 20){
            resultados_por_pagina = total_resultados;
        }

        estadisticasBusqueda += "<p> Texto buscado: " + Session["consulta"] + "<br>";
        estadisticasBusqueda += "<p> Tiempo de búsqueda: " + milisegundos + " milisegundos. <br>";
        estadisticasBusqueda += total_resultados + " resultados. <br>";
        estadisticasBusqueda += "Mostrando " + resultados_por_pagina + " de " + total_resultados + " resultados</p>";

        informacionBusqueda.InnerHtml = estadisticasBusqueda;

        /*paginacion += "<ul class=\"pagination\">";
        for (int i = 0; i < num_paginas + 1; i++) { 
            paginacion += "<li><a id =\"" + i + "\">" + (i + 1) + "</a></li>";
        }

        paginacion += "</ul>";*/

        if (!IsPostBack){
            resultadoImagenes.InnerHtml = images;
            divpaginacion.InnerHtml = paginacion;
        }
        else resultadoImagenes.InnerHtml = images;

    }



    public void busquedaImagenes(object sender, EventArgs e){
        String consulta = entradaBusquedaimg.Text;
        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> resultado_imagenes = OperacionesElasticSearch.SuperConsulta_ImagenesES(consulta, 6);

        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["imagenes"] = resultado_imagenes;
        Response.Redirect("ResultadoBusquedaImagen.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarEtiquetas(string url, string etiquetasnuevas){
        OperacionesElasticSearch.ActualizarEtiquetas(url, etiquetasnuevas);

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarhits(string url){
        OperacionesElasticSearch.AddHit(url);
    }

}