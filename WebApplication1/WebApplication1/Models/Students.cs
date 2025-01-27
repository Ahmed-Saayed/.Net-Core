using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Students{
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "The Lenght Large than Constraints")]
        [MinLength(11,ErrorMessage ="The Lenght Small than Constraints")]
        public string Name { get; set; }

        [Required]
        [Range(1000, 40000, ErrorMessage = "The Number Not in The Ranges")]
        [DisplayName("Salary (Between 1000 , 40000)")]
        public long  Salary { get; set; }

    
        [RegularExpression("Alex|Assiut|Matroh",ErrorMessage = "Not Avalibale only avalibale Alex|Assiut|Matroh")]
        public string City { get; set; }
        
        [DisplayName("Course")]
   
     
        public string course { get; set; }

        public string Phone { get; set; }
        

        [ForeignKey("depkey")]
        public int Dep_id { get; set; }
        public virtual Department? depkey { get; set; }     
    }
}
