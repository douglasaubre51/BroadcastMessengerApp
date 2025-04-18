using System;

namespace BroadcastMvcApp.Models;

public class Post
{
    public int Id { get; set; }
    public int AccountId {get;set;}

    public string Body { get; set; }
    public string CreatedDate { get; set; }
    public string CreatedTime { get; set; }

}
