using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    public class ProductAdd: DynamicObject
    {
      
        public string merchant { get; set; }
        public string merchantSku { get; set; }
        public string VaryantGroupID { get; set; }
        public string Barcode { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklamasi { get; set; }
        public string Marka { get; set; }
        public int GarantiSuresi { get; set; }
        public string kg { get; set; }
        public string tax_vat_rate { get; set; }
        public int categoryId { get; set; }
        public List<ProductImages> Images { get; set; }
      
     
       public Dictionary<dynamic,dynamic> keyvalue { get; set; }








    }
}