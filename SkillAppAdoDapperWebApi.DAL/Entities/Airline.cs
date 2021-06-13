using AeroportWebApi.DAL.Interfaces;
using System.Collections.Generic;

namespace AeroportWebApi.DAL.Entities
{
    public class Airline : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Aeroplane> Aeroplanes { get; set; }
        public string Description { get; set; }
    }
}
