using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Pain001.Validators
{
    public class Pain001Validator:AbstractValidator<Pain001Request>
    {
        public Pain001Validator()
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

            RuleFor(x => x.TotalTransactions)
                .NotEmpty()
                .GreaterThan(0).WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.TotalAmount)
              .GreaterThan(0)
              .Must(x => decimal.Round(x, 2) == x)
              .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(c => c.InitiatingPartyName)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 character")
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


            RuleFor(c=>c.SchemeCode)
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


            RuleFor(c => c.ForwardAgentInstitutionCode)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .Length(6).WithMessage("{PropertyName} must be 6 digit code")
               .When(c => !string.IsNullOrWhiteSpace(c.ForwardAgentInstitutionCode));

            RuleFor(x => x.PaymentInforRequest!)
                .SetValidator(new PaymentInfoValidator());

             RuleFor(x => x.CreditorAccountDesignation)
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

            RuleFor(x => x.CreditorAccountier)
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

            RuleFor(x => x.ChannelCode)
              .NotEmpty()
              .InclusiveBetween(1, 10);


        }
    }
}
