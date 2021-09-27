using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Entities;
using FvManagerApi.Models;

namespace FvManagerApi.Validators
{
    public class CreateInvoiceDtoValidator : AbstractValidator<CreateInvoiceDto>
    {
        public CreateInvoiceDtoValidator(FvManagerDbContext dbContext)
        {
            RuleFor(i => i.DateOfSale)
                .NotEmpty();

            RuleFor(i => i.DateOfPayment)
                .NotEmpty();

            RuleFor(i => i.PaymentTypeId)
                .NotEmpty();

            RuleFor(i => i.SellerId)
                .NotEmpty();

            RuleFor(i => i.BuyerId)
                .NotEmpty();

            RuleFor(i => i.InvoicePossitions)
                .NotEmpty();
        }
        
    }
}
