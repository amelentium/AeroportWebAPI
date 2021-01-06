using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.DAL.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Validators
{
    public class AeroplaneValidator : AbstractValidator<Aeroplane>
    {
        private readonly AeroDbContext _context;
        public AeroplaneValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x)
                .MustAsync(IsPlaneExist).WithMessage("An aeroplane with same name is already exist");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Aeroplane name must be entered")
                .MinimumLength(2).WithMessage("Aeroplane name too short")
                .MaximumLength(20).WithMessage("Aeroplane name too long");
            RuleFor(x => x.Seats)
                .NotNull().WithMessage("Seats count must be entered")
                .InclusiveBetween(5, 880).WithMessage("Seats count must be between 5 and 880");
            RuleFor(x => x.Valocity)
                .NotEmpty().WithMessage("Valocity must be entered")
                .InclusiveBetween(300, 2500).WithMessage("Valocity must be between 300 and 2500");
        }

        private async Task<bool> IsPlaneExist(Aeroplane aeroplane, CancellationToken cancellationToken)
        {
            return !await _context.Aeroplanes.AnyAsync(p => p.Name == aeroplane.Name, cancellationToken);
        }
    }
}
