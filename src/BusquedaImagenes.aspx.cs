using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusquedaImagenes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<ResultadoDeBusqueda> resultadosmasBuscados = OperacionesElasticSearch.masVisitadosImagenes();
        int total_resultados = resultadosmasBuscados.Count;

        List<string> todosresult = new List<string>();
        string result = "";

        for (int i = 0; i < total_resultados; i++)
        {

            string icono_archivo = "";

            switch (resultadosmasBuscados[i].formato)
            {
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
                default:
                    break;

            }

            string departamento = "";
            if (resultadosmasBuscados[i].departamento != null && resultadosmasBuscados[i].departamento.Equals("") == false)
            {
                departamento = "[" + resultadosmasBuscados[i].departamento.ToString() + "] ";
            }

            result += "<div>";
            result += "<img src=\"" + resultadosmasBuscados[i].urlRuta + "\" width=\"32\" height=\"32\" />" + departamento + "<a href=\"" + resultadosmasBuscados[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\" onclick=\"javascript:actualizahits('" + resultadosmasBuscados[i].urlRuta + "')\"><b>" + resultadosmasBuscados[i].nombrearchivo + "</b></a>";
            result += "<br><img src=\"./Imagenes/icono_ojo.png\" width=\"16\" height=\"16\" /> " + resultadosmasBuscados[i].hits + "<p><font color=\"green\">" + resultadosmasBuscados[i].urlRuta + "</font></br>";
            result += "</div>";
            result += "</br>";
        }

        masvisitados.InnerHtml = result;

        }

    public void busquedaImagenes(object sender, EventArgs e){
        String consulta = entradaBusquedaimg.Text;
        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> resultado_imagenes = OperacionesElasticSearch.SuperConsulta_ImagenesES(consulta, 20);
        Session["consulta"] = consulta;
        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["imagenes"] = resultado_imagenes;
        Response.Redirect("ResultadoBusquedaImagen.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> obtenerSugerencias(string prefixText){
        //string prefixText = entradaBusqueda.Text;
        SuperControladora instanciaSuperControladora = new SuperControladora();

        List<string> sugerencias = OperacionesElasticSearch.ConsultaAutoCompletarImagenesES(prefixText);

        /*<foreach (var sugerencia in sugerencias){
            if (sugerencia.Length > 70)
                    sugerencias.Add(sugerencia.Remove(70));
            else
                    sugerencias.Add(sugerencia);
        }*/
        return sugerencias;
    }


}