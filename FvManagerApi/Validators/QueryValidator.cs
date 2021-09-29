using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Models.Query;
using Microsoft.IdentityModel.Tokens;

namespace FvManagerApi.Validators
{
    public class QueryValidator : AbstractValidator<Query>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        public QueryValidator()
        {

            RuleFor(q => q.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(q => q.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(", ", allowedPageSizes)}]");
                }
            });
        }
    }
}
