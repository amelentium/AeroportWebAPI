using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.DAL.Entities;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Validators
{
    class FlightValidator : AbstractValidator<Flight>
    {
        private readonly AeroDbContext _context;
        public FlightValidator(AeroDbContext context)
        {
            _context = context;

            //RuleFor(x => x)
            //    .MustAsync().WithMassage("");
        }

        //private async Task<bool> IsFlightExist(Flight flight)
        //{
        //    return await _context.Flights.AnyAsync(x => x.)
        //}
    }
}
