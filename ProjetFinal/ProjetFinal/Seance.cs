using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Seance
    {
        string date_organisation, heure_organisation,nomAct;
        int idseance,nbr_place_disponible,  id_Admin, id_Activite;
        


        public Seance()
        {
            this.idseance = 0;
            this.date_organisation = "";
            this.heure_organisation = "";
            this.nomAct = "";
            this.nbr_place_disponible = 0;
    
            this.id_Admin = 0;
            this.id_Activite = 0;
    

        }
        public Seance(int idseance,string date_organisation, string heure_organisation, int nbr_place_disponible, int id_Admin, int id_Activite,string nomAct)
        {
            this.idseance = idseance;
            this.date_organisation = date_organisation;
            this.heure_organisation = heure_organisation;
            this.nbr_place_disponible = nbr_place_disponible;
;
            this.id_Admin = id_Admin;
            this.id_Activite = id_Activite;
            this.nomAct =nomAct;

        }

        public int Id_seance{ get => idseance; set => idseance = value; }
        public string Date_organisation { get => date_organisation.ToString().Substring(0,11); set => date_organisation = value; }
        public string Heure_organisation { get => heure_organisation.ToString().Substring(0, 5); set => heure_organisation = value; }
        public string NomAct { get => nomAct; set => nomAct = value; }
        public int Nbr_place_disponible { get => nbr_place_disponible; set => nbr_place_disponible = value; }
  
        public int Id_Admin { get => id_Admin; set => id_Admin = value; }
        public int Id_Activite { get => id_Activite; set => id_Activite = value; }
      
        public Visibility peutAfficher
        {
            get
            {
                return SessionManager.Instance.AdminCon == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }



        public override string ToString()
        {
            return $"{date_organisation} - {heure_organisation}";
        }
    }
}
