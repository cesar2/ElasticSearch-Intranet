using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Descripción breve de Herramientas
/// </summary>
public class Herramientas
{
    public static bool EsWord(string filename){
        if ((filename.EndsWith(".docx") || filename.EndsWith(".doc")) && filename.Contains("~$").Equals(false))
            return true;
        else
            return false;
    }

    public static bool EsExcel(string filename){
        if ((filename.EndsWith(".xlsx") || filename.EndsWith(".xlt")) && filename.Contains("~$").Equals(false))
            return true;
        else
            return false;
    }

    public static bool EsPowerPoint(string filename){
        if (filename.EndsWith(".pptx") && filename.Contains("~$").Equals(false))
            return true;
        else
            return false;
    }

    public static bool EsHiperTexto(string filename){
        if (filename.EndsWith(".html"))
            return true;
        else
            return false;
    }

    public static bool EsPDF(string filename){
        if (filename.EndsWith(".pdf"))
            return true;
        else
            return false;
    }

    public static bool EsImagen(string filename){
        if (filename.EndsWith("png") || filename.EndsWith(".jpg") || filename.EndsWith(".jpeg") || filename.EndsWith(".gif"))
            return true;
        else
            return false;
    }

    public static bool EsAudio(string filename){
        if (filename.EndsWith(".mp3") || filename.EndsWith(".wav"))
            return true;
        else
            return false;
    }

    public static bool EsVideo(string filename){
        if (filename.EndsWith(".mp4") /*|| filename.EndsWith(".avi")*/)
            return true;
        else
            return false;
    }

    public static List<string> ObtenerPalabrasDeFrase(string frase){
        MatchCollection matches = Regex.Matches(frase, @"\b[\w']*\b");

        var words = from m in matches.Cast<Match>()
                    where !string.IsNullOrEmpty(m.Value)
                    select TrimSuffix(m.Value);

        return words.ToList();

    }

    static string TrimSuffix(string word){

        int apostropheLocation = word.IndexOf('\'');
        if (apostropheLocation != -1)
        {
            word = word.Substring(0, apostropheLocation);
        }

        return word;
    }
}