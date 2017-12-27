using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfiguracionAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void indexacionGeneral(object sender, EventArgs e)
    {
        Session["consulta"] = "";
        Session["audios"] = "";
        Session["videos"] = "";
        Session["imagenes"] = "";
        Session["resultado"] = "";
        Session["agregaciones"] = "";
        string tipo = listaTipos.SelectedValue;
        string dpto = listadptos.SelectedValue;
        string servidor = listaservidores.SelectedValue;
        string sem = semilla.Text;

        Crawler.IndexarDocumentos(tipo, servidor, dpto, sem, false);
    }

    public void borradoGeneral(object sender, EventArgs e)
    {
        OperacionesElasticSearch.BorradoGeneral();
    }

    public void borradoPorTipo(object sender, EventArgs e)
    {
        String tipo = BorradodeTipo.Text;
        OperacionesElasticSearch.BorradoPorTipo(tipo);
    }


    public void borradoPorServidor(object sender, EventArgs e)
    {
        string servidor = borradoServ.Text;
        OperacionesElasticSearch.BorradoPorServidor(servidor);
    }

    public void borradoPorDpto(object sender, EventArgs e)
    {
        string dpto = listaBorradoDpto.SelectedValue;
        OperacionesElasticSearch.BorradoDepartamento(dpto);
    }

    public void borradoPorUrl(object sender, EventArgs e)
    {
        string url = borradoUrl.Text;
        if (url.Equals("") == false)
            OperacionesElasticSearch.BorradoPorUrl(url);
    }

    public void actualizacionGeneral(object sender, EventArgs e)
    {
        string tipo = tipoActualizar.SelectedValue;
        string dpto = dptoActualizar.SelectedValue;
        string servidor = servidorActualizar.SelectedValue;
        string sem = actualizacionPorUrl.Text;

        Crawler.IndexarDocumentos(tipo, servidor, dpto, sem, true);

    }

}