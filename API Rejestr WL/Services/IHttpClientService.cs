using API_Rejestr_WL.Models;

namespace API_Rejestr_WL.Services;

public interface IHttpClientService
{
    Task<CompanyModel?> FetchCompany(string nip);
}