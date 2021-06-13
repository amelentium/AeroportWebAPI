using System;
using AeroportWebApi.DAL.Interfaces;

namespace AeroportWebApi.DAL.Entities
{
    public class Flight : IEntity<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public CompanyPlane Plane { get; set; }
        public Aeroport DepartFrom { get; set; }
        public Aeroport ArriveTo { get; set; }
        public DateTime? DepartAt { get; set; }
        public int? Length { get; set; }
        public string Duration { get; set; }
    }
}
