using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Administrateur
    {
        string password, nom_utilisateur;


        public Administrateur()
        {
            this.password = "";
            this.nom_utilisateur = "";

        }
        public Administrateur(string password, string nom_utilisateur)
        {
            this.password = password;
            this.nom_utilisateur = nom_utilisateur;

        }

        public string Password { get => password; set => password = value; }
        public string Nom_utilisateur { get => nom_utilisateur; set => nom_utilisateur = value; }



        public override string ToString()
        {
            return password;
        }
    }
}
