using AeroportWebApi.DAL.Interfaces;

namespace AeroportWebApi.DAL.Entities
{
    public class Passenger : IEntity<int>
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public string SeatNum { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PassportNum { get; set; }
        public string PhoneNum { get; set; }
    }
}
