using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;


namespace NibbssNPSPaymentStack.Business.Models.Pacs003.Validators
{
    public class Pacs003Validator: AbstractValidator<Pacs003Request>
    {
        public Pacs003Validator()
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


            RuleFor(c => c.NameEquiryMessageId)
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


            RuleFor(c => c.ChannelCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(2).WithMessage("{PropertyName} must not exceed 2 character")
                .Must(name => Regex.IsMatch(name ?? "", @"^[0-9]+$")).WithMessage("{PropertyName} is not valid")
                .NotNull();

            RuleFor(c => c.CreateAt)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.NoOfTransaction)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.ControlSumAmount)
               .GreaterThan(0)
               .Must(x => decimal.Round(x, 2) == x)
               .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(c => c.DebtorInstitutionCode)
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

            RuleFor(c => c.CreditorInstitutionCode)
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

            //RuleFor(c => c.InstructionId)
            //   .NotEmpty().WithMessage("{PropertyName} is required")
            //   .Length(35).WithMessage("{PropertyName} must be 35 character")
            //   .Custom((name, context) =>
            //   {
            //       Regex rg = new Regex("<.*?>"); // Matches HTML tags
            //       if (rg.Matches(name!).Count > 0)
            //       {
            //           // Raises an error
            //           context.AddFailure(
            //               new ValidationFailure(
            //               "Name",
            //               "The parameter has invalid content"
            //               )
            //           );
            //       }
            //   });

            //RuleFor(c => c.EndtoEndId)
            //  .NotEmpty().WithMessage("{PropertyName} is required")
            //  .Length(35).WithMessage("{PropertyName} must be 35 character")
            //  .Custom((name, context) =>
            //  {
            //      Regex rg = new Regex("<.*?>"); // Matches HTML tags
            //      if (rg.Matches(name!).Count > 0)
            //      {
            //          // Raises an error
            //          context.AddFailure(
            //              new ValidationFailure(
            //              "Name",
            //              "The parameter has invalid content"
            //              )
            //          );
            //      }
            //  });

            //RuleFor(c => c.TxtId)
            //  .NotEmpty().WithMessage("{PropertyName} is required")
            //  .Length(35).WithMessage("{PropertyName} must be 35 character")
            //  .Custom((name, context) =>
            //  {
            //      Regex rg = new Regex("<.*?>"); // Matches HTML tags
            //      if (rg.Matches(name!).Count > 0)
            //      {
            //          // Raises an error
            //          context.AddFailure(
            //              new ValidationFailure(
            //              "Name",
            //              "The parameter has invalid content"
            //              )
            //          );
            //      }
            //  });

            RuleFor(c => c.SettlementAmount)
                .GreaterThan(0)
               .Must(x => decimal.Round(x, 2) == x)
               .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(c => c.SettlementCurrency)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(5).WithMessage("{PropertyName} must be 5 charcter")
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

            RuleFor(c => c.SettlementDate)
               .NotEmpty().WithMessage("{PropertyName} is required");


            RuleFor(c => c.MandateId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must be 35 character")
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

           

            RuleFor(c => c.FrequencyType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(4).WithMessage("{PropertyName} must be 4 character")
                .Custom((name, context) =>
                {
                    List<string> frequencyList = new List<string>()
                     {
                       "DAIL","WEEK","MNTH","QURT","SEMI","YEAR","ADHO"
                     };

                    if (!frequencyList.Contains(name))
                    {
                        context.AddFailure(
                          new ValidationFailure(
                          "Name",
                          "Invalid frequency Type"
                          )
                      );
                    }
                })
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

            RuleFor(c => c.FirstCollectionDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c => c.FinalCollectionDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
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

            RuleFor(c => c.DebtorIdType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.DebtorValue)
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

            RuleFor(c => c.CreditorIdType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.CreditorValue)
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
        }
    }
}
