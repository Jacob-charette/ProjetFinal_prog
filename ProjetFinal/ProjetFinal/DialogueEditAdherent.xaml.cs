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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class DialogueEditAdherent : ContentDialog
    {
      
        public DialogueEditAdherent(Adherent participant)
        {
            this.InitializeComponent();
            tbxIDAjoutAdherent.Text=participant.Id_Adherent;
            tbxNomAjoutAdherent.Text = participant.Nom;
            tbxPrenomAjoutAdherent.Text = participant.Prenom;
            tbxAdresseAjoutAdherent.Text = participant.Date_naissance;
            AgeAdherent.Text = participant.Age.ToString();
        }
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            //si on a cliquer sur le bouton primaire, on vérifie si la validation est OK
            //si ce n'est pas le cas, on ne ferme pas la boite de dialogue
            //if (args.Result == ContentDialogResult.Primary)
            //{
            //    if (valide == false)
            //        args.Cancel = true;
            //}
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
         
        }
      

    }
}
