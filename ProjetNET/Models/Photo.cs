using System;
using System.Collections.Generic;

namespace ProjetNET.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string Fullpath { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}
