using System;
using APIAutomation.Interfaces;
using APIAutomation.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIAutomation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AllRolesController : ControllerBase
{
	IAllRoles _allRoles;

    public AllRolesController(IAllRoles allRoles)
    {
        _allRoles = allRoles;
    }

    [HttpGet]
	public ActionResult<ResponseRole> GetRoleForToday()
	{
        AllResponseRole role = _allRoles.GetTodayRole();
        return role.Auditorium.Count == 0 ? NoContent() : Ok(role);
	}
}

