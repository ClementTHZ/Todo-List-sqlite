using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

public class TaskServices
{
    public static void CreateTask(string title)
    {

        DateTime date = DateTime.Now;
        var task = new Task(title, date);
        string dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";

        using (var connection = new SqliteConnection($"Data Source={dbfile}"))
        {
            connection.Open();

            using (var commande = connection.CreateCommand())
            {
                commande.CommandText = $"INSERT INTO task (title, is_done, created_at) VALUES (@title, @is_done, @created_at)";
                commande.Parameters.AddWithValue("@title", task.Title);
                commande.Parameters.AddWithValue("@is_done", task.Is_done);
                commande.Parameters.AddWithValue("@created_at", task.Created_at);

                try
                {
                    System.Console.WriteLine($"@title : {task.Title}");
                    System.Console.WriteLine($"@is_done : {task.Is_done}");
                    System.Console.WriteLine($"@created_at : {task.Created_at}");
                    commande.ExecuteNonQuery();
                    System.Console.WriteLine("✅ La tâche à été crée avec succès !");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"❌ Erreur lors de l'insertion : {ex.Message}");
                    throw;


                }
            }
        }
    }

    public static DataTable GetAllTasks()
    {
        var tasks = GetDataTable("SELECT * FROM task");

        foreach (DataRow task in tasks.Rows)
        {
            System.Console.WriteLine($"{task["id"]} - {task["title"]}");

            /* Autre syntaxe
            foreach (DataColumn col in tasks.Columns)
            {
                System.Console.WriteLine(col.ColumnName + ": " + task[col.ColumnName].ToString());
            }
            */
        }

        return tasks;
    }

    public static void DeleteTask(int id)
    {
        ExecuteNonQuery("DELETE FROM task WHERE id=@id", new Dictionary<string, object> { ["@id"] = id });
    }

    /* Private */
    private static string dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";

    private static void ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
    {
        using (var connection = new SqliteConnection($"Data Source={dbfile}"))
        {
            connection.Open();
            using (var commande = connection.CreateCommand())
            {
                commande.CommandText = sql;
                foreach (var arg in parameters)
                {
                    commande.Parameters.AddWithValue(arg.Key, arg.Value);
                }
                commande.ExecuteNonQuery();
            }
        }
    }

    private static DataTable GetDataTable(string sql, Dictionary<string, object> parameters = null)
    {
        using (var connection = new SqliteConnection($"Data Source={dbfile}"))
        {
            connection.Open();
            using (var commande = connection.CreateCommand())
            {
                commande.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        commande.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (var reader = commande.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
    }

    /* Autre syntaxe 
        public void DeleteTask2(int id)
            {
                string dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";
                using (var connection = new SqliteConnection($"Data Source={dbfile}"))
                {
                    connection.Open();

                    using (var commande = connection.CreateCommand())
                    {
                        commande.CommandText = "DELETE FROM task WHERE id = @id";
                        commande.Parameters.AddWithValue("@id", id);
                    }
                }
            }


         public static void ShowAllTasks()
            {
                string dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";
                using (var connection = new SqliteConnection($"Data Source={dbfile}"))
                {
                    connection.Open();

                    using (var commande = connection.CreateCommand())
                    {
                        commande.CommandText = "SELECT * FROM task";

                        using (var reader = commande.ExecuteReader()) // reader de type SqlDataReader
                        {
                            while (reader.Read()) // Avance le SqlDataReader vers l'enregistrement suivant.
                            {
                                System.Console.WriteLine($"{reader["id"]} - {reader["title"]}");

                            }
                        }
                    }
                }
            }
    */
}

