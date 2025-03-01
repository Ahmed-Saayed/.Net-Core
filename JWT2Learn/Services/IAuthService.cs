using JWT2Learn.Entites;
using JWT2Learn.Models;

namespace JWT2Learn.Services
{
    public interface IAuthService
    {
        public Task<User>RegisterAsync(UserDTO request);
        public Task<string>LoginAsync(UserDTO request);

    }
}
