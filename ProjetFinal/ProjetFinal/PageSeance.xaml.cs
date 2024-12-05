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
    public sealed partial class PageSeance : Page
    {
        public PageSeance()
        {
            this.InitializeComponent();
            lvListeSeances.ItemsSource = SingletonListe.getInstance().ListeSeance;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogueAjoutSeance dialog = new DialogueAjoutSeance();
            dialog.XamlRoot = lvListeSeances.XamlRoot;
            dialog.Title = "Ajout de l'adherent";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void EditSeance_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Seance produit = (Seance)button.DataContext;
            int idAct = produit.Id_Activite;
            int index = produit.Id_Activite;

            if (index != -1)
            {
                DialogueEditSeance dialog = new DialogueEditSeance(produit);
                dialog.XamlRoot = lvListeSeances.XamlRoot;
                dialog.Title = "Modification de la seance";
                dialog.PrimaryButtonText = "Modifier";
                dialog.CloseButtonText = "Annuler";
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



            var selectedItem = lvListeSeances.SelectedItem as Activite;
            if (index != -1)
            {
                DialogueDelSeance dialog = new DialogueDelSeance(index);
                dialog.XamlRoot = lvListeSeances.XamlRoot;
                dialog.Title = "Confirmation de suppression";
                dialog.PrimaryButtonText = "Oui";
                dialog.CloseButtonText = "Non";
                dialog.DefaultButton = ContentDialogButton.Primary;
                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }
    }
}
