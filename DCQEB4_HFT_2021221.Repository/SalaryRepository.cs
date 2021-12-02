using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCQEB4_HFT_2021221.Models;
using System.Threading.Tasks;
using DCQEB4_HFT_2021221.Data;

namespace DCQEB4_HFT_2021221.Repository
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(HrDbContext contex) : base(contex)
        {

        }

        public override void Delete(int id)
        {
            contex.Set<Salary>().Remove(GetOne(id));
            contex.SaveChanges();
        }

        public override Salary GetOne(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}
