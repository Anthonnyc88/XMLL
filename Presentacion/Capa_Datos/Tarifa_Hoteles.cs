using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Capa_Datos
{
    class Tarifa_Hoteles
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

        public void _Añadir(string id, string tarifa, string hotel)
        {
            doc.Load(rutaXml);

            XmlNode empleado = _Crear_Tarifa(id, tarifa, hotel);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);

            doc.Save(rutaXml);


        }

        private XmlNode _Crear_Tarifa(string id, string tarifa, string hotel)
        {

            XmlNode empleado = doc.CreateElement("persona");


            XmlElement xid = doc.CreateElement("id");
            xid.InnerText = id;
            empleado.AppendChild(xid);


            XmlElement xtarifa = doc.CreateElement("tarifa");
            xtarifa.InnerText = tarifa;
            empleado.AppendChild(xtarifa);

            XmlElement xhotel = doc.CreateElement("hotel");
            xhotel.InnerText = hotel;
            empleado.AppendChild(xhotel);

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
                string tarifa = unEmpleado.SelectSingleNode("tarifa").InnerText;
                string hotel = unEmpleado.SelectSingleNode("hotel").InnerText;

                mostrar.Rows.Add(id, tarifa, hotel);

            }

        }

        public void _ReadXmlVerificar(ArrayList array)
        {

            doc.Load(rutaXml);

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            XmlNode unEmpleado;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {

                unEmpleado = listaEmpleados.Item(i);

                string hotel = unEmpleado.SelectSingleNode("hotel").InnerText;
                array.Add(hotel);

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

        public void _UpdateXml(string id_update, string nom, string hotel)
        {

            XmlElement empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("Empleados/persona");

            XmlNode nuevo_empleado = _Crear_Tarifa(id_update, nom, hotel);

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

    
