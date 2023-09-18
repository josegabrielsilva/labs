using System.ComponentModel.DataAnnotations;

namespace Labs.Api.Contracts.Response
{
    public class UserByIdResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
