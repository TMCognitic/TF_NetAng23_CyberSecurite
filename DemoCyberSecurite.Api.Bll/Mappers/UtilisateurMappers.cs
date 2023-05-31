using DemoCyberSecurite.Api.Bll.Entities;
using DalUtilisateur = DemoCyberSecurite.Api.Dal.Entities.Utilisateur;


namespace DemoCyberSecurite.Api.Bll.Mappers
{
    internal static partial class Mappers
    {
        internal static DalUtilisateur ToDal(this Utilisateur utilisateur)
        {
            return new DalUtilisateur()
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email,
                Passwd = utilisateur.Passwd
            };
        }

        internal static Utilisateur ToBll(this DalUtilisateur utilisateur)
        {
            return new Utilisateur(utilisateur.Id, utilisateur.Nom, utilisateur.Prenom, utilisateur.Email);          
        }
    }
}
