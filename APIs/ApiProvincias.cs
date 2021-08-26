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
        public List<Provincia> provincias;

        public APIProvincias()
        {
            provincias = GetWebServiceProvincias();
        }

        
        private static List<Provincia> GetWebServiceProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            Provincias ProvinciasArg = null;

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
                                ProvinciasArg = JsonSerializer.Deserialize<Provincias>(responseBody);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Hubo un error con el servicio web");
            }

            return ProvinciasArg.provincias;
        }

        public List<Provincia> GetListadoDeProvincias()
        {
            return provincias;
        }
    }
}