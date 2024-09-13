using CaseStudy.WEBUI.Models;
using FluentValidation;

namespace CaseStudy.WEBUI.Validation.MeetingValidationRules
{
    public class CreateMeetingValidation : AbstractValidator<MeetingVM>
    {
        public CreateMeetingValidation()
        {
            RuleFor(x => x.MeetingName)
             .NotEmpty().WithMessage("Meeting name is required.")
             .Length(3, 100).WithMessage("Meeting name must be between 3 and 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Start date cannot be in the past.")
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start date must be before or equal to the end date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("End date must be after or equal to the start date.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
