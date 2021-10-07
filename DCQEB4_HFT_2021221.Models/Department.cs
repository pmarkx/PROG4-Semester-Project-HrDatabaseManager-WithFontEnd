using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DepartmentType { It,Legal,Finance}
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

        [ForeignKey(nameof(Employee))]
        public int EmployeeID { get; set; }

        [NotMapped]
        public virtual Employee Employee { get; set; }

    }
}
