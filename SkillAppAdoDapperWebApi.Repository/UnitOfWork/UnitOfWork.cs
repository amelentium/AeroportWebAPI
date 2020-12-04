using SkillAppAdoDapperWebApi.Infrastructure.Contexts;
using SkillAppAdoDapperWebApi.Repository.Interfaces;
using SkillAppAdoDapperWebApi.Repository.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.sqlunitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAeroplaneRepository _aeroplaneRepository;
        private readonly IAeroportRepository _aeroportRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly AeroDbContext _context;
        
        public UnitOfWork(IAeroplaneRepository aeroplaneRepository,
            IAeroportRepository aeroportRepository,
            IFlightRepository flightRepository,
            IPassengerRepository passengerRepository,
            AeroDbContext context)
        {
            _aeroplaneRepository = aeroplaneRepository;
            _aeroportRepository = aeroportRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _context = context;
        }
        public IAeroplaneRepository AeroplaneRepository
        {
            get
            {
                return _aeroplaneRepository;
            }
        }

        public IAeroportRepository AeroportRepository
        {
            get
            {
                return _aeroportRepository;
            }
        }

        public IFlightRepository FlightRepository
        {
            get
            {
                return _flightRepository;
            }
        }

        public IPassengerRepository PassengerRepository
        {
            get
            {
                return _passengerRepository;
            }
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
