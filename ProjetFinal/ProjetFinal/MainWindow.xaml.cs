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
using System.Collections.ObjectModel;
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
            mainFrame.Navigate(typeof(PageAffichage));
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
                case "iCSV":
                    // Si l'admin est connecté
                    if (SessionManager.Instance.AdminCon == true)
                    {
                        var picker = new Windows.Storage.Pickers.FileSavePicker();

                        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                        WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

                        picker.SuggestedFileName = "Adherent";
                        picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

                        // Crée le fichier
                        Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

                        ObservableCollection<Adherent> listeAdherent = SingletonListe.getInstance().ListeAdherent;
                        if (monFichier != null)
                        {
                            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, listeAdherent.Select(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
                        }
                    }
                    else
                    {
                        // Handle case where the admin is not connected
                    }

                    break;

                case "iCSVAct":
                    // Si l'admin est connecté
                    if (SessionManager.Instance.AdminCon == true)
                    {
                        var picker = new Windows.Storage.Pickers.FileSavePicker();

                        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                        WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

                        picker.SuggestedFileName = "Activites";
                        picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

                        //crée le fichier
                        Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

                        ObservableCollection<Activite> listeActivite = SingletonListe.getInstance().ListeActivite;
                        if (monFichier != null)
                        {
                            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, listeActivite.Select(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);

                        }
                    }
                    else
                    {
                        // Handle case where the admin is not connected
                    }

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

            if (item.ToString() == "Connexion")
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
        private async void BtnAdherent_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "Adherent";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            ObservableCollection<Adherent> listeAdherent = SingletonListe.getInstance().ListeAdherent;

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, listeAdherent.Select(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }
    }
}
