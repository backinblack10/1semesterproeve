using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TuristAppV5.Model;
using TuristAppV5.View;
using TuristAppV5.Viewmodel;

namespace TuristAppV5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriListeGridView2.SelectedIndex == -1)
            {
                MessageDialog fejl = new MessageDialog("Vælg venligst et item", "Ups! Der skete en fejl!");
                await fejl.ShowAsync();
            }
            else
            {
                MainViewmodel.SelectedKategoriliste = (Kategoriliste) kategoriListeGridView2.SelectedItem;
                this.Frame.Navigate(typeof (SelectedKategoriliste));
            }

        }
    }
}
