using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class MusteriBilgi
    {
        public string sehir { get; set; }
        public string sube { get; set; }
        public string subekodu { get; set; }
        public string seri_no { get; set; }
        public string model { get; set; }
        public DateTime garanti_baslangici { get;set; }
        public string garanti_suresi { get; set; }
        public DateTime bitis_tarihi { get; set; }
        public string teknisyen { get; set; }
        public DateTime onceki_bakim { get; set; }
        public DateTime planlanan_bakim { get; set; }
        public int fark { get; set; }

        public override string ToString()
        {
            return sehir + ";" + sube + ";" + subekodu + ";" + seri_no + ";" + model + ";" + garanti_baslangici + ";" + garanti_suresi + ";" + bitis_tarihi + ";" + teknisyen + ";" + onceki_bakim + ";" + planlanan_bakim + ";" + fark;
        }
    }
    
}
