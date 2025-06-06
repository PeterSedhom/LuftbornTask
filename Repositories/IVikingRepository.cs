using LuftbornTask.Models;

namespace LuftbornTask.Repositories
{
    public interface IVikingRepository
    {
        Task<List<Viking>> GetAllAsync();
        Task<Viking> GetByIdAsync(string id);
        Task CreateAsync(Viking viking);
        Task UpdateAsync(string id, Viking viking);
        Task DeleteAsync(string id);
    }
}
