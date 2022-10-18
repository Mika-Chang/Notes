////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        AppShell.xaml.cs
//
// Author:           Mika Chang
// Email:            mikacchang@gmail.com
////////////////////////////////////////////////////////////////////////////////

using Notes.Views;
using Xamarin.Forms;

namespace Notes {
    /// <summary>
    /// Class for the object that takes the ShellContent objects to organize
    /// the app layout
    /// </summary>
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
        }
    }
}