using Fiap.Atividade.Models;
namespace Fiap.Atividade.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}
