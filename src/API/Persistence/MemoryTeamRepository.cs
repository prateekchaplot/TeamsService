using API.Models;

namespace API.Persistence;

public class MemoryTeamRepository : ITeamRepository
{
    private readonly ICollection<Team> _teams;

    public MemoryTeamRepository()
    {
        _teams ??= new List<Team>();
    }

    public MemoryTeamRepository(ICollection<Team> teams)
    {
        _teams = teams;
    }

    public Team Add(Team team)
    {
        _teams.Add(team);
        return team;
    }

    public Team Delete(Guid id)
    {
        var team = _teams.FirstOrDefault(x => x.ID == id);

        if (team != null)
        {
            _teams.Remove(team);
        }

        return team;
    }

    public Team Get(Guid id)
    {
        return _teams.FirstOrDefault(x => x.ID == id);
    }

    public IEnumerable<Team> List()
    {
        return _teams;
    }

    public Team Update(Team t)
    {
        var team = Delete(t.ID);

        if (team != null)
        {
            team = Add(t);
        }

        return team;
    }
}