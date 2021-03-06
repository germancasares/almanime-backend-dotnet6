using Almanime.Models;
using Almanime.Models.DTO;
using Almanime.Services.Interfaces;
using Almanime.Utils;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Almanime.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FansubController : ControllerBase
{
    private readonly IFansubService _fansubService;

    public FansubController(IFansubService fansubService)
    {
        _fansubService = fansubService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var fansubs = _fansubService.Get();

        return Ok(fansubs.Select(fansub => new {
            fansub.Acronym,
            fansub.Name,
            fansub.Webpage,
            fansub.CreationDate,
            Members = fansub.FansubRoles.Select(role => role.Memberships).Count(),
        }));
    }

    [HttpGet("search/{fansubName}")]
    public IActionResult Search(string fansubName)
    {
        var results = _fansubService.Search(fansubName);

        return Ok(results);
    }

    [HttpGet("acronym/{acronym}")]
    public IActionResult GetByAcronym(string acronym)
    {
        var fansub = _fansubService.GetByAcronym(acronym);

        if (fansub == null) return NotFound();

        return Ok(new {
            fansub.Acronym,
            fansub.Name,
            fansub.Webpage,
            fansub.CreationDate,
            Members = fansub.FansubRoles.Sum(role => role.Memberships.Count),
        });
    }

    [HttpGet("acronym/{acronym}/isMember")]
    [Authorize]
    public IActionResult IsMember(string acronym)
    {
        var isMember = _fansubService.IsMember(acronym, User.GetAuth0ID());

        return Ok(isMember);
    }

    [HttpGet("acronym/{acronym}/members")]
    public IActionResult GetMembers(string acronym)
    {
        var members = _fansubService.GetMembers(acronym);

        return Ok(members.Select(member => new {
            member.User.Name,
            Role = member.FansubRole.Name,
        }));
    }

    [HttpGet("acronym/{acronym}/subtitles")]
    public IActionResult GetSubtitles(string acronym)
    {
        var subtitles = _fansubService.GetSubtitles(acronym);

        return Ok(subtitles.Select(subtitle => new {
            subtitle.ID,
            subtitle.Url,
            subtitle.Format,
            subtitle.CreationDate,
            Anime = subtitle.Episode.Anime.Name,
            Episode = subtitle.Episode.Number,
            User = subtitle.Membership.User.Name,
        }));
    }

    [HttpGet("acronym/{acronym}/roles")]
    public IActionResult GetRoles(string acronym)
    {
        var roles = _fansubService.GetRoles(acronym);

        return Ok(roles);
    }

    [HttpPut("acronym/{acronym}/roles")]
    public IActionResult PutRoles(string acronym, Dictionary<string, IEnumerable<EPermission>> roles)
    {
        _fansubService.UpdateRoles(acronym, User.GetAuth0ID(), roles);

        return NoContent();
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(FansubDTO fansubDTO)
    {
        var fansub = _fansubService.Create(fansubDTO, User.GetAuth0ID());

        return Ok(new {
            fansub.Acronym,
            fansub.Name,
            fansub.Webpage,
        });
    }

    [HttpPost("acronym/{acronym}/join")]
    [Authorize]
    public IActionResult Join(string acronym)
    {
        _fansubService.Join(acronym, User.GetAuth0ID());

        return NoContent();
    }
}
