using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Entities;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Validators
{
    public class InvoiceQueryValidator : AbstractValidator<InvoiceQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        private string[] allowedSortByColumnNames = { nameof(Invoice.InvoiceNumber), nameof(Invoice.DateOfInvoice) };

        public InvoiceQueryValidator()
        {
            RuleFor(i => i.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(i => i.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
            RuleFor(i => i.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value)).WithMessage($"SortBy is optional, or must be in [{string.Join(", ", allowedSortByColumnNames)}]");
        }
    }
}
