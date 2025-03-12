using TCC_Backend.Domain.Models.Adms;
using TCC_Backend.Domain.Models.Usuarios;

namespace TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms
{
    public class BCryptAlgorithm
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public static bool Verify(string password, Usuario user) => BCrypt.Net.BCrypt.Verify(password, user.Password);

        public static bool Verify(string password, Adm user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}
