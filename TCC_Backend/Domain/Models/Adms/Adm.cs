namespace TCC_Backend.Domain.Models.Adms
{
    public class Adm : BaseEntity
    {
        public Adm()
        {
        }

        public Adm(string userName, string password, string email, string type)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Type = type;
        }

        public string UserName { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public string Email {  get; private set; } = string.Empty;

        public string Type {  get; private set; } = string.Empty;
    }
}
