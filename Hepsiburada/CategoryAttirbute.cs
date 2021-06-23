using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    using System.Net;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Web.Script.Serialization;
    using static EfasisCMS.entegrasyon.pazaryeri.Hepsiburada.AttirbuteValuecs;

    public class CategoryAttirbute
    {
       
        
        public class BaseAttribute
        {
            public string name { get; set; }
            public string id { get; set; }
            public bool mandatory { get; set; }
            public string type { get; set; }
            public bool multiValue { get; set; }
        }

        public class Attribute
        {
            public string name { get; set; }
            public string id { get; set; }
            public bool mandatory { get; set; }
            public string type { get; set; }
            public bool multiValue { get; set; }
        }

        public class VariantAttribute
        {
            public string name { get; set; }
            public string id { get; set; }
            public bool mandatory { get; set; }
            public string type { get; set; }
            public bool multiValue { get; set; }
            public List<Attribute> attirbute { get; set; }
            public List<attirbutevaluee> values { get; set; }
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
            VariantAttribute atr = js.Deserialize<VariantAttribute>(data);

            List<attirbutevaluee> asw = atr.values;

            return asw;
        }

        public class atttirbutevalues
        {
            public List<VariantAttribute> variamt { get; set; }
        }

        public class Data
        {
            public List<BaseAttribute> baseAttributes { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<VariantAttribute> variantAttributes { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public int code { get; set; }
            public int version { get; set; }
            public object message { get; set; }
            public Data data { get; set; }
        }


      

        public List<VariantAttribute> ozellikk(string token, int categoryid)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            WebClient cs = new WebClient();
            cs.Encoding = Encoding.UTF8;
            cs.Headers.Add("Authorization", "Bearer" + token);
            cs.Headers.Add("Accept", "application/json");
            var data = cs.DownloadString($"https://mpop.hepsiburada.com/product/api/categories/{categoryid}/attributes");
            Root rd = js.Deserialize<Root>(data);
            Data dt = new Data();
            dt = rd.data;
            List<VariantAttribute> t = dt.variantAttributes;
  
           
            return t;

        }
        public List<Attribute> ozellik(string token, int categoryid)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            WebClient cs = new WebClient();
            cs.Encoding = Encoding.UTF8;
            cs.Headers.Add("Authorization", "Bearer" + token);
            cs.Headers.Add("Accept", "application/json");
            var data = cs.DownloadString($"https://mpop.hepsiburada.com/product/api/categories/{categoryid}/attributes");
            Root rd = js.Deserialize<Root>(data);
            Data dt = new Data();
            dt = rd.data;
            List<Attribute> t = dt.attributes;
            return t;

        }



    }
}