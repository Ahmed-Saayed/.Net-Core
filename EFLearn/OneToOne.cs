using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLearn
{
    internal class OneToOne
    {
    }

    public class Depatment      // principal table
    {
        public int DepatmentID { get; set; }        // principal key
        public string DepatmentName { get; set; }

        public Person Personn { get; set; }         // navigation property
    }
    public class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }

        public int DepID { get; set; }      // foreign key

        //[ForeignKey("DepatmentNumber")]
        public Depatment Depatmentt { get; set; } // reference navigation property
    }
}
