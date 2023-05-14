using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IStatusService
{
    StatusResponseModel GetStatusByID(int id);

}