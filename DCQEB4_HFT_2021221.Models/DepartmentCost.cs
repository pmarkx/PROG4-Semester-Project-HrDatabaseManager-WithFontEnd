using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Models
{
    public class DepartmentCost
    {
        public string DepartmentName { get; set; }
        public double AvargeCost { get; set; }

        public override string ToString()
        {
            return $"Department Name: {DepartmentName}, \tDepartment Avarage Salary: {AvargeCost}";
        }
    }
}
