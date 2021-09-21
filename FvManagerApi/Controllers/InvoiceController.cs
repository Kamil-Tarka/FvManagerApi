using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FvManagerApi.Controllers
{
    [Route("api/fvmanager/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public ActionResult CreateInvoice([FromBody]CreateInvoiceDto dto)
        {
            var id = _invoiceService.Create(dto);

            return Created($"api/fvmanager/invoice/{id}", null);
        }

        [HttpGet]
        public ActionResult<List<InvoiceDto>> GetAll()
        {
            var result = _invoiceService.GetAll();

            return Ok(result);
        }

        [HttpGet("{invoiceId}")]
        public ActionResult<InvoiceDto> GetById([FromRoute]int invoiceId)
        {
            var result = _invoiceService.GetById(invoiceId);

            return Ok(result);
        }

        [HttpPut("{invoiceId}")]
        public ActionResult Update([FromRoute]int invoiceId, [FromBody]UpdateInvoiceDto dto)
        {
            _invoiceService.Update(invoiceId, dto);

            return Ok();
        }

        [HttpDelete("{invoiceId}")]
        public ActionResult Delete([FromRoute] int invoiceId)
        {
            _invoiceService.Delete(invoiceId);

            return Ok();
        }

    }
}
