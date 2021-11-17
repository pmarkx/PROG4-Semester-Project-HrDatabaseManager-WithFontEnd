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
        public double AvargePrice { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is DepartmentCost)
            {
                var other = obj as DepartmentCost;
                return this.AvargePrice == other.AvargePrice && this.DepartmentName == other.DepartmentName;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.DepartmentName.GetHashCode() + (int)this.AvargePrice;
        }

        public override string ToString()
        {
            return $"BrandName={DepartmentName}, AveragePrice={AvargePrice}";
        }
    }
}
