using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class ItemType
{
    public Guid ItemTypeId { get; set; }

    public string ItemTypeName { get; set; }

    public DateTime UpdateDate { get; set; }

    public DateTime CreateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
