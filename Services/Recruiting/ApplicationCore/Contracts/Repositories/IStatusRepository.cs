using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IStatusRepository
{
    StatusResponseModel GetStatusByID(int id);
}