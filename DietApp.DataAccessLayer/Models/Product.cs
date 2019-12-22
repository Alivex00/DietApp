using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietApp.DataAccessLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int ENERC_KCAL { get; set; }
        public int PROCNT { get; set; }
        public int FAT { get; set; }
        public int CHOCDF { get; set; }
        public string DATE { get; set; }

    }
}
