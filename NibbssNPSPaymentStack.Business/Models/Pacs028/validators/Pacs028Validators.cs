using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028.validators
{
    public class Pacs028Validators:AbstractValidator<Pacs028Request>
    {
        public Pacs028Validators()
        {
            RuleFor(c => c.Pacs008MessageId)
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

            RuleFor(c => c.SourceInstitutionCode)
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

            RuleFor(c => c.DestinationInstitutionCode)
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

            RuleFor(c => c.Pacs008TxtId)
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

            RuleFor(c => c.Pacs008CreateAt)
                .NotEmpty().WithMessage("{PropertyName} is not requuired")
                .NotNull();

            RuleFor(c => c.Pacs008SettlementDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

        }
    }
}
