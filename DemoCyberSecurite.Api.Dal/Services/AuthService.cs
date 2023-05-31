using DemoCyberSecurite.Api.Dal.Entities;
using DemoCyberSecurite.Api.Dal.Mappers;
using DemoCyberSecurite.Api.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Database;

namespace DemoCyberSecurite.Api.Dal.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Utilisateur? Login(string email, string passwd)
        {
            return _dbConnection.ExecuteReader("CSP_Authentifier", dr => dr.ToUtilisateur(), true, new { Email = email, Passwd = passwd }).SingleOrDefault();
        }

        public void Register(Utilisateur utilisateur)
        {
            _dbConnection.ExecuteNonQuery("CSP_Enregistrement", true, new { utilisateur.Nom, utilisateur.Prenom, utilisateur.Email, utilisateur.Passwd });
        }
    }
}
