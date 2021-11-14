using System;
using System.Collections.Generic;
using System.Linq;
using DCQEB4_HFT_2021221.Models;
using System.Text;
using System.Threading.Tasks;
using DCQEB4_HFT_2021221.Data;

namespace DCQEB4_HFT_2021221.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HrDbContext contex) : base(contex)
        {
        }

        public void ChangeDepartment(int id, int NewDepID)
        {
            var emp = GetAll().SingleOrDefault(x => x.ID == id);
            emp.DepartmentID = NewDepID;
            contex.SaveChanges();
        }

        public void ChangeEmail(int id, string NewEmail)
        {
            var emp = GetAll().SingleOrDefault(x => x.ID == id);
            emp.Email = NewEmail;
            contex.SaveChanges();
        }

        public void ChangeName(int id, string NewName)
        {
            var emp = GetAll().SingleOrDefault(x => x.ID == id);
            emp.Name = NewName;
            contex.SaveChanges();
        }

        public override void Delete(int id)
        {
            contex.Set<Employee>().Remove(GetOne(id));
            contex.SaveChanges();
        }

        public override Employee GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }
    }
}
