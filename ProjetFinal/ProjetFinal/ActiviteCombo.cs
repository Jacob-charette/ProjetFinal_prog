using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class ActiviteCombo
    {

        string nom;


        public ActiviteCombo()
        {       
            this.nom = "";
        }

        public ActiviteCombo( string nom)
        {;
            this.nom = nom;
        }

      
        public string Nom { get => nom; set => nom = value; }



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
