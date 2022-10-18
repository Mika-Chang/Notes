////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        NoteEntryPage.xaml.cs
//
// Author:           Mika Chang
// Email:            mikacchang@gmail.com
////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using Notes.Models;
using Xamarin.Forms;

namespace Notes.Views {
    /// <summary>
    /// Class defining the behavior of a page where a note is typed
    /// </summary>
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage: ContentPage {
        public string ItemId {
            set {
                LoadNote(value);
            }
        }

        public NoteEntryPage() {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        /// <summary>
        /// Load a note given an id.
        /// </summary>
        /// <param name="itemId">the id of the note.</param>
        async void LoadNote(string itemId) {
            try {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            } catch (Exception) {
                Console.WriteLine("Failed to load note.");
            }
        }

        /// <summary>
        /// Save a given note when the save button is pressed.
        /// </summary>
        /// <param name="sender">the pressed button.</param>
        /// <param name="e">additional event arguments.</param>
        async void OnSaveButtonClicked(object sender, EventArgs e) {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text)) {
                await App.Database.SaveNoteAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// Delete a given note when the delete button is pressed
        /// </summary>
        /// <param name="sender">the pressed button.</param>
        /// <param name="e">event arguments.</param>
        async void OnDeleteButtonClicked(object sender, EventArgs e) {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}