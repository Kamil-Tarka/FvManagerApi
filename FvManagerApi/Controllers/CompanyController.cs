using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvManagerApi.Controllers
{
    [Route("api/fvmanager/company")]
    [ApiController]
    [Authorize(Policy = "IsUserAccoundActive")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<List<CompanyDto>> GetAll()
        {
            var result = _companyService.GetAll();

            return Ok(result);
        }

        [HttpGet("{companyId}")]
        public ActionResult<CompanyDto> GetById([FromRoute]int companyId)
        {
            var result = _companyService.GetById(companyId);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateCompanyDto dto)
        {
            var id = _companyService.Create(dto);

            return Created($"api/fvmanager/company/{id}", null);
        }

        [HttpPut("{companyId}")]
        public ActionResult Update([FromRoute]int companyId, [FromBody]UpdateCompanyDto dto)
        {
            _companyService.Update(companyId, dto);

            return Ok();
        }

        [HttpDelete("{companyId}")]
        public ActionResult Delete([FromRoute]int companyId)
        {
            _companyService.Delete(companyId);

            return NoContent();
        }


    }
}
