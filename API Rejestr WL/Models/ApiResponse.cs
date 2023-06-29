namespace API_Rejestr_WL.Models;

public class ApiResponse
{
    public ApiResponseModel? Result { get; set; }
}
public class ApiResponseModel
{
    public DatabaseProvider.Models.CompanyModel? Subject { get; set; }
    public string? RequestDateTime { get; set; }
    public string? RequestId { get; set; }
}
