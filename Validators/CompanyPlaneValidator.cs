using AeroportWebApi.DAL.Entities;
using AeroportWebApi.Infrastructure.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AeroportWebApi.Validators
{
    class CompanyPlaneValidator : AbstractValidator<CompanyPlane>
    {
        private readonly AeroDbContext _context;
        public CompanyPlaneValidator(AeroDbContext context)
        {
            _context = context;

            RuleFor(x => x.Company)
                .NotNull().WithMessage("Company must be entered")
                .MustAsync(IsExist).WithMessage("");
            RuleFor(x => x.Plane)
                .NotNull().WithMessage("Plane nust be entered")
                .MustAsync(IsExist).WithMessage("");
            RuleFor(x => x.Mark)
                .NotNull().WithMessage("Plane mark must be entered")
                .Matches(@"^(\w{1,3}(-|\s)?(\w{1,5}))$");
        }

        public async Task<bool> IsExist<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            return await _context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
        }
    }
}
