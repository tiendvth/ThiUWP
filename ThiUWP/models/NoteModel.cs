using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiUWP.entities;
using Windows.UI.Xaml.Controls;

namespace ThiUWP.models
{
    public class NoteModel
    {
        private static string _selectStatementWithConditionTemplate = "SELECT * FROM contacts WHERE Name like @keyword";
        public NoteModel()
        {
            DatabaseMigration.UpdateDatabase();
        }
        public bool Save(Note note)
        {
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand command = new SqliteCommand("INSERT INTO contacts (PhoneNumber, Name)" +
                " values (@phoneNumber, @name)", cnn);
                    command.Parameters.AddWithValue("@phoneNumber", note.PhoneNumber);
                    command.Parameters.AddWithValue("@name", note.Name);
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
                    SqliteCommand command = new SqliteCommand("SELECT * FROM contacts", cnn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var phoneNumber = reader.GetString(0);
                        var name = reader.GetString(1);
                        var contact = new Note()
                        {
                            PhoneNumber = phoneNumber,
                            Name = name
                        };
                        result.Add(contact);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return result;
        }


        public List<Note> SearchByKeyword(string keyword)
        {
            List<Note> contacts = new List<Note>();
            try
            {
                //
                using (SqliteConnection cnn = new SqliteConnection($"Filename={DatabaseMigration._databasePath}"))
                {
                    cnn.Open();
                    //Tạo câu lệnh
                    SqliteCommand cmd = new SqliteCommand(_selectStatementWithConditionTemplate, cnn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    //Bắn lệnh vào và lấy dữ liệu.
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        var name = Convert.ToString(reader["Name"]);
                        var contact = new Note()
                        {
                            PhoneNumber = phoneNumber,
                            Name = name
                        };
                        contacts.Add(contact);
                    }
                   
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return contacts;
        }
    }
}