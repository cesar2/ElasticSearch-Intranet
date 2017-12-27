using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusquedaGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){

        List<ResultadoDeBusqueda> resultadosmasBuscados = OperacionesElasticSearch.masVisitados();
        int total_resultados = resultadosmasBuscados.Count;

        List<string> todosresult = new List<string>();
        string result = "" ;

        for (int i = 0; i < total_resultados; i++){
            
            string icono_archivo = "";

            switch (resultadosmasBuscados[i].formato){
                case ".html":
                    icono_archivo = "./Imagenes/icono-html.png";
                    break;
                case ".pptx":
                    icono_archivo = "./Imagenes/icono-pptx.png";
                    break;
                case ".xlsx":
                    icono_archivo = "./Imagenes/icono-excel.png";
                    break;
                case ".docx":
                case ".doc":
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
            if (resultadosmasBuscados[i].departamento != null && resultadosmasBuscados[i].departamento.Equals("") == false)
            {
                departamento = "[" + resultadosmasBuscados[i].departamento.ToString() + "] ";
            }

            result += "<div>";
            result += "<img src=\"" + icono_archivo + "\" width=\"32\" height=\"32\" />" + departamento + "<a href=\"" + resultadosmasBuscados[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\" onclick=\"javascript:actualizahits('" + resultadosmasBuscados[i].urlRuta + "')\"><b>" + resultadosmasBuscados[i].nombrearchivo + "</b></a>";
            result += "<br><img src=\"./Imagenes/icono_ojo.png\" width=\"16\" height=\"16\" /> "+ resultadosmasBuscados[i].hits + "<p><font color=\"green\">" + resultadosmasBuscados[i].urlRuta + "</font></br>";
            result += "</div>";
            result += "</br>";
                  
        }

        masvisitados.InnerHtml = result;

    }

    public void Busquedanormal(object sender, EventArgs e)
    {
        
        string consulta = txtCity.Text;

        // PRUEBAS  PARA LAS AGREGACIONES
        var p = OperacionesElasticSearch.BusquedaAgregation2(consulta);
        int num_agg = p.Count();
        string aggregations = "";
        List<string> agregaciones = new List<string>();
        aggregations += "<h3> Departamentos: </h3> ";
        for (int i = 0; i < num_agg; i++){
            agregaciones.Add(p[i].Key);
            if (i == 0)
                aggregations += "<a id=\"resultado\" onclick=\"mostrarTodos(this.id)\" href=\"#\"> TODOS </a> <br>";


            aggregations += "<a id=\"" + p[i].Key + "\" onclick=\"mifuncion(this.id)\" href=\"#\"> " + p[i].Key + "(" + p[i].DocCount + ")</a><br>";

            Session[p[i].Key] = OperacionesElasticSearch.BusquedaFiltro(p[i].Key, consulta);

        }

        Session["agregaciones"] = aggregations;


        // FIN PRUEBAS


        Session["consulta"] = consulta;

        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> resultado = OperacionesElasticSearch.SuperConsultaES(consulta);

        List<ResultadoDeBusqueda> resultado_imagenes = OperacionesElasticSearch.SuperConsulta_ImagenesES(consulta, 6);

        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["resultado"] = resultado;
        if (resultado_imagenes.Count > 0)
            Session["imagenes"] = resultado_imagenes;
        else
            Session["imagenes"] = "";

        Response.Redirect("ResultadoBusquedaGeneral.aspx");

    }

    public void MostrarPaginaN(object sender, EventArgs e){
        Response.Redirect("ResultadoBusquedaGeneral.aspx");

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