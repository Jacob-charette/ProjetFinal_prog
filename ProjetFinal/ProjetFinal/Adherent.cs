using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Adherent
    {
        string id_Adherent;
        string nom;
        string prenom;
        string adresse;
        string date_naissance;
        int age;
        int id_Admin;


        public Adherent()
        {
            this.id_Adherent = "";
            this.nom = "";
            this.prenom = "";
            this.adresse = "";
            this.date_naissance = "";
            this.age = 0;
            this.id_Admin = 0;

        }
        public Adherent(string id_Adherent, string nom, string prenom, string adresse, string date_naissance, int age, int id_Admin)
        {
            this.id_Adherent = id_Adherent;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.date_naissance = date_naissance;
            this.age = age;
            this.id_Admin = id_Admin;
        }

        public string Id_Adherent { get => id_Adherent; set => id_Adherent = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Date_naissance { get => date_naissance; set => date_naissance = value; }
        public int Age { get => age; set => age = value; }
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }

        public Visibility peutAfficher
        {
            get
            {
                return SessionManager.Instance.AdminCon == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility peutAfficherAdherent
        {
            get
            {
                return SessionManager.Instance.AdherentCon == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }


        public override string ToString()
        {
            return nom;
        }
    }
}
