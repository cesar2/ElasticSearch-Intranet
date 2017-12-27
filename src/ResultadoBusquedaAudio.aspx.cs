using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultadoBusquedaAudio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){
        mostrarPaginaN(sender, e);
    }


    public void mostrarPaginaN(object sender, EventArgs e){
        string icono_audio = "";
        String estadisticasBusqueda = "";
        string result = "";
        string paginacion = "";
        string audios = "";
        int resultados_por_pagina = 20;
        float milisegundos = (int)Session["tiempotranscurrido"];
        List<ResultadoDeBusqueda> resultados_audio = (List<ResultadoDeBusqueda>)Session["audios"];
        string etiquetas = "";
        for (int i = 0; i < resultados_audio.Count; i++){
            if (resultados_audio[i].formato.Equals(".mp3"))
                icono_audio = "./Imagenes/icono-mp3.png";
            else if (resultados_audio[i].formato.Equals(".wav"))
                icono_audio = "./Imagenes/icono-wav.png";

            audios += "<div class=\"sonido\">";
            audios += "<img src=\"" + icono_audio + "\" width=\"32\" height=\"32\" /> [" + resultados_audio[i].departamento + "] <a href=\"" + resultados_audio[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\"><b>" + resultados_audio[i].nombrearchivo + "</b></a>";
            if (resultados_audio[i].urlRuta.Length >= 110)
            {
                string aux = resultados_audio[i].urlRuta.Substring(0, 110);
                aux += "...";
                audios += "<p><font color=\"green\">" + aux + "</font></br>";

            }
            else
            {
                audios += "<p><font color=\"green\">" + resultados_audio[i].urlRuta + "</font></br>";
            }
            audios += "<p> Duración: " + resultados_audio[i].duracion + " segundos.<br>";
            audios += "<audio controls>";
            audios += "<source src=\"" + resultados_audio[i].urlRuta + "\" type=\"audio/mpeg\">";
            audios += "</audio><br>";
            if (resultados_audio[i].etiquetas != null && resultados_audio[i].etiquetas.Count > 0){
                etiquetas = string.Join(",", resultados_audio[i].etiquetas);
                if (etiquetas.Equals("") == false)
                    audios += "<p> Etiquetas: " + etiquetas + "<p>";
            }
            audios += "<input class=\"form-control input-md\" type=\"text\"\" placeholder=\"Etiquetas separadas por ,\" id=\"" + i + "\"> <br>";
            audios += "<button runat = \"server\" class=\"btn btn-success btn-sm\"  OnClick=\"actualizarEtiquetas('" + resultados_audio[i].urlRuta + "'," + i + ")\"> <span class=\"glyphicon glyphicon-plus\"></span></button>";
            audios += "</div>";
        }

        resultadoBusquedaAudio.InnerHtml = audios;

        int total_resultados = resultados_audio.Count;
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
        paginacion += "<ul class=\"pagination\">";
        for (int i = 0; i < num_paginas + 1; i++){
            paginacion += "<li><a id =\"" + i + "\">" + (i + 1) + "</a></li>";
        }

        paginacion += "</ul>";*/

        if (!IsPostBack){
            resultadoBusquedaAudio.InnerHtml = audios;
            divpaginacion.InnerHtml = paginacion;
        }
        else resultadoBusquedaAudio.InnerHtml = audios;

    }


    public void busquedaAudio(object sender, EventArgs e){
        String consulta = entradaBusquedaaudio.Text;
        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> resultado = OperacionesElasticSearch.SuperConsulta_AudioES(consulta);

        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["audios"] = resultado;
        Response.Redirect("ResultadoBusquedaAudio.aspx");

    }

    
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarhits(string url){
        OperacionesElasticSearch.AddHit(url);
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarEtiquetas(string url, string etiquetasnuevas)
    {
        OperacionesElasticSearch.ActualizarEtiquetas(url, etiquetasnuevas);

    }


}