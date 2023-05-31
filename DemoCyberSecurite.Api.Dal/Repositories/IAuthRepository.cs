using DemoCyberSecurite.Api.Dal.Entities;

namespace DemoCyberSecurite.Api.Dal.Repositories
{
    public interface IAuthRepository
    {
        void Register(Utilisateur utilisateur);
        Utilisateur? Login(string email, string passwd);
    }
}
