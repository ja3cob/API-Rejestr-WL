﻿using API_Rejestr_WL.Models;
using DatabaseProvider;
using DatabaseProvider.Models;
using Newtonsoft.Json;

namespace API_Rejestr_WL.Services;

public class HttpClientService : IHttpClientService
{
    private const string WLApiAddress = "https://wl-api.mf.gov.pl/api/search/nip/";
    private readonly HttpClient _httpClient;
    private readonly IDatabaseService _databaseService;
    public HttpClientService(IDatabaseService databaseService)
    {
        _databaseService = databaseService;

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(WLApiAddress)
        };
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<CompanyModel?> FetchCompany(string nip)
    {
        if(string.IsNullOrWhiteSpace(nip))
        {
            return null;
        }
        
        CompanyModel? company = _databaseService.Get(nip);
        if(company != null) { return company; }

        var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        var httpResponse = await _httpClient.GetAsync($"{nip}?date={currentDate}");
        if (httpResponse == null || !httpResponse.IsSuccessStatusCode)
        { 
            return null; 
        }    

        var body = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<ApiResponse>(body);
        if(response?.Result == null)
        {
            return null;
        }

        company = response.Result.Subject;
        if (company != null)
        {
            _databaseService.Insert(company);
        }

        return company;
    }
}
