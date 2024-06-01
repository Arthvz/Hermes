namespace Hermes.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}