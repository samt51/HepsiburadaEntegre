using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EfasisCMS.entegrasyon.pazaryeri.Hepsiburada;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using Newtonsoft.Json;
    using EfasisCMS.entegrasyon.pazaryeri.Hepsiburada;



    public class CategoriaAllGet
    {

        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }

        public bool first { get; set; }
        public bool last { get; set; }
        public List<categoria> data { get; set; }



        public List<categoria> CategoryAll(string token)
        {
            WebClient wc = new WebClient();

            JavaScriptSerializer js = new JavaScriptSerializer();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Authorization", "Bearer" + token);
            wc.Headers.Add("Accept", "application/json");
            string data = wc.DownloadString("https://mpop.hepsiburada.com/product/api/categories/get-all-categories?leaf=true&status=ACTIVE&available=true&page=0&size=2000&version=1");
            //string data = wc.DownloadString("https://mpop.hepsiburada.com/product/api/categories/get-all-categories");
            CategoriaAllGet d = js.Deserialize<CategoriaAllGet>(data);
            List<categoria> list = d.data;
            return list;

        }

    }

    public class categoria
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public int parentCategoryId { get; set; }
        public string[] paths { get; set; }
        public bool leaf { get; set; }
        public string status { get; set; }
        public bool available { get; set; }
        public List<categoria> ct { get; set; }
       


    }

    










}