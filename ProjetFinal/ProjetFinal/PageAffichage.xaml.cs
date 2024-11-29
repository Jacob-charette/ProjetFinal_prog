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
            lv_listeAdherent.ItemsSource=SingletonListe.getInstance().ListeAdherent;
            lvListeSeances.ItemsSource=SingletonListe.getInstance().ListeSeance;


        }
        //a
        private async void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private async void DeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var produit = (Activite)button.DataContext;
            var index = SingletonListe.getInstance().ListeActivite.IndexOf(produit);

            //    gvListe.SelectedIndex = index;
           
            var selectedItem = lv_liste.SelectedItem as Activite;
            if (lv_liste.SelectedItem != null)
            {
                DialogueSuppressionActivite dialog = new DialogueSuppressionActivite();
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Nom";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }
    }
}
