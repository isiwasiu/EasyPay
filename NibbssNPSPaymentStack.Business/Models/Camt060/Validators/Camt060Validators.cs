using FluentValidation;
using FluentValidation.Results;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Camt060.Validators
{
    public class Camt060Validators:AbstractValidator<Camt060Request>
    {
        public Camt060Validators()
        {
            RuleFor(c => c.MessageId)
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

            RuleFor(x => x.SenderInstitutionCode)
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
                })
                .NotNull();

            RuleFor(c => c.ReportingRequestingId)
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


            RuleFor(c => c.ReportingRequestingId)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 character")
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

            RuleFor(x => x.AccountNo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(10).WithMessage("{PropertyName} must be 10 character")
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
                })
                .NotNull();

            RuleFor(c => c.CurrencyCode)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .Length(3).WithMessage("{PropertyName} must be 3 character")
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
             })
             .NotNull();

            RuleFor(x => x.AcoountOwnerInstitutionCode)
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
               })
               .NotNull();

            RuleFor(x => x.AccountServicerInstitutionCode)
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
               })
               .NotNull();

            RuleFor(c => c.FromDate)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.ToDate)
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c=>c.ReportPeriodType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 character")
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
                })
                .NotNull();

            RuleFor(x => x.CreditorDesignation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1).WithMessage("{PropertyName} must be 1 character")
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
                })
                .NotNull();

            RuleFor(x => x.CreditorAccountTier)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .Length(1).WithMessage("{PropertyName} must be 1 character")
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
                 })
                 .NotNull();

            RuleFor(x => x.CreditorIdType)
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
              })
              .NotNull();

            RuleFor(x => x.CreditorIdValue)
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
                })
                .NotNull();

            RuleFor(x => x.TransactionLocation)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 character")
              .NotNull();

            RuleFor(x => x.MandateCode)
              .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 character")
              .When(x => !string.IsNullOrWhiteSpace(x.MandateCode));

            RuleFor(x => x.ChannelCode)
              .NotEmpty()
              .InclusiveBetween(1, 10);

        }
    }
}
