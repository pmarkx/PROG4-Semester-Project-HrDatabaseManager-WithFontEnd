using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Logic;
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
    public class SalaryController : ControllerBase
    {
        ISalaryLogic sal;
        IHubContext<SignalRHub> hub;
        public SalaryController(ISalaryLogic sal, IHubContext<SignalRHub> hub)
        {
            this.sal = sal;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Salary> Get()
        {
            return sal.GetAll();
        }
        [HttpGet("{id}")]
        public Salary Get(int id)
        {
            return sal.GetOne(id);
        }
        [HttpPost]
        public void Post([FromBody] Salary value)
        {
            sal.Create(value);
            hub.Clients.All.SendAsync("SalCreated", value);
        }
        [HttpPut]
        public void Put([FromBody] Salary value)
        {
            sal.Update(value);
            hub.Clients.All.SendAsync("SalUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var saltodelete = sal.GetOne(id);
            sal.Delete(id);
            hub.Clients.All.SendAsync("DeletedSal", saltodelete);
        }
    }
}
