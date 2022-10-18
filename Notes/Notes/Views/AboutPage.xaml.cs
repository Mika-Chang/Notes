////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        AboutPage.xaml.cs
//
// Author:           Mika Chang
// Email:            mikacchang@gmail.com
////////////////////////////////////////////////////////////////////////////////

using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notes.Views {
    /// <summary>
    /// Class for the about page on the app
    /// </summary>
    public partial class AboutPage : ContentPage {
        public AboutPage() {
            InitializeComponent();
        }

        /// <summary>
        /// Send the user to the Xamarin quickstart page after pressing
        /// learn more
        /// </summary>
        /// <param name="sender">the pressed button.</param>
        /// <param name="e">the event args.</param>
        async void OnButtonClicked(object sender, EventArgs e) {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://aka.ms/xamarin-quickstart");
        }
    }
}