using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Categorie
    {
        string nom;
        string image;
        int id_Admin;


        public Categorie()
        {
            this.nom = "";
            this.image = "";
            this.id_Admin = 0;

        }
        public Categorie(string nom, int id_Admin,string image)
        {
            this.nom = nom;
            this.image = image;
            this.id_Admin = id_Admin;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }
        public string Image { get => image; set => image = value; }


        public override string ToString()
        {
            return nom ;
        }
    }
}
