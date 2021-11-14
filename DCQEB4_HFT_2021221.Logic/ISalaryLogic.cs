using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCQEB4_HFT_2021221.Models;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    interface ISalaryLogic
    {
        Salary GetOne(int id);
        IList<Salary> GetAll();
        void Update(Salary updatedSal);
        void Create(Salary newSal);
        void Delete(int id);
        void Delete(Salary delete);
        void ChangeDate(int id, DateTime NewDate);
        void ChangeEmployee(int id, int NewEmpID);

    }
}
