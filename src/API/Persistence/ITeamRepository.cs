using API.Models;

namespace API.Persistence;

public interface ITeamRepository
{
    IEnumerable<Team> List();
    Team Get(Guid id);
    Team Add(Team team);
    Team Update(Team team);
    Team Delete(Guid id);
}