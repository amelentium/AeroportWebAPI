using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AeroportWebApi.Validators
{
    public class AirlineValidator : AbstractValidator<Airline>
    {
        private readonly AeroDbContext _context;
        public AirlineValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x.Aeroplanes)
                .MustAsync(PlanesAreExist).WithMessage("Inputed planes must be exist");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Airline country must be entered")
                .MinimumLength(2).WithMessage("City name too short")
                .MaximumLength(20).WithMessage("City name too long");
            RuleFor(x => x.Description)
                .MaximumLength(999).WithMessage("Airline decription too long");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Airline name must be entered")
                .MinimumLength(2).WithMessage("Airline name too short")
                .MaximumLength(20).WithMessage("Airline name too long");

            async Task<bool> PlanesAreExist(List<Aeroplane> planes, CancellationToken cancellationToken)
            {
                if (planes != null)
                    foreach(Aeroplane plane in planes)
                        if (!await _context.Aeroplanes.ContainsAsync(plane))
                            return false;
                return true;
            }
        }
    }
}
