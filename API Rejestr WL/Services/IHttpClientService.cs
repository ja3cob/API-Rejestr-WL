using DatabaseProvider.Models;

namespace API_Rejestr_WL.Services;

public interface IHttpClientService
{
    Task<CompanyModel?> FetchCompany(string nip);
}