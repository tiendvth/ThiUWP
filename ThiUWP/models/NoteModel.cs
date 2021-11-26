using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiUWP.entities;

namespace ThiUWP.models
{
    public class NoteModel
    {
        public NoteModel()
        {
            DatabaseMigration.UpdateDatabase();
        }
        public bool Save(Note note)
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    db.Open();
                    SqliteCommand command = new SqliteCommand("INSERT INTO notes(Id, Name, PhoneNumber)" +
                " values ( @name, @phonnumber)", db);
                    command.Parameters.AddWithValue("@Name", note.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", note.PhoneNumber);                    
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Note> FindAll()
        {
            List<Note> result = new List<Note>();
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand command = new SqliteCommand("SELECT * FROM notes", cnn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = reader.GetString(0);
                        var name = reader.GetString(1);
                        var phonenumber = reader.GetString(2);                        
                        var note = new Note()
                        {
                           
                            Name = name,
                            PhoneNumber = phonenumber,
                           
                        };
                        result.Add(note);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}