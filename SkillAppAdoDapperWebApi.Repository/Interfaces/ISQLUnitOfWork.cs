using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLunitOfWork
    {
        ISQLAeroplaneRepository SQLAeroplaneRepository { get; }
        ISQLAeroportRepository SQLAeroportRepository { get; }
        ISQLFlightRepository SQLFlightRepository { get; }
        ISQLPassengerRepository SQLPassengerRepository { get; }
        void Complete();
    }
}
