using Microsoft.AspNetCore.Identity;

namespace Hermes.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // Adicione quaisquer propriedades adicionais que você deseja aqui
        public object? Role { get; internal set; }
    }
}