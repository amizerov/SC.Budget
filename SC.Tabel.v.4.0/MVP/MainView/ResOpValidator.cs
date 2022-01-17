using DevExpress.Utils.Extensions;
using FluentValidation;
using SC.Common.Model;
using System;
using System.Linq.Expressions;

namespace SwissClean.MVP.MainView
{
	public class ResOpValidator : AbstractValidator<ResOPViewModel>
	{
		public ResOpValidator(ResOPViewModel prevVm, DateTime month, decimal rest)
		{
			new Expression<Func<ResOPViewModel, decimal?>>[]
			{
				vm => vm.Avans,
				vm => vm.Docs,
				vm => vm.MedBook,
				vm => vm.Paid,
				vm => vm.Penalty,
				vm => vm.Premium,
				vm => vm.RateDays,
				vm => vm.SpecWear,
				vm => vm.Washings,
			}.ForEach(value => RuleFor(value)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Это число не может быть отрицательным"));

			new Expression<Func<ResOPViewModel, decimal?>>[]
			{
				vm => vm.Avans,
				vm => vm.Paid,
			}.ForEach(value =>
			{
				var func = value.Compile();
				bool ValueNotNull(ResOPViewModel s) => func.Invoke(s) != null;
				var prevValue = func.Invoke(prevVm) ?? 0;

				RuleFor(value)
					.NotNull()
					.When(s => prevValue > 0)
					.WithMessage("Это число нельзя уменьшить");

				RuleFor(value)
					.GreaterThan(prevValue)
					.When(ValueNotNull)
					.WithMessage("Это число нельзя уменьшить");

				RuleFor(value)
					.LessThanOrEqualTo(rest + prevValue)
					.When(ValueNotNull)
					.WithMessage("У Вас недостаточно средств");
			});

			var daysMaxCount = DateTime.DaysInMonth(month.Year, month.Month);
			RuleFor(s => s.RateDays)
				.LessThanOrEqualTo(daysMaxCount)
				.WithMessage($"Норма не может быть больше {daysMaxCount}");
		}
	}
}
