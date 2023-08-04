using TeamsService.Models;
using TeamsService.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace TeamsService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamRepository _repository;

    public TeamsController(ITeamRepository repo)
    {
        _repository = repo;
    }

    [HttpGet]
    public IActionResult GetAllTeams()
    {
        return Ok(_repository.List());
    }

    [HttpGet("{id}")]
    public IActionResult GetTeam(Guid id)
    {
        var team = _repository.Get(id);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
    }

    [HttpPost]
    public IActionResult CreateTeam(Team t)
    {
        var team = _repository.Add(t);
        return CreatedAtAction(nameof(GetTeam), new { id = team.ID }, team);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTeam(Team team, Guid id)
    {
        team.ID = id;
        var t = _repository.Update(team);

        if (t == null)
        {
            return NotFound();
        }

        return Ok(t);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(Guid id)
    {
        var team = _repository.Delete(id);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
    }
}