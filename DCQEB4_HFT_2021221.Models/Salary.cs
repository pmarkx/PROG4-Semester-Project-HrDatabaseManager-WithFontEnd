using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Models
{
    [Table("salaries")]
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int BaseSalary { get; set; }

        public int? Bonus { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeID { get; set; }

        [NotMapped]
        public virtual Employee Employee { get; set; }
    }
}
