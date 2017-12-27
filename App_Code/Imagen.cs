using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Imagen
/// </summary>
public class Imagen
{
    public int hits;
    public long pixelesAltura;
    public long pixelesAnchura;
    public List<string> etiquetas;
    public string idServidor;
    public string urlProtocolo;
    public int urlPuerto;
    public string urlRuta;
    public string formato;
    public int estadoActividad;
    public string nombreArchivo;
    public string autorArchivo;
    public DateTime fechaCreacionArchivo;
    public DateTime fechaModificacionArchivo;
    public DateTime fechaUltimaActualizacion;
    public double tamanoArchivo;
    public string departamento;
    public DateTime fechaUltimaLectura;
}