using API_Rejestr_WL.Models;
using API_Rejestr_WL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Rejestr_WL.Controllers;

[ApiController]
public class NipController : ControllerBase
{
    private readonly IHttpClientService _httpClientService;
    public NipController(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [HttpGet]
    [Route("/find")]
    public async Task<ActionResult<CompanyModel>> Get([FromQuery] string nip)
    {
        var result = await _httpClientService.FetchCompany(nip);
        return result == null ? NotFound() : Ok(result);
    }
}