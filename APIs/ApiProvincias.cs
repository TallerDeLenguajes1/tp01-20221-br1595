using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AppProvincias.APIs
{
    class APIProvincias
    {
        private List<Provincias> provincias;

        public APIProvincias()
        {
            provincias = GetWebServiceProvincias();
        }

        private static List<Provincias> GetWebServiceProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<Provincias> ProvinciasArg = null;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                ProvinciasArg = JsonSerializer.Deserialize<List<Provincias>>(responseBody);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Hubo un error con el servicio web");
            }

            return ProvinciasArg.OrderBy(x => x.Nombre).ToList(); ;
        }

        public List<Provincias> GetListadoDeProvincias()
        {
            return provincias;
        }

        public void ActualizarProvincias()
        {
            List<Provincias> provincias2 = null;
            if ((provincias = GetListadoDeProvincias()) != null)
            {
                provincias = provincias2;
            }
        }
    }
}