using API_Rejestr_WL.Services;
using DatabaseProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rejestr_WL.Controllers;

[ApiController]
[Route("[controller]")]
public class NipController : ControllerBase
{
    private readonly IHttpClientService _httpClientService;
    public NipController(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [HttpGet]
    [Route("{nip}")]
    public async Task<ActionResult<CompanyModel>> Get([FromRoute] string nip)
    {
        var result = await _httpClientService.FetchCompany(nip);
        return result == null ? NotFound() : Ok(result);
    }
}