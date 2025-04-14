using System;

namespace BroadcastMvcApp.Models;

public class Post
{
    public int id { get; set; }
    public string data { get; set; }
    public TimeOnly? Time { get; set; }
    public DateOnly? Date { get; set; }
}
