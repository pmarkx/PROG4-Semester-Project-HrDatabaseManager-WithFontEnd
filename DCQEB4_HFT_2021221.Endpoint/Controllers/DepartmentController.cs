using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using DCQEB4_HFT_2021221.Endpoint.Services;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic dep;
        IHubContext<SignalRHub> hub;
        public DepartmentController(IDepartmentLogic dep, IHubContext<SignalRHub> hub)
        {
            this.dep = dep;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return dep.GetAll();
        }
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return dep.GetOne(id);
        }
        [HttpPost]
        public void Post([FromBody] Department value)
        {
            dep.Create(value);
            hub.Clients.All.SendAsync("DepCreated", value);
        }
        [HttpPut]
        public void Put([FromBody] Department value)
        {
            dep.Update(value);
            hub.Clients.All.SendAsync("DepUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deptodelete=dep.GetOne(id);
            dep.Delete(id);
            hub.Clients.All.SendAsync("DepDeleted", deptodelete);
        }
    }
}
