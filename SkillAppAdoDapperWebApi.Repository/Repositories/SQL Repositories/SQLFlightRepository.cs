using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLFlightRepository : GenericRepository<SQLFlight, int>, ISQLFlightRepository
    {
        private readonly AeroDbContext _context;
        public SQLFlightRepository(AeroDbContext context) : base(context)
        {
            _context = context;
        }

        public new SQLFlight Add(SQLFlight flight)
        {
            flight.Plane = _context.Aeroplanes.Find(flight.Plane.Id);
            flight.ArriveTo = _context.Aeroports.Find(flight.ArriveTo.Id);
            flight.DepartFrom = _context.Aeroports.Find(flight.DepartFrom.Id);

            _context.Flights.Add(flight);
            _context.SaveChanges();

            return flight;
        } 

        public new List<SQLFlight> GetAll()
        {
            var result =_context.Flights
                .Include(p => p.Plane)
                .Include(a => a.ArriveTo)
                .Include(d => d.DepartFrom)
                .ToList();

            return result;
        }

        public IEnumerable<SQLFlight> GetAllFlightsByArriveId(int aeroportId)
        {
            return _context.Flights.Where(e => e.ArriveTo.Id == aeroportId);
        }

        public IEnumerable<SQLFlight> GetAllFlightsByDepartId(int aeroportId)
        {
            return _context.Flights.Where(e => e.DepartFrom.Id == aeroportId);
        }

        public IEnumerable<SQLFlight> GetAllFlightsByPlaneId(int planeId)
        {
            return _context.Flights.Where(e => e.Plane.Id == planeId);
        }
    }
}
