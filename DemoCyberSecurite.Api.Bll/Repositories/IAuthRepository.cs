using DemoCyberSecurite.Api.Bll.Entities;

namespace DemoCyberSecurite.Api.Bll.Repositories
{
    public interface IAuthRepository
    {
        void Register(Utilisateur utilisateur);
        Utilisateur? Login(string email, string passwd);
    }
}
