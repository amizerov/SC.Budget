using FluentValidation;
using SC.Cash.Model;
using SC.Common.Model;

namespace SC.Cash.Services
{
	public class OperationCashValidator : AbstractValidator<COperationCash>
	{
		public OperationCashValidator(COperationCash prev)
		{
			RuleFor(o => o.OutPercent)
				.InclusiveBetween(0, 100);

			RuleFor(o => o.AmountToAcc)
				.InclusiveBetween(0, prev.Amount);

			RuleFor(o => o.Status)
				.NotEqual(OperationCashStatus.Completed)
				.When(o => (o.AmountToAcc ?? 0) <= 0)
				.WithMessage("Изменение статуса невозможно, так как не все поля заполнены.");
		}
	}
}
