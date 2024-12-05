using Google.Protobuf.WellKnownTypes;
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
    public sealed partial class DialogueAjoutSeance : ContentDialog
    {
        bool valide = true;
        public DialogueAjoutSeance()
        {
            this.InitializeComponent();
            listeAct.ItemsSource = SingletonListe.getInstance().ListeActivite3;
        }
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {


        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            if (ValidationInput.isNomValide(tbxNbrPlaceDispo.Text) == false)
            {
                tblErreurNbrPlaceDispo.Text = "Veuillez entrer un nombre de place disponible ";
                valide = false;
            }
            if (ValidationInput.isPrixValide(tbxNbrPlaceDispo.Text) == false)
            {
                tblErreurNbrPlaceDispo.Text = "Veuillez entrer un nombre valide ";
                valide = false;
            }
            if (valide == true)
            {
           
            }
        }
    }
}
