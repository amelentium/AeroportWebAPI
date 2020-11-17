using SkillManagement.DataAccess.Interfaces;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLPassenger : IEntity<int>
    {
        public int Id { get; set; }
        public SQLFlight Flight { get; set; }
        public string SeatNum { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PassportNum { get; set; }
        public string PhoneNum { get; set; }
    }
}
