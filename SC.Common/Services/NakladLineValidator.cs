using FluentValidation;
using SC.Common.Model;

namespace SC.Common.Services
{
	public class NakladLineValidator : AbstractValidator<CNakladLine>
	{
		public NakladLineValidator()
		{
			RuleFor(n => n.Nomenkl).NotEmpty();
			RuleFor(n => n.Measure).NotEmpty();
			RuleFor(n => n.Price).GreaterThanOrEqualTo(0);
			RuleFor(n => n.PriceAdditional).GreaterThanOrEqualTo(0);
			RuleFor(n => n.Quantity).GreaterThan(0);
		}
	}
}
