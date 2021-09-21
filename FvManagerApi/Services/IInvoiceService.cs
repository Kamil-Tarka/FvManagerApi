using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;

namespace FvManagerApi.Services
{
    public interface IInvoiceService
    {
        public int Create(CreateInvoiceDto dto);
        public InvoiceDto GetById(int invoiceId);
        public List<InvoiceDto> GetAll();
        public void Delete(int invoiceId);
        public void Update(int invoiceId, UpdateInvoiceDto dto);
    }
}
