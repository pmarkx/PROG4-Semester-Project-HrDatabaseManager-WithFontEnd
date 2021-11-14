using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    class DepartmentLogic : IDepartmentLogic
    {
        IDepartmentRepository depRepo;
        public void ChangeName(int id, string NewName)
        {
            if (id<1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.ChangeName(id,NewName);
        }

        public void ChangeType(int id, DepartmentType Newdeptype)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.ChangeType(id, Newdeptype);
        }

        public void Create(Department newDep)
        {
            if (newDep.ID < 1)
            {
                throw new ArgumentException("New ID mustbe positive");
            }
            depRepo.Create(newDep);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.Delete(id);
        }

        public void Delete(Department delete)
        {
            if (delete.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.Delete(delete);
        }

        public IList<Department> DepartmentCost()
        {
            //var x = from y in depRepo.GetAll()
            //        group y by new { y.DepartmentName, y.ID } into g
            //        select new
            //        {
            //            DepartmentName=g.Key.DepartmentName,
            //            Cost=Math.Round(g.Average(z=>z.Employees.Select(k=>k.Salaries.Select(l=>l.BaseSalary+l.Bonus))),2)
            //        };
            //return x.ToList();
            throw new NotImplementedException();


        }

        public IList<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department updatedDep)
        {
            throw new NotImplementedException();
        }
    }
}
