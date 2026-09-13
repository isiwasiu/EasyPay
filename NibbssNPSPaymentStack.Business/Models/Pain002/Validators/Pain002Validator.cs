using FluentValidation;
using FluentValidation.Results;   // <-- add this
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain002.Validators
{

    using FluentValidation;
    using System.Text.RegularExpressions;

    public class Pain002Validators : AbstractValidator<CustomerPaymentStatusReport>
    {
        public Pain002Validators()
        {
            // Group header message ID – nested property
            RuleFor(c => c.GrpHdr.MsgId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(35).WithMessage("{PropertyName} must be 35 characters")
                .Custom((value, context) =>
                {
                    Regex rg = new Regex("<.*?>");
                    if (rg.Matches(value!).Count > 0)
                    {
                        context.AddFailure("GrpHdr.MsgId", "The parameter has invalid content");
                    }
                });

            // Creation date/time – just ensure it's not default
            RuleFor(c => c.GrpHdr.CreDtTm)
                .NotEmpty().WithMessage("{PropertyName} is required");



        }
    }
}
