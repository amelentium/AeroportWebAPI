using AeroportWebApi.DAL.Interfaces;

namespace AeroportWebApi.DAL.Entities
{
    public class Aeroplane : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Seats { get; set; }
        public int? Valocity { get; set; }
    }
}
