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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAdherents : Page
    {
        public PageAdherents()
        {
            this.InitializeComponent();
            lv_listeAdherent.ItemsSource = SingletonListe.getInstance().ListeAdherent;
        }

        private async void DelAdherent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Adherent produit = (Adherent)button.DataContext;
            string idAct = produit.Id_Adherent;
            string index = produit.Id_Adherent;



            var selectedItem = lv_listeAdherent.SelectedItem as Adherent;
            if (index != "")
            {
                DialogDelAdherent dialog = new DialogDelAdherent(index);
                dialog.XamlRoot = lv_listeAdherent.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Non";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }

        }
        private async void EditAdherent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Adherent produit = (Adherent)button.DataContext;

            DialogueEditAdherent dialog = new DialogueEditAdherent(produit);
            dialog.XamlRoot = lv_listeAdherent.XamlRoot;
            dialog.Title = "Modifiaction de l'activité";
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;

            ContentDialogResult resultat = await dialog.ShowAsync();


        }
        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogueAjoutAdherent dialog = new DialogueAjoutAdherent();
            dialog.XamlRoot = lv_listeAdherent.XamlRoot;
            dialog.Title = "Ajout de l'adherent";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            ContentDialogResult resultat = await dialog.ShowAsync();
        }
    }
}
