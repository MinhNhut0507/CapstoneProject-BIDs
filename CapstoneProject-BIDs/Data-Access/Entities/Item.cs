using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class Item
{
    public Guid ItemId { get; set; }

    public Guid UserId { get; set; }

    public Guid? StaffId { get; set; }

    public Guid? SessionId { get; set; }

    public string ItemName { get; set; }

    public string Description { get; set; }

    public Guid ItemTypeId { get; set; }

    public int Quantity { get; set; }

    public byte[] Image { get; set; }

    public double FirstPrice { get; set; }

    public double StepPrice { get; set; }

    public double? FinalPrice { get; set; }

    public int Duration { get; set; }

    public double? Deposit { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<BidderPrice> BidderPrices { get; } = new List<BidderPrice>();

    public virtual ItemType ItemType { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual Session Session { get; set; }

    public virtual Staff Staff { get; set; }

    public virtual User User { get; set; }
}
