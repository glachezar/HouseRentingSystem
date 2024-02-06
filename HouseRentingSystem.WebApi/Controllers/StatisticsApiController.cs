﻿namespace HouseRentingSystem.WebApi.Controllers;

using Data.Services.Interfaces;
using Data.Services.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

[Route("api/statistics")]
[ApiController]
public class StatisticsApiController : ControllerBase
{
    private readonly IHouseService houseService;

    public StatisticsApiController(IHouseService houseService)
    {
        this.houseService = houseService;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetStatistics()
    {
        try
        {
            StatisticsServiceModel serviceModel =
                await houseService.GetStatisticsAsync();

            return Ok(serviceModel);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
