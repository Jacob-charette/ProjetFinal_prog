﻿using Microsoft.UI.Xaml;
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
                case "iConnection":
                    DialogAdherent dialog = new DialogAdherent();
                    dialog.XamlRoot = nvih_text.XamlRoot;
                    dialog.Title = "Boite de dialog";
                    dialog.PrimaryButtonText = "Se connecter";
                    dialog.CloseButtonText = "Annuler";
                    dialog.DefaultButton = ContentDialogButton.Primary;

                    ContentDialogResult resultat = await dialog.ShowAsync(); // Mettre "async" après "private"
                    break;
                default:
                    break;
            }
            
        }
    }
}
