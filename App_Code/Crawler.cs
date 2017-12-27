using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Powerpoint = Microsoft.Office.Interop.PowerPoint;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using Microsoft.CSharp;
using TikaOnDotNet.TextExtraction;
using Microsoft.Office.Core;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using java.net;

/// <summary>
/// Descripción breve de Crawler
/// </summary>
public class Crawler
{
    public Crawler()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    public static void IndexarDocumentos(string tipo, string servidor, string dpto,  string urlPrioritaria, bool actualizar){

        string rutaPrincipal = "C:\\xampp\\htdocs\\servidores";

        if (servidor.Equals("") == false){
            rutaPrincipal = rutaPrincipal+"\\" + servidor;
            ProcessDirectory(rutaPrincipal, tipo, servidor, "", actualizar);
        }
        else if (urlPrioritaria.Equals("")==false) {
            ProcessFile(urlPrioritaria, tipo, "", actualizar);
        }
        else if (dpto.Equals("") == false)
        {
            ProcessDirectory(rutaPrincipal, tipo, servidor, dpto, actualizar);
        }
        else{
            ProcessDirectory(rutaPrincipal, tipo, servidor, "", actualizar);
        }

    }

    public static void ProcessDirectory(string targetDirectory, string tipo, string servidor, string dpto, bool actualizar)
    {
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            ProcessFile(fileName, tipo, dpto, actualizar);

        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory, tipo, servidor,dpto, actualizar);
    }

    public static HtmlNode GetNodes(Uri url){
        // Create the WebRequest for the URL we are using
        var req = WebRequest.Create(url);

        // Get the stream from the returned web response
        var stream = new StreamReader(req.GetResponse().GetResponseStream());

        var htmlDocument = new HtmlDocument();
        htmlDocument.Load(stream);
        return htmlDocument.DocumentNode;
    }

    // Insert logic for processing found files here.
    public static void ProcessFile(string path, string tipo, string dpto, bool actualizar) { 
        bool indexatexto = false, indexaaudio = false, indexaimagen = false, indexahipertexto = false, indexavideo = false;

        Random rnd = new Random();
        

        switch (tipo){
            case "texto":
                indexatexto = true;
                break;
            case "hipertexto":
                indexahipertexto = true;
                break;
            case "video":
                indexavideo = true;
                break;
            case "imagen":
                indexaimagen = true;
                break;
            case "audio":
                indexaaudio = true;
                break;
            case "":
                indexatexto = true;
                indexahipertexto = true;
                indexavideo = true;
                indexaimagen = true;
                indexaaudio = true;
                break;
        }


        if (Herramientas.EsHiperTexto(path) && indexatexto && path.Contains(dpto)){
            Regex trimmer = new Regex(@"\s\s+");
            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            Browser.AllowMetaRedirect = true;
            HtmlNode html = GetNodes(new Uri(path));

            var titulo = html.CssSelect("title").FirstOrDefault().InnerText;
            var body = html.CssSelect("body").FirstOrDefault().InnerText;

            body = Regex.Replace(body, "<.*?>", string.Empty);
            body = Regex.Replace(body, @"(?:(?:\r?\n)+ +){2,}", @"\n");

            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;

            Hipertexto h = new Hipertexto();
            h.nombreArchivo = titulo;
            h.textoContenido = body;
            h.tamanoArchivo = fileLengthInKB;

            Uri u = new Uri(path);
            string ext = System.IO.Path.GetExtension(path);
            string auxiliar = "http://localhost/servidores/";
            h.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = h.urlRuta.IndexOf("servidores/") + 11 ;
            string aux2 = h.urlRuta.Substring(pos);
            int pos2 = aux2.IndexOf("/");
            h.urlRuta = auxiliar + aux2;
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");

            h.departamento = depart;
            h.urlRuta = auxiliar + aux2;
            h.tamanoArchivo = fileLengthInKB;
            h.formato = ext;
            h.idServidor = servidor;
            h.nombreArchivo = System.IO.Path.GetFileName(path);
            h.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            h.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            h.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            h.fechaUltimaActualizacion = DateTime.Now;
            h.hits = rnd.Next(1, 55);

            if (File.Exists(path))
                h.estadoActividad = 1;

            Hipertexto existente = OperacionesElasticSearch.ExisteHipertexto(h);
            if (existente==null)
                OperacionesElasticSearch.InsertarHiperTexto(h);
            else
                OperacionesElasticSearch.actualizarHipertexto(existente,h);



        }
        else if (path.EndsWith(".txt") && indexatexto && path.Contains(dpto)){
            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;
            Uri u = new Uri(path);
            Texto t = new Texto();
            string ext = System.IO.Path.GetExtension(path);
            string auxiliar = "http://localhost/servidores/";
            t.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = t.urlRuta.IndexOf("servidores/") + 11;
            string aux2 = t.urlRuta.Substring(pos);
            t.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");

            string textoContenido = System.IO.File.ReadAllText(path);
            string user = System.IO.File.GetAccessControl(path).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            t.estadoActividad = 1;
            t.departamento = depart;
            t.urlRuta = auxiliar + aux2;
            t.tamanoArchivo = fileLengthInKB;
            t.idServidor = servidor;
            t.textoContenido = textoContenido;
            t.titulo = t.nombreArchivo;
            t.formato = ext;
            t.nombreArchivo = System.IO.Path.GetFileName(path);
            t.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            t.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            t.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            t.fechaUltimaActualizacion = DateTime.Now;
            t.hits = rnd.Next(1, 55);
            t.autorArchivo = user;
                       

            Texto existente = OperacionesElasticSearch.ExisteTexto(t);
            if (existente == null)
                OperacionesElasticSearch.InsertarTexto(t);
            else
                OperacionesElasticSearch.actualizarTexto(existente, t);


        }
        else if (Herramientas.EsWord(path) && indexatexto && path.Contains(dpto)){
            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;

            var applicationWord = new Microsoft.Office.Interop.Word.Application();
            applicationWord.Visible = false;
            Word.Document w = applicationWord.Documents.Open(@path, ReadOnly: true);
            Word.Range ContentTypeProperties = w.Content;

            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;

            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);


            //Get Author Name
            object wordProperties = docs.BuiltInDocumentProperties;

            Type typeDocBuiltInProps = wordProperties.GetType();
            Object Authorprop = typeDocBuiltInProps.InvokeMember("Item", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.GetProperty, null, wordProperties, new object[] { "Author" });//query for author properties 
            Type typeAuthorprop = Authorprop.GetType();
            //string strAuthor = typeAuthorprop.InvokeMember("Value", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.GetProperty, null, Authorprop, new object[] { }).ToString();//get author name 

            string textoContenido = "";
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                textoContenido += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
            }
            Uri u = new Uri(path);
            Texto t = new Texto();
            string ext = System.IO.Path.GetExtension(path);

            string auxiliar = "http://localhost/servidores/";
            t.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = t.urlRuta.IndexOf("servidores/") + 11;
            string aux2 = t.urlRuta.Substring(pos);
            t.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");


            t.departamento = depart;
            t.urlRuta = auxiliar + aux2;
            t.tamanoArchivo = fileLengthInKB;
            t.idServidor = servidor;
            t.textoContenido = textoContenido;
            t.titulo = t.nombreArchivo;
            t.formato = ext;
            t.nombreArchivo = System.IO.Path.GetFileName(path);
            t.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            t.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            t.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            t.fechaUltimaActualizacion = DateTime.Now;
            t.hits = rnd.Next(1, 55);

            if (File.Exists(path))
                t.estadoActividad = 1;

            w.Close();


            Texto existente = OperacionesElasticSearch.ExisteTexto(t);
            if (existente == null)
                OperacionesElasticSearch.InsertarTexto(t);
            else
                OperacionesElasticSearch.actualizarTexto(existente, t);


        }
        else if (Herramientas.EsExcel(path) && indexatexto && path.Contains(dpto))
        {
            /*Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(@path, ReadOnly: true);

            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;
            
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[0];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            //Get Author Name
            String autor = wb.Author;

            String textoContenido = "";
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if ((Excel.Range)xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        textoContenido += xlRange.Cells[i, j].Value2.ToString() + " ";

                    //add useful things here!   
                }
            }

            xlWorkbook.Close();
            Uri u = new Uri(path);

            Texto t = new Texto();
            t.urlRuta = u.AbsoluteUri;
            string ext = System.IO.Path.GetExtension(path);

           string auxiliar = "http://localhost/servidorIntranet/";
            h.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = h.urlRuta.IndexOf("servidores/") + 11 ;
            string aux2 = h.urlRuta.Substring(pos);
            t.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");
            t.departamento = depart;

            t.idServidor = servidor;
            t.urlRuta = u.AbsoluteUri;
            t.tamanoArchivo = fileLengthInKB;
            t.textoContenido = textoContenido;
            t.titulo = t.nombreArchivo;
            t.formato = ext;
            t.nombreArchivo = System.IO.Path.GetFileName(path);
            t.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            t.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            t.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            t.fechaUltimaActualizacion = DateTime.Now;
            t.hits = 0;

            if (File.Exists(path))
                t.estadoActividad = 1;

             Texto existente = OperacionesElasticSearch.ExisteTexto(t);
            if (existente == null)
                OperacionesElasticSearch.InsertarTexto(t);
            else
                OperacionesElasticSearch.actualizarTexto(existente, t);
                
         */
        }
        else if (Herramientas.EsPDF(path) && indexatexto  && path.Contains(dpto))
        {
            var text = new TextExtractor().Extract(path).Text;
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Replace("\r", "");
            text = text.Replace("\n", "");

            PDFParser pdfParser = new PDFParser();

            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;

            // extract the text
            String resultado = "";
            pdfParser.ExtractText(path, "C:\\Users\\cesar\\Desktop\\DocumentosIndeaxar\\salida.txt");
            resultado = pdfParser.ToString();

            String autor = "";
            String textoContenido = "";
            String titulo = "";


            using (PdfReader reader = new PdfReader(path)){
                //titulo = reader.Info["Title"];
                //String ayt = reader.Info["Author"];
                titulo = "";

                StringBuilder text2 = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++){
                    text2.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                textoContenido = text.ToString();
            }

            Texto t = new Texto();
            Uri u = new Uri(path);

            t.urlRuta = u.AbsoluteUri;
            string auxiliar = "http://localhost/servidores/";
            t.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = t.urlRuta.IndexOf("servidores/") + 11;
            
            string aux2 = t.urlRuta.Substring(pos);
            t.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");

            t.idServidor = servidor;
            t.departamento = depart;
            t.textoContenido = textoContenido;
            t.nombreArchivo = path.Substring(0, path.IndexOf(".pdf"));
            t.titulo = titulo;
            t.tamanoArchivo = fileLengthInKB;
            
            string ext = System.IO.Path.GetExtension(path);
            t.formato = ext;
            t.nombreArchivo = path.Substring(0, path.IndexOf(ext));
            t.nombreArchivo = System.IO.Path.GetFileName(path);
            t.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            t.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            t.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            t.fechaUltimaActualizacion = DateTime.Now;
            t.hits = rnd.Next(1, 55);

            if (File.Exists(path))
                t.estadoActividad = 1;

            Texto existente = OperacionesElasticSearch.ExisteTexto(t);
            if (existente == null)
                OperacionesElasticSearch.InsertarTexto(t);
            else
                OperacionesElasticSearch.actualizarTexto(existente, t);

        }
        else if (Herramientas.EsPowerPoint(path) && indexatexto && path.Contains(dpto)){

            Microsoft.Office.Interop.PowerPoint.Application PowerPoint_App = new Microsoft.Office.Interop.PowerPoint.Application();
            Microsoft.Office.Interop.PowerPoint.Presentations multi_presentations = PowerPoint_App.Presentations;
            Microsoft.Office.Interop.PowerPoint.Presentation presentation = multi_presentations.Open(path);

            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;

            string textoContenido = "";
            for (int i = 0; i < presentation.Slides.Count; i++){
                foreach (var item in presentation.Slides[i + 1].Shapes){
                    var shape = (Powerpoint.Shape)item;
                    if (shape.HasTextFrame == MsoTriState.msoTrue){
                        if (shape.TextFrame.HasText == MsoTriState.msoTrue){
                            var textRange = shape.TextFrame.TextRange;
                            var text = textRange.Text;
                            textoContenido += text + " ";
                        }
                    }
                }
            }
            //Get Author Name
            object wordProperties = presentation.BuiltInDocumentProperties;
            Type typeDocBuiltInProps = wordProperties.GetType();
            Object Authorprop = typeDocBuiltInProps.InvokeMember("Item", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.GetProperty, null, wordProperties, new object[] { "Author" });//query for author properties 
            Type typeAuthorprop = Authorprop.GetType();
            string autor = typeAuthorprop.InvokeMember("Value", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.GetProperty, null, Authorprop, new object[] { }).ToString();//get author name 

            Texto t = new Texto();
            t.textoContenido = textoContenido;
            Uri u = new Uri(path);
            t.urlRuta = u.AbsoluteUri;
            string ext = System.IO.Path.GetExtension(path);
            t.formato = ext;
            t.nombreArchivo = path.Substring(0, path.IndexOf(ext));
            string auxiliar = "http://localhost/servidores/";
            t.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = t.urlRuta.IndexOf("servidores/") + 11;

            string aux2 = t.urlRuta.Substring(pos);
            t.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");
            t.departamento = depart;
            t.hits = rnd.Next(1, 55);


            PowerPoint_App.Quit();
            presentation.Close();

            t.idServidor = servidor;
            textoContenido = textoContenido.Trim();
            t.nombreArchivo = System.IO.Path.GetFileName(path);
            t.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            t.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            t.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            t.fechaUltimaActualizacion = DateTime.Now;

            if (File.Exists(path))
                t.estadoActividad = 1;

            Texto existente = OperacionesElasticSearch.ExisteTexto(t);
            if (existente == null)
                OperacionesElasticSearch.InsertarTexto(t);
            else
                OperacionesElasticSearch.actualizarTexto(existente, t);

        }
        else if (Herramientas.EsImagen(path) && indexaimagen && path.Contains(dpto))
        {

            var f = new FileInfo(path);
            var fileLengthInKB = f.Length / 1024.0;
            string ext = System.IO.Path.GetExtension(path);
            List<string> eti = new List<string>();
            eti.Add("imagen");
            eti.Add("foto");

            String titulo = path.Substring(0, path.IndexOf(ext));
            FileInfo file = new FileInfo(path);
            int tamanio = (int)file.Length;

            Bitmap img = new Bitmap(path);

            int altura = img.Height;
            int anchura = img.Width;

            Imagen im = new Imagen();
            im.pixelesAltura = altura;
            im.pixelesAnchura = anchura;

            Uri u = new Uri(path);
            im.urlRuta = u.AbsoluteUri;


            string auxiliar = "http://localhost/servidores/";
            im.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = im.urlRuta.IndexOf("servidores/") + 11;

            string aux2 = im.urlRuta.Substring(pos);
            im.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");
            im.departamento = depart;

            im.idServidor = servidor;
            ext = System.IO.Path.GetExtension(path);
            im.formato = ext;
            im.nombreArchivo = System.IO.Path.GetFileName(path);
            im.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            im.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            im.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            im.fechaUltimaActualizacion = DateTime.Now;
            im.etiquetas = eti;
            im.hits = rnd.Next(1, 55);


            if (File.Exists(path))
                im.estadoActividad = 1;

            Imagen existente = OperacionesElasticSearch.ExisteImagen(im);
            if (existente == null)
                OperacionesElasticSearch.InsertarImagen(im);
            else
                OperacionesElasticSearch.actualizarImagen(existente, im);


        }
        else if (Herramientas.EsAudio(path) && indexaaudio){
            var fi = new FileInfo(path);
            var fileLengthInKB = fi.Length / 1024.0;

            string ext = System.IO.Path.GetExtension(path);
            string titulo = path.Substring(0, path.IndexOf(ext));

            TagLib.File f = TagLib.File.Create(path, TagLib.ReadStyle.Average);
            var duracion = (int)f.Properties.Duration.TotalSeconds;

            List<string> eti = new List<string>();
            eti.Add("audio");
            eti.Add("sonido");

            Audio au = new Audio();
            Uri u = new Uri(path);
            au.urlRuta = u.AbsoluteUri;
            string auxiliar = "http://localhost/servidores/";
            au.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = au.urlRuta.IndexOf("servidores/") + 11;

            string aux2 = au.urlRuta.Substring(pos);
            au.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");
            au.departamento = depart;
            au.duracion = duracion;
            au.etiquetas = eti;
            au.formato = ext;
            au.nombreArchivo = System.IO.Path.GetFileName(path);
            au.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            au.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            au.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            au.fechaUltimaActualizacion = DateTime.Now;
            au.hits = rnd.Next(1, 55);
            au.idServidor = servidor;

            if (File.Exists(path))
                au.estadoActividad = 1;

            Audio existente = OperacionesElasticSearch.ExisteAudio(au);
            if (existente == null)
                OperacionesElasticSearch.InsertarAudio(au);
            else
                OperacionesElasticSearch.actualizarAudio(existente, au);

        }
        else if (Herramientas.EsVideo(path) && indexavideo){
            string ext = System.IO.Path.GetExtension(path);
            string titulo = path.Substring(0, path.IndexOf(ext));
            List<string> eti = new List<string>();
            eti.Add("video");
            var fi = new FileInfo(path);
            int duracion = 0;
            string calidad = "";
            var fileLengthInKB = fi.Length / 1024.0;
            if (ext == ".mp4"){
               
                TagLib.File f = TagLib.File.Create(path, TagLib.ReadStyle.Average);
                duracion = (int)f.Properties.Duration.TotalSeconds;

                if (f.Properties.VideoHeight != 0 && f.Properties.VideoWidth != 0){
                    int height = (int)f.Properties.VideoHeight;
                    int width = (int)f.Properties.VideoWidth;
                    calidad = height + "x" + width;
                }
            }

            Uri u = new Uri(path);

            Video v = new Video();
            v.urlRuta = u.AbsoluteUri;
            string auxiliar = "http://localhost/servidores/";
            v.urlRuta = u.AbsoluteUri;
            var puerto = u.Port;
            int pos = v.urlRuta.IndexOf("servidores/") + 11;

            string aux2 = v.urlRuta.Substring(pos);
            v.urlRuta = auxiliar + aux2;
            int pos2 = aux2.IndexOf("/");
            string servidor = aux2.Substring(0, pos2);
            int pos3 = aux2.IndexOf(servidor + "/") + servidor.Length + 1;

            string depart = aux2.Substring(pos3);
            int pos4 = depart.IndexOf("/");
            depart = depart.Substring(0, pos4);
            depart = depart.Replace("%20", " ");
            depart = depart.Replace("%20", " ");
            v.departamento = depart;
            v.duracion = duracion;
            v.etiquetas = eti;
            v.calidad = calidad;
            v.idServidor = servidor;
            v.nombreArchivo = System.IO.Path.GetFileName(path);
            v.fechaCreacionArchivo = (DateTime)File.GetCreationTime(path);
            v.fechaModificacionArchivo = (DateTime)File.GetLastWriteTime(path);
            v.fechaUltimaLectura = (DateTime)File.GetLastAccessTime(path);
            v.fechaUltimaActualizacion = DateTime.Now;
            v.formato = ext;
            v.hits = rnd.Next(1, 55);

            if (File.Exists(path))
                v.estadoActividad = 1;

            Video existente = OperacionesElasticSearch.ExisteVideo(v);
            if (existente == null)
                OperacionesElasticSearch.InsertarVideo(v);
            else
                OperacionesElasticSearch.actualizarVideo(existente, v);
        }
    }

    public static string[] GetRange(string range, Excel.Worksheet excelWorksheet){
        Microsoft.Office.Interop.Excel.Range workingRangeCells =
          excelWorksheet.get_Range(range, Type.Missing);
        //workingRangeCells.Select();

        System.Array array = (System.Array)workingRangeCells.Cells.Value2;
        string[] arrayS = array.OfType<System.Array>().Select(o => o.ToString()).ToArray();

        return arrayS;
    }
}