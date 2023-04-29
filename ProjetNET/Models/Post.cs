using System;
using System.Collections.Generic;

namespace ProjetNET.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Countlike { get; set; }

    public int Countcomment { get; set; }

    public int Countshare { get; set; }

    public int UserId { get; set; }

    public int Time { get; set; }

    public int Reserve { get; set; }

    public virtual ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual User User { get; set; } = null!;
}
