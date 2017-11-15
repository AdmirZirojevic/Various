using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Prozori
{
    class WindowSpecs
    {         
        public int WindowSpecsId { get; set; }
        [MaxLength(30)]
        public string Profil { get; set; }
        [MaxLength(15)]
        public string Boja { get; set; }
        [MaxLength(30)]
        public string Okov { get; set; }
        [MaxLength(30)]
        public string Ispuna { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }
        public double Vrijednost { get; set; }     
    }
}
