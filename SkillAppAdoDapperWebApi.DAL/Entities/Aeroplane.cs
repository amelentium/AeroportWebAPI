using SkillAppAdoDapperWebApi.DAL.Interfaces;

namespace SkillAppAdoDapperWebApi.DAL.Entities
{
    public class Aeroplane : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Seats { get; set; }
        public int? Valocity { get; set; }
    }
}
