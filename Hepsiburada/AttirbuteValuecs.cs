using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;

    public class AttirbuteValuecs
    {

        public class attirbutevaluee
        {
            public string id { get; set; }
            public string value { get; set; }
            public List<value> asd { get; set; }




            public List<attirbutevaluee> valuelist(string token, int categoryid, string attributeid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Authorization", "Bearer" + token);
                wc.Headers.Add("Accept", "application/json");
                var data = wc.DownloadString(
                    $"https://mpop.hepsiburada.com/product/api/categories/{categoryid}/attribute/{attributeid}");
                Root atr = js.Deserialize<Root>(data);
                List<attirbutevaluee> value = atr.data;

                if (value == null)
                {
                    return value;
                }
                return value;
            }

        }
        public class value
        {
            public List<attirbutevaluee> vas { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public int code { get; set; }
            public int version { get; set; }
            public string message { get; set; }
            public List<attirbutevaluee> data { get; set; }
        }

        public List<attirbutevaluee> valuelist(string token, int categoryid, string attributeid)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Authorization", "Bearer" + token);
            wc.Headers.Add("Accept", "application/json");
            var data = wc.DownloadString(
                $"https://mpop.hepsiburada.com/product/api/categories/{categoryid}/attribute/{attributeid}");
            Root atr = js.Deserialize<Root>(data);
            List<attirbutevaluee> value = atr.data;

            if (value == null)
            {
                return value;
            }
            return value;
        }


    }
}