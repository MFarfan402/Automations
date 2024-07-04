using System;
using APIAutomation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAutomation.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class ReportsController : ControllerBase
{
	IReports _reports;

    public ReportsController(IReports reports)
    {
        _reports = reports;
    }

    [HttpGet]
    public ActionResult<int> GetReports()
    {
        return _reports.GetHours();
    }
}

