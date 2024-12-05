using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(PageAccueil));
        }

        private async void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iActivite":
                    mainFrame.Navigate(typeof(PageAffichage));
                    break;
                case "iStatistique":
                    mainFrame.Navigate(typeof(PageStatistique));
                    break;
                case "iSeance":
                    mainFrame.Navigate(typeof(PageSeance));
                    break;
                case "iConnexion":

                    break;
                case "iDeconnexion":
                    SessionManager.Instance.AdherentCon = false;
                    SessionManager.Instance.AdminCon = false;
                    mainFrame.Navigate(typeof(PageAffichage));
                    break;
                case "iAdherent":
                    mainFrame.Navigate(typeof(PageAdherents)); 
                    break;
                default:
                    break;
            }
            
        }

        private async void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItem;

            if(item.ToString() == "Connexion")
            {
                DialogAdherent dialog = new DialogAdherent();
                dialog.XamlRoot = nvih_text.XamlRoot;
                dialog.Title = "Authentification";
                dialog.PrimaryButtonText = "Se connecter";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;

                ContentDialogResult resultat = await dialog.ShowAsync();
            }
        }
    }
}
