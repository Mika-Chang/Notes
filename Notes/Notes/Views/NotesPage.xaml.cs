////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        NotesPage.xaml.cs
//
// Author:           Mika Chang
// Email:            mikacchang@gmail.com
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Notes.Models;
using Xamarin.Forms;

namespace Notes.Views {
    /// <summary>
    /// Class for the page where notes can viewed
    /// </summary>
    public partial class NotesPage : ContentPage {
        /// <summary>
        /// Class defining behavior of the page containing a list of notes.
        /// </summary>
        public NotesPage() {
            InitializeComponent();
        }

        /// <summary>
        /// Method that defines behavior when the app appears, creating a data
        /// source for the CollectionView
        /// </summary>
        protected override async void OnAppearing() {
            base.OnAppearing();

            // Retrieve all notes from database and set as source for CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        /// <summary>
        /// Execute event handler when a button is pressed
        /// </summary>
        /// <param name="sender">the button that was pressed.</param>
        /// <param name="e">the note.</param>
        async void OnAddClicked(object sender, EventArgs e) {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }

        /// <summary>
        /// Go to the NoteEntryPage searching for the ID of the given Note
        /// </summary>
        /// <param name="sender">the button that was pressed.</param>
        /// <param name="e">the note.</param>
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.CurrentSelection != null) {

                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}