using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLAeroport : IEntity<int>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
    }
}
