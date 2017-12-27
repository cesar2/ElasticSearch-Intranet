using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;

/// <summary>
/// Descripción breve de SuperControladora
/// </summary>
public class SuperControladora
{

    #region Atributos

    private static SuperControladora instanciaSuperControladora;

    protected ElasticClient clienteES;

    #endregion


    #region Constructores

    public SuperControladora()
    {
        var node = new Uri("http://localhost:9200");
        var settings = new ConnectionSettings(node);
        this.clienteES = new ElasticClient(settings);

        // Comprobamos si existe el índice
        var existeIndice = this.clienteES.GetIndex("documentos").IsValid;       // Las mayúsculas no son admitidas en el nombre del índice
        if (existeIndice == false) this.CrearIndiceES(this.clienteES);

        settings = new ConnectionSettings(node).DefaultIndex("documentos");
        this.clienteES = new ElasticClient(settings);




    }

    public static SuperControladora GetSuperControladora()
    {
        if (instanciaSuperControladora == null)
        {
            instanciaSuperControladora = new SuperControladora();
        }
        return instanciaSuperControladora;
    }


    #endregion


    #region Métodos internos


    private void CrearIndiceES(ElasticClient pClient)
    {

        var createIndexResponse = pClient.CreateIndex("documentos", c => c
          .Settings(s => s
              .Setting("analysis.filter.spanish_stemmer.type", "stemmer")
              .Setting("analysis.filter.spanish_stemmer.language", "spanish")
              .NumberOfShards(1)
              .NumberOfReplicas(0)
              .Analysis(analysis => analysis
                   .TokenFilters(tf => tf.Stop("stop_es", st => st.StopWords("_spanish_")))
                  //.TokenFilters(tf => tf.Stemmer("spanish_stemmer", st => st.Language("spanish")))
                   .Analyzers(bases => bases
                       //.Snowball("es_std", es => es.Language(SnowballLanguage.Spanish))
                       .Custom("analizador_prueba", ca => ca
                       .Tokenizer("standard")
                       .Filters("lowercase", "stop_es", "spanish_stemmer", "asciifolding")
                       )
                   )
               )
          )
          .Mappings(m => m
           .Map<Hipertexto>(d => d
               .Properties(p => p
                       .Text(st => st
                            .Name(na => na.textoContenido)
                            .TermVector(TermVectorOption.WithPositionsOffsets)  //<-- PARA EL HIGHLIGHT FAST VECTOR
                            .Analyzer("analizador_prueba")
                       )
                       .Text(st2 => st2
                            .Name(na2 => na2.nombreArchivo)
                            .TermVector(TermVectorOption.WithPositionsOffsets)  //<-- PARA EL HIGHLIGHT FAST VECTOR
                            .Analyzer("analizador_prueba")
                       )
                       .Keyword(st => st          // id es un string
                            .Name(na => na.formato)
                            .Name(na => na.departamento)
                            .Name(na => na.idServidor)
                            .Name(na => na.urlRuta)
                       )
                )
           )
           .Map<Audio>(d => d
               .Properties(p => p
                   .Text(st => st
                        .Name(na => na.etiquetas)
                        .Analyzer("analizador_prueba"))
                   .Keyword(st => st
                        .Name(na => na.formato)
                        .Name(na => na.departamento)
                        .Name(na => na.idServidor)
                        .Name(na => na.urlRuta)
                    )

               )
           )
           .Map<Imagen>(d => d
               .Properties(p => p
                .Text(st => st
                             .Name(na => na.urlRuta)
                             .Analyzer("analizador_prueba"))
                   .Keyword(st => st
                        .Name(na => na.formato)
                        .Name(na => na.departamento)
                        .Name(na => na.etiquetas)
                        .Name(na => na.idServidor)
                        .Name(na => na.urlRuta)
                   )
               )
           )
           .Map<Texto>(d => d
               .Properties(p => p
                       .Text(st => st
                            .Name(na => na.textoContenido)
                            .TermVector(TermVectorOption.WithPositionsOffsets)  //<-- PARA EL HIGHLIGHT FAST VECTOR
                            .Analyzer("analizador_prueba")
                       )
                       .Text(st => st
                            .Name(na => na.nombreArchivo)
                            .TermVector(TermVectorOption.WithPositionsOffsets)  //<-- PARA EL HIGHLIGHT FAST VECTOR
                            .Analyzer("analizador_prueba")
                       )
                       .Keyword(st => st          // id es un string
                             .Name(na => na.formato)
                             .Name(na => na.departamento)
                             .Name(na => na.idServidor)
                             .Name(na => na.urlRuta)
                       )
                )
           )
           .Map<Video>(d => d
               .Properties(p => p
                .Text(st => st
                             .Name(na => na.urlRuta)
                             .Analyzer("analizador_prueba"))
                    .Text(st => st
                        .Name(na => na.etiquetas)
                        .Analyzer("analizador_prueba"))
                   .Keyword(st => st
                        .Name(na => na.formato)
                        .Name(na => na.departamento)
                        .Name(na => na.idServidor)
                        .Name(na => na.urlRuta)
                     )
                )
            )
           )
       );
    }

    #endregion


    #region Get atributos

    public ElasticClient GetClienteES()
    {
        return this.clienteES;
    }


    #endregion

}