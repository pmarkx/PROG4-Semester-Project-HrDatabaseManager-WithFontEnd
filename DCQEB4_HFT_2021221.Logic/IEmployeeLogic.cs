using System;
using System.Collections.Generic;
using System.Linq;
using DCQEB4_HFT_2021221.Models;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    public interface IEmployeeLogic
    {
        Employee GetOne(int id);
        IList<Employee> GetAll();
        void Update(Employee updatedEmp);
        void Create(Employee newEmp);
        void Delete(int id);
        void Delete(Employee delete);
        IList<DepartmentCost> EmployeeAvargeSalary();
        Employee BiggestSalaryEmployee();

    }
}
