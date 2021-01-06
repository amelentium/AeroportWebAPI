using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.DAL.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Validators
{
    public class AeroportValidator : AbstractValidator<Aeroport>
    {
        private readonly AeroDbContext _context;
        public AeroportValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x)
                .MustAsync(IsPortExist).WithMessage("An aeroport with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Aeroport name must be entered")
                .MinimumLength(3).WithMessage("Aeroport name too short")
                .MaximumLength(50).WithMessage("Aeroport name too long")
                .Matches("^\\D*$").WithMessage("Invalid aeroport neme entered");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country name must be entered")
                .MinimumLength(2).WithMessage("Country name too short")
                .MaximumLength(20).WithMessage("Country name too long")
                .Matches("^\\D*$").WithMessage("Invalid country name entered");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City name must be entered")
                .MinimumLength(3).WithMessage("City name too short")
                .MaximumLength(20).WithMessage("City name too long")
                .Matches("^\\D*$").WithMessage("Invalid city name entered");

        }

        private async Task<bool> IsPortExist(Aeroport aeroport, CancellationToken cancellationToken)
        {
            return !await _context.Aeroports.AnyAsync(p => p.Name == aeroport.Name, cancellationToken);
        }
    }
}
