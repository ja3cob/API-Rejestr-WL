using DatabaseProvider.Models;

namespace DatabaseProvider;

public interface IDatabaseService
{
    bool Insert(CompanyModel company);
    bool Delete(string nip);

    CompanyModel? Get(string nip);
    List<CompanyModel>? GetAll();
}
