using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories.SQL_Repositories
{
    public class SQLPassengerRepository : GenericRepository<SQLPassenger, int>, ISQLPassengerRepository
    {
        private readonly AeroDbContext _context;
        public SQLPassengerRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public new SQLPassenger Add(SQLPassenger passenger)
        {
            passenger.Flight = _context.Flights.Find(passenger.Flight.Id);

            _context.Passengers.Add(passenger);
            _context.SaveChanges();

            return passenger;
        }

        public new IEnumerable<SQLPassenger> GetAll()
        {
            var result = _context.Passengers
                .Include(f => f.Flight)
                .Include(f => f.Flight.Plane)
                .Include(f => f.Flight.ArriveTo)
                .Include(f => f.Flight.DepartFrom)
                .ToList();

            return result;
        }

        public new SQLPassenger Get(int Id)
        {
            return GetAll().FirstOrDefault(p => p.Id == Id);
        }

        public new SQLPassenger Update(SQLPassenger passenger, int Id)
        {
            var existingPassenger = Get(Id);

            existingPassenger.Flight = _context.Flights.Find(passenger.Flight.Id);
            existingPassenger.FirstName = passenger.FirstName;
            existingPassenger.MiddleName = passenger.MiddleName;
            existingPassenger.LastName = passenger.LastName;
            existingPassenger.SeatNum = passenger.SeatNum;
            existingPassenger.PassportNum = passenger.PassportNum;
            existingPassenger.PhoneNum = passenger.PhoneNum;

            _context.SaveChanges();

            return existingPassenger;
        }

        public IEnumerable<SQLPassenger> GetAllPassengersByFlightId(int flightId)
        {
            return _context.Passengers.Where(e => e.Flight.Id == flightId);
        }
    }
}
