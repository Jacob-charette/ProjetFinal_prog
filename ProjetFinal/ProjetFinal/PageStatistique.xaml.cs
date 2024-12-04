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
    public sealed partial class PageStatistique : Page
    {
        public PageStatistique()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().ListeActivite2;
            tbl_NbrTotAdherent.Text = "Nombre total d'adhérents : " + SingletonListe.getInstance().getNbrAdherent().ToString();
            tbl_NbrTotActivite.Text = "Nombre total d'activités : " + SingletonListe.getInstance().getNbrActivite().ToString();
            tbl_NbrTotSeance.Text = "Nombre total de séances : " + SingletonListe.getInstance().getNbrSeance().ToString();
            tbl_NbrTotCategorie.Text = "Nombre total de catégories : " + SingletonListe.getInstance().getNbrCategorie().ToString();
            tbl_MoyNoteApp.Text = "Moyenne des notes d'appréciations : " + SingletonListe.getInstance().getMoyenneNoteApp().ToString();
            tbl_AdherentPlusActif.Text = "L'adhérent le plus actif : " + SingletonListe.getInstance().getParticipantPlusActif();
        }
    }
}
