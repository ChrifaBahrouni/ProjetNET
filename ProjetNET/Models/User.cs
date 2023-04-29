using System;
using System.Collections.Generic;

namespace ProjetNET.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Chat> ChatRecivers { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatSenders { get; set; } = new List<Chat>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
