using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using Newtonsoft.Json;

/// <summary>
/// Descripción breve de OperacionesElasticSearch
/// </summary>
public class OperacionesElasticSearch
{


    #region Inserciones (INDEX)

    #region HiperTexto

    public static IIndexResponse InsertarHiperTexto(Hipertexto pNuevoHiperTexto)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        // Creamos el ContenidoWeb con el ID del padre (parámetro)
        IIndexResponse respuestaInsercion = controladoraDeInicio.GetClienteES().Index(pNuevoHiperTexto, idx => idx.Type("hipertexto"));

        return respuestaInsercion;
    }

    #endregion


    #region Texto


    public static IIndexResponse InsertarTexto(Texto pNuevoTexto)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        // Creamos el ContenidoWeb con el ID del padre (parámetro)
        IIndexResponse respuestaInsercion = controladoraDeInicio.GetClienteES().Index(pNuevoTexto, idx => idx.Type("texto"));

        return respuestaInsercion;
    }
    #endregion


    #region Imagenes

    public static IIndexResponse InsertarImagen(Imagen pNuevaImagen)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        // Creamos el ContenidoWeb con el ID del padre (parámetro)
        IIndexResponse respuestaInsercion = controladoraDeInicio.GetClienteES().Index(pNuevaImagen, idx => idx.Type("imagen"));

        return respuestaInsercion;
    }


    #endregion


    #region Audio

    public static IIndexResponse InsertarAudio(Audio pNuevoAudio)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        // Creamos el ContenidoWeb con el ID del padre (parámetro)
        IIndexResponse respuestaInsercion = controladoraDeInicio.GetClienteES().Index(pNuevoAudio, idx => idx.Type("audio"));

        return respuestaInsercion;
    }

    #endregion


    #region Video

    public static IIndexResponse InsertarVideo(Video pNuevoVideo/*, string pIdPadre*/)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
        //pNuevoVideo.id = pIdPadre;

        // Creamos el ContenidoWeb con el ID del padre (parámetro)
        IIndexResponse respuestaInsercion = controladoraDeInicio.GetClienteES().Index(pNuevoVideo);//, idx => idx.Type("video")/*.Parent(pIdPadre)*/);

        return respuestaInsercion;
    }

    #endregion


    #endregion



    #region Actualizaciones (UPDATE)


    #region HiperTexto
/*
    public static IUpdateResponse<Hipertexto> actualizarHiperTexto(Hipertexto pHiperTextoActualizar, string pId)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        IUpdateResponse<Hipertexto> resultado = controladoraDeInicio.getClienteES().Update<Hipertexto, Hipertexto>(pId, descriptor => descriptor
        .Doc(new Hipertexto
        {
            id = pId,
            textoContenido = pHiperTextoActualizar.textoContenido,
            nombreArchivo = pHiperTextoActualizar.nombreArchivo
        }));

        return resultado;
    }
    */

    #endregion


    #region Texto
    /*
public static IUpdateResponse<Texto> actualizarTexto(Texto pTextoActualizar, string pId)
{
    SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

    IUpdateResponse<Texto> resultado = controladoraDeInicio.getClienteES().Update<Texto, Texto>(pId, descriptor => descriptor
    .Parent(pId)
    .Doc(new Texto
    {
        id = pId,
        textoContenido = pTextoActualizar.textoContenido
    }));

    return resultado;
}
*/

    #endregion


    #region Imagenes
    /*
    public static IUpdateResponse<Imagen> actualizarImagen(Imagen pImagenActualizar, string pId)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        IUpdateResponse<Imagen> resultado = controladoraDeInicio.getClienteES().Update<Imagen, Imagen>(pId, descriptor => descriptor
        .Parent(pId)
        .Doc(new Imagen
        {
            id = pId,
            pixelesAltura = pImagenActualizar.pixelesAltura,
            pixelesAnchura = pImagenActualizar.pixelesAnchura,
            etiquetas = pImagenActualizar.etiquetas
        }));

        return resultado;
    }*/

    #endregion


    #region Audio
    /*
        public static IUpdateResponse<Audio> actualizarAudio(Audio pAudioActualizar, string pId)
        {
            SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

            IUpdateResponse<Audio> resultado = controladoraDeInicio.getClienteES().Update<Audio, Audio>(pId, descriptor => descriptor
            .Parent(pId)
            .Doc(new Audio
            {
                id = pId,
                duracion = pAudioActualizar.duracion,
                etiquetas = pAudioActualizar.etiquetas
            }));

            return resultado;
        }
        */
    #endregion


    #region Video
    /*
public static IUpdateResponse<Video> actualizarVideo(Video pVideoActualizar, string pId)
{
    SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

    IUpdateResponse<Video> resultado = controladoraDeInicio.getClienteES().Update<Video, Video>(pId, descriptor => descriptor
    .Parent(pId)
    .Doc(new Video
    {
        id = pId,
        calidad = pVideoActualizar.calidad,
        duracion = pVideoActualizar.duracion,
        etiquetas = pVideoActualizar.etiquetas,
    }));

    return resultado;
}*/

    #endregion


    #endregion



    #region Consultas (SEARCH - QUERY)


    #region Registros TEMP

    /*
    public static temp2 obtenerTempPorID(string pIdTemp)
    {
        ControladoraDeInicio controladoraDeInicio = ControladoraDeInicio.getControladoraDeInicio();

        var resultado = controladoraDeInicio.getClienteES().Search<temp2>(s => s
         .Size(1)
         .Type(Types.Type("temp"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.id).Value(pIdTemp))))));

        temp2 tempSeleccionado = resultado.Documents.FirstOrDefault();

        return tempSeleccionado;
    }


    // ATENCIÓN: Si se obtiene un temp no evaluado con ID == NULL, entonces le asignará el id de los metadatos (_id)
    public static temp2 dameTempNoEvaluado(servidores pServidor, aplicacionesdeservidores pAplicacionDeServidor)
    {
        ControladoraDeInicio controladoraDeInicio = ControladoraDeInicio.getControladoraDeInicio();
        ISearchResponse<temp2> resultado = null;

        if (pAplicacionDeServidor != null)
        {
            string urlRutaBuscado = "/" + pAplicacionDeServidor.rutaRelativa + "*";
            resultado = controladoraDeInicio.getClienteES().Search<temp2>(s => s
                .Type(Types.Type("temp"))
                .Size(1)
                .Query(q =>
                    //(q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.urlRuta.Substring(1, numeroCaracteres).ToUpper()).Value(pAplicacionDeServidor.rutaRelativa.ToUpper())))))
                    //(q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.urlRuta.ToUpper()).Value(urlRutaBuscado)))))
                    //(q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("urlRuta.keyword").Value(urlRutaBuscado)))))
                    //(q.MatchPhrasePrefix(m => m.Field(f => f.urlRuta).Query(urlRutaBuscado).MaxExpansions(10)))
                    (q.MatchPhrasePrefix(m => m.Field("urlRuta.text").Query(urlRutaBuscado)))
                    && !+q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.evaluado).Value(2))))
               ));
        }
        else if (pServidor != null)
        {
            resultado = controladoraDeInicio.getClienteES().Search<temp2>(s => s
                .Type(Types.Type("temp"))
                .Size(1)
                .Query(q =>
                    (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.idServidor).Value(pServidor.id)))))
                  && !+q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.evaluado).Value(2)))) // || q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field(fie => fie.evaluado).Value(null))))
                //&& +q.Bool(bo => bo.Filter(fil => fil.Bool(b => b.MustNot(ms => ms.Term(te => te.Field(fi => fi.idServidor).Value(null)))))) 
                //&& +q.Bool(bo => bo.Filter(fil => fil.Bool(b => b.MustNot(ms => ms.Term(te => te.Field(fi => fi.urlRuta).Value(null))))))
               ));
        }
        else     // Carga normal
        {
            resultado = controladoraDeInicio.getClienteES().Search<temp2>(s => s // probar con <temp2>
                 .Type(Types.Type("temp"))
                 .Size(1)
                 .Query(q =>
                    (!q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.evaluado).Value(2)))))        // || q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field(fie => fie.evaluado).Value(null)))))   
                //&& +q.Bool(bo => bo.Filter(fil => fil.Bool(b => b.MustNot(ms => ms.Term(te => te.Field(fi => fi.idServidor).Value(null)))))) 
                //&& +q.Bool(bo => bo.Filter(fil => fil.Bool(b => b.MustNot(ms => ms.Term(te => te.Field(fi => fi.urlRuta).Value(null)))))) 
                ));
        }


        temp2 tempNoEvaluado = resultado.Documents.FirstOrDefault();
        if (tempNoEvaluado != null)
        { 
            // IMPORTANTE: Si el tempNoEvaluado no tiene id, lo tomará del UID de sus propios metadatos
            if (tempNoEvaluado.id == null)
            {
                var resultadosParaID = resultado.Hits.Select(hit =>
                {
                    var resultadoParaId = hit.Source;
                    resultadoParaId.id = hit.Id;
                    tempNoEvaluado.id = hit.Id;
                    return resultadoParaId;
                });

                tempNoEvaluado.id = resultadosParaID.FirstOrDefault().id;
            }
        }

        return tempNoEvaluado;
    }



    public static temp2 estaContenidoEnTemp(temp2 pNuevoTemp)
    {
        ControladoraDeInicio controladoraDeInicio = ControladoraDeInicio.getControladoraDeInicio();

        var resultado = controladoraDeInicio.getClienteES().Search<temp2>(s => s
            .Size(1)
            .Type(Types.Type("temp"))
            .Query(q =>
                q.Bool(b =>
                    b.Filter(fi => fi.Term(t => t.Field(f => f.idServidor).Value(pNuevoTemp.idServidor))
                                && +fi.Term(t => t.Field(f => f.urlRuta).Value(pNuevoTemp.urlRuta))
                                && +fi.Term(t => t.Field(f => f.urlPuerto).Value(pNuevoTemp.urlPuerto))
                                && +fi.Term(t => t.Field(f => f.urlProtocolo).Value(pNuevoTemp.urlProtocolo))
                    )
                )
             )
        );

        temp2 temp_final = resultado.Documents.FirstOrDefault();
        return temp_final;
    }
*/

    #endregion

    /*
        #region Contenidos Web


            /*
        public static ContenidoWeb obtenerContenidoWebPorID(string pIdCw)
        {
            SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

            var resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
             .Size(1)
             .Type(Types.Type("contenidosweb"))
             .Query(q =>
                 q.Bool(b => b
                    .Filter(f => f
                        .Term(t => t
                            .Field(f2 => f2.id).Value(pIdCw))))));

            ContenidoWeb contenidoWebSeleccionado = resultado.Documents.FirstOrDefault();

            return contenidoWebSeleccionado;
        }
        /*
        /*
        public static List<ContenidoWeb> obtenerContenidosWeb_Actualizacion(int pNumeroCW_actualizar, servidores pServidor, aplicaciones pAplicacion, aplicacionesdeservidores pAplicacionDeServidor)
        {
            SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
            ISearchResponse<ContenidoWeb> resultado;


            if (pAplicacion != null)                // Carga por aplicación
            {
                resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
                 .Size(pNumeroCW_actualizar)
                 .Type(Types.Type("contenidosweb"))
                 .Query(q =>
                        (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("nombreAplicacionBis.keyword").Value(pAplicacion.nombre))))))
                 .Sort(ss => ss.Ascending(p => p.fechaUltimaLectura))
                 );
            }

            else if (pServidor != null)             // Carga por servidor
            {
                resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
                 .Size(pNumeroCW_actualizar)
                 .Type(Types.Type("contenidosweb"))
                 .Query(q =>
                    (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field(fie => fie.idServidor).Value(pServidor.id))))))
                 .Sort(ss => ss.Ascending(p => p.fechaUltimaLectura))
                 );
            }

            else                                    // Carga normal
            {
                resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
                 .Size(pNumeroCW_actualizar)
                 .Type(Types.Type("contenidosweb"))
                 .Sort(ss => ss.Ascending(p => p.fechaUltimaLectura))
                 );
            }

            return resultado.Documents.ToList();
        }
        */

    // OJO: urlRuta se calcula mientras que urlPuerto se obtiene del parámetro, contradictorio

    /*
public static ContenidoWeb estaContenidoEnCW(ContenidoWeb cw, TempExtendido tempExtendido)
{
    SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
    string urlRuta = Herramientas.obtenerUrlRuta(cw.dameUrl());     // ¿QUE HACE ESTA LINEA AQUI??


    var resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
        .Size(1)
        .Type(Types.Type("contenidosweb"))
        .Query(q =>
            q.Bool(b =>
                b.Filter(fi => fi.Term(t => t.Field(f => f.idServidor).Value(tempExtendido.servidor.id))
                           && +fi.Term(t => t.Field(f => f.urlRuta).Value(tempExtendido.temp.urlRuta))
                           && +fi.Term(t => t.Field(f => f.urlPuerto).Value(tempExtendido.temp.urlPuerto))
                           && +fi.Term(t => t.Field(f => f.urlProtocolo).Value(tempExtendido.temp.urlProtocolo))
                )
            )
         )
    );

    ContenidoWeb contenidosWebSeleccionado = resultado.Documents.FirstOrDefault();
    return contenidosWebSeleccionado;
}
*/
    /*
    // OJO: urlRuta se calcula mientras que urlPuerto se obtiene del parámetro, contradictorio
    public static ContenidoWeb estaContenidoEnCW(Uri pUri, servidores pServidor)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.getClienteES().Search<ContenidoWeb>(s => s
            .Size(1)
            .Type(Types.Type("contenidosweb"))
            .Query(q =>
                q.Bool(b =>
                    b.Filter(fi => fi.Term(t => t.Field(f => f.idServidor).Value(pServidor.id))
                               && +fi.Term(t => t.Field(f => f.urlRuta).Value(pUri.PathAndQuery))
                               && +fi.Term(t => t.Field(f => f.urlPuerto).Value(pUri.Port))
                               && +fi.Term(t => t.Field(f => f.urlProtocolo).Value(pUri.Scheme))
                    )
                )
             )
        );


        ContenidoWeb contenidosWebSeleccionado = resultado.Documents.FirstOrDefault();
        return contenidosWebSeleccionado;
    }
    */
    #endregion


    #region HiperTexto
    /*
public static Hipertexto obtenerHiperTextoPorID(string pIdHiperTexto)
{
    SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

    var resultado = controladoraDeInicio.getClienteES().Search<Hipertexto>(s => s
     .Size(1)
     .Type(Types.Type("hipertexto"))
     .Query(q =>
         q.Bool(b => b
            .Filter(f => f
                .Term(t => t
                    .Field(f2 => f2.id).Value(pIdHiperTexto))))));

    Hipertexto hipertextoSeleccionado = resultado.Documents.FirstOrDefault();

    return hipertextoSeleccionado;
}
*/


    #endregion


    #region Texto
    /*
    public static Texto obtenerTextoPorID(string pIdTexto)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.getClienteES().Search<Texto>(s => s
         .Size(1)
         .Type(Types.Type("texto"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.id).Value(pIdTexto))))));

        Texto textoSeleccionado = resultado.Documents.FirstOrDefault();

        return textoSeleccionado;
    }
    */
    // Usado para la CARGA

    #endregion


    #region Imágenes
    /*
    public static Imagen obtenerImagenPorID(string pIdImagen)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.getClienteES().Search<Imagen>(s => s
         .Size(1)
         .Type(Types.Type("imagen"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.id).Value(pIdImagen))))));

        Imagen imagenSeleccionada = resultado.Documents.FirstOrDefault();

        return imagenSeleccionada;
    }
    */

    // PTE. PROBAR
    /*
    public static bool existeImagen_Duplicidades(ContenidoWeb pCw, aplicacionesdeservidores pAplicacionesDeServidores, int pPixelesAltura, int pPixelesAnchura)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
        aplicaciones aplicacion = Herramientas.obtenerAplicacionPorId(pAplicacionesDeServidores.idAplicacion);


        var resultado = controladoraDeInicio.getClienteES().Search<Imagen>(s => s
            .Type(Types.Type("imagen"))
            .Size(1)
            .Query(q =>
                q.Bool(b =>
                    b.Filter(fi => fi.Term(t => t.Field(f => f.pixelesAltura).Value(pPixelesAltura))
                               && +fi.Term(t => t.Field(f => f.pixelesAnchura).Value(pPixelesAnchura))
                    )
                )
                && q.HasParent<ContenidoWeb>(p => p
                    .Type("contenidosweb")
                    .Query(q2 => q2
                        .Bool(b => b
                            .Filter(fi => fi.Term(t => t.Field("formato.keyword").Value(pCw.formato))
                                        && +fi.MatchPhrase(t => t.Field(fi2 => fi2.nombreArchivo).Query(pCw.nombreArchivo))
                                        && +fi.Term(t => t.Field("nombreAplicacionBis.keyword").Value(aplicacion.nombre))
                            )
                         )
                    )
                )
            ));


        if (resultado.Documents.Count == 0)
            return false;
        else
            return true;
    }
    */
    #endregion


    public static Texto ExisteTexto(Texto tex)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Texto>(s => s
         .Type(Types.Type("texto"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.urlRuta).Value(tex.urlRuta)))))).Documents;

        if (resultado.Count > 0)
            return resultado.FirstOrDefault();
        else
            return null;


    }

    public static Hipertexto ExisteHipertexto(Hipertexto ht)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Hipertexto>(s => s
         .Type(Types.Type("hipertexto"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.urlRuta).Value(ht.urlRuta)))))).Documents;

        if (resultado.Count > 0)
            return resultado.FirstOrDefault();
        else
            return null;

    }

    public static Imagen ExisteImagen(Imagen im){
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Imagen>(s => s
         .Type(Types.Type("imagen"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.urlRuta).Value(im.urlRuta)))))).Documents;

        if (resultado.Count > 0)
            return resultado.FirstOrDefault();
        else
            return null;

    }


    public static Audio ExisteAudio(Audio au)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Audio>(s => s
         .Type(Types.Type("audio"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.urlRuta).Value(au.urlRuta)))))).Documents;

        if (resultado.Count > 0)
            return resultado.FirstOrDefault();
        else
            return null;

    }


    public static Video ExisteVideo(Video vi)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Video>(s => s
         .Type(Types.Type("video"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.urlRuta).Value(vi.urlRuta)))))).Documents;

        if (resultado.Count > 0)
            return resultado.FirstOrDefault();
        else
            return null;

    }


    public static bool BorradoGeneral(){
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().DeleteByQuery<AllField>(q => q
            .AllTypes()
            .Query(rq => rq.MatchAll()));


        return true;
    }

    public static bool BorradoPorTipo(string tipo)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().DeleteByQuery<Texto>(q => q
            .Type(tipo)
            .Query(rq => rq.MatchAll()));

        return true;

    }

    public static bool BorradoPorServidor(string servidor)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().DeleteByQuery<Texto>(q => q
            .AllTypes()
            .Query(rq => rq.Match(ma => ma.Field(fi => fi.idServidor).Query(servidor))));

        return true;

    }

    public static bool BorradoDepartamento(string depart)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().DeleteByQuery<Texto>(q => q
            .AllTypes()
            .Query(rq => rq.Match(ma => ma.Field(fi => fi.departamento).Query(depart))));

        return true;

    }

    public static bool BorradoPorUrl(string url)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().DeleteByQuery<Texto>(q => q
            .AllTypes()
            .Query(rq => rq.Match(ma => ma.Field(fi => fi.urlRuta).Query(url))));

        return true;

    }







    /*
    public static Audio obtenerAudioPorID(string pIdAudio)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.getClienteES().Search<Audio>(s => s
         .Size(1)
         .Type(Types.Type("audio"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.id).Value(pIdAudio))))));

        Audio audioSeleccionado = resultado.Documents.FirstOrDefault();

        return audioSeleccionado;
    }
    */
    /*
    public static Video obtenerVideoPorID(string pIdVideo)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.getClienteES().Search<Video>(s => s
         .Size(1)
         .Type(Types.Type("video"))
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field(f2 => f2.id).Value(pIdVideo))))));

        Video videoSeleccionado = resultado.Documents.FirstOrDefault();

        return videoSeleccionado;
    }

        */


    #region masVisitados

    public static List<ResultadoDeBusqueda> masVisitados()
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(5)
         .Type(Types.Type("hipertexto", "texto"))
         .Sort(ss => ss.Descending("hits"))
         .Query(q => q.MatchAll())
        );



        int i = 0;
        string id = "0";
        var tipoDocumento = "";
        var hits = resultado.Hits.ToList();
        var listaResultados = resultado.Documents.ToList();

        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();

        foreach (dynamic objeto in listaResultados)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();

            tipoDocumento = hits[i].Type;

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.hits = objeto.hits;


            // PROBLEMÓN: Hay algunas URL que vienen vacias y no sé porque, pero con que haya al menos una fastidia la búsqueda
            if (resultadoDeBusqueda.urlRuta != null)
                if (resultadoDeBusqueda.urlRuta.Trim() != "")
                    lista_resultados.Add(resultadoDeBusqueda);

        }


        lista_resultados = lista_resultados.OrderByDescending(x => x.puntaje).ToList();
        return lista_resultados;
    }

    public static List<ResultadoDeBusqueda> masVisitadosImagenes()
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Imagen>(s => s
         .Size(5)
         .Type(Types.Type("imagen"))
         .Sort(ss => ss.Descending(img => img.hits))
         .Query(q => q.MatchAll())
        );

        int i = 0;
        var tipoDocumento = "";
        var hits = resultado.Hits.ToList();
        var listaResultados = resultado.Documents.ToList();

        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();

        foreach (dynamic objeto in listaResultados)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();

            tipoDocumento = hits[i].Type;

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.hits = objeto.hits;


            // PROBLEMÓN: Hay algunas URL que vienen vacias y no sé porque, pero con que haya al menos una fastidia la búsqueda
            if (resultadoDeBusqueda.urlRuta != null)
                if (resultadoDeBusqueda.urlRuta.Trim() != "")
                    lista_resultados.Add(resultadoDeBusqueda);

        }


        lista_resultados = lista_resultados.OrderByDescending(x => x.puntaje).ToList();
        return lista_resultados;
    }


    public static List<ResultadoDeBusqueda> masVisitadosAudios()
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Audio>(s => s
         .Size(5)
         .Type(Types.Type("audio"))
         .Sort(ss => ss.Descending(img => img.hits))
         .Query(q => q.MatchAll())
        );

        int i = 0;
        var tipoDocumento = "";
        var hits = resultado.Hits.ToList();
        var listaResultados = resultado.Documents.ToList();

        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();

        foreach (dynamic objeto in listaResultados)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();

            tipoDocumento = hits[i].Type;

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.hits = objeto.hits;


            // PROBLEMÓN: Hay algunas URL que vienen vacias y no sé porque, pero con que haya al menos una fastidia la búsqueda
            if (resultadoDeBusqueda.urlRuta != null)
                if (resultadoDeBusqueda.urlRuta.Trim() != "")
                    lista_resultados.Add(resultadoDeBusqueda);

        }


        lista_resultados = lista_resultados.OrderByDescending(x => x.puntaje).ToList();
        return lista_resultados;
    }


    public static List<ResultadoDeBusqueda> masVisitadosVideos()
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Video>(s => s
         .Size(5)
         .Type(Types.Type("video"))
         .Sort(ss => ss.Descending(img => img.hits))
         .Query(q => q.MatchAll())
        );

        int i = 0;
        var tipoDocumento = "";
        var hits = resultado.Hits.ToList();
        var listaResultados = resultado.Documents.ToList();

        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();

        foreach (dynamic objeto in listaResultados)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();

            tipoDocumento = hits[i].Type;

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.hits = objeto.hits;


            // PROBLEMÓN: Hay algunas URL que vienen vacias y no sé porque, pero con que haya al menos una fastidia la búsqueda
            if (resultadoDeBusqueda.urlRuta != null)
                if (resultadoDeBusqueda.urlRuta.Trim() != "")
                    lista_resultados.Add(resultadoDeBusqueda);

        }


        lista_resultados = lista_resultados.OrderByDescending(x => x.puntaje).ToList();
        return lista_resultados;
    }

    #endregion

    #region SuperConsultasES

    public static List<ResultadoDeBusqueda> SuperConsultaES(string pTextoBusqueda)
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        // ------ PARTE 1/3: Generamos SLOP + tipoHighLight + pTextoBusqueda
        string tipoHighLight = "fvh";
        int slop = 0, numeroPalabrasFraseBusqueda;

        // Las resoluciones y las normas suelen llevar un caracter '/' o '\', estas son a priori consideradas como espacios en ES
        if (pTextoBusqueda.Contains("/"))
        {
            // Debemos eliminar las palabras que no incluyan '/'
            pTextoBusqueda = pTextoBusqueda.Replace("\u0022", "");      // Quitamos las comillas para que lo entrecomillado no sea considerado como una sola palabra
            List<string> listaPalabras = Herramientas.ObtenerPalabrasDeFrase(pTextoBusqueda);
            foreach (string palabra in listaPalabras)
            {
                if (palabra.Contains("/"))
                {
                    string palabraConBarra = palabra;
                    pTextoBusqueda = palabraConBarra;
                    break;
                }
            }

            numeroPalabrasFraseBusqueda = Herramientas.ObtenerPalabrasDeFrase(pTextoBusqueda.Replace("/", " ")).Count;
            //pTextoBusqueda = pTextoBusqueda.Replace("/", " ");
            if (numeroPalabrasFraseBusqueda > 1) tipoHighLight = "plain";       // OJO: están llegando aquí los artículos
        }
        else    // No lleva '/'
        {
            numeroPalabrasFraseBusqueda = Herramientas.ObtenerPalabrasDeFrase(pTextoBusqueda).Count;

            // Slop
            for (int iterator = 0; iterator <= numeroPalabrasFraseBusqueda; iterator++) slop = slop + iterator;
            slop = slop + 2;

            if (numeroPalabrasFraseBusqueda > 1) tipoHighLight = "plain";       // OJO: están llegando aquí los artículos
        }


        // ------ PARTE 2/3: Búsqueda ES de objetos
        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(200)//elementosMaximosBusquedaWeb)
         .Type(Types.Type("hipertexto", "texto"))
         //.Sort(ss => ss.Descending(p => p.fechaModificacionArchivo))
         .Query(q => q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field("estadoActividad").Value(1))))
                     && +(q.Match(m => m.Field("textoContenido").Query(pTextoBusqueda).Slop(10))
                          || q.Match(m => m.Field("nombreArchivo").Slop(slop).Query(pTextoBusqueda))
                        )
         )
         .Highlight(h => h
                .PreTags("<strong style=\"color:#FF4000;\">")
                .PostTags("</strong>")
                .Fields(fs => fs
                    .Field("textoContenido")
                    .Order("score")
                    //.Type(tipoHighLight)
                    .Type(HighlighterType.Unified)
                    .FragmentSize(150)
                    .NumberOfFragments(3)
                    .NoMatchSize(150)
                    .ForceSource()
                 ))
        );


        // ------ PARTE 3/3: Asignación de objetos a ResultadoDeBusqueda

        int i = 0;  //, idServidor = 0, urlPuerto = 80;
        string id = "0";    //, titulo = "", nombreAplicacionBis = "", formato = "", urlProtocolo = "", urlRuta = "";
        var tipoDocumento = "";                 // = "-1"; Debe inicializarse
        var hits = resultado.Hits.ToList();     // Lista de los hits para obtener las puntuaciones:
        var listaResultados = resultado.Documents.ToList();


        List<string> fragmentos = new List<string>();
        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();

        foreach (dynamic objeto in listaResultados)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();

            tipoDocumento = hits[i].Type;

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;

            if (hits[i].Highlights.Count > 0)
            {
                fragmentos = hits[i].Highlights.FirstOrDefault().Value.Highlights.ToList();
            }

            if (fragmentos.Count == 1)
            {
                resultadoDeBusqueda.textocontenido = fragmentos[0];
                if (resultadoDeBusqueda.textocontenido.Length > 500)
                    resultadoDeBusqueda.textocontenido = resultadoDeBusqueda.textocontenido.Substring(0, 500);
            }
            else if (fragmentos.Count == 2)
                resultadoDeBusqueda.textocontenido = fragmentos[0] + "[...] <br>[...] " + fragmentos[1];
            else if (fragmentos.Count == 3)
                resultadoDeBusqueda.textocontenido = fragmentos[0] + "[...] <br>[...] " + fragmentos[1] + "[...] <br>[...] " + fragmentos[2];
            else
                resultadoDeBusqueda.textocontenido = "Contenido disperso";


            // FACTOR 1: ALGORITMO ELASTICSEARCH
            resultadoDeBusqueda.puntaje = (int)(hits[i].Score * 8);    // Obtenemos la puntuación del documento, pasado a entero.

            // FACTOR 2: FORMATO
            if (tipoDocumento.Equals("texto"))
                resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 3;

            // FACTOR 3: TÍTULOS VACIOS (PENALIZADOR)
            if (resultadoDeBusqueda.nombrearchivo == null) resultadoDeBusqueda.nombrearchivo = "";

            if (resultadoDeBusqueda.nombrearchivo.Trim() == "")
                resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje - 50;

            // FACTOR 5: HITS
            resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje /*+ puntajePorHits*/;

            // FACTOR 6: FECHAMODIFICACION
            TimeSpan ts = resultadoDeBusqueda.fechaModificacionArchivo - DateTime.Now;
            int diferenciaEnDias = Math.Abs(ts.Days);

            if (tipoDocumento.Equals("texto"))
            {
                if (diferenciaEnDias < 3) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 30;
                else if (diferenciaEnDias < 7) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 25;
                else if (diferenciaEnDias < 30) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 20;
                else if (diferenciaEnDias < 120) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 15;
                else if (diferenciaEnDias < 365) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 10;
                else if (diferenciaEnDias < 730) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 5;
                else if (diferenciaEnDias < 1095) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 3;
            }
            else if (tipoDocumento.Equals("hipertexto"))   // Es hipertexto
            {
                if (diferenciaEnDias < 3) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 15;
                else if (diferenciaEnDias < 7) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 10;
                else if (diferenciaEnDias < 30) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 5;
                else if (diferenciaEnDias < 120) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 4;
                else if (diferenciaEnDias < 365) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 3;
                else if (diferenciaEnDias < 730) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 2;
                else if (diferenciaEnDias < 1095) resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje + 1;
            }

            i++;
            // PROBLEMÓN: Hay algunas URL que vienen vacias y no sé porque, pero con que haya al menos una fastidia la búsqueda
            if (resultadoDeBusqueda.urlRuta != null)
                if (resultadoDeBusqueda.urlRuta.Trim() != "")
                    lista_resultados.Add(resultadoDeBusqueda);

        }


        lista_resultados = lista_resultados.OrderByDescending(x => x.puntaje).ToList();
        return lista_resultados;
    }


    public static List<ResultadoDeBusqueda> SuperConsulta_ImagenesES(string pTextoBusqueda, int pNumeroImagenes)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
        DateTime tiempoPrincipioConsulta = DateTime.Now;

        var resultado = controladoraDeInicio.GetClienteES().Search<Imagen>(s => s
         .Type(Types.Type("imagen"))
         .Size(pNumeroImagenes)
         .Query(q => q.MultiMatch(m => m.Fields(fie => fie
                                .Field(fi => fi.etiquetas)
                                .Field(fi => fi.urlRuta))
                                .Query(pTextoBusqueda)))

        ///.Sort(ss => ss.Descending(p => p.fechaModificacionArchivo))
        );

        var lista_contenidosweb = resultado.Documents.ToList();
        var hits = resultado.Hits.ToList();   // Lista de los hits para obtener las puntuaciones.
        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();
        int i = 0;

        foreach (Imagen im in lista_contenidosweb)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
            resultadoDeBusqueda.formato = im.formato;
            resultadoDeBusqueda.departamento = im.departamento;
            resultadoDeBusqueda.urlRuta = im.urlRuta;
            resultadoDeBusqueda.nombrearchivo = im.nombreArchivo;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)im.fechaModificacionArchivo;
            //resultadoDeBusqueda.idRegistroDeBusqueda = (int)pRegistroDeBusqueda.id;
            //resultadoDeBusqueda.puntaje = (int)(hits[i].Score * 10);
            resultadoDeBusqueda.puntaje = 0;
            resultadoDeBusqueda.pixelesAltura = (int)im.pixelesAltura;
            resultadoDeBusqueda.pixelesAnchura = (int)im.pixelesAnchura;
            if (im.etiquetas != null)
                resultadoDeBusqueda.etiquetas = im.etiquetas.ToList();
            lista_resultados.Add(resultadoDeBusqueda);
            i++;
        }


        TimeSpan TiempoFinalConsulta = new TimeSpan(DateTime.Now.Ticks - tiempoPrincipioConsulta.Ticks);
        return lista_resultados;
    }

    
    public static List<ResultadoDeBusqueda> SuperConsulta_AudioES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
        DateTime tiempoPrincipioConsulta = DateTime.Now;

        var resultado = controladoraDeInicio.GetClienteES().Search<Audio>(s => s
        .Type(Types.Type("audio"))
        .Size(20)
        .Query(q =>
            q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field("estadoActividad").Value(1))))
               && ((q.MultiMatch(
                          m => m.Query(pTextoBusqueda).Fields(fie => fie.Field(fi => fi.nombreArchivo).Field(fi => fi.urlRuta))))
               || +q.Match(ma => ma.Field("etiquetas").Query(pTextoBusqueda))))
        //.Sort(ss => ss.Descending(p => p.fechaModificacionArchivo))
        );

        var lista_contenidosweb = resultado.Documents.ToList();
        var hits = resultado.Hits.ToList();   // Lista de los hits para obtener las puntuaciones.
        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();
        int i = 0;

        foreach (Audio au in lista_contenidosweb)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
            resultadoDeBusqueda.formato = au.formato;
            resultadoDeBusqueda.departamento = au.departamento;
            resultadoDeBusqueda.urlRuta = au.urlRuta;
            resultadoDeBusqueda.nombrearchivo = au.nombreArchivo;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)au.fechaModificacionArchivo;
            resultadoDeBusqueda.puntaje = 0;
            List<string> et = new List<string>();
            et.Add("");
            resultadoDeBusqueda.etiquetas = et;

            resultadoDeBusqueda.duracion = (int)au.duracion;
            if (au.etiquetas != null)
                resultadoDeBusqueda.etiquetas = au.etiquetas.ToList();

            lista_resultados.Add(resultadoDeBusqueda);
            i++;
        }

        TimeSpan TiempoFinalConsulta = new TimeSpan(DateTime.Now.Ticks - tiempoPrincipioConsulta.Ticks);
        return lista_resultados;
    }

    public static List<ResultadoDeBusqueda> SuperConsulta_VideoES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();
        DateTime tiempoPrincipioConsulta = DateTime.Now;

        var resultado = controladoraDeInicio.GetClienteES().Search<Video>(s => s
        .Type(Types.Type("video"))
        .Size(1000)
        .Query(q =>
            q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field("estadoActividad").Value(1))))
               && ((q.MultiMatch(
                          m => m.Query(pTextoBusqueda).Fields(fie => fie.Field(fi => fi.nombreArchivo).Field(fi => fi.urlRuta))))
               || +q.Match(ma => ma.Field("etiquetas").Query(pTextoBusqueda))))
        .Sort(ss => ss.Descending(p => p.fechaModificacionArchivo))
        );

        var lista_contenidosweb = resultado.Documents.ToList();
        var hits = resultado.Hits.ToList();   // Lista de los hits para obtener las puntuaciones.
        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();
        int i = 0;

        foreach (Video v in lista_contenidosweb)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
            resultadoDeBusqueda.formato = v.formato;
            resultadoDeBusqueda.departamento = v.departamento;
            resultadoDeBusqueda.urlRuta = v.urlRuta;
            resultadoDeBusqueda.nombrearchivo = v.nombreArchivo;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)v.fechaModificacionArchivo;
            resultadoDeBusqueda.puntaje = 0;
            List<string> et = new List<string>();
            et.Add("");
            resultadoDeBusqueda.etiquetas = et;

            resultadoDeBusqueda.duracion = (int)v.duracion;
            if (v.etiquetas != null)
                resultadoDeBusqueda.etiquetas = v.etiquetas.ToList();

            lista_resultados.Add(resultadoDeBusqueda);
            i++;
        }

        TimeSpan TiempoFinalConsulta = new TimeSpan(DateTime.Now.Ticks - tiempoPrincipioConsulta.Ticks);
        return lista_resultados;
    }

    #endregion


    #region Consultas AutoCompletarES


    public static List<string> ConsultaAutoCompletarES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<string> resultadoBusqueda = new List<string>();

        var fi = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
          .Size(6)
          .Type(Types.Type("texto", "hipertexto"))
          .Source(fs => fs.Includes(inc => inc.Field("nombreArchivo")))
          .Query(q =>
              (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("estadoActividad").Value(1)))) // 20-03-2017
              && +q.MatchPhrasePrefix(
                  m => m.Field("nombreArchivo").Query(pTextoBusqueda))
          )));

        var tipoDocumento = "";             // = "-1"; Debe inicializarse
        var lista_documentos = fi.Documents.ToList();
        string titulo_archivo = "";         // = "-1"; Debe inicializarse

        var hits_resultado = fi.Hits.ToList();
        int i = 0;
        foreach (dynamic ob in lista_documentos)
        {
            tipoDocumento = hits_resultado[i].Type;
            titulo_archivo = JsonConvert.SerializeObject(ob.nombreArchivo);
            titulo_archivo = titulo_archivo.Replace("\"", "");
            i++;
            //resultadoBusqueda.Add(Herramientas.quitarComillas(titulo_archivo));
            resultadoBusqueda.Add(titulo_archivo);
        }


        return resultadoBusqueda;
    }

    public static List<string> ConsultaAutoCompletarImagenesES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<string> resultadoBusqueda = new List<string>();

        var fi = controladoraDeInicio.GetClienteES().Search<Imagen>(s => s
          .Size(6)
          .Type(Types.Type("imagen"))
          .Source(fs => fs.Includes(inc => inc.Field("nombreArchivo")))
          .Query(q =>
              (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("estadoActividad").Value(1))))
              && +q.MatchPhrasePrefix(m => m.Field("nombreArchivo").Query(pTextoBusqueda))
              )
          )
        );

        var lista_documentos = fi.Documents.ToList();
        string titulo_archivo = "";         // = "-1"; Debe inicializarse
        foreach (Imagen im in lista_documentos)
        {
            titulo_archivo = im.nombreArchivo;
            resultadoBusqueda.Add(titulo_archivo);
        }

        return resultadoBusqueda;
    }

    public static List<string> ConsultaAutoCompletarAudioES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<string> resultadoBusqueda = new List<string>();

        var fi = controladoraDeInicio.GetClienteES().Search<Audio>(s => s
          .Size(6)
          .Type(Types.Type("audio"))
          .Source(fs => fs.Includes(inc => inc.Field("nombreArchivo")))
          .Query(q =>
              (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("estadoActividad").Value(1))))
              && +q.MatchPhrasePrefix(m => m.Field("nombreArchivo").Query(pTextoBusqueda))
              )
          )
        );

        var lista_documentos = fi.Documents.ToList();
        string titulo_archivo = "";         // = "-1"; Debe inicializarse
        foreach (Audio au in lista_documentos)
        {
            titulo_archivo = au.nombreArchivo;
            resultadoBusqueda.Add(titulo_archivo);
        }

        return resultadoBusqueda;
    }

    public static List<string> ConsultaAutoCompletarVideoES(string pTextoBusqueda)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<string> resultadoBusqueda = new List<string>();

        var fi = controladoraDeInicio.GetClienteES().Search<Video>(s => s
          .Size(6)
          .Type(Types.Type("video"))
          .Source(fs => fs.Includes(inc => inc.Field("nombreArchivo")))
          .Query(q =>
              (q.Bool(bo => bo.Filter(fil => fil.Term(te => te.Field("estadoActividad").Value(1))))
              && +q.MatchPhrasePrefix(m => m.Field("nombreArchivo").Query(pTextoBusqueda))
              )
          )
        );

        var lista_documentos = fi.Documents.ToList();
        string titulo_archivo = "";         // = "-1"; Debe inicializarse
        foreach (Video v in lista_documentos)
        {
            titulo_archivo = v.nombreArchivo;
            resultadoBusqueda.Add(titulo_archivo);
        }

        return resultadoBusqueda;
    }

    #endregion


    #region pruebasAggregations

    public static string BusquedaAgregation(string st)
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<ResultadoDeBusqueda> resultadoBusqueda = new List<ResultadoDeBusqueda>();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .AllTypes()
         .Query(q => q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field("estadoActividad").Value(1))))
                     && +(q.MatchPhrase(m => m.Field("textoContenido").Query(st).Slop(5))
                          || q.MatchPhrase(m => m.Field("tituloHiperTexto").Query(st).Slop(5))
                          || q.MatchPhrase(m => m.Field("nombreArchivo").Slop(5).Query(st))
                        )
         )
         .Aggregations(a => a.Terms("my_terms_aggs", term => term.Field("formato")))
         .Highlight(h => h
                .PreTags("<strong style=\"color:#FF4000;\">")
                .PostTags("</strong>")
                .Fields(fs => fs
                    .Field("textoContenido")
                    .Order("score")
                    //.Type(tipoHighLight)
                    .Type(HighlighterType.Unified)
                    .FragmentSize(150)
                    .NumberOfFragments(3)
                    .NoMatchSize(150)
                    .ForceSource()
                 ))
        );



        var v = resultado.Aggregations.Values;
        var agg = resultado.Aggs.Terms("my_terms_aggs").Buckets.ToList();
        int num_agg = agg.Count();
        string aggregations = "";
        aggregations += "<h3> Departamentos </h3> ";
        for (int i = 0; i < num_agg; i++)
        {
            aggregations += "<h4><a id=\"" + agg[i].Key + "\"   runat=\"server\" onserverclick=\"aplicarFiltro\"> " + agg[i].Key + "(" + agg[i].DocCount + ") </a></h4>";

        }

        return aggregations;
    }


    public static List<KeyedBucket<string>> BusquedaAgregation2(string st)
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<ResultadoDeBusqueda> resultadoBusqueda = new List<ResultadoDeBusqueda>();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(200)
         .Type(Types.Type("hipertexto", "texto"))
         .Query(q => q.Bool(bo => bo.Filter(fi => fi.Term(te => te.Field("estadoActividad").Value(1))))
                     && +(q.MatchPhrase(m => m.Field("textoContenido").Query(st).Slop(5))
                          || q.MatchPhrase(m => m.Field("nombreArchivo").Slop(5).Query(st))
                        )
         )
         .Aggregations(a => a
            .Terms("departamento_agg", term => term.Field("departamento.keyword"))
         )
         .Highlight(h => h
                .PreTags("<strong style=\"color:#FF4000;\">")
                .PostTags("</strong>")
                .Fields(fs => fs
                    .Field("textoContenido")
                    .Order("score")
                    .Type(HighlighterType.Unified)
                    .FragmentSize(150)
                    .NumberOfFragments(3)
                    .NoMatchSize(150)
                    .ForceSource()
                 ))
        );


        var v = resultado.Aggregations.Values;
        var agg = resultado.Aggs.Terms("departamento_agg").Buckets.ToList();
        return agg;

    }



    public static List<ResultadoDeBusqueda> BusquedaFiltro(string filtro, string st)
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        List<ResultadoDeBusqueda> resultadoBusqueda = new List<ResultadoDeBusqueda>();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(1000)
         .Type(Types.Type("texto"))
         .Query(q => q.Bool(b => b.Filter(mu => mu.Term(my => my.Field("departamento.keyword").Value(filtro))))
                     && +(q.MatchPhrase(m => m.Field("textoContenido").Query(st).Slop(5))
                          || q.MatchPhrase(m => m.Field("nombreArchivo").Slop(5).Query(st))
                        )
         )
         .Highlight(h => h
                .PreTags("<strong style=\"color:#FF4000;\">")
                .PostTags("</strong>")
                .Fields(fs => fs
                    .Field("textoContenido")
                    .Order("score")
                    //.Type(tipoHighLight)
                    .Type(HighlighterType.Unified)
                    .FragmentSize(150)
                    .NumberOfFragments(3)
                    .NoMatchSize(150)
                    .ForceSource()
                 ))
        );




        var lista_resultadoss = resultado.Documents.ToList();
        var hits = resultado.Hits.ToList();   // Lista de los hits para obtener las puntuaciones.
        List<ResultadoDeBusqueda> lista_resultados = new List<ResultadoDeBusqueda>();


        var listaResultados = resultado.Documents.ToList();


        List<string> fragmentos = new List<string>();
        int i = 0;
        foreach (dynamic objeto in lista_resultadoss)
        {
            ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            lista_resultados.Add(resultadoDeBusqueda);

            if (hits[i].Highlights.Count > 0)
            {
                fragmentos = hits[i].Highlights.FirstOrDefault().Value.Highlights.ToList();
            }

            if (fragmentos.Count == 1)
            {
                resultadoDeBusqueda.textocontenido = fragmentos[0];
                if (resultadoDeBusqueda.textocontenido.Length > 500)
                    resultadoDeBusqueda.textocontenido = resultadoDeBusqueda.textocontenido.Substring(0, 500);
            }
            else if (fragmentos.Count == 2)
                resultadoDeBusqueda.textocontenido = fragmentos[0] + "[...] <br>[...] " + fragmentos[1];
            else if (fragmentos.Count == 3)
                resultadoDeBusqueda.textocontenido = fragmentos[0] + "[...] <br>[...] " + fragmentos[1] + "[...] <br>[...]" + fragmentos[2];
            else
                resultadoDeBusqueda.textocontenido = "Contenido disperso";


            // FACTOR 1: ALGORITMO ELASTICSEARCH
            resultadoDeBusqueda.puntaje = (int)(hits[i].Score * 8);    // Obtenemos la puntuación del documento, pasado a entero.

            // FACTOR 2: FORMATO


            // FACTOR 3: TÍTULOS VACIOS (PENALIZADOR)
            if (resultadoDeBusqueda.nombrearchivo == null) resultadoDeBusqueda.nombrearchivo = "";

            if (resultadoDeBusqueda.nombrearchivo.Trim() == "")
                resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje - 50;

            // FACTOR 5: HITS
            resultadoDeBusqueda.puntaje = resultadoDeBusqueda.puntaje /*+ puntajePorHits*/;
        }

        return lista_resultados;

    }

    #endregion


    #region hits
    public static void AddHit(string url)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(1)
         .AllTypes()
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field("urlRuta.keyword").Value(url))))));

        var hits = resultado.Hits.ToList();     // Lista de los hits para obtener las puntuaciones:4
        var id = hits[0].Id;
        var tipo = hits[0].Type;
        var listaResultados = resultado.Documents.ToList();

        ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
        foreach (dynamic objeto in listaResultados)
        {
            if (tipo.Equals("imagen"))
            {
                resultadoDeBusqueda.pixelesAltura = objeto.pixelesAltura;
                resultadoDeBusqueda.pixelesAnchura = objeto.pixelesAnchura;
            }
            else if (tipo.Equals("audio") || tipo.Equals("video"))
            {
                resultadoDeBusqueda.duracion = objeto.duracion;
            }

            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.tipo = tipo;
            resultadoDeBusqueda.hits = objeto.hits;
            resultadoDeBusqueda.estadoActividad = objeto.estadoActividad;

        }

        switch (tipo)
        {
            case "imagen":
                controladoraDeInicio.GetClienteES().Update<Imagen, Imagen>(id, descriptor => descriptor
               .Type(tipo)
               .Doc(new Imagen
               {
                   pixelesAltura = resultadoDeBusqueda.pixelesAltura,
                   pixelesAnchura = resultadoDeBusqueda.pixelesAnchura,
                   idServidor = resultadoDeBusqueda.idServidor,
                   estadoActividad = resultadoDeBusqueda.estadoActividad,
                   tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                   hits = (resultadoDeBusqueda.hits + 1),
               }));
                break;
            case "audio":
                controladoraDeInicio.GetClienteES().Update<Audio, Audio>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Audio
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    duracion = resultadoDeBusqueda.duracion,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    hits = (resultadoDeBusqueda.hits + 1),
                }));
                break;
            case "video":
                controladoraDeInicio.GetClienteES().Update<Video, Video>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Video
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    duracion = resultadoDeBusqueda.duracion,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    hits = (resultadoDeBusqueda.hits + 1),
                }));
                break;
            case "texto":
                controladoraDeInicio.GetClienteES().Update<Texto, Texto>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Texto
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    hits = (resultadoDeBusqueda.hits + 1),
                }));
                break;

            case "hipertexto":
                controladoraDeInicio.GetClienteES().Update<Hipertexto, Hipertexto>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Hipertexto
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    hits = (resultadoDeBusqueda.hits + 1),
                }));
                break;

            default:
                break;

        }






    }
    #endregion


    #region etiquetas
    public static void ActualizarEtiquetas(string url, string etiquetas)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<dynamic>(s => s
         .Size(1)
         .AllTypes()
         .Query(q =>
             q.Bool(b => b
                .Filter(f => f
                    .Term(t => t
                        .Field("urlRuta.keyword").Value(url))))));

        var hits = resultado.Hits.ToList();     // Lista de los hits para obtener las puntuaciones:4
        var id = hits[0].Id;
        var tipo = hits[0].Type;
        var listaResultados = resultado.Documents.ToList();
        List<string> nuevalista = new List<string>();
        ResultadoDeBusqueda resultadoDeBusqueda = new ResultadoDeBusqueda();
        List<string> et_aux = new List<string>();
        foreach (dynamic objeto in listaResultados)
        {
            if (tipo.Equals("imagen"))
            {
                resultadoDeBusqueda.pixelesAltura = objeto.pixelesAltura;
                resultadoDeBusqueda.pixelesAnchura = objeto.pixelesAnchura;
            }
            else if (tipo.Equals("audio") || tipo.Equals("video"))
            {
                resultadoDeBusqueda.duracion = objeto.duracion;
            }


            resultadoDeBusqueda.nombrearchivo = objeto.nombreArchivo;
            resultadoDeBusqueda.formato = objeto.formato;
            resultadoDeBusqueda.fechaModificacionArchivo = (DateTime)objeto.fechaModificacionArchivo;
            resultadoDeBusqueda.departamento = objeto.departamento;
            resultadoDeBusqueda.urlRuta = objeto.urlRuta;
            resultadoDeBusqueda.tipo = tipo;
            resultadoDeBusqueda.hits = objeto.hits;
            resultadoDeBusqueda.estadoActividad = objeto.estadoActividad;

            var et = objeto.etiquetas;
            foreach (string a in et)
            {
                et_aux.Add(a);
            }
            resultadoDeBusqueda.etiquetas = et_aux;
        }

        for (int i = 0; i < resultadoDeBusqueda.etiquetas.Count; i++)
        {
            nuevalista.Add(resultadoDeBusqueda.etiquetas[i]);
        }

        List<string> etiquetasactuales = etiquetas.Split(',').ToList();

        for (int i = 0; i < etiquetasactuales.Count; i++)
        {
            nuevalista.Add(etiquetasactuales[i]);
        }



        switch (tipo)
        {
            case "imagen":
                controladoraDeInicio.GetClienteES().Update<Imagen, Imagen>(id, descriptor => descriptor
               .Type(tipo)
               .Doc(new Imagen
               {
                   pixelesAltura = resultadoDeBusqueda.pixelesAltura,
                   pixelesAnchura = resultadoDeBusqueda.pixelesAnchura,
                   idServidor = resultadoDeBusqueda.idServidor,
                   estadoActividad = resultadoDeBusqueda.estadoActividad,
                   tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                   etiquetas = nuevalista,
                   hits = resultadoDeBusqueda.hits,
               }));
                break;
            case "audio":
                controladoraDeInicio.GetClienteES().Update<Audio, Audio>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Audio
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    duracion = resultadoDeBusqueda.duracion,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    etiquetas = nuevalista,
                    hits = resultadoDeBusqueda.hits,
                }));
                break;
            case "video":
                controladoraDeInicio.GetClienteES().Update<Video, Video>(id, descriptor => descriptor
                .Type(tipo)
                .Doc(new Video
                {
                    idServidor = resultadoDeBusqueda.idServidor,
                    duracion = resultadoDeBusqueda.duracion,
                    estadoActividad = resultadoDeBusqueda.estadoActividad,
                    tamanoArchivo = resultadoDeBusqueda.tamanoArchivo,
                    etiquetas = nuevalista,
                    hits = resultadoDeBusqueda.hits,
                }));
                break;
            default:
                break;

        }

    }



    #endregion



    #region actualizar
    public static void actualizarHipertexto(Hipertexto ht, Hipertexto htnuevo)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Hipertexto>(s => s
        .Size(1)
        .Query(q =>
            q.Bool(b => b
               .Filter(f => f
                   .Term(t => t
                       .Field("urlRuta.keyword").Value(ht.urlRuta))))));

        var hits = resultado.Hits.ToList();
        var id = hits[0].Id;

        controladoraDeInicio.GetClienteES().Update<Hipertexto, Hipertexto>(id, descriptor => descriptor
        .Type("hipertexto")
                .Doc(new Hipertexto
                {
                    hits = htnuevo.hits,
                    textoContenido = htnuevo.textoContenido,
                    idServidor = htnuevo.idServidor,
                    urlProtocolo = htnuevo.urlProtocolo,
                    urlPuerto = htnuevo.urlPuerto,
                    urlRuta = htnuevo.urlRuta,
                    formato = htnuevo.formato,
                    estadoActividad = htnuevo.estadoActividad,
                    nombreArchivo = htnuevo.nombreArchivo,
                    autorArchivo = htnuevo.autorArchivo,
                    fechaCreacionArchivo = htnuevo.fechaCreacionArchivo,
                    fechaModificacionArchivo = htnuevo.fechaModificacionArchivo,
                    fechaUltimaActualizacion = htnuevo.fechaUltimaActualizacion,
                    tamanoArchivo = htnuevo.tamanoArchivo,
                    departamento = htnuevo.departamento,
                    fechaUltimaLectura = htnuevo.fechaUltimaLectura,
                }));
    }



    public static void actualizarTexto(Texto tx, Texto tnuevo)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Texto>(s => s
        .Size(1)
        .Query(q =>
            q.Bool(b => b
               .Filter(f => f
                   .Term(t => t
                       .Field("urlRuta.keyword").Value(tx.urlRuta))))));

        var hits = resultado.Hits.ToList();
        var id = hits[0].Id;

        controladoraDeInicio.GetClienteES().Update<Texto, Texto>(id, descriptor => descriptor
        .Type("texto")
                .Doc(new Texto
                {
                    hits = tnuevo.hits,
                    textoContenido = tnuevo.textoContenido,
                    idServidor = tnuevo.idServidor,
                    urlProtocolo = tnuevo.urlProtocolo,
                    urlPuerto = tnuevo.urlPuerto,
                    urlRuta = tnuevo.urlRuta,
                    formato = tnuevo.formato,
                    estadoActividad = tnuevo.estadoActividad,
                    nombreArchivo = tnuevo.nombreArchivo,
                    autorArchivo = tnuevo.autorArchivo,
                    fechaCreacionArchivo = tnuevo.fechaCreacionArchivo,
                    fechaModificacionArchivo = tnuevo.fechaModificacionArchivo,
                    fechaUltimaActualizacion = tnuevo.fechaUltimaActualizacion,
                    tamanoArchivo = tnuevo.tamanoArchivo,
                    departamento = tnuevo.departamento,
                    fechaUltimaLectura = tnuevo.fechaUltimaLectura,
                }));
    }



    public static void actualizarImagen(Imagen im, Imagen imnueva)
    {
        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Imagen>(s => s
        .Size(1)
        .Query(q =>
            q.Bool(b => b
               .Filter(f => f
                   .Term(t => t
                       .Field("urlRuta.keyword").Value(im.urlRuta))))));

        var hits = resultado.Hits.ToList();
        var id = hits[0].Id;

        controladoraDeInicio.GetClienteES().Update<Imagen, Imagen>(id, descriptor => descriptor
        .Type("imagen")
                .Doc(new Imagen
                {
                    pixelesAltura = imnueva.pixelesAltura,
                    pixelesAnchura = imnueva.pixelesAnchura,
                    etiquetas = imnueva.etiquetas,
                    hits = imnueva.hits,
                    idServidor = imnueva.idServidor,
                    urlProtocolo = imnueva.urlProtocolo,
                    urlPuerto = imnueva.urlPuerto,
                    urlRuta = imnueva.urlRuta,
                    formato = imnueva.formato,
                    estadoActividad = imnueva.estadoActividad,
                    nombreArchivo = imnueva.nombreArchivo,
                    autorArchivo = imnueva.autorArchivo,
                    fechaCreacionArchivo = imnueva.fechaCreacionArchivo,
                    fechaModificacionArchivo = imnueva.fechaModificacionArchivo,
                    fechaUltimaActualizacion = imnueva.fechaUltimaActualizacion,
                    tamanoArchivo = imnueva.tamanoArchivo,
                    departamento = imnueva.departamento,
                    fechaUltimaLectura = imnueva.fechaUltimaLectura,
                }));
    }


    public static void actualizarAudio(Audio au, Audio aunuevo){

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Audio>(s => s
        .Size(1)
        .Query(q =>
            q.Bool(b => b
               .Filter(f => f
                   .Term(t => t
                       .Field("urlRuta.keyword").Value(au.urlRuta))))));

        var hits = resultado.Hits.ToList();
        var id = hits[0].Id;

        controladoraDeInicio.GetClienteES().Update<Audio, Audio>(id, descriptor => descriptor
        .Type("audio")
                .Doc(new Audio
                {
                    duracion = aunuevo.duracion,
                    etiquetas = aunuevo.etiquetas,
                    hits = aunuevo.hits,
                    idServidor = aunuevo.idServidor,
                    urlProtocolo = aunuevo.urlProtocolo,
                    urlPuerto = aunuevo.urlPuerto,
                    urlRuta = aunuevo.urlRuta,
                    formato = aunuevo.formato,
                    estadoActividad = aunuevo.estadoActividad,
                    nombreArchivo = aunuevo.nombreArchivo,
                    autorArchivo = aunuevo.autorArchivo,
                    fechaCreacionArchivo = aunuevo.fechaCreacionArchivo,
                    fechaModificacionArchivo = aunuevo.fechaModificacionArchivo,
                    fechaUltimaActualizacion = aunuevo.fechaUltimaActualizacion,
                    tamanoArchivo = aunuevo.tamanoArchivo,
                    departamento = aunuevo.departamento,
                    fechaUltimaLectura = aunuevo.fechaUltimaLectura,
                }));
    }




    public static void actualizarVideo(Video vi, Video vinuevo)
    {

        SuperControladora controladoraDeInicio = SuperControladora.GetSuperControladora();

        var resultado = controladoraDeInicio.GetClienteES().Search<Video>(s => s
        .Size(1)
        .Query(q =>
            q.Bool(b => b
               .Filter(f => f
                   .Term(t => t
                       .Field("urlRuta.keyword").Value(vi.urlRuta))))));

        var hits = resultado.Hits.ToList();
        var id = hits[0].Id;

        controladoraDeInicio.GetClienteES().Update<Video, Video>(id, descriptor => descriptor
        .Type("video")
                .Doc(new Video
                {
                    calidad = vinuevo.calidad,
                    duracion = vinuevo.duracion,
                    etiquetas = vinuevo.etiquetas,
                    hits = vinuevo.hits,
                    idServidor = vinuevo.idServidor,
                    urlProtocolo = vinuevo.urlProtocolo,
                    urlPuerto = vinuevo.urlPuerto,
                    urlRuta = vinuevo.urlRuta,
                    formato = vinuevo.formato,
                    estadoActividad = vinuevo.estadoActividad,
                    nombreArchivo = vinuevo.nombreArchivo,
                    autorArchivo = vinuevo.autorArchivo,
                    fechaCreacionArchivo = vinuevo.fechaCreacionArchivo,
                    fechaModificacionArchivo = vinuevo.fechaModificacionArchivo,
                    fechaUltimaActualizacion = vinuevo.fechaUltimaActualizacion,
                    tamanoArchivo = vinuevo.tamanoArchivo,
                    departamento = vinuevo.departamento,
                    fechaUltimaLectura = vinuevo.fechaUltimaLectura,
                }));
    }





    #endregion

}