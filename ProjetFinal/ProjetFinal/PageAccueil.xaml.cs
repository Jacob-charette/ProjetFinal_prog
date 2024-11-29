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
    public sealed partial class PageAccueil : Page
    {
        public PageAccueil()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().ListeActivite;
        }
        private async void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = lv_liste.SelectedItem as Activite;
            if (lv_liste.SelectedItem != null)
            {
                DialogAdherent dialog = new DialogAdherent();
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Veuillez vous connectez";
                dialog.PrimaryButtonText = "Connexion";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }
    }
}
