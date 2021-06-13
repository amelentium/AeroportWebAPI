using AeroportWebApi.DAL.Interfaces;

namespace AeroportWebApi.DAL.Entities
{
    public class CompanyPlane : IEntity<int>
    {
        public int Id { get; set; }
        public Airline Company { get; set; }
        public Aeroplane Plane { get; set; }
        public string Mark { get; set; }
    }
}
