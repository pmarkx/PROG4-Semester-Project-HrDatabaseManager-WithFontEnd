using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCQEB4_HFT_2021221.Models;
using System.Threading.Tasks;
using DCQEB4_HFT_2021221.Data;

namespace DCQEB4_HFT_2021221.Repository
{
    class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(HrDbContext contex) : base(contex)
        {
        }

        public void ChangeDate(int id, DateTime NewDate)
        {
            var sal = GetAll().FirstOrDefault(x => x.ID == id);
            sal.Date = NewDate;
            contex.SaveChanges();
        }

        public void ChangeEmployee(int id, int NewEmpID)
        {
            var sal = GetAll().FirstOrDefault(x => x.ID == id);
            sal.EmployeeID = NewEmpID;
            contex.SaveChanges();
        }

        public override Salary GetOne(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}
