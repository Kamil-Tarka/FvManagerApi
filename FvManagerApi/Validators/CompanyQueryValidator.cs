using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Entities;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Validators
{
    public class CompanyQueryValidator : AbstractValidator<CompanyQuery>
    {
        private string[] allowedSortByColumnNames = { nameof(Company.Name), nameof(Company.Nip) };
        private int[] allowedPageSizes = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        public CompanyQueryValidator()
        {

            RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(c => c.PageSize).Custom((value, context) =>
                {
                    if (!allowedPageSizes.Contains(value))
                    {
                        context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                    }
                });

            RuleFor(c => c.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value)).WithMessage($"SortBy is optional, or must be in [{string.Join(", ", allowedSortByColumnNames)}]");
        }
    }
}
