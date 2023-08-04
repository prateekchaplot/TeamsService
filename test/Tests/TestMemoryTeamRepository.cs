using API.Models;
using API.Persistence;

namespace Tests;

public class TestMemoryTeamRepository : MemoryTeamRepository
{
    public TestMemoryTeamRepository() : base(CreateInitialFake())
    {
    }

    private static ICollection<Team> CreateInitialFake()
    {
        var teams = new List<Team>()
        {
            new Team("one"),
            new Team("two")
        };

        return teams;
    }
}