using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    public class ProductCreate
    {
        public string Add(List<ProductAdd> item)
        {
            #region token
            JavaScriptSerializer js = new JavaScriptSerializer();
            


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
           

            String data = js.Serialize(item);

            string json = @"[{""basim_variant_property"":""Almanca"",""secenek_variant_property"":""SARI"",""kitap-ebati_variant_property"":""Cep Boy"",""00001CM0"":""Evet"",""kitap-cildi_variant_property"":""Ciltli"",""0000412H"":""Ciltsiz""}]";




            //data += json;
            

            HttpWebRequest req =
                (HttpWebRequest)WebRequest.Create("https://mpop.hepsiburada.com/api/authenticate");
            req.Method = "POST";
            req.ContentType = "application/json";

            string loginjson = js.Serialize(new
            {
                username = "bebekmamadeposu_dev",
                password = "!GjuoRLEMncFCB",
                authenticationType = "INTEGRATOR"
            });
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(loginjson);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();

            streamIn.Close();

            #endregion



         

            const string URL = "https://mpop.hepsiburada.com/product/api/products/import";


            var target = @"E:\deneme.json";
            FileInfo filee = new FileInfo(target);

            StreamWriter wr = new StreamWriter(target);
            wr.WriteLine(data);
            wr.Close();




            var file = @"C:\bodyy.json";

            var path = @"E:\deneme.json";

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");


            var requestt = (HttpWebRequest)WebRequest.Create(URL);




            requestt.Headers.Add("Authorization", "Bearer" + strResponse.Replace("\"id_token\":", "").Replace("{", "").Replace("}", "").Replace('"', ' ').Replace('"', ' '));

            requestt.ContentType = "multipart/form-data;boundary=" + boundary;
            requestt.Accept = "application/json";
            requestt.Method = "POST";
            requestt.KeepAlive = true;
            requestt.Credentials = System.Net.CredentialCache.DefaultCredentials;

            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


            string headerTemplate = "Content-Disposition: form-data;name=\"{0}\";filename=\"{1}\"\r\n\r\n\r\n";
            string header = string.Format(headerTemplate, "file", path);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            requestt.ContentLength = new FileInfo(path).Length + headerbytes.Length + (boundarybytes.Length * 2) + 2;
            Stream requestStream = requestt.GetRequestStream();

            requestStream.Write(boundarybytes, 0, boundarybytes.Length);
         

            requestStream.Write(headerbytes, 0, headerbytes.Length);

            FileStream files = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;

 

            while ((bytesRead = files.Read(buffer, 0, buffer.Length)) != 0)

            {

                requestStream.Write(buffer, 0, bytesRead);

                requestStream.Flush();

            }
            boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");


            requestStream.Write(boundarybytes, 0, boundarybytes.Length);

            requestStream.Close();
            files.Close();


            WebResponse webResponse = requestt.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string responseString = reader.ReadToEnd();
           
            if (responseString != null)
            {
                strResponse.Replace("\"id_token\":", "").Replace("{", "").Replace("}", "").Replace('"', ' ')
                    .Replace('"', ' ');

                //4cb667ec-e58a-40a6-a57b-3b13e0863b76
                //09e21672-b488-4e27-a039-cabf4c5c2d76
            }


            webResponse.Close();
           
            return null;
        }
    }
}