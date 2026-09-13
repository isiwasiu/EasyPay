using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Pain013.Validator
{
    public class Pain013Validator:AbstractValidator<Pain013Request>
    {
        public Pain013Validator()
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

            RuleFor(c => c.ClientId)
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

            RuleFor(c => c.PaymentInformationId)
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

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .Must(x => decimal.Round(x, 2) == x)
                .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(x => x.Narration)
                .MaximumLength(100).WithMessage("{PropertyName} must not be more than 100 character")
                .When(x => !string.IsNullOrWhiteSpace(x.Narration))
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

            RuleFor(x => x.DebtorAccountDesignation)
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

            RuleFor(x => x.DebtorAccountTier)
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

            RuleFor(x => x.DebtorIdType)
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

            RuleFor(x => x.DebtorIdValue)
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

            RuleFor(x => x.ChannelCode)
              .NotEmpty()
              .InclusiveBetween(1, 10);

            RuleFor(x => x.BiometricData)
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
                .When(x => !string.IsNullOrWhiteSpace(x.BiometricData));

            RuleFor(x=>x.Email)
                .EmailAddress().WithMessage("{PropertyName} is not valid")
                .When(x=>!string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Address)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 charcters")
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
                 .When(x => !string.IsNullOrWhiteSpace(x.Address));
        }
    }
}
