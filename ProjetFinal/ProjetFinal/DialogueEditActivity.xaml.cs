﻿using Microsoft.UI.Xaml;
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
    public sealed partial class DialogueEditActivity : ContentDialog
    {
        int idActivity = 0;
        int categorie = 0;
        bool valide;
        public DialogueEditActivity(Activite act)
        {
            this.InitializeComponent();
            tbxCoutActivite.Text = act.Cout_organisation.ToString();
            tbxPrixVente.Text = act.Prix_vente.ToString();
            tbxImageAjout.Text = act.Image;
            tbxNomAjoutActivite.Text = act.Nom;
            idActivity = act.Id_Activite;
            categorie = act.Id_categorie;
          
        }
        private void resetErreurs()
        {
            tbxCoutActiviteErreur.Text = string.Empty;
            tbxPrixVenteErreur.Text = string.Empty;
            tblErreurImage.Text = string.Empty;
            tblErreurNomActivite.Text = string.Empty;

        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            resetErreurs();
            valide = true;
            

            if (ValidationInput.isNomValide(tbxCoutActivite.Text) == false )
            {
                tbxCoutActiviteErreur.Text = "Veuillez entrer un cout";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxPrixVente.Text) == false )
            {
                tbxPrixVenteErreur.Text = "Veuillez entrer un prix de vente";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxImageAjout.Text) == false )
            {
                tblErreurImage.Text = "Veuillez entrer un URL pour l'image";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxNomAjoutActivite.Text) == false )
            {
                tblErreurNomActivite.Text = "Veuillez entrer un nom d'activité";
                valide = false;
            }
            if (ValidationInput.isPrixValide(tbxPrixVente.Text) == false)
            {
                tbxPrixVenteErreur.Text = "Veuillez entrer un prix valide";
                valide = false;
            }
            if (ValidationInput.isPrixValide(tbxCoutActivite.Text) == false)
            {
                tbxCoutActiviteErreur.Text = "Veuillez entrer un cout valide";
                valide = false;
            }
            if (ValidationInput.isLienValide(tbxImageAjout.Text) == false)
            {
                tblErreurImage.Text = "Veuillez entrer un URL valide";
                valide = false;
            }
            if (valide==true)
            {
                int prix = Convert.ToInt32(tbxPrixVente.Text);
                int cout = Convert.ToInt32(tbxCoutActivite.Text);
                if (cout >= prix)
                {
                    tbxPrixVenteErreur.Text = "Le cout de vente doit etre inferieur au prix de vente";
                    valide = false;
                }
                if (valide == true)
                {
                    SingletonListe.getInstance().UpdateActivity(idActivity, cout, prix, categorie, tbxImageAjout.Text, tbxNomAjoutActivite.Text);
             
                    DialogueEditActivite.Navigate(typeof(PageAffichage));

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
