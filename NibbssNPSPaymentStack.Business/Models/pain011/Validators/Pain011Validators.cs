using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.pain011.Validators
{
    public class Pain011Validators:AbstractValidator<pain011Request>
    {
        public Pain011Validators()
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


            RuleFor(c => c.MandateDate)
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.CancellationReasonCode)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .Length(4).WithMessage("{PropertyName} must be 4 character")
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

            RuleFor(c => c.CancellationReasonDescription)
                .MaximumLength(100).WithMessage("{PropertyName} must not be more than 100 character")
                .When(x => !string.IsNullOrWhiteSpace(x.CancellationReasonDescription));

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

            RuleFor(c => c.MandateSequenceType)
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

            RuleFor(c => c.MandateFrequencyType)
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


            RuleFor(c => c.MandateFirstCollectionDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c => c.MandateLastCollectionDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.MandateCreditorNameonAccount)
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

            RuleFor(x => x.MandateCreditorAccountNo)
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

            RuleFor(x => x.MandateCreditorInstitutionCode)
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

            RuleFor(x => x.MandateDebtorNameonAccount)
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

            RuleFor(x => x.MandateDebtorAccountNo)
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

            RuleFor(x => x.MandateDebtorInstitutionCode)
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
        }
    }
}
