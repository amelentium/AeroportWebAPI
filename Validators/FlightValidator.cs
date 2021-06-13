using FluentValidation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using System.Text.RegularExpressions;
using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;

namespace AeroportWebApi.Validators
{
    public class FlightValidator : AbstractValidator<Flight>
    {
        private readonly AeroDbContext _context;
        public FlightValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x.ArriveTo)
                .NotNull().WithMessage("Arrive port must be entered")
                .MustAsync(IsExist).WithMessage("The entered arrive port does not exist");
            RuleFor(x => x.DepartAt)
                .NotNull().WithMessage("Depart time nust be entered")
                .Must(DateIsCorrect).WithMessage("The entered date is incorrect");
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Flight code must be entered")
                .Matches(@"^\d{2,3}(-|\s)?\d{1,4}$").WithMessage("Invalid flight code");
            RuleFor(x => x.DepartFrom)
                .NotNull().WithMessage("Depart port must be entered")
                .MustAsync(IsExist).WithMessage("The entered depart port does not exist");
            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Flight duration must be entered")
                .Must(TimeIsCorrect).WithMessage("Invalid flight duration");
            RuleFor(x => x.Length)
                .NotEmpty().WithMessage("Flight length must be entered")
                .InclusiveBetween(2500, 16000000).WithMessage("Length must be between 2500 and 16000000 (meters)");
            RuleFor(x => x.Plane)
                .NotNull().WithMessage("Plane must be entered")
                .MustAsync(IsExist).WithMessage("The entered plane does not exist");
        }

        public async Task<bool> IsExist<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            return await _context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
        }

        bool DateIsCorrect(DateTime? date)
        {
            if (!DateTime.TryParse(date.ToString(), out DateTime parsedDate))
                return false;
            var localNow = DateTime.UtcNow.AddHours(3);
            if (DateTime.Compare(parsedDate, localNow) == -1)
                return false;
            else return true;
        }

        bool TimeIsCorrect(string time)
        {
            if (!Regex.IsMatch(time, "^((((2[0-3])|1?[0-9]):)?(([1-5][0-9])|(0[3-9])|([3-9])))$"))
                return false;
            else return true;
        }
    }
}
