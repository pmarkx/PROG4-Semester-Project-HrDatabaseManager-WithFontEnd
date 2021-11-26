using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic dep;
        public DepartmentController(IDepartmentLogic dep)
        {
            this.dep = dep;
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
        }
        [HttpPut]
        public void Put([FromBody] Department value)
        {
            dep.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dep.Delete(id);
        }
    }
}
