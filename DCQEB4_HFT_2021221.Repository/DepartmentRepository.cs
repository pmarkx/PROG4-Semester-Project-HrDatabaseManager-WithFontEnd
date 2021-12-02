using System;
using System.Collections.Generic;
using System.Linq;
using DCQEB4_HFT_2021221.Models;
using System.Text;
using System.Threading.Tasks;
using DCQEB4_HFT_2021221.Data;

namespace DCQEB4_HFT_2021221.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HrDbContext contex) : base(contex)
        {

        }

        public override void Delete(int id)
        {
            contex.Set<Department>().Remove(GetOne(id));
            contex.SaveChanges();
        }

        public override Department GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }

        public override Department GetOne(string name)
        {
            return GetAll().SingleOrDefault(x => x.DepartmentName == name);
        }
    }
}
