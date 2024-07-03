

using LoginAPI.Models;

namespace LoginAPI.Interface
{
    public interface IRegisterService
    {
        public Task<bool> RegisterUser(User user);
    }
}
