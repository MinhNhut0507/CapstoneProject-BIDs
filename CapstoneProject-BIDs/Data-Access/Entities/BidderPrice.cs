using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class BidderPrice
{
    public Guid ItemId { get; set; }

    public Guid UserId { get; set; }

    public double Price { get; set; }

    public DateTime CreateDate { get; set; }

    public bool Status { get; set; }

    public virtual Item Item { get; set; }

    public virtual User User { get; set; }
}
