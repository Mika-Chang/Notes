////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        App.xaml.cs
//
// Author:           Mika Chang
// Email:            mikacchang@wisc.edu
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using Notes.Data;
using Xamarin.Forms;

namespace Notes {
    /// <summary>
    /// Class for the app object which instantiates the app.
    /// </summary>
    public partial class App : Application {
        static NoteDatabase database;

        /// <summary>
        /// Create the database connection as a singleton.
        /// </summary>
        public static NoteDatabase Database {
            get {
                if (database == null) {
                    database = new NoteDatabase(Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "Notes.db3"));
                }
                return database;
            }
        }

        /// <summary>
        /// Instantiate the app.
        /// </summary>
        public App() {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}