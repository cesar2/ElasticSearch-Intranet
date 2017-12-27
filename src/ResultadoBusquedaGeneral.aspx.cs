using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResultadoBusquedaGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //pru.InnerHtml = "<a runat = \"server\" OnClick = \"aplicarFiltro\" id = \"LinkButton1\"> Electronica y tecnologia de computadores(1) </a>";
        mostrarPaginaInicial(sender, e);

    }



    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string aplicarFiltro(string nombre){

        int n = 0;
        String estadisticasBusqueda = "";
        string result = "";
        string paginacion = "";
        string images = "";
        int resultados_por_pagina = 20;
        List<string> todosresultfiltro = new List<string>();


        List<ResultadoDeBusqueda> resultados = (List<ResultadoDeBusqueda>)HttpContext.Current.Session[nombre];

        int total_resultados = resultados.Count;
        int num_paginas = (int)(total_resultados / resultados_por_pagina);
        if (total_resultados - (resultados_por_pagina * num_paginas) > 0)
            num_paginas++;

        if (total_resultados < 20){
            resultados_por_pagina = total_resultados;
        }



        //informacionBusqueda.InnerHtml = estadisticasBusqueda;

        for (int i = 0; i < total_resultados; i++){
            result = "";
            string icono_archivo = "";
            switch (resultados[i].formato){
                case ".html":
                    icono_archivo = "./Imagenes/icono-html.png";
                    break;
                case ".pptx":
                    icono_archivo = "./Imagenes/icono-pptx.png";
                    break;
                case ".xlsx":
                    icono_archivo = "./Imagenes/icono-excel.png";
                    break;
                case ".wav":
                    icono_archivo = "./Imagenes/icon-wav.png";
                    break;
                case ".mp3":
                    icono_archivo = "./Imagenes/icon-elasticsearch.png";
                    break;
                case ".docx":
                    icono_archivo = "./Imagenes/icono-word.png";
                    break;
                case ".pdf":
                    icono_archivo = "./Imagenes/icono-pdf.png";
                    break;
                case ".txt":
                    icono_archivo = "./Imagenes/icono-txt.png";
                    break;
                default:
                    break;

            }
            string departamento = "";
            if (resultados[i].departamento != null && resultados[i].departamento.Equals("") == false){
                departamento = "[" + resultados[i].departamento.ToString() + "] ";
            }

            result += "<div>";
            result += "<img src=\"" + icono_archivo + "\" width=\"32\" height=\"32\" />" + departamento + "<a href=\"" + resultados[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\"><b>" + resultados[i].nombrearchivo + "</b></a>";
            result += "<p><font color=\"green\">" + resultados[i].urlRuta + "</font></br>";
            result += "<img src=\"./Imagenes/icono-diana.png\" width=\"18\" height=\"18\"/> <font color=\"red\" size=\"1\">Puntuación: " + resultados[i].puntaje + "</font></br>";
            result += resultados[i].textocontenido + "</p>";
            result += "</div>";
            result += "</br>";

            todosresultfiltro.Add(result);
        }



        for (int i = 0; i < num_paginas; i++){
            for (int j = 0; (j < resultados_por_pagina) && (i * resultados_por_pagina + j < total_resultados); j++){
                HttpContext.Current.Session["resultadopaginafiltro" + nombre.ToString() + i.ToString()] += todosresultfiltro[i * resultados_por_pagina + j].ToString();
            }
            var borrame = HttpContext.Current.Session["resultadopaginafiltro" + nombre.ToString() + "0"].ToString();
        }

        string devolver = HttpContext.Current.Session["resultadopaginafiltro" + nombre.ToString() + "0"].ToString();
        return devolver;
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string paginacionDeFiltro(string nombre){
        List<ResultadoDeBusqueda> resultados = (List<ResultadoDeBusqueda>)HttpContext.Current.Session[nombre];
        int resultados_por_pagina = 20;
        string paginacionfiltro = "";

        int total_resultados = resultados.Count;
        int num_paginas = (int)(total_resultados / resultados_por_pagina);
        if (total_resultados - (resultados_por_pagina * num_paginas) > 0)
            num_paginas++;

        if (total_resultados < 20){
            resultados_por_pagina = total_resultados;
        }

        paginacionfiltro += "<ul class=\"pagination\">";

        for (int i = 0; i < num_paginas; i++){
            if (i == 0)
                paginacionfiltro += "<li><a id=\"0\" href = \"javascript:mostrarPaginaDeFiltroN(" + i + ",'" + nombre + "')\">" + (i + 1) + "</a></li>";
            else
                paginacionfiltro += "<li ><a id=\"" + i + "\" href = \"javascript:mostrarPaginaDeFiltroN(" + i + ",'" + nombre + "')\">" + (i + 1) + "</a></li>";

        }

        paginacionfiltro += "</ul>";

        return paginacionfiltro;
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string mostrarPaginaN(string n){
        var a = HttpContext.Current.Session["resultadopagina" + n].ToString();
        return HttpContext.Current.Session["resultadopagina" + n].ToString();
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string mostrarPaginaFiltroN(string filtro, string n){
        return HttpContext.Current.Session["resultadopaginafiltro" + filtro + n].ToString();
    }

    public void mostrarPaginaInicial(object sender, EventArgs e){
        agrs.InnerHtml = Session["agregaciones"].ToString();
        int n = 0;
        String estadisticasBusqueda = "";
        string result = "";
        string paginacion = "";
        string images = "";
        int resultados_por_pagina = 20;

        float milisegundos = (int)Session["tiempotranscurrido"];
        List<ResultadoDeBusqueda> resultados = (List<ResultadoDeBusqueda>)Session["resultado"];

        if (Session["imagenes"] != null && Session["imagenes"].Equals("")==false)
        {
            List<ResultadoDeBusqueda> resultados_imagenes = (List<ResultadoDeBusqueda>)Session["imagenes"];

            images += "<div class=\"row\">";
            for (int i = 0; i < resultados_imagenes.Count && i<4; i++){

                images += "<div class=\"col-md-3 \"> <a href = \"" + resultados_imagenes[i].urlRuta + "\" target = \"_blank\" onclick=\"javascript:actualizahits('" + resultados_imagenes[i].urlRuta + "')\"> <img class=\"img-responsive\" src=\"" + resultados_imagenes[i].urlRuta + "\"\"> </a> </div>";
            }
            images += "</div>";
            resultadoImagenes.InnerHtml = images;
        }

        int total_resultados = resultados.Count;
        int num_paginas = (int)(total_resultados / resultados_por_pagina);

        if (total_resultados % resultados_por_pagina > 0)
            num_paginas++;

        if (total_resultados < 20){
            resultados_por_pagina = total_resultados;
        }


        estadisticasBusqueda += "<p> Texto buscado: " + Session["consulta"] + "<br>";
        estadisticasBusqueda += "Tiempo de búsqueda: " + milisegundos + " milisegundos. <br>";
        estadisticasBusqueda += total_resultados + " resultados. <br>";
        estadisticasBusqueda += "Mostrando " + resultados_por_pagina + " de " + total_resultados + " resultados</p>";
        Session["resultadopagina0"] = "";
        informacionBusqueda.InnerHtml = estadisticasBusqueda;
        List<string> todosresult = new List<string>();

        for (int i = 0; i < total_resultados; i++){
            result = "";
            string icono_archivo = "";

            switch (resultados[i].formato){
                case ".html":
                    icono_archivo = "./Imagenes/icono-html.png";
                    break;
                case ".pptx":
                    icono_archivo = "./Imagenes/icono-pptx.png";
                    break;
                case ".xlsx":
                    icono_archivo = "./Imagenes/icono-excel.png";
                    break;
                case ".wav":
                    icono_archivo = "./Imagenes/icon-wav.png";
                    break;
                case ".mp3":
                    icono_archivo = "./Imagenes/icon-elasticsearch.png";
                    break;
                case ".docx":
                    icono_archivo = "./Imagenes/icono-word.png";
                    break;
                case ".pdf":
                    icono_archivo = "./Imagenes/icono-pdf.png";
                    break;
                case ".txt":
                    icono_archivo = "./Imagenes/icono-txt.png";
                    break;
                default:
                    break;

            }

            string departamento = "";
            if (resultados[i].departamento != null && resultados[i].departamento.Equals("") == false){
                departamento = "[" + resultados[i].departamento.ToString() + "] ";
            }

            result += "<div>";
            result += "<img src=\"" + icono_archivo + "\" width=\"32\" height=\"32\" />" + departamento + "<a href=\"" + resultados[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\" onclick=\"javascript:actualizahits('" + resultados[i].urlRuta + "')\"><b>" + resultados[i].nombrearchivo + "</b></a>";
            if (resultados[i].urlRuta.Length >= 115){
                string aux = resultados[i].urlRuta.Substring(0, 115);
                aux += "...";
                result += "<p><font color=\"green\">" + aux + "</font></br>";

            }
            else { 
                result += "<p><font color=\"green\">" + resultados[i].urlRuta + "</font></br>";
            }

            result += "<img src=\"./Imagenes/icono-diana.png\" width=\"18\" height=\"18\"> <font color=\"red\" size=\"2\">Puntuación: " + resultados[i].puntaje + "</font></br>";
            result += resultados[i].textocontenido + "</p>";
            result += "</div>";
            result += "</br>";

            todosresult.Add(result);
        }
        if (num_paginas == 0)
            num_paginas++;

        paginacion += "<ul class=\"pagination\">";

        for (int i = 0; i < num_paginas; i++){
            if (i == 0)
                paginacion += "<li><a id=\"0\" href = \"javascript:mostrarPaginaN(" + i + ")\">" + (i + 1) + "</a></li>";
            else
                paginacion += "<li ><a id=\"" + i + "\" href = \"javascript:mostrarPaginaN(" + i + ")\">" + (i + 1) + "</a></li>";

            //paginacion += "<img id=\"" + i + "\" src=\"./Imagenes/icon-elasticsearch.png\" onclick=\"mostrarPaginaN(this.id)\"  width=\"32\" height=\"32\" />";
        }

        paginacion += "</ul>";
        int ya = 0;

        for (int i = 0; i < num_paginas; i++) {
            for (int j = 0; j < resultados_por_pagina && ya<total_resultados; j++){
                Session["resultadopagina" + i.ToString()] += todosresult[i * resultados_por_pagina + j].ToString();
                ya++;
            }
            string er = Session["resultadopagina" + i.ToString()].ToString();
        }


        if (!IsPostBack){
            ResultadoDeBusquedaGeneral.InnerHtml = Session["resultadopagina0"].ToString();
            divpaginacion.InnerHtml = paginacion;
        }
        else ResultadoDeBusquedaGeneral.InnerHtml = Session["resultadopagina0"].ToString();

    }


    public void Busquedanormal(object sender, EventArgs e){
        string consulta = entradaBusqueda.Text;
        var p = OperacionesElasticSearch.BusquedaAgregation2(consulta);
        int num_agg = p.Count();
        string aggregations = "";
        List<string> agregaciones = new List<string>();
        aggregations += "<h3> Departamentos: </h3> ";
        for (int i = 0; i < num_agg; i++){
            agregaciones.Add(p[i].Key);
            aggregations += "<a id=\"" + p[i].Key + "\" onclick=\"mifuncion(this.id)\" href=\"#\"> " + p[i].Key + "(" + p[i].DocCount + ")</a><br>";
            Session[p[i].Key] = OperacionesElasticSearch.BusquedaFiltro(p[i].Key, consulta);
        }

        Session["agregaciones"] = aggregations;
        Session["consulta"] = consulta;

        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> resultado = OperacionesElasticSearch.SuperConsultaES(consulta);

        List<ResultadoDeBusqueda> resultado_imagenes = OperacionesElasticSearch.SuperConsulta_ImagenesES(consulta, 6);

        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["resultado"] = resultado;
        if (resultado_imagenes.Count > 0)
            Session["imagenes"] = resultado_imagenes;

        Response.Redirect("ResultadoBusquedaGeneral.aspx");

    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void actualizarhits(string url){
        OperacionesElasticSearch.AddHit(url);
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> obtenerSugerencias(string prefixText)
    {
        //string prefixText = entradaBusqueda.Text;
        SuperControladora instanciaSuperControladora = new SuperControladora();

        List<string> sugerencias = OperacionesElasticSearch.ConsultaAutoCompletarES(prefixText);

        /*foreach (var sugerencia in sugerencias){
            if (sugerencia.Length > 70)
                    sugerencias.Add(sugerencia.Remove(70));
            else
                    sugerencias.Add(sugerencia);
        }*/
        return sugerencias;


    }
}