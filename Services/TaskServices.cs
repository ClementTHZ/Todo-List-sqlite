using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System.Collections.Generic;

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

    public static void DeleteTask(int id)
    {
        string dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";
        using (var connection = new SqliteConnection($"Data Source={dbfile}"))
        {

        }
    }
}

