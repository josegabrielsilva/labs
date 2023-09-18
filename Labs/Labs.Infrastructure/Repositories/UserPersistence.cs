using Labs.Application.Interfaces.Persistence;
using Labs.Domain.Entities;

namespace Labs.Infrastructure.Repositories
{
    public class UserPersistence : IUserPersistence
    {
        public async Task<User> GetById(long id)
        {
            return await Task.FromResult(new User("John","john@gmail.com", "123456"));
        }

        public async Task<long> Persist(User user)
        {
            return await Task.FromResult(1);
        }
    }
}
