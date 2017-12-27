using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultadoBusquedaVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
        mostrarPaginaN(sender, e);
    }


    public void mostrarPaginaN(object sender, EventArgs e){
        String estadisticasBusqueda = "";
        string result = "";
        string paginacion = "";
        string videos = "";
        int resultados_por_pagina = 20;
        float milisegundos = (int)Session["tiempotranscurrido"];
        List<ResultadoDeBusqueda> resultados_video = (List<ResultadoDeBusqueda>)Session["videos"];
        string etiquetas = "";

        for (int i = 0; i < resultados_video.Count; i++){
            videos += "<div class=\"video\">";
            videos += "<center>";
            videos += "<p style=\"font-size:16px;\"> <b>" + resultados_video[i].nombrearchivo + "<b><br>";
            videos += "<p> Duración: " + resultados_video[i].duracion + " segundos.<br>";
            if (resultados_video[i].formato.Equals(".mp4"))
            {
                
                videos += "<video width = \"700\" controls> <source src = \"" + resultados_video[i].urlRuta + "\" > </video> <br>";
                
            }
            if (resultados_video[i].etiquetas != null && resultados_video[i].etiquetas.Count > 0){
                etiquetas = string.Join(",", resultados_video[i].etiquetas);
                if (etiquetas.Equals("") == false)
                    videos += "<p> Etiquetas: " + etiquetas + "<p>";
            }

            videos += "<input class=\"form-control input-md\" type=\"text\"\"  style=\"width: 700px;\" placeholder=\"Etiquetas separadas por ,\" id=\"" + i + "\"> <br>";
            videos += "<button runat = \"server\" class=\"btn btn-success btn-sm\"  OnClick=\"actualizarEtiquetas('" + resultados_video[i].urlRuta + "'," + i + ")\"> <span class=\"glyphicon glyphicon-plus\"></span></button>";
            videos += "</center>";
            videos += "</div>";
        }
        resultadoBusquedaVideos.InnerHtml = videos;

        int total_resultados = resultados_video.Count;
        int num_paginas = (int)(total_resultados / resultados_por_pagina);

        if (total_resultados < 20){
            resultados_por_pagina = total_resultados;
        }

        estadisticasBusqueda += "<p> Texto buscado: " + Session["consulta"] + "<br>";
        estadisticasBusqueda += "Tiempo de búsqueda: " + milisegundos + " milisegundos. <br>";
        estadisticasBusqueda += total_resultados + " resultados. <br>";
        estadisticasBusqueda += "Mostrando " + resultados_por_pagina + " de " + total_resultados + " resultados</p>";

        informacionBusqueda.InnerHtml = estadisticasBusqueda;

        /*
        for (int i = 0; i < num_paginas + 1; i++){
            paginacion += "<p> <button id=" + i + " runat=\"server\" class=\"btn btn-primary btn-lg\" onserverclick=\"mostrarPaginaN\" src=\"./Imagenes/icon-elasticsearch.png\" width=\"32\" height=\"32\" Text=\"" + i + "\" /></p>";
        }*/

        if (!IsPostBack){
            resultadoBusquedaVideos.InnerHtml = videos;
            divpaginacion.InnerHtml = paginacion;
        }
        else resultadoBusquedaVideos.InnerHtml = videos;

    }




    public void busquedaVideo(object sender, EventArgs e){
        String consulta = entradaBusquedavideo.Text;

        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> lista_videos = OperacionesElasticSearch.SuperConsulta_VideoES(consulta);

        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["videos"] = lista_videos;
        Response.Redirect("ResultadoBusquedaVideo.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarhits(string url){
        OperacionesElasticSearch.AddHit(url);
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void ActualizarEtiquetas(string url, string etiquetasnuevas){
        OperacionesElasticSearch.ActualizarEtiquetas(url, etiquetasnuevas);
    }


}