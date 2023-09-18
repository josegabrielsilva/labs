using Labs.Domain.Entities;

namespace Labs.Domain.Validations
{
    public static class UserValidation
    {
        public static IDictionary<string, string> Validate(User user)
        {
            var validations = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(user.Name))
                validations.Add(nameof(user.Name), $"is required");

            if (string.IsNullOrEmpty(user.Email))
                validations.Add(nameof(user.Email), $"is required");

            if (string.IsNullOrEmpty(user.Password))
                validations.Add(nameof(user.Password), $"is required");

            return validations;
        }
    }
}
