using System;
using System.Collections.Generic;

namespace ProjetNET.Models;

public partial class Chat
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReciverId { get; set; }

    public string Message { get; set; } = null!;

    public int Timestamp { get; set; }

    public string Feeling { get; set; } = null!;

    public virtual User Reciver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
