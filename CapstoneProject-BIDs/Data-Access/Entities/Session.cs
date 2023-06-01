using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class Session
{
    public Guid SessionId { get; set; }

    public string SessionName { get; set; }

    public Guid ItemTypeId { get; set; }

    public DateTime BeginTime { get; set; }

    public int AuctionTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime UpdateDate { get; set; }

    public DateTime CreateDate { get; set; }

    public bool Status { get; set; }

    public virtual ItemType ItemType { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
