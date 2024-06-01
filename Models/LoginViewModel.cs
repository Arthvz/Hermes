namespace Hermes.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            RememberMe = true;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
