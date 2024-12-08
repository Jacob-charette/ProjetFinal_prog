using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageCSV : Page
    {
        public PageCSV()
        {
            this.InitializeComponent();
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

            ObservableCollection<Adherent>listeAdherent= SingletonListe.getInstance().ListeAdherent;

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, listeAdherent.Select(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }

        private async void BtnActivite_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "Activites";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            ObservableCollection<Activite> listeActivite = SingletonListe.getInstance().ListeActivite;

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, listeActivite.Select(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }
    }
}
