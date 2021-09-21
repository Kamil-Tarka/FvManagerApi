using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class UpdateInvoiceDto
    {

        public DateTime DateOfPayment { get; set; } = DateTime.Now;

        public int PaymentTypeId { get; set; }

        public int SellerId { get; set; }

        public int BuyerId { get; set; }

        public List<UpdateInvoicePossitionDto> InvoicePossitions { get; set; }
    }
}
