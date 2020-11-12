using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLAeroplane : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int Valocity { get; set; }
    }
}
