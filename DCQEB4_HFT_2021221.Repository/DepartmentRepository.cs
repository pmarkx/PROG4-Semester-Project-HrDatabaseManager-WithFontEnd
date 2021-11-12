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

        public void ChangeName(int id, string NewName)
        {
            var dep = GetAll().SingleOrDefault(x => x.ID == id);
            dep.DepartmentName = NewName;
            contex.SaveChanges();
        }

        public void ChangeType(int id, DepartmentType Newdeptype)
        {
            var dep = GetAll().SingleOrDefault(x => x.ID == id);
            dep.Type = Newdeptype;
            contex.SaveChanges();
        }

        public override Department GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }
    }
}
