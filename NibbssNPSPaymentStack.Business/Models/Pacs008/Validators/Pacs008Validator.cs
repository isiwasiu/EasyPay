using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Pacs008.Validators
{
    public class Pacs008Validator:AbstractValidator<CreditTransferRequest>
    {
        public Pacs008Validator()
        {

            RuleFor(c => c.SenderInstitutionCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 character")
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
                .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 character")
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

        
            RuleFor(c=>c.CurrencyCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3).WithMessage("{PropertyName} must not exceed 3 character")
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

            RuleFor(c => c.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");


            RuleFor(c => c.TransactionDate)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.SenderName)
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

            RuleFor(c => c.SenderAccountNo)
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
                 });

            RuleFor(c => c.SenderAccountName)
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

            RuleFor(c => c.BeneficiaryName)
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

            RuleFor(c => c.BeneficiaryAccountNo)
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
                 });

            RuleFor(c => c.BeneficiaryAccountName)
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


            RuleFor(c => c.Narration)
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

            RuleFor(c => c.DebitorAccountDesignation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c=>c.DebtorIDType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(7).WithMessage("{PropertyNam} must not exceed 7 characer")
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

            RuleFor(c => c.DebtorIDValue)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(12).WithMessage("{PropertyNam} must not exceed 12 characer")
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

            RuleFor(c => c.DebtorAccountTier)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            //GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0");


            RuleFor(c => c.CreditorAccountDesignation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
                //GreaterThan(0).WithMessage("{PropertyName} is not valid");

            RuleFor(c => c.CreditorIDType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(7).WithMessage("{PropertyNam} must not exceed 7 characer")
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

            RuleFor(c => c.CreditorIDValue)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(12).WithMessage("{PropertyNam} must not exceed 12 characer")
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

            RuleFor(c => c.CreditorAccountTier)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
                //.GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0");


            RuleFor(c => c.TransactionLocation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 character");

            RuleFor(c => c.NameEnquiryMssgId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 characters");

            RuleFor(c => c.channelCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} is not valid");

        }
    }
}
