using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    public class Urunler
    {
        public class Attributes
        {
            public string merchantSku { get; set; }
            public string VaryantGroupID { get; set; }
            public string Barcode { get; set; }
            public string UrunAdi { get; set; }
            public string UrunAciklamasi { get; set; }
            public string Marka { get; set; }
            public int GarantiSuresi { get; set; }
            public string kg { get; set; }
            public string tax_vat_rate { get; set; }
            public string price { get; set; }
            public string stock { get; set; }
            public string Image1 { get; set; }
            public string Image2 { get; set; }
            public string Image3 { get; set; }
            public string Image4 { get; set; }
            public string Image5 { get; set; }
            public string renk_variant_property { get; set; }
            public string ebatlar_variant_property { get; set; }
        }

        public class Root
        {
            public int categoryId { get; set; }
            public string merchant { get; set; }
            public Attributes attributes { get; set; }
        }


    }
}