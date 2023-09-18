using Labs.Application.DTOs;
using Labs.Application.Interfaces.Persistence;
using Labs.Application.Interfaces.Services;
using Labs.Application.Models;
using Labs.Domain.Entities;
using Labs.Domain.Validations;

namespace Labs.Application.Services
{
    public sealed class UserService : IUserService
    {
        private IUserPersistence UserPersistence { get; }

        public UserService(IUserPersistence userPersistence)
        {
            UserPersistence = userPersistence;
        }

        public async Task<ProcessServiceResponse<long>> Create(UserDTO userDto)
        {
            var processResult = new ProcessServiceResponse<long>();

            try
            {
                var domainUser = new User(userDto.Name, userDto.Email, userDto.Password);

                var validations = UserValidation.Validate(domainUser);

                if (validations.Any())
                {
                    processResult.Data = 0;
                    processResult.ValidationMessages = validations;
                }
                else
                {
                    var userCode = await UserPersistence.Persist(domainUser);

                    processResult.Data = userCode;
                }
            }
            catch
            {
                processResult.ErrorMessages.Add(
                        "System", 
                        "Ocorreu um erro inesperado ao criar o usuário. Contate o suporte do sistema"
                    );
            }

            return processResult;
        }

        public async Task<ProcessServiceResponse<User>> GetById(long id)
        {
            var processResult = new ProcessServiceResponse<User>();

            try
            {
                if(id < 0)
                {
                    processResult.ValidationMessages.Add("Id", "Informe um ID válido.");
                }
                else
                {
                    var user = await UserPersistence.GetById(id);

                    if(user != null)
                        processResult.Data = user;
                }
            }
            catch
            {
                processResult.ErrorMessages.Add(
                        "System", 
                        "Ocorreu um erro inesperado ao recuperar o usuário. Contate o suporte do sistema"
                    );
            }

            return processResult;
        }
    }
}
