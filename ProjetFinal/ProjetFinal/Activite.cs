﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Activite
    {
        int cout_organisation, prix_vente, id_Admin, id_categorie;


        public Activite()
        {
            this.cout_organisation = 0;
            this.prix_vente = 0;
            this.id_Admin = 0;
            this.id_categorie = 0;

        }
        public Activite(int cout_organisation, int prix_vente, int id_Admin, int id_categorie)
        {
            this.cout_organisation = cout_organisation;
            this.prix_vente = prix_vente;
            this.id_Admin = id_Admin;
            this.id_categorie = id_categorie;
        }

        public int Cout_organisation { get => cout_organisation; set => cout_organisation = value; }
        public int Prix_vente { get => prix_vente; set => prix_vente = value; }
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }
        public int Id_categorie { get => id_categorie; set => id_categorie = value; }



        public override string ToString()
        {
            return " " ;
        }
    }
}
