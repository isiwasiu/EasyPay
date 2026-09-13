using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain008.Validators
{
    public class Pain008Validator : AbstractValidator<Pain008Request>
    {
        public Pain008Validator()
        {
            // Group Header Validations
            RuleFor(c => c.MessageId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>"); // Matches HTML tags
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "MessageId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.CreationDateTime)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(c => c.NumberOfTransactions)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BePositiveInteger).WithMessage("{PropertyName} must be a positive integer");

            RuleFor(c => c.ControlSum)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidDecimalWith2Places).WithMessage("{PropertyName} must be a decimal number with up to 2 decimal places");

            RuleFor(c => c.InitiatingPartyName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(140).WithMessage("{PropertyName} must not exceed 140 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "InitiatingPartyName",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.ForwardingAgentBIC)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(8).WithMessage("{PropertyName} must be exactly 8 characters")
                .Must(BeValidBIC).WithMessage("{PropertyName} must be in valid BIC format");

            // Payment Information Validations
            RuleFor(c => c.PaymentInformationId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "PaymentInformationId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.PmtMtd)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Equal("DD").WithMessage("{PropertyName} must be 'DD'");

            RuleFor(c => c.PmtInfNumberOfTransactions)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BePositiveInteger).WithMessage("{PropertyName} must be a positive integer");

            RuleFor(c => c.PmtInfControlSum)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidDecimalWith2Places).WithMessage("{PropertyName} must be a decimal number with up to 2 decimal places");

            // Payment Type Information
            RuleFor(c => c.ServiceLevelCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(4).WithMessage("{PropertyName} must be exactly 4 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "ServiceLevelCode",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.LocalInstrumentCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "LocalInstrumentCode",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.SequenceType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidSequenceType).WithMessage("{PropertyName} must be one of: FRST, RCUR, OOFF, FNAL");

            RuleFor(c => c.RequestedCollectionDate)
                .NotNull().WithMessage("{PropertyName} is required");

            // Creditor Information
            RuleFor(c => c.CreditorName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(140).WithMessage("{PropertyName} must not exceed 140 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "CreditorName",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Creditor Account
            RuleFor(c => c.CreditorAccountNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "CreditorAccountNumber",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.CurrencyCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3).WithMessage("{PropertyName} must be exactly 3 characters")
                .Must(BeValidCurrencyCode).WithMessage("{PropertyName} must be a valid currency code");

            // Creditor Agent
            RuleFor(c => c.CreditorAgentBIC)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(8).WithMessage("{PropertyName} must be exactly 8 characters")
                .Must(BeValidBIC).WithMessage("{PropertyName} must be in valid BIC format");

            RuleFor(c => c.CreditorAgentMemberId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "CreditorAgentMemberId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Direct Debit Transaction Information
            RuleFor(c => c.InstructionId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "InstructionId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.EndToEndId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "EndToEndId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.InstructedAmount)
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(val => BeValidDecimalWith2Places(val.ToString())).WithMessage("{PropertyName} must be a decimal number with up to 2 decimal places");

            RuleFor(c => c.InstructedAmountCurrency)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3).WithMessage("{PropertyName} must be exactly 3 characters")
                .Must(BeValidCurrencyCode).WithMessage("{PropertyName} must be a valid currency code");

            // Mandate Information
            RuleFor(c => c.MandateId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "MandateId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.DateOfSignature)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(c => c.FirstCollectionDate)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(c => c.FinalCollectionDate)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(c => c.FrequencyType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidFrequencyType).WithMessage("{PropertyName} must be one of: DAIL, WEEK, MNTH, QURT, YEAR");

            // Debtor Agent
            RuleFor(c => c.DebtorAgentMemberId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "DebtorAgentMemberId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Debtor Information
            RuleFor(c => c.DebtorName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(140).WithMessage("{PropertyName} must not exceed 140 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "DebtorName",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Debtor Account
            RuleFor(c => c.DebtorAccountIBAN)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "DebtorAccountIBAN",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.OtherAccountIdentifier)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "OtherAccountIdentifier",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.DebtorCurrencyCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3).WithMessage("{PropertyName} must be exactly 3 characters")
                .Must(BeValidCurrencyCode).WithMessage("{PropertyName} must be a valid currency code");

            // Remittance Information
            RuleFor(c => c.RemittanceInformation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(140).WithMessage("{PropertyName} must not exceed 140 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "RemittanceInformation",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Supplementary Data - Place and Name
            RuleFor(c => c.PlaceAndName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "PlaceAndName",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Supplementary Data - Debtor Info
            RuleFor(c => c.AccountDesignation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidAccountDesignation).WithMessage("{PropertyName} must be 1, 2, or 3");

            RuleFor(c => c.IdType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "IdType",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.IdValue)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .Length(11).WithMessage("{PropertyName} must be exactly 11 digits (BVN format)")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "IdValue",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.AccountTier)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidAccountTier).WithMessage("{PropertyName} must be 1, 2, or 3")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "AccountTier",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            // Supplementary Data - Transaction Info
            RuleFor(c => c.TransactionLocation)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d+$").WithMessage("{PropertyName} must contain only digits")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "TransactionLocation",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.NameEnquiryMsgId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "NameEnquiryMsgId",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });

            RuleFor(c => c.ChannelCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeValidChannelCode).WithMessage("{PropertyName} must be 1-Teller, 2-Internet, 3-Mobile, 4-POS, or 5-ATM");

            RuleFor(c => c.FixedCollectionAmount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.MandateCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(35).WithMessage("{PropertyName} must not exceed 35 characters")
                .Custom((name, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(name!).Count > 0)
                    {
                        context.AddFailure(
                            new ValidationFailure(
                            "MandateCode",
                            "The parameter has invalid content"
                            )
                        );
                    }
                });
        }

        // Custom validation methods
        private bool BeValidIso8601DateTime(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return DateTime.TryParse(value, null, System.Globalization.DateTimeStyles.RoundtripKind, out _);
        }

        private bool BeValidIso8601DateWithZ(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (!value.EndsWith("Z")) return false;

            string datePart = value.Substring(0, value.Length - 1);
            return DateTime.TryParseExact(datePart, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _);
        }

        private bool BePositiveInteger(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return int.TryParse(value, out int result) && result > 0;
        }

        private bool BeValidDecimalWith2Places(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (!decimal.TryParse(value, out decimal result)) return false;

            int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(result)[3])[2];
            return decimalPlaces <= 2;
        }

        private bool BeValidBIC(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return Regex.IsMatch(value, @"^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$");
        }

        private bool BeValidCurrencyCode(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validCurrencies = { "NGN", "USD", "EUR", "GBP", "JPY", "CHF", "CAD", "AUD", "ZAR", "KES" };
            return Array.Exists(validCurrencies, c => c == value);
        }

        private bool BeValidSequenceType(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validTypes = { "FRST", "RCUR", "OOFF", "FNAL" };
            return Array.Exists(validTypes, t => t == value);
        }

        private bool BeValidFrequencyType(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validTypes = { "DAIL", "WEEK", "MNTH", "QURT", "YEAR" };
            return Array.Exists(validTypes, t => t == value);
        }

        private bool BeValidAccountDesignation(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validValues = { "1", "2", "3" };
            return Array.Exists(validValues, v => v == value);
        }

        private bool BeValidAccountTier(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validValues = { "1", "2", "3" };
            return Array.Exists(validValues, v => v == value);
        }

        private bool BeValidChannelCode(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            string[] validValues = { "1", "2", "3", "4", "5" };
            return Array.Exists(validValues, v => v == value);
        }

        private bool BeValidBoolean(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return bool.TryParse(value, out _);
        }
    }
}
