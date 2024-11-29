using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Activite
    {
        int cout_organisation, prix_vente, id_Admin, id_categorie, id_Activite, nombre_Adherent;
        string image, nom;


        public Activite()
        {
            this.id_Activite=0;
            this.cout_organisation = 0;
            this.prix_vente = 0;
            this.id_Admin = 0;
            this.id_categorie = 0;
            this.image = "";
            this.nom = "";

        }
        
        public Activite(int id_Activite, int cout_organisation, int prix_vente, int id_Admin, int id_categorie,string image,string nom)
        {
            this.id_Activite = id_Activite;
            this.cout_organisation = cout_organisation;
            this.prix_vente = prix_vente;
            this.id_Admin = id_Admin;
            this.id_categorie = id_categorie;
            this.image = image;
            this.nom = nom;
        }

        public Activite(string nom, int nombreAdherents)
        {
            Nom = nom;
            nombre_Adherent = nombreAdherents;
        }


        public int Id_Activite { get => id_Activite; set => id_Activite = value; }
        public int Cout_organisation { get => cout_organisation; set => cout_organisation = value; }
        public int Nombre_Adherent { get => nombre_Adherent; set => nombre_Adherent = value; }
        public int Prix_vente { get => prix_vente; set => prix_vente = value; }
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }
        public int Id_categorie { get => id_categorie; set => id_categorie = value; }
        public string Image { get => image; set => image = value; }
        public string Nom { get => nom; set => nom = value; }
        public string NomActivite { get; set; }
        public string Prix_vente_string
        {
            get => "Prix vente: " + prix_vente + "$"; set
            {
                if (int.TryParse(value.Replace("$", ""), out int parsedValue))
                {
                    prix_vente = parsedValue;
                }
                if (int.TryParse(value.Replace("Prix vente: ", ""), out int parsedValue2))
                {
                    prix_vente = parsedValue2;
                }
            }
        }

        public string Cout_organisation_string
        {
            get => "Cout d'organisation: " + cout_organisation + "$"; set
            {
                if (int.TryParse(value.Replace("$", ""), out int parsedValue))
                {
                    prix_vente = parsedValue;
                }
                if (int.TryParse(value.Replace("Cout d'organisation: ", ""), out int parsedValue2))
                {
                    prix_vente = parsedValue2;
                }
            }
        }


        public override string ToString()
        {
            return " " ;
        }
    }
}
