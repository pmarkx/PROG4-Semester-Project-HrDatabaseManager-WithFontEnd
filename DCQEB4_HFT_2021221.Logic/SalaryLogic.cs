using DCQEB4_HFT_2021221.Models;
using System;
using DCQEB4_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    public class SalaryLogic : ISalaryLogic
    {
        ISalaryRepository SalRepo;
        public SalaryLogic(ISalaryRepository salaryLogic)
        {
            SalRepo = salaryLogic;
        }


        public void Create(Salary newSal)
        {
            //if (newSal.ID < 1)
            //{
            //    throw new ArgumentException("WrongID");
            //}
            if (newSal.EmployeeID<1)
            {
                throw new ArgumentException("WrongID");
            }
            if (newSal.BaseSalary<10)
            {
                throw new ArgumentException("Minum salary is required");
            }
            SalRepo.Create(newSal);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            SalRepo.Delete(id);
        }

        public void Delete(Salary delete)
        {
            if (delete.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            SalRepo.Delete(delete);
        }

        public IList<Salary> GetAll()
        {
            return SalRepo.GetAll().ToList();
        }

        public Salary GetOne(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            return SalRepo.GetOne(id);
        }

        public void Update(Salary updatedSal)
        {
            if (updatedSal.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            SalRepo.Update(updatedSal);
        }
    }
}
