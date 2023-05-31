using DemoCyberSecurite.Api.Bll.Entities;
using DemoCyberSecurite.Api.Bll.Mappers;
using DemoCyberSecurite.Api.Bll.Repositories;
using IDalAuthRespository = DemoCyberSecurite.Api.Dal.Repositories.IAuthRepository;

namespace DemoCyberSecurite.Api.Bll.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDalAuthRespository _dalRepository;

        public AuthService(IDalAuthRespository dalRepository)
        {
            _dalRepository = dalRepository;
        }

        public Utilisateur? Login(string email, string passwd)
        {
            return _dalRepository.Login(email, passwd)?.ToBll();
        }

        public void Register(Utilisateur utilisateur)
        {
            _dalRepository.Register(utilisateur.ToDal());
        }
    }
}
