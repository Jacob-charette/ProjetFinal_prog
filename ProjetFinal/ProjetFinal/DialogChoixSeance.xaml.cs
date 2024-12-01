﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
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
    //lo
    public sealed partial class DialogChoixSeance : ContentDialog
    {
        bool valide;
        public int Id_Activite { get; internal set; }
        public int Nbr_place_disponible { get; internal set; }

        public DialogChoixSeance(int idActivite)
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().getIdActivite(idActivite);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (valide == true)
            {

                //if (ActiviteNom != null)
                //{
                //Frame parentFrame = Window.Current.Content as Frame;
                //    parentFrame.Navigate(typeof(DetailActivite), ActiviteNom);
                //}
                //else
                //{
                //    Debug.WriteLine("ActiviteNom est null.");
                //}


            }
        }
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            //si on a cliquer sur le bouton primaire, on vérifie si la validation est OK
            //si ce n'est pas le cas, on ne ferme pas la boite de dialogue
            if (args.Result == ContentDialogResult.Primary)
            {
                if (valide == false)
                    args.Cancel = true;
            }
        }


    }
}
