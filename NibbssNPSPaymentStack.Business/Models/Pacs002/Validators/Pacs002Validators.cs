using FluentValidation;
using FluentValidation.Results;
using NibbssNPSPaymentStack.Business.Models.Pacs002.NibbssNPSPaymentStack.Business.Models.Pacs002;
using System.Text.RegularExpressions;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002.Validators
{
    public class Pacs002Validators: AbstractValidator<CreditTransferStatusReport>
    {
        public Pacs002Validators()
        {
            RuleFor(c=>c.MssgId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 character")
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

            RuleFor(c => c.CreateAt)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.SenderInstitutionCode)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 characters")
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

            RuleFor(c => c.ReceivingInstitutionCode)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 characters")
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

            RuleFor(c => c.CreditTransferMssgId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Length(35).WithMessage("{PropertyName} must be 35 characters")
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

        }
    }
}
