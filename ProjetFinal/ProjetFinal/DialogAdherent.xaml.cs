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
    public sealed partial class DialogAdherent : ContentDialog
    {
        bool valide;
        
        public  Activite ActiviteNom { get; internal set; }

        public DialogAdherent()
        {
            this.InitializeComponent();
            

        }
        private void resetErreurs()
        {
            tblAdherenErreur.Text = string.Empty;
            tblAdminNomError.Text = string.Empty;
            tblAdminPasswordError.Text = string.Empty;
            chkError.Text = string.Empty;
           
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            resetErreurs();
            valide = true;

           

            if (ValidationInput.isNomValide(tbxAdherent.Text) == false && Adherent.IsChecked==true)
            {
                tblAdherenErreur.Text = "Veuillez entrer un identifiant";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxAdminPassword.Password) == false && Administrateur.IsChecked == true)
            {
                tblAdminPasswordError.Text = "Veuillez entrer un mot de passe";
                valide = false;
            }
            if (ValidationInput.isNomValide(tbxAdminNom.Text) == false && Administrateur.IsChecked == true)
            {
                tblAdminNomError.Text = "Veuillez entrer un nom d'administrateur";
                valide = false;
            }

            if(Adherent.IsChecked != true && Administrateur.IsChecked != true) 
            {
                chkError.Text = "Veuillez selectionner un role d'usager";
                valide = false;
            }

            if (valide == true)
            {
                if (Administrateur.IsChecked == true)
                {
                    if (SingletonListe.getInstance().connexionAdmin(tbxAdminNom.Text,tbxAdminPassword.Password)==true)
                    {
                        // Si la connexion en tant qu'admin est accepté
                        SessionManager.Instance.AdminCon = true;
                        SessionManager.Instance.Id_adherent_ = tbxAdherent.Text;
                        DialogueConnexion.Navigate(typeof(PageAffichage));
                    }
                    else
                    {
                        // Si la connexion en tant qu'admin est refusé
                        SessionManager.Instance.AdminCon = false;
                        valide = false;
                        tblAdminPasswordError.Text = "Erreur d'authentification";
                    }
                }
                if (Adherent.IsChecked == true)
                {
                    if (SingletonListe.getInstance().connexionAdherent(tbxAdherent.Text) == true)
                    {
                        // Si la connexion en tant qu'adhérent est accepté
                        SessionManager.Instance.AdherentCon = true;
                        SessionManager.Instance.Id_adherent_ = tbxAdherent.Text;
                        DialogueConnexion.Navigate(typeof(PageAffichage));
                    }
                    else
                    {
                        // Si la connexion en tant qu'adhérent est refusé
                        SessionManager.Instance.AdherentCon = false;
                        valide = false;
                        tblAdherenErreur.Text = "Erreur d'authentification";
                    }
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

        private void Administrateur_Checked(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            if (Administrateur.IsChecked==true)
            {
                Adherent.IsChecked = false;
                tbxAdminNom.Visibility = Visibility.Visible;
                tbxAdminPassword.Visibility = Visibility.Visible;
            }
           

        }

        private void Adherent_Checked(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            if (Adherent.IsChecked == true)
            {
                Administrateur.IsChecked = false;
                tbxAdherent.Visibility = Visibility.Visible;            
            }
           
        }

        private void Administrateur_Unchecked(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            if (Administrateur.IsChecked == false)
            {
                tbxAdminNom.Visibility = Visibility.Collapsed;
                tbxAdminPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void Adherent_Unchecked(object sender, RoutedEventArgs e)
        {
            resetErreurs();
            if (Adherent.IsChecked == false)
            {
                tbxAdherent.Visibility = Visibility.Collapsed;
            }
        }
    }
}
