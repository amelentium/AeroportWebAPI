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
        private readonly IAirlineRepository _airlineRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly ICompanyPlaneRepository _companyPlaneRepository;
        private readonly AeroDbContext _context;
        
        public UnitOfWork(IAeroplaneRepository aeroplaneRepository,
            IAeroportRepository aeroportRepository,
            IFlightRepository flightRepository,
            IPassengerRepository passengerRepository,
            IAirlineRepository airlineRepository,
            ICompanyPlaneRepository companyPlaneRepository,
            AeroDbContext context)
        {
            _aeroplaneRepository = aeroplaneRepository;
            _aeroportRepository = aeroportRepository;
            _airlineRepository = airlineRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _companyPlaneRepository = companyPlaneRepository;
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

        public IAirlineRepository AirlineRepository
        {
            get
            {
                return _airlineRepository;
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

        public ICompanyPlaneRepository CompanyPlaneRepository
        {
            get
            {
                return _companyPlaneRepository;
            }
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
