using Microsoft.AspNetCore.Mvc;
using TeamsService.Models;
using TeamsService.Persistence;

namespace TeamsService.Controller;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly ITeamRepository _repository;

    public MemberController(ITeamRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetMembers(Guid teamId)
    {
        var team = _repository.Get(teamId);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team.Members);
    }

    [HttpGet("/api/teams/{teamId}/[controller]/{memberId}")]
    public IActionResult GetMember(Guid teamId, Guid memberId)
    {
        var team = _repository.Get(teamId);

        if (team == null)
        {
            return NotFound();
        }

        var member = team.Members.FirstOrDefault(x => x.ID == memberId);

        if (member == null)
        {
            return NotFound();
        }

        return Ok(member);
    }

    [HttpPost("{teamId}")]
    public IActionResult CreateMember(Guid teamId, Member member)
    {
        var team = _repository.Get(teamId);

        if (team == null)
        {
            return NotFound();
        }

        team.Members.Add(member);
        return CreatedAtAction(nameof(GetMember), new { teamId, memberId = member.ID }, member);
    }

    [HttpPut("{teamId}")]
    public IActionResult UpdateMember(Guid teamId, Member member)
    {
        var team = _repository.Get(teamId);

        if (team == null)
        {
            return NotFound();
        }

        var m = team.Members.FirstOrDefault(x => x.ID == member.ID);

        if (m == null)
        {
            return NotFound();
        }

        team.Members.Remove(m);
        team.Members.Add(member);
        return Ok(member);
    }

    [HttpGet("/api/members/{memberId}/team")]
    public IActionResult GetTeamForMember(Guid memberId)
    {
        var teamId = GetTeamIdForMember(memberId);

        if (teamId == Guid.Empty)
        {
            return NotFound();
        }

        return Ok(new { teamId });
    }

    private Guid GetTeamIdForMember(Guid memberId)
    {
        foreach (var team in _repository.List())
        {
            var member = team.Members.FirstOrDefault(x => x.ID == memberId);
            if (member != null)
            {
                return team.ID;
            }
        }

        return Guid.Empty;
    }
}