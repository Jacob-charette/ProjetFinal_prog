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
        }
        //a
        private async void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_liste.SelectedItem != null)
            {
                DialogActivite dialog = new DialogActivite();
                dialog.XamlRoot = lv_liste.XamlRoot;
                dialog.Title = "Mon titre";
                dialog.PrimaryButtonText = "Se connecter";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                //dialog.Content = "Mon contenu";

                ContentDialogResult resultat = await dialog.ShowAsync(); // Mettre "async" après "private"

            }
        }
    }
}
