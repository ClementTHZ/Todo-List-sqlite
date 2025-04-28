using Microsoft.Data.Sqlite;
using System.Collections.Generic;

string? readResult = "";
string? menuSelection = "";


/* Autre syntaxe
var dbfile = @"C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db";
var sql = File.ReadAllText("queries.sql");

using (var connection = new SqliteConnection(@"Data Source=C:\Users\ClémentTHOREZ\Documents\Cours C#\Projet C#\TodoList\BDD\todolist.db"))
{
    connection.Open();
    Console.WriteLine("La base de donnée est connectée !");

    using (var commande = connection.CreateCommand())
    {
        commande.CommandText = sql;
        commande.ExecuteNonQuery();
        System.Console.WriteLine("La base de donnée à été mise à jour");
    }
} */
Console.Clear();
while (readResult != "6")
{
    System.Console.WriteLine("-----------------------------------------");
    System.Console.WriteLine("1 - Lister toutes les tâches");
    System.Console.WriteLine("2 - Ajouter une tâche");
    System.Console.WriteLine("3 - supprimer une tâche");
    System.Console.WriteLine("4 - Marquer une tâche comme terminée");
    System.Console.WriteLine("5 - Lister les tâches à terminer");
    System.Console.WriteLine("6 - Quitter l'application");
    System.Console.WriteLine("-----------------------------------------");
    System.Console.WriteLine("Votre choix :");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.Trim().ToLower();
    }
    switch (menuSelection)
    {
        case "1": // Lister toutes les tâches
            TaskServices.GetAllTasks();
            break;

        case "2": // Ajouter une tâche
            string title = "";
            System.Console.WriteLine("Titre de la tâche :");
            readResult = Console.ReadLine();

            if (readResult != null)
            {
                title = readResult.Trim().ToLower();
                TaskServices.CreateTask(title);
            }
            break;

        case "3": // Supprimer une tâche
            int id = 0;
            TaskServices.GetAllTasks();
            System.Console.WriteLine("Indiquer l'ID de la tâche à supprimer :");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                id = int.Parse(readResult.Trim());
            }
            try
            {
                TaskServices.DeleteTask(id);
                System.Console.WriteLine("✅La tâche à été supprimée avec succès !");
            }
            catch (System.Exception err)
            {
                System.Console.WriteLine($"❌ Erreur lors de l'insertion : {err.Message}");
                throw;
            }
            break;

        case "4": // Marquer une tâche comme réalisé
            int taskId = 0;
            TaskServices.GetAllTasks();
            System.Console.WriteLine("Indiquer la tâche à marquer (ID) :");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                taskId = int.Parse(readResult);
            }
            TaskServices.MarkedTask(taskId);
            TaskServices.GetAllTasks();
            break;

        case "5": // Afficher uniquement les tâches à réalisé
            TaskServices.GetAllTasksWithoutMark();
            break;

        default:
            break;
    }

    System.Console.WriteLine("Tapez entrée pour continuer");
    Console.ReadLine();
}


