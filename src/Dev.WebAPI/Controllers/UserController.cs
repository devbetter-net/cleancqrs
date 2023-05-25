using Dev.Core.UseCases.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery(email));
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}
