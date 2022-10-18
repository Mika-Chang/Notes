////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml
// This File:        NoteDatabase.cs
//
// Author:           Mika Chang
// Email:            mikacchang@wisc.edu
////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data {
    /// <summary>
    /// Class that creates a database from a given database file path.
    /// </summary>
    public class NoteDatabase {
        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Instantiate a database.
        /// </summary>
        /// <param name="dbPath">the path to the database file.</param>
        public NoteDatabase(string dbPath) {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        /// <summary>
        /// Get all the notes from the database.
        /// </summary>
        /// <returns></returns>
        public Task<List<Note>> GetNotesAsync() {
            // Get all notes.
            return database.Table<Note>().ToListAsync();
        }

        /// <summary>
        /// Get a note from the database.
        /// </summary>
        /// <param name="id">the note id in the database.</param>
        /// <returns></returns>
        public Task<Note> GetNoteAsync(int id) {
            //Get a specific note.
            return database.Table<Note>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Saves a note.
        /// </summary>
        /// <param name="note">The note to be updated.</param>
        /// <returns></returns>
        public Task<int> SaveNoteAsync(Note note) {
            if (note.ID != 0) {
                //Update existing note
                return database.UpdateAsync(note);
            } else {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        /// <summary>
        /// Delete a note.
        /// </summary>
        /// <param name="note">the note to be deleted.</param>
        /// <returns></returns>
        public Task<int> DeleteNoteAsync(Note note) {
            return database.DeleteAsync(note);
        }
    }
}