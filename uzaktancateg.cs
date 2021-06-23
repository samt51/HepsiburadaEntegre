using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    public class uzaktancateg
    {
     
            public int categoryId { get; set; }
            public string name { get; set; }
            public int parentCategoryId { get; set; }
            public string[] paths { get; set; }
            public bool leaf { get; set; }
            public string status { get; set; }
            public bool available { get; set; }


    }
}