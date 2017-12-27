using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusquedaVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ResultadoDeBusqueda> resultadosmasBuscados = OperacionesElasticSearch.masVisitadosVideos();
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
                case ".docx":
                    icono_archivo = "./Imagenes/icono-word.png";
                    break;
                case ".pdf":
                    icono_archivo = "./Imagenes/icono-pdf.png";
                    break;
                default:
                    icono_archivo = "./Imagenes/icono-video.png";
                    break;

            }

            string departamento = "";
            if (resultadosmasBuscados[i].departamento != null && resultadosmasBuscados[i].departamento.Equals("") == false)
            {
                departamento = "[" + resultadosmasBuscados[i].departamento.ToString() + "] ";
            }

            result += "<div>";
            result += "<img src=\"" + icono_archivo + "\" width=\"32\" height=\"32\" />" + departamento + "<a href=\"" + resultadosmasBuscados[i].urlRuta + "\" target=\"_blank\" style=\"font-size:16px;\" onclick=\"javascript:actualizahits('" + resultadosmasBuscados[i].urlRuta + "')\"><b>" + resultadosmasBuscados[i].nombrearchivo + "</b></a>";
            result += "<br><img src=\"./Imagenes/icono_ojo.png\" width=\"16\" height=\"16\" /> " + resultadosmasBuscados[i].hits + "<p><font color=\"green\">" + resultadosmasBuscados[i].urlRuta + "</font></br>";
            result += "</div>";
            result += "</br>";

        }

        masvisitados.InnerHtml = result;
    }

    public void busquedaVideo(object sender, EventArgs e){
        String consulta = entradaBusquedavideo.Text;
        DateTime antes = DateTime.Now;
        List<ResultadoDeBusqueda> lista_videos = OperacionesElasticSearch.SuperConsulta_VideoES(consulta);
        Session["consulta"] = consulta;
        Session["tiempotranscurrido"] = (int)(DateTime.Now - antes).TotalMilliseconds;
        Session["videos"] = lista_videos;
        Response.Redirect("ResultadoBusquedaVideo.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> obtenerSugerencias(string prefixText)
    {

        List<string> sugerencias = OperacionesElasticSearch.ConsultaAutoCompletarVideoES(prefixText);

        /*foreach (var sugerencia in sugerencias){
            if (sugerencia.Length > 70)
                sugerencias.Add(sugerencia.Remove(70));
            else
                sugerencias.Add(sugerencia);
        }*/
        return sugerencias;
    }
}