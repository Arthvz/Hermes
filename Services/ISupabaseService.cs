using System.Threading.Tasks;

namespace Hermes.Services
{
    public interface ISupabaseService
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
    }
}