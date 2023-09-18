using Labs.Application.DTOs;
using Labs.Application.Models;
using Labs.Domain.Entities;

namespace Labs.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ProcessServiceResponse<long>> Create(UserDTO userDto);
        Task<ProcessServiceResponse<User>> GetById(long id);
    }
}
