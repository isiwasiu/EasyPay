using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.acmt024
{
    public class Acmt024Validators:AbstractValidator<AccountVerificationStatusRequest>
    {
        public Acmt024Validators()
        {
            RuleFor(c => c.MssgId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 characters")
                .NotNull();

            RuleFor(c => c.CreatedAt)
            .NotEmpty().WithMessage("PropertyName is required")
            .NotNull();

            RuleFor(c => c.SendingInstitutionCode)
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

            RuleFor(c => c.ReceiverInstitutionName)
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

            RuleFor(c => c.ReceiverInstitutionCode)
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

            RuleFor(c => c.nameEquiryMssgId)
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
                })
                .NotNull();

            RuleFor(c => c.nameEquiryDate)
             .NotEmpty().WithMessage("PropertyName is required")
             .NotNull();

            RuleFor(c => c.AccountDesignation)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull();

            RuleFor(c => c.AccountIdType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(7).WithMessage("{PropertyName} must not exceed 7 character")
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

            RuleFor(c => c.AccountIdValue)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 character")
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


            RuleFor(c=>c.VerifiedAccountNo)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(10).WithMessage("{PropertyName} must be 10 characters")
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

            RuleFor(c=>c.AccountName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters")
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

            RuleFor(c => c.AccountTier)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

        }
    }
}
