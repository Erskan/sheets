using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SheetsApi.Forces
{
    [Authorize]
    [Route("forces")]
    public class ForcesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateForce([FromBody] Force force)
        {
            throw new NotImplementedException();
        }
    }
}
