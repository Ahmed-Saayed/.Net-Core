using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Department
    {
        [DisplayName("DepID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maneger_name { get; set; }

        public virtual List<Students>? vec_st { get; set; }
    
    }
}