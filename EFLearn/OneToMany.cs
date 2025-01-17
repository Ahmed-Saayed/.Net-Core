using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLearn
{
    internal class OneToMany
    {
    }

    public class Car        // Principal table
    {
        public int CarID { get; set; }
        public string CarName { get; set; }                 // principal key

        public List<CarSale> CarSale { get; set; }          // collection navigation property
    }
    public class CarSale    // Dependent table
    {
        public int SaleID { get; set; }
        public string SaleName { get; set; }

        public string CN { get; set; }                      // foreign key

        //[ForeignKey("CN")]
        public Car Carr { get; set; }       // reference navigation property
    }
}
