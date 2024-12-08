using Google.Protobuf.WellKnownTypes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class DialogueAjoutAdherent : ContentDialog
    {
        bool valide = true;
        public DialogueAjoutAdherent()
        {
            this.InitializeComponent();
        }
        private void resetErreurs()
        {
            tblErreurNomAjoutAdherent.Text = string.Empty;
            tblErreurPrenomAjoutAdherent.Text = string.Empty;
            tblErreurAdresseAjoutAdherent.Text = string.Empty;
            tblErreurdatePickerNaissance.Text = string.Empty;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            resetErreurs();


            if (ValidationInput.isNomValide(tbxNomAjoutAdherent.Text) == false)
            {
                tblErreurNomAjoutAdherent.Text = "Veuillez entrer un nom d'adherent";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxPrenomAjoutAdherent.Text) == false)
            {
                tblErreurPrenomAjoutAdherent.Text = "Veuillez entrer un prenom de l'adherent";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxAdresseAjoutAdherent.Text) == false)
            {
                tblErreurAdresseAjoutAdherent.Text = "Veuillez entrer une adresse de l'adherent";
                valide = false;
            }
            if (datePickerNaissance.SelectedDate.HasValue)
            {
               valide = true;
            }
            else
            {
                valide=false;
                tblErreurdatePickerNaissance.Text = "Veuillez choisir une date de naissance";
            }
            if (valide == true)
            {
                {
                    //StateTrigger dateBorn = datePickerNaissance.ToString();
                    SingletonListe.getInstance().AddAdherent(tbxNomAjoutAdherent.Text, tbxPrenomAjoutAdherent.Text, tbxAdresseAjoutAdherent.Text, datePickerNaissance.Date.ToString("yyyy/MM/d"));
                    DialogueAddAdherent.Navigate(typeof(PageAffichage));
                }
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
    }
}
