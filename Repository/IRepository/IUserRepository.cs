using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User user);
        Task EditAsync(User user);
        Task DeleteAsync(User user);
        Task<IEnumerable<User>> GetUserAsync();
    }
}
