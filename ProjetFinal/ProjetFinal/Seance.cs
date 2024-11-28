using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Seance
    {
        string date_organisation, heure_organisation, id_Adherent;
        int nbr_place_disponible, note_appreciation, id_Admin, id_Activite;


        public Seance()
        {
            this.date_organisation = "";
            this.heure_organisation = "";
            this.nbr_place_disponible = 0;
            this.note_appreciation = 0;
            this.id_Admin = 0;
            this.id_Activite = 0;
            this.id_Adherent = "";

        }
        public Seance(string date_organisation, string heure_organisation, int nbr_place_disponible, int note_appreciation, int id_Admin, int id_Activite, string id_Adherent)
        {
            this.date_organisation = date_organisation;
            this.heure_organisation = heure_organisation;
            this.nbr_place_disponible = nbr_place_disponible;
            this.note_appreciation = note_appreciation;
            this.id_Admin = id_Admin;
            this.id_Activite = id_Activite;
            this.id_Adherent = id_Adherent;
        }

        public string Date_organisation { get => date_organisation; set => date_organisation = value; }
        public string Heure_organisation { get => heure_organisation; set => heure_organisation = value; }
        public int Nbr_place_disponible { get => nbr_place_disponible; set => nbr_place_disponible = value; }
        public int Note_appreciation { get => note_appreciation; set => note_appreciation = value; }
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }
        public int Id_Activite { get => id_Activite; set => id_Activite = value; }
        public string Id_Adherent { get => id_Adherent; set => id_Adherent = value; }



        public override string ToString()
        {
            return $"{date_organisation} - {heure_organisation}";
        }
    }
}
