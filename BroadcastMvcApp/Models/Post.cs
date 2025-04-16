using System;

namespace BroadcastMvcApp.Models;

public class Post
{
    public int Id { get; set; }
    public string Body { get; set; }
    public string CreatedDate { get; set; }
    //    public TimeOnly? CreatedTime { get; set; }
}
