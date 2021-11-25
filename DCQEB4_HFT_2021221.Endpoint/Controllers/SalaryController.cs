using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        ISalaryLogic sal;
        public SalaryController(ISalaryLogic sal)
        {
            this.sal = sal;
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
        }
        [HttpPut]
        public void Put([FromBody] Salary value)
        {
            sal.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sal.Delete(id);
        }
    }
}
