using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Services
{
    public interface IInvoiceService
    {
        public int Create(CreateInvoiceDto dto);
        public InvoiceDto GetById(int invoiceId);
        public PagetResult<InvoiceDto> GetAll(InvoiceQuery invoiceQuery);
        public void Delete(int invoiceId);
        public void Update(int invoiceId, UpdateInvoiceDto dto);
    }
}
