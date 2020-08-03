using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace _07LoginBasico
{
    class UtilesXML
    {
        public void CrearXML(string rutaArchivo)
        {
            try
            {
                XmlReader lector = XmlReader.Create(rutaArchivo);
                lector.Close();
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
                XmlWriter escritor = null;
                try
                {
                    escritor = XmlWriter.Create(rutaArchivo);
                    escritor.WriteStartElement("configuración");
                    escritor.WriteEndElement();
                    escritor.Flush();

                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }

                escritor.Close();
            }
            
        }


        public string AgregarConfig(string rutaArchivo, string[] parConfigDato)
        {
            string resultado = "";
            XmlWriter escritor = null;
            try
            {
                escritor = XmlWriter.Create(rutaArchivo);
                escritor.WriteStartElement("configuración");
                foreach (var par in parConfigDato)
                {
                    string config = par.Split(':')[0];
                    string dato = par.Split(':')[1];
                    escritor.WriteElementString(config, dato);
                }
                escritor.WriteEndElement();
                escritor.Flush();
                resultado = "Datos guardados con éxito";
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
                Console.WriteLine(ex.Message);
            }

            escritor.Close();
            return resultado;
        }




        public string LeerConfig(string rutaArchivo, string config)
        {
            string dato = "";
            try
            {
                XDocument archivo = XDocument.Load(rutaArchivo);
                foreach (var item in archivo.Element("configuración").Descendants())
                {
                    if (item.Name.ToString().Equals(config))
                    {
                        dato = item.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                dato = "Error: " + ex.Message;
            }
            return dato;
        }

    }
}
