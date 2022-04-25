using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DCQEB4_HFT_2021221.Logic;
using DCQEB4_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using DCQEB4_HFT_2021221.Endpoint.Services;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IDepartmentLogic deplogic;
        IEmployeeLogic emplogic;
        ISalaryLogic sallogic;
        IHubContext<SignalRHub> hub;
        public StatController(IDepartmentLogic deplogic, IEmployeeLogic emplogic, ISalaryLogic sallogic,IHubContext<SignalRHub> hub)
        {
            this.deplogic = deplogic;
            this.emplogic = emplogic;
            this.sallogic = sallogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<DepartmentCost> GetDepartmentCosts()
        {
            return deplogic.DepartmentCost();
        }
        [HttpGet]
        public IEnumerable<DepartmentCost> AllEmpAvarageSalary()
        {
            return emplogic.EmployeeAvargeSalary();
        }
        [HttpGet("{id}")]
        public IEnumerable<Employee> GetEmpForOneDep(int id)
        {
            return deplogic.ListAllEmpForOneDep(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<Salary> GetSalForOneEmp(int id)
        {
            return deplogic.ListAllSalForOneEmp(id);
        }
        [HttpGet]
        public IEnumerable<Employee> BiggestSalaryEmployee()
        {
            List<Employee> emp = new List<Employee>();
            emp.Add(emplogic.BiggestSalaryEmployee());
            return emp;
        }

    }
}
