using System;
using System.Collections.Generic;

namespace ProjetNET.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPhoto { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Time { get; set; } = null!;

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}
