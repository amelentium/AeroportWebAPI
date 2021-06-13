using AeroportWebApi.DAL.Interfaces;

namespace AeroportWebApi.DAL.Entities
{
    public class Aeroport : IEntity<int>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
    }
}
