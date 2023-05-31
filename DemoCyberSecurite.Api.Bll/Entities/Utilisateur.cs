using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCyberSecurite.Api.Bll.Entities
{
    public class Utilisateur
    {
        public int Id { get; init; }
        public string Nom { get; init; }
        public string Prenom { get; init; }
        public string Email { get; init; }
        public string? Passwd { get; internal set; }

        public Utilisateur(string nom, string prenom, string email, string? passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }

        internal Utilisateur(int id, string nom, string prenom, string email)
            : this (nom, prenom, email, null)
        {
            Id = id;
        }
    }
}
