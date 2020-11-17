using System;
using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLFlight : IEntity<int>
    {
        public int Id { get; set; }
        public SQLAeroplane Plane { get; set; }
        public SQLAeroport DepartFrom { get; set; }
        public SQLAeroport ArriveTo { get; set; }
        public DateTime DepartAt { get; set; }
        public int Length { get; set; }
        public string Duration { get; set; }
    }
}
