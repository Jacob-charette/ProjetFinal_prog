using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    //lo
    public sealed partial class DialogChoixSeance : ContentDialog
    {
        bool valide=true;
        public int Id_Activite { get; internal set; }
        public int Nbr_place_disponible { get; internal set; }
        public int Id_seance { get; internal set; }
        public string Id_Adherent { get; internal set; }

        public DialogChoixSeance(int idActivite)
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().getIdActivite(idActivite);
        }

        private void resetErreurs()
        {
            tblErreurSeance.Text = string.Empty;
            tblErreurRating.Text = string.Empty;

        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            resetErreurs();
            int id = 0;
            if (rating.Value < 0 && lv_liste.Items.Count > 0)
            {
                valide = false;
                tblErreurRating.Text = "Veuillez noter la seance";
            }
            if (lv_liste.SelectedIndex< 0 && lv_liste.Items.Count>0)
            {
                valide = false;
                tblErreurSeance.Text = "Veuillez choisir une seance ";
            }
            if (lv_liste.SelectedItem is Seance selectedSeance)
            {
                id = selectedSeance.Id_seance;
                valide = true;
            }

            if (valide == true)
            {
              SingletonListe.getInstance().ajouterSeance(SessionManager.Instance.Id_adherent_,id, DateTime.Now,rating.Value);
            }

            

        }
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            //si on a cliquer sur le bouton primaire, on vérifie si la validation est OK
            //si ce n'est pas le cas, on ne ferme pas la boite de dialogue
            if (args.Result == ContentDialogResult.Primary)
            {
                if (valide == false)
                    args.Cancel = true;
            }
        }

        private void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            if (lv_liste.SelectedItem is Seance selectedSeance)
            {
                id = selectedSeance.Id_seance;
                valide = true;
            }

            if (valide)
            {
                if (id > 0)
                {
                    SingletonListe.getInstance().ajouterSeance(SessionManager.Instance.Id_adherent_, id, DateTime.Now,rating.Value);
                }
                else
                {
                    // Gérez le cas où aucun élément n'est sélectionné
                    Debug.WriteLine("Aucune séance sélectionnée.");
                }
            }


        }
    }
}
