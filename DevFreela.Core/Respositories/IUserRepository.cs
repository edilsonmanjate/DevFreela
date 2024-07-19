
using DevFreela.Core.Entities;

namespace DevFreela.Core.Respositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
