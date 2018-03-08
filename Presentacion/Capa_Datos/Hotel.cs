using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Npgsql;

namespace Capa_Datos
{
    public class Hotel
    {
        XmlDocument doc;
        string rutaXml;

        public void _crearXml(string ruta, string nodoRaiz)
        {

            this.rutaXml = ruta;
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlNode root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);


            XmlNode element1 = doc.CreateElement(nodoRaiz);
            doc.AppendChild(element1);
            doc.Save(ruta);
        }

        public void _Añadir(string id, string nom, string foto, string habi, string pais, string lugar)
        {
            doc.Load(rutaXml);

            XmlNode empleado = _Crear_Hotel(id, nom, foto, habi, pais, lugar);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);

            doc.Save(rutaXml);


        }

        private XmlNode _Crear_Hotel(string id, string nom, string foto, string habi, string pais, string lugar)
        {

            XmlNode empleado = doc.CreateElement("persona");


            XmlElement xid = doc.CreateElement("id");
            xid.InnerText = id;
            empleado.AppendChild(xid);


            XmlElement xnombre = doc.CreateElement("nombre");
            xnombre.InnerText = nom;
            empleado.AppendChild(xnombre);


            XmlElement xfotos = doc.CreateElement("foto");
            xfotos.InnerText = foto;
            empleado.AppendChild(xfotos);


            XmlElement xhabitacion = doc.CreateElement("habitaciones");
            xhabitacion.InnerText = habi;
            empleado.AppendChild(xhabitacion);

            XmlElement xpais = doc.CreateElement("pais");
            xpais.InnerText = pais;
            empleado.AppendChild(xpais);

            XmlElement xlugar = doc.CreateElement("lugar");
            xlugar.InnerText = lugar;
            empleado.AppendChild(xlugar);

            return empleado;
        }

        public void _ReadXml(DataGridView mostrar)
        {

            doc.Load(rutaXml);

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            XmlNode unEmpleado;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {

                unEmpleado = listaEmpleados.Item(i);

                string id = unEmpleado.SelectSingleNode("id").InnerText;
                string nombre = unEmpleado.SelectSingleNode("nombre").InnerText;
                string foto = unEmpleado.SelectSingleNode("foto").InnerText;
                string habi = unEmpleado.SelectSingleNode("habitaciones").InnerText;
                string pais = unEmpleado.SelectSingleNode("pais").InnerText;
                string lugar = unEmpleado.SelectSingleNode("lugar").InnerText;

                mostrar.Rows.Add(id, nombre, foto, habi, pais, lugar);

            }

        }

        public void _ReadXmlCombo(ArrayList array)
        {

            doc.Load(rutaXml);

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            XmlNode unEmpleado;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {

                unEmpleado = listaEmpleados.Item(i);

                string nombre = unEmpleado.SelectSingleNode("nombre").InnerText;

                array.Add(nombre);

            }

        }

        public void _DeleteNodo(string id_borrar)
        {
            doc.Load(rutaXml);

            XmlNode empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            foreach (XmlNode item in listaEmpleados)
            {

                if (item.SelectSingleNode("id").InnerText == id_borrar)
                {

                    XmlNode nodoOld = item;

                    empleados.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
        }

        public void _UpdateXml(string id_update, string nom, string foto, string habi, string pais, string lugar)
        {

            XmlElement empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            XmlNode nuevo_empleado = _Crear_Hotel(id_update, nom, foto, habi, pais, lugar);

            foreach (XmlNode item in listaEmpleados)
            {

                if (item.FirstChild.InnerText == id_update)
                {
                    XmlNode nodoOld = item;
                    empleados.ReplaceChild(nuevo_empleado, nodoOld);

                }
            }

            doc.Save(rutaXml);
        }
    }
}

