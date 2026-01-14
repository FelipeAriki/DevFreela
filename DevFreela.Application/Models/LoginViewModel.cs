namespace DevFreela.Application.Models
{
    public class LoginViewModel
    {
        public string Token { get; set; }

        public LoginViewModel(string token)
        {
            Token = token;
        }
    }
}
