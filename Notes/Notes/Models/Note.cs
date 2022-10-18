////////////////////////////////////////////////////////////////////////////////
// Main File:		 App.xaml.cs
// This File:        Note.cs
//
// Author:           Mika Chang
// Email:            mikacchang@gmail.com
////////////////////////////////////////////////////////////////////////////////
using System;
using SQLite;

namespace Notes.Models {
    /// <summary>
    /// Class that defines the Note object
    /// </summary>
    public class Note {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}