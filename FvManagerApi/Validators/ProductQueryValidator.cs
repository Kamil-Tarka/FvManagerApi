using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Entities;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Validators
{
    public class ProductQueryValidator : AbstractValidator<ProductQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        private string[] allowedSortByColumnNames = { nameof(Product.Name), nameof(Product.NetPrice) };

        public ProductQueryValidator()
        {
            RuleFor(p => p.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(p => p.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
            RuleFor(p => p.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value)).WithMessage($"SortBy is optional, or must be in [{string.Join(", ", allowedSortByColumnNames)}]");
        }
    }
}
