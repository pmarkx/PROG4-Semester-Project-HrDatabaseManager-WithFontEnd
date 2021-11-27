using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DepartmentType { It=1,Legal,Finance}
namespace DCQEB4_HFT_2021221.Models
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set;}

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public DepartmentType Type { get; set; }

        [NotMapped]
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public override string ToString()
        {
            return "Id: " + ID + "\tDepartment Name: " + DepartmentName + "\tType: " + Type;
        }

    }
}
