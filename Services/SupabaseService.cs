using System.Threading.Tasks;

namespace Hermes.Services
{
    public class SupabaseService : ISupabaseService
    {
        public async Task<bool> RegisterUser(string email, string password)
        {
            // Implementação pendente
            return await Task.FromResult(false);
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            // Implementação pendente
            return await Task.FromResult(false);
        }
    }
}