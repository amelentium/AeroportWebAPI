using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AeroportWebApi.Validators
{
    class PassengerValidator : AbstractValidator<Passenger>
    {
        private readonly AeroDbContext _context;
        public PassengerValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Passenger's first name must be entered")
                .MinimumLength(2).WithMessage("Passenger's first name too short")
                .MaximumLength(20).WithMessage("Passenger's first name too long")
                .Matches(@"^[A-Za-z]$").WithMessage("Invalid first name entered");
            RuleFor(x => x.MiddleName)
                .NotEmpty().WithMessage("Passenger's second name must be entered")
                .MinimumLength(2).WithMessage("Passenger's second name too short")
                .MaximumLength(20).WithMessage("Passenger's second name too long")
                .Matches(@"^[A-Za-z]$").WithMessage("Invalid second name entered");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Passenger's last name must be entered")
                .MinimumLength(2).WithMessage("Passenger's last name too short")
                .MaximumLength(20).WithMessage("Passenger's last name too long")
                .Matches(@"^[A-Za-z]$").WithMessage("Invalid last name entered");
            RuleFor(x => x.Flight)
                .NotNull().WithMessage("Flight must be entered")
                .MustAsync(IsExist).WithMessage("The entered flight does not exist");
            RuleFor(x => x.PassportNum)
                .NotEmpty().WithMessage("Passport number must be entered")
                .Matches(@"^\w{9}$").WithMessage("Invalid passport number entered");
            RuleFor(x => x.PhoneNum)
                .NotEmpty().WithMessage("Phone number must be entered")
                .Matches(@"^(+?\d{11,15})$").WithMessage("Invalid phone number entered");
            RuleFor(x => x.SeatNum)
                .NotEmpty().WithMessage("Seat number must be entered")
                .Matches(@"^([A-Za-z]\d{1,2})$").WithMessage("Invalid seat number entered");
        }

        public async Task<bool> IsExist<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            return await _context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
        }
    }
}
