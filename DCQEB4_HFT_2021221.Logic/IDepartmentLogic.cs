using System;
using System.Collections.Generic;
using DCQEB4_HFT_2021221.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    public interface IDepartmentLogic
    {
        Department GetOne(int id);
        IList<Department> GetAll();
        void Update(Department updatedDep);
        void Create(Department newDep);
        void Delete(int id);
        void Delete(Department delete);
        void ChangeName(int id, string NewName);
        void ChangeType(int id, DepartmentType Newdeptype);
        IList<DepartmentCost> DepartmentCost();
        IList<Employee> ListAllEmpForOneDep(int id);
        IList<Salary> ListAllSalForOneEmp(int id);
    }
}
