using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Texto
/// </summary>
public class Texto
{

    public int hits;
    public string titulo;
    public string textoContenido;
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
    public int ratingActualizacion;

    public string DameIdServidor(){
        return idServidor;
    }

    public string DameUrlProtocolo(){
        return urlProtocolo;
    }

    public int DamePuerto(){
        return urlPuerto;
    }

    public string DameUrlRuta(){
        return urlRuta;
    }

    public string DameFormato(){
        return formato;
    }

    public string DameNombreArchivo(){
        return nombreArchivo;
    }

    public string DameAutorArchivo(){
        return autorArchivo;
    }

    public DateTime DameFechaModificacionArchivo(){
        return fechaModificacionArchivo;
    }


    public Texto()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}