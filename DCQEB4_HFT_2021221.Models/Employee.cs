using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }

        [NotMapped]
        public virtual Department Department { get; set; }

        [NotMapped]
        public virtual ICollection<Salary> Salaries { get; set; }

        public Employee()
        {
            Salaries = new HashSet<Salary>();
        }
    }
}
