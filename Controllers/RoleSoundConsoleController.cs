using System;
using APIAutomation.Interfaces;
using APIAutomation.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIAutomation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoleSoundConsoleController : ControllerBase
{
	IRoleSoundConsole _roleSoundConsole;

    public RoleSoundConsoleController(IRoleSoundConsole roleSoundConsole)
    {
        _roleSoundConsole = roleSoundConsole;
    }

    [HttpGet]
	public ActionResult<ResponseRole> GetRoleForToday()
	{
        ResponseRole role = _roleSoundConsole.GetTodayRole();
        return role.PersonA.Equals("") ? NoContent() : Ok(role);
	}
}

