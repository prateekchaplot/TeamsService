using System.Text;
using API.Models;
using Newtonsoft.Json;

namespace IntegrationTests;

public class SimpleIntegrationTests : IClassFixture<TestWebAppFactory<Program>>
{
    // private readonly TestServer _testServer;
    private readonly HttpClient _testClient;
    private readonly Team _teamZombie;

    public SimpleIntegrationTests(TestWebAppFactory<Program> factory)
    {
        // _testServer = new TestServer(new WebHostBuilder().UseStartup<Program>());
        _testClient = factory.CreateClient();
        _teamZombie = new Team() { ID = Guid.NewGuid(), Name = "Zombie" };
    }

    [Fact]
    public async void TestTeamPostAndGet()
    {
        StringContent stringContent = new(
            JsonConvert.SerializeObject(_teamZombie),
            Encoding.UTF8,
            "application/json");

        HttpResponseMessage postResponse =
        await _testClient.PostAsync("/api/teams", stringContent);
        postResponse.EnsureSuccessStatusCode();

        var getResponse = await _testClient.GetAsync("/api/teams");
        getResponse.EnsureSuccessStatusCode();

        string raw = await getResponse.Content.ReadAsStringAsync();

        List<Team> teams = JsonConvert.DeserializeObject<List<Team>>(raw);
        Assert.Equal(1, teams.Count());
        Assert.Equal("Zombie", teams[0].Name);
        Assert.Equal(_teamZombie.ID, teams[0].ID);
    }
}