using ABI.Windows.UI;
using Microsoft.UI;
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
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichage : Page
    {
        public PageAffichage()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().ListeActivite;

            // Si l'utilisateur est admin, on affiche le bouton d'ajout
            if (SessionManager.Instance.AdminCon == true)
            {
                cmb_ajouter.Visibility = Visibility.Visible;
            }
            else
            {
                cmb_ajouter.Visibility = Visibility.Collapsed;
            }

            if (SessionManager.Instance.AdminCon == true)
            {
                tbl_name.Text = "Bonjour " + SingletonListe.getInstance().getUtilisateurAdminAdherent();
                tbl_name.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else if (SessionManager.Instance.AdherentCon == true)
            {
                tbl_name.Text = "Bonjour " + SingletonListe.getInstance().getNomPrenomAdherent();
                tbl_name.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                tbl_name.Text = "";
            }

        }
        //a
        private async void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionManager.Instance.AdherentCon == true /*|| SessionManager.Instance.AdminCon == true*/)
            {
                tbl_sous_titre.Text = "CLiquer sur l'une des activités pour choisir une séance";
                tbl_sous_titre.Foreground = new SolidColorBrush(Colors.Black);

                var selectedItem = lv_liste.SelectedItem as Activite;
                if (lv_liste.SelectedItem != null)
                {
                    DialogChoixSeance dialog = new DialogChoixSeance(selectedItem.Id_Activite);
                    dialog.Id_Activite = selectedItem.Id_Activite;
                    dialog.XamlRoot = lv_liste.XamlRoot;
                    dialog.Title = "Boite de dialog";
                    dialog.PrimaryButtonText = "Valider";
                    dialog.CloseButtonText = "Annuler";
                    dialog.DefaultButton = ContentDialogButton.Primary;
              
                    ContentDialogResult resultat = await dialog.ShowAsync();
                }
            }
            else
            {
                tbl_sous_titre.Text =  "Vous devez être connecté pour chosir une séance";
                tbl_sous_titre.Foreground = new SolidColorBrush(Colors.Red);
                tbl_sous_titre.FontSize = 30;
            }
        }

        private async void DeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Activite produit = (Activite)button.DataContext;
            int idAct = produit.Id_Activite;
            int index = produit.Id_Activite;

          
           
            var selectedItem = lv_liste.SelectedItem as Activite;
            if (index !=-1)
            {
                DialogueDeleteActivity dialog = new DialogueDeleteActivity(index);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Non";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }

        private async void DelAdherent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Adherent produit = (Adherent)button.DataContext;
            string idAct = produit.Id_Adherent;
            string index = produit.Id_Adherent;



            var selectedItem = lv_liste.SelectedItem as Activite;
            if (index != "")
            {
                DialogDelAdherent dialog = new DialogDelAdherent(index);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Non";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }

        }

        private async void DelSeance_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Seance produit = (Seance)button.DataContext;
            int idAct = produit.Id_seance;
            int index = produit.Id_seance;



            var selectedItem = lv_liste.SelectedItem as Activite;
            if (index != -1)
            {
                DialogueDelSeance dialog = new DialogueDelSeance(index);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Non";
                dialog.DefaultButton = ContentDialogButton.Primary;
                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }

        private async void EditActivity_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Activite produit = (Activite)button.DataContext;
            int idAct = produit.Id_Activite;
            int index = produit.Id_Activite;



            var selectedItem = lv_liste.SelectedItem as Activite;
            if (index != -1)
            {
                DialogueEditActivity dialog = new DialogueEditActivity(produit);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Modifiaction de l'activité";
                dialog.PrimaryButtonText = "Modifier";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }

        private async void EditSeance_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Seance produit = (Seance)button.DataContext;
            int idAct = produit.Id_Activite;
            int index = produit.Id_Activite;



            var selectedItem = lv_liste.SelectedItem as Activite;
            if (index != -1)
            {
                DialogueEditSeance dialog = new DialogueEditSeance(produit);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Modifiaction de l'activité";
                dialog.PrimaryButtonText = "Modifier";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }

        }

        private async void  EditAdherent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Adherent produit = (Adherent)button.DataContext;
 
                DialogueEditAdherent dialog = new DialogueEditAdherent(produit);
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Modifiaction de l'activité";
                dialog.PrimaryButtonText = "Modifier";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private void lv_liste_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogueAjoutActivite dialog = new DialogueAjoutActivite();
            dialog.XamlRoot = lv_liste.XamlRoot;
            dialog.Title = "Ajout de l'activité";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogueAjoutAdherent dialog = new DialogueAjoutAdherent();
            dialog.XamlRoot = lv_liste.XamlRoot;
            dialog.Title = "Ajout de l'adherent";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            ContentDialogResult resultat = await dialog.ShowAsync();
        }
    }
}
