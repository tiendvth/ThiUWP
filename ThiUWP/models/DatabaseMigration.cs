﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ThiUWP.models
{
   public class DatabaseMigration
    {
        private static string _databaseFile = "mynote.db";
        public static string _databasePath;
        private static string _createNoteTable = "CREATE TABLE IF NOT EXISTS notes Contacts " +
            "(PhoneNumber NVARCHAR(100) PRIMARY KEY," +
            "Name NVARCHAR(255) NOT NULL,";
            
            
        public async static void UpdateDatabase()
        {
            //Tạo đường dẫn.
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_databaseFile, CreationCollisionOption.OpenIfExists);
            _databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, _databaseFile);
            using (SqliteConnection db = new SqliteConnection($"Filename = {_databasePath}"))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand(_createNoteTable,db );

                command.ExecuteNonQuery();
            }
        }
       
    }
}
