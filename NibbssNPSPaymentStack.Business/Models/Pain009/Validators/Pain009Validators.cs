using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace NibbssNPSPaymentStack.Business.Models.Pain009.Validators
{
    public class Pain009Validators:AbstractValidator<Pain009Request>
    {
        public Pain009Validators()
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

            RuleFor(c=>c.MandateId)
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

            RuleFor(c => c.SequenceType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(4).WithMessage("{PropertyName} must be 4 character")
                .Custom((name, context) =>
                 {
                     List<string> sequenceTypeList = new List<string>()
                     {
                       "FRST","RCUR","FNAL","OOFF"
                     };

                     if (!sequenceTypeList.Contains(name))
                     {
                         context.AddFailure(
                           new ValidationFailure(
                           "Name",
                           "Invalid Sequence Type"
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

            RuleFor(c=>c.FrequencyType)
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

            RuleFor(c => c.FirstCollectiondate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c => c.LastCollectiondate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c => c.Currency)
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

            RuleFor(x => x.CollectionAmount)
                .GreaterThan(0)
                .Must(x => decimal.Round(x, 2) == x)
                .WithMessage("Amount must be greater than zero and have 2 decimal places");

            RuleFor(x=>x.CreditorNameOnAccount)
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

            RuleFor(x => x.DebtororNameOnAccount)
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

            RuleFor(x => x.DocumentTypeCode)
                .Length(3).WithMessage("{PropertyName} must be 3 character")
                .When(x => !string.IsNullOrEmpty(x.DocumentTypeCode));

            RuleFor(x => x.DocumentNumber)
               .MaximumLength(35).WithMessage("{PropertyName} must not be more than 35 character")
               .When(x => !string.IsNullOrEmpty(x.DocumentNumber));

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

            RuleFor(x => x.DebtorBvn)
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

            RuleFor(x => x.CreditorBvn)
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

            RuleFor(x => x.DebtorAddress)
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

            RuleFor(c => c.DebtorPhoneNo)
                .NotEmpty().WithMessage("{PropertyName} is reuired")
                .Matches(@"^[0-9]{11}$").WithMessage("{PropertyName} is not valid")
                .NotNull();

            RuleFor(x => x.DebtorEmail)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .EmailAddress().WithMessage("{PropertyName} is not valid")
               .NotNull();

            RuleFor(x => x.ChannelCode)
                .NotEmpty()
                .InclusiveBetween(1, 10).WithMessage("{PropertyName} is not valid");

           
        }
    }
}
