using Microsoft.AspNetCore.Http;
using DCQEB4_HFT_2021221.Logic;
using DCQEB4_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using DCQEB4_HFT_2021221.Endpoint.Services;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic emp;
        IHubContext<SignalRHub> hub;
        public EmployeeController(IEmployeeLogic emp, IHubContext<SignalRHub> hub)
        {
            this.emp = emp;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return emp.GetAll();
        }
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return emp.GetOne(id);
        }
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            emp.Create(value);
            hub.Clients.All.SendAsync("EmpCreated",value);
        }
        [HttpPut]
        public void Put([FromBody] Employee value)
        {
            emp.Update(value);
            hub.Clients.All.SendAsync("EmpUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var emptodelete = emp.GetOne(id);
            emp.Delete(id);
            hub.Clients.All.SendAsync("EmpDeleted", emptodelete);
        }
    }
}
