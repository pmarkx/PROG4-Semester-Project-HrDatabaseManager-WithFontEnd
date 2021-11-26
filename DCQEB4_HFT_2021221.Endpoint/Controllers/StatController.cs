using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DCQEB4_HFT_2021221.Logic;
using DCQEB4_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
         IDepartmentLogic cl;

        public StatController(IDepartmentLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<DepartmentCost> AverageByBrands()
        {
            return cl.DepartmentCost();
        }
    }
}
