using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.acmt023.Validators
{
    public class Acmt023Validators:AbstractValidator<AccountVerificationRequest>
    {
        public Acmt023Validators()
        {
            RuleFor(c => c.MessageId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 characters")
                .NotNull();

            RuleFor(c=>c.VerifyID)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 character")
                .Equal(c=>c.MessageId).WithMessage("MssgId does not match VerifyId")
                .NotNull();

            RuleFor(c => c.CreatedAt)
                .NotEmpty().WithMessage("PropertyName is required")
                .NotNull();

            RuleFor(c => c.RequestingBankName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} is not valid")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>"); // Matches HTML tags
                    if (rg.Matches(name!).Count > 0)
                    {
                        // Raises an error
                        context.AddFailure(
                            new ValidationFailure(
                            "Name",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.RequestingCbnbankCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(6).WithMessage("{PropertyName} must be 6 character")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>"); // Matches HTML tags
                    if (rg.Matches(name!).Count > 0)
                    {
                        // Raises an error
                        context.AddFailure(
                            new ValidationFailure(
                            "Name",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.RespondingCbnbankCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>"); // Matches HTML tags
                    if (rg.Matches(name!).Count > 0)
                    {
                        // Raises an error
                        context.AddFailure(
                            new ValidationFailure(
                            "Name",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.AccountName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(80).WithMessage("{PropertyName} mwust not exceed 80 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>"); // Matches HTML tags
                    if (rg.Matches(name!).Count > 0)
                    {
                        // Raises an error
                        context.AddFailure(
                            new ValidationFailure(
                            "Name",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

          

            RuleFor(c => c.AccountNo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(10).WithMessage("{PropertyName} must be 10 characters")
                .Matches("^[0-9]*$").WithMessage("{PropertyName} must contain only digit");
        }
    }
}
