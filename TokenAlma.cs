using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;

    public class TokenAlma
    {
        public List<TokenAlma> deneme()
        {
            var username = "bebekmamadeposu_dev";
            var password = "!GjuoRLEMncFCB";
            var integrator = "INTEGRATOR";
            JavaScriptSerializer js = new JavaScriptSerializer();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string deger =
                $"{{\r\n    \"username\": \"{username}\",\r\n   \"password\": \"{password}\",\r\n   \"authenticationType\": \"{integrator}\"\r\n}}";
            var d = js.Deserialize<List<TokenAlma>>(deger);
            return null;
         
        }

     

        public string Token()
        {
            var username = "bebekmamadeposu_dev";
            var password = "!GjuoRLEMncFCB";
            var integrator = "INTEGRATOR";
            JavaScriptSerializer js = new JavaScriptSerializer();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;

            var deger =
                $"{{\r\n    \"username\": \"{username}\",\r\n   \"password\": \"{password}\",\r\n   \"authenticationType\": \"{integrator}\"\r\n}}";
             
           

            var httprequest = WebRequest.Create("https://mpop.hepsiburada.com/api/authenticate");
            httprequest.ContentType = "application/json";

            httprequest.Credentials = CredentialCache.DefaultCredentials;
            var byteArray = Encoding.UTF8.GetBytes(deger);
            httprequest.Method = "POST";


            httprequest.ContentLength = byteArray.Length;
            Stream dataStream = httprequest.GetRequestStream();
            dataStream.Write(byteArray,0,byteArray.Length);
            dataStream.Close();
            WebResponse response = httprequest.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string nt = reader.ReadToEnd();
            
            reader.Close();
            dataStream.Close();
            response.Close();




            var tokn= nt.Replace("\"id_token\":", "").Replace("{", "").Replace("}", "").Replace('"', ' ').Replace('"', ' ');

            //CategoriaAllGet ctg = new CategoriaAllGet();
            //ctg.CategoryAll(tokn);

            return tokn;
        }
    }
}