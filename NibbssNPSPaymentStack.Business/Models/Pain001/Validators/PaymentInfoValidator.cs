using FluentValidation;
using FluentValidation.Results;
using NibbssNPSPaymentStack.Business.Models.Pain001;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Pain001.Validators
{
    public class PaymentInfoValidator:AbstractValidator<PaymentInforRequest>
    {
        public PaymentInfoValidator()
        {
            RuleFor(x=>x.PaymentInformationId)
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

            RuleFor(x => x.NoOfTransaction)
                .NotEmpty().WithMessage("{ProprtyName} is required")
                .GreaterThan(0);

            RuleFor(c=>c.TotalAmount)
                .GreaterThan(0).WithMessage("{PropertyName} is not valid")
                 .Must(x => decimal.Round(x, 2) == x)
                 .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(c => c.RequestExecutionDate)
              .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.DebtorAccountName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must not be more than 100 character")
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

            RuleFor(x => x.DebtorAccountNo)
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

            RuleFor(x => x.DebtorInstitutionCode)
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

            RuleFor(x => x.ChargeBearerType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(4).WithMessage("{PropertyName} must be 4 characters")
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

            RuleFor(x => x.CurrencyCode)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MaximumLength(10).WithMessage("{PropertyName} must be 4 characters")
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

            RuleFor(c => c.IntructedAmount)
                .GreaterThan(0).WithMessage("{PropertyName} is not valid")
                 .Must(x => decimal.Round(x, 2) == x)
                 .WithMessage("Amount must be greater than zero and have 2 decimal places");



            RuleFor(x => x.CreditorAccountName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must not be more than 100 character")
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

            RuleFor(x => x.CreditorAccountNo)
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

            RuleFor(x => x.CreditorInstitutionCode)
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

            RuleFor(x => x.RemittanceInformation)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .MaximumLength(140).WithMessage("{PropertyName} must not exceed 140 character")
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
                 .When(x => !string.IsNullOrWhiteSpace(x.RemittanceInformation));


           
        }
    }
}
