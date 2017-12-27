using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ResultadoDeBusqueda
/// </summary>
public class ResultadoDeBusqueda
{
    public int hits;
    public string textocontenido;
    public string idServidor;
    public string urlProtocolo;
    public int urlPuerto;
    public string urlRuta;
    public string formato;
    public int estadoActividad;
    public string nombrearchivo;
    public string autorArchivo;
    public DateTime fechaCreacionArchivo;
    public DateTime fechaModificacionArchivo;
    public DateTime fechaUltimaActualizacion;
    public double tamanoArchivo;
    public string departamento;
    public DateTime fechaUltimaLectura;
    public int ratingActualizacion;
    public int puntaje;
    public int pixelesAltura;
    public int pixelesAnchura;
    public List<string> etiquetas;
    public int duracion;
    public string tipo;
    public string calidad;
}