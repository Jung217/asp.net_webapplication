using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace WebApplication1.Pages
{
    public class SQLiteModel : PageModel
    {
        [BindProperty]
        public string message { set; get; }

        public void OnGet()
        {
        }

        public void OnPostCreate()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                CREATE TABLE user (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL
                );
            ";
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void OnPostInsert()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            //command.CommandText = @"INSERT INTO user VALUES (1, 'Brice'), (2, 'Alexander'), (3, 'Nate');";
            command.CommandText = @"INSERT INTO user (name) VALUES ('John')";
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void OnPostUpdate()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"UPDATE user SET name = 'Bill' WHERE id = 1";
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void OnPostSelect()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT name FROM user WHERE id = $id";
            command.Parameters.AddWithValue("id", 3);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    message = reader.GetString(0);
                }
            }

            connection.Close();
        }

        public void OnPostDelete()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM user WHERE id = $id";
            command.Parameters.AddWithValue("id", 15);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void OnPostTransaction()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM user WHERE ids = $id";
                command.Parameters.AddWithValue("id", 15);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();

                message = "Faild to delete.";
            }

            connection.Close();
        }
    }
}
