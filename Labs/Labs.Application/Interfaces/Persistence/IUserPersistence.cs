using Labs.Domain.Entities;

namespace Labs.Application.Interfaces.Persistence
{
    public interface IUserPersistence
    {
        public Task<long> Persist(User user);
        public Task<User> GetById(long id);
    }
}
