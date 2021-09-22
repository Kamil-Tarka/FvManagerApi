using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FvManagerApi.Entities;
using FvManagerApi.Models;

namespace FvManagerApi.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(FvManagerDbContext dbContext)
        {
            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(x => x.UserEmail)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.UserName)
                .Custom((value, context) =>
                {
                    var userNameInUse = dbContext.User.Any(u => u.UserName == value);

                    if (userNameInUse)
                    {
                        context.AddFailure("UserName", "That username is taken");
                    }
                });

            RuleFor(x => x.UserEmail)
                .Custom((value, context) =>
                {
                    var userEmailInUse = dbContext.User.Any(u => u.UserEmail == value);

                    if (userEmailInUse)
                    {
                        context.AddFailure("UserEmail", "That email is taken");
                    }
                });
        }
    }
}
