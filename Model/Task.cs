using System.Collections.Concurrent;
using System.Runtime.Serialization;

public class Task
{
    public string Title { get; set; }
    public DateTime Created_at { get; set; }
    public int Is_done { get; set; }

    public Task(string title, DateTime created_At, int is_done = 0)
    {
        Title = title;
        Created_at = created_At;
        Is_done = is_done;
    }
}