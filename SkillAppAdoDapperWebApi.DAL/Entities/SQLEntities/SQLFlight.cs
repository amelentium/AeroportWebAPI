using System;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLFlight : IEntity<int>
    {
        public int Id { get; set; }
        public int Plane_Id { get; set; }
        public int DepartFrom_Id { get; set; }
        public int ArriveTo_Id { get; set; }
        public DateTime DepartAt { get; set; }
        public int Length { get; set; }
        public string Duration { get; set; }
    }
}
