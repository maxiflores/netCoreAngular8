using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoriesService _subCategoriesService;

        public SubCategoriesController(ISubCategoriesService subCategoriesService)
        {
            _subCategoriesService = subCategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _subCategoriesService.GetSubCategories();

            return Ok(response);
        }
    }
}
