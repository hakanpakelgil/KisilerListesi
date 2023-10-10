using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IsinmaForm
{
    public class Kisi
    {
        public string Ad { get; set; } = "";
        public string Soyad { get; set; } = "";
        
       

        //public string TamAd => $"{Ad} {Soyad}";
        public override string ToString()
        {
            return $"{Ad} {Soyad}"; 
        }
    }
}
