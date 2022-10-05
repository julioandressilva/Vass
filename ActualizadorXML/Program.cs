using System;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace ActualizadorXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string UrlActual = "";
            string VersionSistema = "";
            string versionActual = "";

            try
            {
                UrlActual = ConfigurationManager.AppSettings["RutaEjeuctable"].ToString();
                VersionSistema = ConfigurationManager.AppSettings["Version"].ToString();
            }
            catch (Exception e)
            {
               
                throw new Exception("No se encunetra configurada la ruta y la version en el config", e);
            }

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(UrlActual);

                XmlNodeList xParametros = xDoc.GetElementsByTagName("parametros");
                versionActual = ((XmlElement)xParametros[0]).GetElementsByTagName("version")[0].InnerText;
            }
            catch (Exception e)
            {

                throw new Exception("No es posible procesar el archivo configuracion del ejecutable", e);
            }

           

            if (double.Parse(VersionSistema) > double.Parse(versionActual))
            {
                Console.WriteLine("Se actualizan los datos del sistema con nueva version " + VersionSistema);
            }else
            {
                Console.WriteLine("No se actualiza version");
            }
            
           
        }
    }
}
